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

        void ConfigExtraColumn(SgGrid grid,InventoryVoucher iv);





    }
}
