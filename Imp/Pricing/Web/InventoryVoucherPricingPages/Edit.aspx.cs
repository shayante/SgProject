using System;
using System.Collections.Generic;
using System.Linq;
using SystemGroup.Framework;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Localization;
using SystemGroup.Framework.Lookup;
using SystemGroup.Framework.Service;
using SystemGroup.Framework.StateManagement.ProtoType;
using SystemGroup.Training.Pricing.Common;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Shell;
using Telerik.Web.UI;

namespace SystemGroup.Training.Pricing.Web.InventoryVoucherPricingPages
{
    public partial class Edit : SgPage
    {

        #region Statics

        private static IInventoryVoucherBusiness InventoryVoucherBusiness => ServiceFactory.Create<IInventoryVoucherBusiness>();
        private static IItemPriceBusiness ItemPriceBiz => ServiceFactory.Create<IItemPriceBusiness>();

        #endregion

        #region Properties

        SgEntityDataSource<ItemPrice> dsItems;
        //IList<ItemPrice> orginalItems;

        #endregion
        #region Methods

        //protected override void OnLoad(EventArgs e)
        //{


        //    base.OnLoad(e);
        //    //var id = Request.QueryString["ID"];
        //    //ServiceFactory.Create<IItemPriceBusiness>().FetchAll();

        //}


        public override SgToolBar ToolBar
        {
            get
            {
                return toolbar;
            }
        }

        protected override void OnInit(EventArgs e)
        {

            dsItems = new SgEntityDataSource<ItemPrice>() { ID = "dsItems", OperationalOnClientSide = true };
            Form.Controls.Add(dsItems);
            dsItems.RegisterDecimalPropertySerializedAsString(nameof(ItemPrice.Quantity));
            dsItems.RegisterDecimalPropertySerializedAsString(nameof(ItemPrice.EditablePrice));

            var id = Convert.ToInt64(Request.QueryString["ID"]);

            var loadOptions = LoadOptions
                .With<InventoryVoucher>(i => i.InventoryVoucherItems)
                .With<InventoryVoucher>(i=>i.Store)
                //.With<InventoryVoucher>(i=>i.StoreKeeper)
                ;

            var iv = InventoryVoucherBusiness.FetchByID(id,loadOptions).FirstOrDefault()?.FillPartyProperty();
            if (iv == null)
            {
                throw this.CreateException("Training.Pricing:Messages_InventoryVoucherNotFound");
            }
            else if (iv.State != InventoryVoucherState.Confirmed || iv.Type != InventoryVoucherType.Enter)
            {
                SgShell.CurrentPage.Close();
                throw this.CreateException("Training.Pricing:Messages_InventoryVoucherCannotBePriced");
                
            } 

            Title = this.ServerTranslate("Training.Pricing:Labels_Pricing") + $" ({iv.Number})";


            txtNumber.Text = iv.Number;
            txtStore.Text = iv.Store.Name;
            txtStoreKeeper.Text = iv.StoreKeeperFullName;
            dpDate.SelectedDate = iv.Date;
            txtState.Text = StateMachine.Of<InventoryVoucher,InventoryVoucherState>().GetCurrentState(iv).Title;
            txtType.Text = LookupService.Lookup(iv.Type).Value;
            
            dsItems.Entities = ItemPriceBiz.FetchItemPricesByInventoryVoucher(id);
            base.OnInit(e);
        }

        


        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
        }

        #endregion

        
        private void DoSave()
        {
            var list = new List<ItemPrice>();
            list.AddRange(dsItems.Entities);
            ItemPriceBiz.SaveItems(ref list);
            dsItems.Entities = list;
        }



        protected void toolbar_Click(object sender, RadToolBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "Save":
                    DoSave();
                    SgShell.Refresh();
                    break;

                case "SaveAndClose":
                    DoSave();
                    SgShell.CloseCurrentPage();
                    break;
            }
        }

        




    }
}