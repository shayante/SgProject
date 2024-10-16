using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Views;
using Telerik.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Convention
{
    public interface IInventoryVoucherExtraColumn: IConvention
    {

        bool HasColumn(long ivID);// => HasColumn(ServiceFactory.Create<IInventoryVoucherBusiness>().FetchByID(ivID).First());
        bool HasColumn(InventoryVoucher iv);
        void AddColumn(SgGrid grid);
        void FillExtraProperies(SgEntityDataSource<InventoryVoucherItem> dataSource);


    }
}
