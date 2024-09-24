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
    public interface IUnitBusiness : IBusinessBase<Unit>
    {
        [EntityView("AllUnits", "Unit_AllUnits", typeof(UnitProjection), "Title", IsDefaultView = true)]
        new IQueryable<Unit> FetchAll();
    }
}
