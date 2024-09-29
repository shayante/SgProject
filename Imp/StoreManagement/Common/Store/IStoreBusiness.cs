using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    [ServiceInterface]
    public interface IStoreBusiness : IBusinessBase<Store>
    {
        [EntityView("AllStores", "Views_AllStores", typeof(StoreProjection), "Name", IsDefaultView = true)]
        new IQueryable<Store> FetchAll();
    }
}
