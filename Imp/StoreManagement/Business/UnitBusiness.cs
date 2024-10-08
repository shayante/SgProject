﻿using System.Collections.Generic;
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
        
        protected override void OnSavingRecord(Unit record, List<Pair<Entity, EntityActionType>> changeSet)
        {
            

            if (FetchAll().Where(u => u.ID != record.ID).Select(u => u.Title).Any(title => title == record.Title))
            {
                throw this.CreateException("Messages_UnitTitleDuplicated");
            }

            base.OnSavingRecord(record, changeSet);
        }
    }
}
