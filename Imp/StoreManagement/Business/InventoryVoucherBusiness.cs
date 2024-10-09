using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Eventing;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class InventoryVoucherBusiness : BusinessBase<InventoryVoucher>, IInventoryVoucherBusiness
    {

        [SubscribeTo(typeof(IUnitBusiness), "UpdatingRecord", IsAdvisor = true)]
        private void RestrictEditUnit(object sender, EntitySavingEventArgs<Unit> e)
        {
            var hasInventoryVoucher = (from item in FetchDetail<InventoryVoucherItem>()
                                       join part in ServiceFactory.Create<IPartBusiness>().FetchAll() on item.PartRef equals part.ID
                                       where part.UnitRef == (long)e.SavedEntity.GetPorpertyOriginalValue("UnitRef")
                                       select part)
                                       .Any();

            if (hasInventoryVoucher)
            {
                throw this.CreateException("Messages_CannotEditUnitWhenUsedInInventoryVoucherItem");
            }
        }


        [SubscribeTo(typeof(IPartBusiness), "UpdatingRecord", IsAdvisor = true)]
        private void RestrictEditPart(object sender, EntitySavingEventArgs<Part> e)
        {
            if (FetchDetail<InventoryVoucherItem>().Any(i => i.PartRef == e.SavedEntity.ID))
            {
                throw this.CreateException("Messages_CannotEditPartWhenUsedInInventoryVoucherItem");
            }
        }



        [SubscribeTo(typeof(IStoreBusiness), "UpdatingRecord", IsAdvisor = true)]
        private void RestrictEditStore(object sender, EntitySavingEventArgs<Store> e)
        {
            if (FetchAll().Any(i => i.StoreRef == e.SavedEntity.ID))
            {
                throw this.CreateException("Messages_CannotEditStoreWhenUsedInInventoryVoucher");
            }
        }



    }
}
