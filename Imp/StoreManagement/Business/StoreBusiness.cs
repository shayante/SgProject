using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;
using SystemGroup.Training.StoreManagement.Common;


namespace SystemGroup.Training.StoreManagement.Business
{
    [Service]
    public class StoreBusiness : BusinessBase<Store>, IStoreBusiness
    {
        protected override void OnUpdatingRecord(Store record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            var inventoryVouchers = ServiceFactory.Create<IInventoryVoucherBusiness>().FetchAll();
            if (inventoryVouchers.Any(i => i.StoreRef == record.ID))
            {
                throw this.CreateException("Messages_CannotEditStoreWhenUsedInInventoryVoucher");
            }
            base.OnUpdatingRecord(record, changeSet);
        }
    }
}