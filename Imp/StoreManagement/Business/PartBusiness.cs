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
        public virtual IQueryable<Part> FetchPartsAvailableForStore(long[] igonreIDs)//TODO change method name
        {
            return FetchAll().Where(p => !igonreIDs.Contains(p.ID));
        }


        //TODO check duplicate and foreign key in database
        protected override void OnSavingRecord(Part record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            if (FetchAll().Select(p => p.Code).Any(code => code == record.Code))
            {
                throw this.CreateException("Messages_PartCodeDuplicated");
            }

            if (FetchAll().Select(p => p.Title).Any(title => title == record.Title))
            {
                throw this.CreateException("Messages_PartTitleDuplicated");
            }
            base.OnSavingRecord(record, changeSet);
        }
    }
}
