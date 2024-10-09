using SystemGroup.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Exceptions;
using SystemGroup.Framework.Service.Attributes;
using SystemGroup.Training.StoreManagement.Common;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class InventoryService : ServiceBase, IInventoryService
    {
        public virtual IQueryable<PartInventory> FetchPartInventoryByStore(long storeRef)
        {
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            var units = ServiceFactory.Create<IUnitBusiness>().FetchAll();
            var partStores = ServiceFactory.Create<IStoreBusiness>().FetchDetail<PartStore>();
            var inventorybiz = ServiceFactory.Create<IInventoryVoucherBusiness>();
            var inventoryVouchers = inventorybiz.FetchAll();
            var items = inventorybiz.FetchDetail<InventoryVoucherItem>();



            return from p in parts
                   join u in units on p.UnitRef equals u.ID
                   join ps in partStores on p.ID equals ps.PartRef
                   where ps.StoreRef == storeRef
                   join item in items on p.ID equals item.PartRef
                   into p_items
                   from item in p_items.DefaultIfEmpty()
                   join iv in (from iv in inventoryVouchers where iv.StoreRef == storeRef select iv) on item.InventoryVoucherRef equals iv.ID
                   into p_item_ivs
                   from iv in p_item_ivs.DefaultIfEmpty()
                   group new { iv, item } by new { p, u } into pu_ivitem_group
                   select new PartInventory
                   {

                       PartRef = pu_ivitem_group.Key.p.ID,
                       StoreRef = storeRef,
                       UnitRef = pu_ivitem_group.Key.u.ID,
                       Quantity = pu_ivitem_group.Sum(x => x.item == null || x.iv == null ? 0
                                       : x.iv.Type == InventoryVoucherType.Enter ? x.item.Quantity : x.item.Quantity * -1
                        )
                   };
        }


        private IQueryable<PartInventory> FetchPartsByStore(long storeRef)
        {
            throw null;

            //return parts
            //    .Join(units,
            //            p => p.UnitRef,
            //            u => u.ID,
            //            (p, u) => new { p, u }) // Join Unit

            //    .Join(partStores.Where(ps => ps.StoreRef == storeRef),
            //            pu => pu.p.ID,
            //            ps => ps.PartRef,
            //            (pu, ps) => pu)  // Join PartStore 

            //    .GroupJoin(items,
            //            pu => pu.p.ID,
            //            item => item.PartRef,
            //            (pu, itemGroup) => new { pu, itemGroup })  // Left join InventoryVoucherItem

            //    .SelectMany(
            //            pu_item => pu_item.itemGroup.DefaultIfEmpty(),
            //            (pu_items, item) => new { pu_items.pu.p, pu_items.pu.u, item })  // Flatten the result

            //    .GroupJoin(inventoryVouchers.Where(iv => iv.StoreRef == storeRef),
            //            pu_item => pu_item.item.InventoryVoucherRef,
            //            iv => iv.ID,
            //            (pu_item, ivGroup) => new { pu_item, ivGroup })  // Left join InventoryVoucher

            //    .SelectMany(
            //            pu_item_ivGroup => pu_item_ivGroup.ivGroup.DefaultIfEmpty(),
            //            (pu_item_ivGroup, iv) => new { pu_item_ivGroup.pu_item.p, pu_item_ivGroup.pu_item.u, iv, pu_item_ivGroup.pu_item.item })  // Flatten the result

            //    .GroupBy(x => new { x.p, x.u })
            //    .Select(g => new PartAndRemainInStore
            //    {
            //        ID = g.Key.p.ID,
            //        Code = g.Key.p.Code,
            //        Title = g.Key.p.Title,
            //        Unit = g.Key.u.Title,
            //        Remaining = g.Sum(x => x.iv != null && x.item != null
            //                                ? (x.iv.Type == InventoryVoucherType.Enter ? x.item.Quantity : x.item.Quantity * -1)
            //                                : 0
            //                         )
            //    });



        }

        [SubscribeTo(typeof(IInventoryVoucherBusiness), "SavingRecord", IsAdvisor = true)]
        private void ControlInventory(object sender, EntitySavingEventArgs<InventoryVoucher> e)
        {
            var record = e.SavedEntity;
            var changeSet = e.ChangeSet;

            var partsInventory = FetchPartInventoryByStore(record.StoreRef).ToDictionary(p => p.PartRef);

            var factor = record.Type == InventoryVoucherType.Enter ? 1 : -1;
            var orgFactor = (InventoryVoucherType)record.GetPorpertyOriginalValue("Type") == InventoryVoucherType.Enter ? 1 : -1;

            foreach (var change in changeSet.Where(cs => cs.First is InventoryVoucherItem))
            {
                var partInventory = partsInventory[(long)change.First.GetPropertyValue("PartRef")];
                switch (change.Second)
                {
                    case EntityActionType.Insert:

                        var inventory = partInventory.Quantity;
                        var quantity = (decimal)change.First.GetPropertyValue("Quantity");
                        if (inventory + quantity * factor < 0)
                        {

                            ThrowInventoryControlException(partInventory);
                        }
                        break;
                    case EntityActionType.Update:

                        quantity = (decimal)change.First.GetPropertyValue("Quantity");
                        var Orgquantity = (decimal)change.First.GetPorpertyOriginalValue("Quantity");

                        var partRef = change.First.GetPropertyValue("PartRef");
                        var orgPartRef = change.First.GetPorpertyOriginalValue("PartRef");

                        if (partRef == orgPartRef)
                        {
                            if (partInventory.Quantity + quantity * factor - Orgquantity * orgFactor < 0)
                            {
                                ThrowInventoryControlException(partInventory);
                            }
                        }
                        else
                        {
                            if (partInventory.Quantity + quantity * factor < 0)
                            {
                                ThrowInventoryControlException(partInventory);
                            }

                            if (partsInventory[(long)orgPartRef].Quantity - Orgquantity * orgFactor < 0)
                            {
                                ThrowInventoryControlException(partInventory);
                            }
                        }

                        break;
                    case EntityActionType.Delete:
                        inventory = partInventory.Quantity;
                        quantity = (decimal)change.First.GetPorpertyOriginalValue("Quantity");
                        if (inventory - quantity * orgFactor < 0)
                        {
                            ThrowInventoryControlException(partInventory);
                        }
                        break;
                }
            }

            if (factor != orgFactor && record.Type == InventoryVoucherType.Exit)
            {
                IEnumerable<InventoryVoucherItem> unchangedItems = record.InventoryVoucherItems.Except(changeSet
                    .Where(c => c.First is InventoryVoucherItem && c.Second != EntityActionType.Delete)
                    .Select(c => c.First).Cast<InventoryVoucherItem>());
                ;
                foreach (var item in unchangedItems)
                {
                    var partInventory = partsInventory[item.PartRef];
                    if (partInventory.Quantity - 2 * item.Quantity < 0)
                    {
                        ThrowInventoryControlException(partInventory);
                    }
                }
            }

        }


        [SubscribeTo(typeof(IInventoryVoucherBusiness), "DeletingRecord", IsAdvisor = true)]
        private void ControlInventory(object sender, EntityDeletingEventArgs<InventoryVoucher> e)
        {
            var iv = e.Entity;
            if (iv.Type == InventoryVoucherType.Enter)
            {
                var partIDs = iv.InventoryVoucherItems.Select(item=> item.PartRef).ToArray();
                var partsInventory = FetchPartInventoryByStore(iv.StoreRef)
                    .Where(pi => partIDs.Contains(pi.PartRef))
                    .ToDictionary(pi=>pi.PartRef); 
                foreach (var item in iv.InventoryVoucherItems)
                {
                    var pi = partsInventory[item.PartRef];
                    if (pi.Quantity - item.Quantity < 0)
                    {
                        ThrowInventoryControlException(pi);
                    }
                }
            }
        }


        private void FillPartInventoryProperties(ref PartInventory inventory)
        {
            var partBiz = ServiceFactory.Create<IPartBusiness>();
            var unitBiz = ServiceFactory.Create<IUnitBusiness>();
            var partID = inventory.PartRef;
            var pu = (from part in partBiz.FetchAll()
                      join unit in unitBiz.FetchAll() on part.UnitRef equals unit.ID
                      where part.ID == partID
                      select new
                      {
                          part,
                          unit
                      }).Single();
            inventory.PartTitle = pu.part.Title;
            inventory.UnitTitle = pu.unit.Title;
        }

        private void ThrowInventoryControlException(PartInventory inventory)
        {
            FillPartInventoryProperties(ref inventory);
            throw this.CreateException("Messages_InventoryCannotBeNegative", inventory.PartTitle, inventory.Quantity.ToString("N2"), inventory.UnitTitle);
        }

    }
}
