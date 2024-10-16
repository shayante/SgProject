using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Service;
using SystemGroup.Training.Pricing.Web.Conventions;
using SystemGroup.Training.Pricing.Web.InventoryVoucherPricingPages;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web;
using SystemGroup.Web.ApplicationServices;
using SystemGroup.Web.UI.Shell;

namespace SystemGroup.Training.Pricing.Web
{
    
    public class WebComponentInitializer : WebComponentInitializerBase
    {
        #region EntityActions


        [CustomEntityAction(typeof(InventoryVoucher), "Training.Pricing:Labels_AddPrice",ImageUrl = "~/Training/Pricing/Icons/pricing.gif", ToolTip = "Training.Pricing:Labels_AddPrice")]
        public void CustomTestConvention(long[] ids)
        {
            foreach (var id in ids)
            {
                if (IsInventoryPriceable(id))
                {
                    SgShell.Show<Edit>($"id={id}");
                }
                else
                {
                    throw this.CreateException("Training.Pricing:Messages_InventoryVoucherCannotBePriced");
                }
                
            }
        }
        #endregion

        #region Methods

        private bool IsInventoryPriceable(long id)
        {
           return ServiceFactory.Create<IInventoryVoucherBusiness>().FetchByID(id).Where(iv => iv.State == InventoryVoucherState.Confirmed && iv.Type == InventoryVoucherType.Enter).FirstOrDefault() != null;
        }


        protected override IEnumerable<ConventionImplementationInfo> GetConventionImplementations()
        {
            yield return new ConventionImplementationInfo("عنوان قیمت گذاری",typeof(InventoryVoucherPricing),1);
        }

        #endregion
    }
}
