using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class InventoryService : ServiceBase, IInventoryService
    {
        public virtual IQueryable<PartInventory> FetchPartInventoryByStore(long storeRef)
        {
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            var partStores = ServiceFactory.Create<IStoreBusiness>().FetchDetail<PartStore>();
            var inventorybiz = ServiceFactory.Create<IInventoryVoucherBusiness>();
            var inventoryVouchers = inventorybiz.FetchAll();
            var items = inventorybiz.FetchDetail<InventoryVoucherItem>();



            return from p in parts
                   join ps in partStores on p.ID equals ps.PartRef
                   where ps.StoreRef == storeRef
                   join item in items on p.ID equals item.PartRef
                   into p_items
                   from item in p_items.DefaultIfEmpty()
                   join iv in (from iv in inventoryVouchers where iv.StoreRef == storeRef select iv) on item.InventoryVoucherRef equals iv.ID
                   into p_item_ivs
                   from iv in p_item_ivs.DefaultIfEmpty()
                   group new { iv, item } by p.ID into pu_ivitem_group
                   select new PartInventory
                   {

                       PartRef = pu_ivitem_group.Key,
                       StoreRef = storeRef,
                       
                       Quantity = pu_ivitem_group.Sum(x => x.item == null || x.iv == null ? 0
                                       : x.iv.Type == InventoryVoucherType.Enter ? x.item.Quantity : x.item.Quantity * -1
                        )
                   };
        }

    }
}
