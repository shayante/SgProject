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
    public class UnitBusiness : BusinessBase<Unit>, IUnitBusiness
    {
        protected override void OnUpdatingRecord(Unit record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            var items = ServiceFactory.Create<IInventoryVoucherBusiness>().FetchDetail<InventoryVoucherItem>();
            var parts = ServiceFactory.Create<IPartBusiness>().FetchAll();
            var hasInventoryVoucher = (from item in items
                                       join part in parts on item.PartRef equals part.ID
                                       where part.UnitRef == record.ID
                                       select part)
                                       .Any();

            if (hasInventoryVoucher)
            {
                throw this.CreateException("Messages_CannotEditUnitWhenUsedInInventoryVoucherItem");
            }
            base.OnUpdatingRecord(record, changeSet);
        }
    }
}
