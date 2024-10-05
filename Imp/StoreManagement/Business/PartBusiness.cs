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


        
        protected override void OnSavingRecord(Part record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            if (FetchAll().Where(p=>p.ID != record.ID).Select(p => p.Code).Any(code => code == record.Code))
            {
                throw this.CreateException("Messages_PartCodeDuplicated");
            }

            if (FetchAll().Where(p => p.ID != record.ID).Select(p => p.Title).Any(title => title == record.Title))
            {
                throw this.CreateException("Messages_PartTitleDuplicated");
            }
            base.OnSavingRecord(record, changeSet);
        }
    }
}
