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
        protected override void OnSavingRecord(Store record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            if (FetchAll().Select(s => s.Code).Any(code => code == record.Code))
            {
                throw this.CreateException("Messages_StoreCodeDuplicated");
            }

            if (FetchAll().Select(s => s.Name).Any(name => name == record.Name))
            {
                throw this.CreateException("Messages_StoreNameDuplicated");
            }

            base.OnSavingRecord(record, changeSet);
        }
    }
}