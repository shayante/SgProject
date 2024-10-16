using SystemGroup.Framework.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Business;
using SystemGroup.Training.Pricing.Common;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Framework.Eventing;


namespace SystemGroup.Training.Pricing.Business
{
    [Service]
    public class ItemPriceBusiness : BusinessBase<ItemPrice>, IItemPriceBusiness
    {

        private IQueryable<InventoryVoucherItem> FetchItemsByInventoryVoucherID(long ivRef) 
            => ServiceFactory.Create<IInventoryVoucherBusiness>().FetchDetail<InventoryVoucherItem>().Where(i => i.InventoryVoucherRef == ivRef);

        private IQueryable<ItemPrice> FetchItemPricesByInventoryVoucherID(long ivRef) => FetchItemsByInventoryVoucherID(ivRef)
                    .Join(FetchAll(), item => item.ID, itemPrice => itemPrice.VoucherItemRef, (item, itemPrice) => itemPrice);

        public virtual IList<ItemPrice> FetchItemPricesByInventoryVoucher(long ivID)
        {
            
            var units= ServiceFactory.Create<IUnitBusiness>().FetchAll();
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            var voucherItems = FetchItemsByInventoryVoucherID(ivID);
            var itemPrices = FetchAll();
            var index = -2;

            ItemPrice FillParameter(in ItemPrice ip,Part p, Unit u ,InventoryVoucherItem i)
            {
                ip.PartTitle = p.Title;
                ip.UnitTitle = u.Title;
                ip.Quantity = i.Quantity;
                ip.EditablePrice = ip.Price;
                return ip;
                
            }
           


            return (from item in voucherItems
                   join part in parts on item.PartRef equals part.ID
                   join unit in units on part.UnitRef equals unit.ID
                   join itemPrice in itemPrices on item.ID equals itemPrice.VoucherItemRef into itemPrice
                   from ip in itemPrice.DefaultIfEmpty()
                    select new
                    {
                        item,
                        part,
                        unit,
                        ip
                    }).ToList()
                    .Select(x => x.ip != null 
                        ? FillParameter(x.ip,x.part,x.unit,x.item)
                        : new ItemPrice { ID = index--, VoucherItemRef = x.item.ID, PartTitle = x.part.Title, UnitTitle = x.unit.Title, Quantity = x.item.Quantity })
                    .ToList();


        }

        public virtual void SaveItems(ref List<ItemPrice> items)
        {

            List<ItemPrice> saveItems = new List<ItemPrice>();
            List<ItemPrice> deleteItems = new List<ItemPrice>();

            foreach (var item in items)
            {

                item.SubmitPrice();
                if (item.Price > 0)
                {
                    saveItems.Add(item);
                }
                else if(item.ID > 0)
                {
                    deleteItems.Add(item);
                }
            }


            Save(ref saveItems);
            Delete(deleteItems);

            //var index = -2;
            //foreach (var item in deleteItems)
            //{
            //    items.Remove(item);
            //    items.Add(new ItemPrice
            //    {
            //        ID = index--,
            //        VoucherItemRef = item.ID,
            //        PartTitle = item.PartTitle,
            //        UnitTitle = item.UnitTitle,
            //        Quantity = item.Quantity
            //    });
            //}



        }


        [SubscribeTo(typeof(IInventoryVoucherBusiness), "RecordSaved", IsAdvisor = true)]
        private void CheckInventoryVoucherCanChangeState(object sender, EntitySavingEventArgs<InventoryVoucher> e)
        {
            if (e.SavedEntity.State != InventoryVoucherState.Confirmed || e.SavedEntity.Type != InventoryVoucherType.Enter)
            {
                var hasAnyItemPrice = FetchItemPricesByInventoryVoucherID(e.SavedEntity.ID).Any();
                if (hasAnyItemPrice)
                {
                    throw this.CreateException("Training.Pricing:Messages_StateOfInventoryVoucherWithPriceCannotChange");
                }
            }
        }
    }
}
