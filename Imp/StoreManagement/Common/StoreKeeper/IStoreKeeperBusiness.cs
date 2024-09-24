using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.MetaData.Mapping;
using SystemGroup.Framework.Party;
using SystemGroup.Framework.Security;
using SystemGroup.Framework.Service;

namespace SystemGroup.Training.StoreManagement.Common
{
    [ServiceInterface]
    public interface IStoreKeeperBusiness : IBusinessBase<StoreKeeper>
    {


        
        new IQueryable<IParty> FetchAll();


    }
}
