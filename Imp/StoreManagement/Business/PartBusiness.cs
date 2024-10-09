using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
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


    }
}
