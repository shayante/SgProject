﻿using System;
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
    public interface IPartBusiness : IBusinessBase<Part>
    {
        [EntityView("AllParts", "Views_AllParts", typeof(PartProjection), "Title", IsDefaultView = true)]
        new IQueryable<Part> FetchAll();
    }
}
