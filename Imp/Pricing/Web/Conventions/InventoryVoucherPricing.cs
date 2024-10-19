using System.Linq;
using System.Runtime.Remoting.Messaging;
using SystemGroup.Framework.Service;
using SystemGroup.Training.Pricing.Common;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.Convention;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Localization;
using Telerik.Web.UI;

namespace SystemGroup.Training.Pricing.Web.Conventions
{
    internal class InventoryVoucherPricing : IInventoryVoucherExtraColumn
    {

        public bool HasColumn(long ivID)
        {
            var iv = ServiceFactory.Create<IInventoryVoucherBusiness>().FetchByID(ivID).FirstOrDefault();
            if (iv == null) return false;
            return iv.Type == InventoryVoucherType.Enter && iv.State == InventoryVoucherState.Confirmed;
        }



        public void AddColumn(SgGrid grid)
        {
            var column = new SgDecimalGridColumn
            {
                AllowEdit = false,
                HeaderText = Translator.Translate("Training.Pricing:Labels_Price"),
                GroupSize = 3,
                Precision = 2,
                PropertyName = "ExtraPropery",
                

            };

            grid.Columns.Add(column);
            

        }

        public void FillExtraProperies(SgEntityDataSource<InventoryVoucherItem> dataSource)
        {
            var priceBiz = ServiceFactory.Create<IItemPriceBusiness>();
            var ItemIds = dataSource.Entities.Select(i => i.ID);
            var itemPrices = priceBiz.FetchAll().Where(ip => ItemIds.Contains(ip.VoucherItemRef)).ToDictionary(ip => ip.VoucherItemRef);
            foreach (var item in dataSource.Entities)
            {
                if (itemPrices.ContainsKey(item.ID))
                {
                    item.ExtraPropery = itemPrices[item.ID].Price;//.ToString("N2");
                }
                
            }
        }

        
    }
}
