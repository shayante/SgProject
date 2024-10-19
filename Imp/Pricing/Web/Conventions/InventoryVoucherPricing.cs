using System.Linq;
using System.Runtime.Remoting.Messaging;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.Utilities;
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


        public void ConfigExtraColumn(SgGrid grid, InventoryVoucher iv)
        {

            var shouldAdd = iv != null && iv.ID > 0 && iv.Type == InventoryVoucherType.Enter && iv.State == InventoryVoucherState.Confirmed;

            if (shouldAdd)
            {
               if(!grid.Columns.Any(c=>c.UniqueName == "PriceColumn"))
                {
                    var column = new SgDecimalGridColumn
                    {
                        AllowEdit = false,
                        HeaderText = Translator.Translate("Training.Pricing:Labels_Price"),
                        GroupSize = 3,
                        Precision = 2,
                        PropertyName = "ExtraPropery",
                        UniqueName = "PriceColumn",
                        


                    };

                    grid.Columns.Add(column);
                    grid.Rebuild();
                    FillExtraProperies((SgEntityDataSource<InventoryVoucherItem>)grid.DataSourceObject);
                }
            }
            else
            {
                grid.Columns.TryRemoveFirst(c => c.UniqueName == "PriceColumn", out SgGridColumn delColumn);
            }



            
            

        }

        private void FillExtraProperies(SgEntityDataSource<InventoryVoucherItem> dataSource)
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
