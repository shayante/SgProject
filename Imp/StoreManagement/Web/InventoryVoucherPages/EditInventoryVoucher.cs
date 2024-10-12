using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Common;
using SystemGroup.Framework.Localization;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.StorePages;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Pages.EditorPage;
using Telerik.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.InventoryVoucherPages
{
    public partial class EditInventoryVoucher : SgEditorView<InventoryVoucher>
    {

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get { yield return ".InventoryVoucherItems"; }
        }

        public override DetailLoadOptions EntityLoadOptions
        {
            get { return LoadOptions.With<InventoryVoucher>(i => i.InventoryVoucherItems); }
        }

      

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ScriptManager.Scripts.Add(new ScriptReference("Edit.js"));
        }

        protected override void OnCreateViews()
        {
            AddControls();

        }

        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<InventoryVoucher> context)
        {
            BindControls(context);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var ds = FindDataSource(ClientSideDetailDataSources.First());
            ds.OnClientInsertedEntity = "ds_onInsertedEntity";
            ds.OnClientRemovedEntity = "ds_onRemovedEntity";
            ds.OnClientUpdatedEntity = "ds_onUpdatedEntity";

        }


        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);
            CurrentEntity?.FillItemsProperties();


            var ds = FindDataSource(ClientSideDetailDataSources.First());
            sltStore.Enabled = ds.Entities.Count == 0;

            txtItemCount.Text =  ds.Entities.Count.ToString();
            txtQuantitySum.Text = ds.Entities.Cast<InventoryVoucherItem>().Sum(i => i.Quantity).ToString("N2");


        }

        

        protected override void OnEntityCreated(object sender, EntityCreatedEventArgs e)
        {
            base.OnEntityCreated(sender, e);
            sltStore.Enabled = true;
        }



        private void sltPart_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {

            var slt = (SgSelector)sender;
            var ignores = ((IEnumerable)e.Context["IgnoreIDs"]).Cast<object>()
                .Select(x => Convert.ToInt64(x));

            slt.FilterExpression = i => !ignores.Contains(((PartInventory)i).PartRef);


            var storeRef = e.Context["storeRef"] ?? throw this.CreateException("Training.StoreManagement:Messages_SelectStoreToAddItem");
            slt.ViewParameters[0].Value = storeRef;


        }
    }
}
