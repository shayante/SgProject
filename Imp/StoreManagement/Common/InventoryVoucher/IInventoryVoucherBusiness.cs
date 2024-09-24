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
    public interface IInventoryVoucherBusiness : IBusinessBase<InventoryVoucher>
    {
        [EntityView("AllInventoryVouchers", "Views_AllInventoryVouchers", typeof(InventoryVoucherProjection), "Number", IsDefaultView = true)]
        new IQueryable<InventoryVoucher> FetchAll();
    }
}
