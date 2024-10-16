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
    public class PartBusiness : BusinessBase<Part>, IPartBusiness
    {

        public virtual IQueryable<Part> FetchPartsExcept(long[] igonreIDs)
        {
            return FetchAll().Where(p => !igonreIDs.Contains(p.ID));
        }

        protected override void OnUpdatingRecord(Part record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            var items = ServiceFactory.Create<IInventoryVoucherBusiness>().FetchDetail<InventoryVoucherItem>();
            if (items.Any(i => i.PartRef == record.ID))
            {
                throw this.CreateException("Messages_CannotEditPartWhenUsedInInventoryVoucherItem");
            }

            base.OnUpdatingRecord(record, changeSet);
        }
    }
}
