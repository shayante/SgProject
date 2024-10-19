using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Localization;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.Convention;
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

        private SgEntityDataSource<InventoryVoucherItem> DataSource =>(SgEntityDataSource<InventoryVoucherItem>) FindDataSource(ClientSideDetailDataSources.First());

        public override DetailLoadOptions EntityLoadOptions => LoadOptions.With<InventoryVoucher>(i => i.InventoryVoucherItems);

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ScriptManager.Scripts.Add(new ScriptReference("Edit.js"));
            DataSource.RegisterDecimalPropertySerializedAsString(nameof(InventoryVoucherItem.Quantity));
            
        }

        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<InventoryVoucher> context)
        {
            context.BindProperty(iv => iv.Number).To(nrgNumber);
            context.BindValueTypeProperty(iv => iv.StoreRef).To(sltStore);
            context.BindValueTypeProperty(iv => iv.Date).To(dpDate);
            context.BindValueTypeProperty(iv => iv.Type).To(lkpType);
            context.BindValueTypeProperty(iv => iv.StoreKeeperRef).To(sltStoreKeeper);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var ds = DataSource;
            ds.OnClientInsertedEntity = "ds_onInsertedEntity";
            ds.OnClientRemovedEntity = "ds_onRemovedEntity";
            ds.OnClientUpdatedEntity = "ds_onUpdatedEntity";

        }


        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);
            CurrentEntity?.FillItemsProperties();


            var ds = DataSource;
            sltStore.Enabled = ds.Entities.Count == 0;

            decItemCount.Value = ds.Entities.Count;
            decQuantitySum.Value = ds.Entities.Sum(i => i.Quantity);


            FillExtraColumns();

        }

        

        protected override void OnEntityCreated(object sender, EntityCreatedEventArgs e)
        {
            base.OnEntityCreated(sender, e);
            sltStore.Enabled = true;
        }


        private void AddExtraColumns()
        {
            var implementations = new SgConventionExecutor<IInventoryVoucherExtraColumn>().Implementations;

            foreach (var imp in implementations)
            {
                
                if (imp.HasColumn(Convert.ToInt64(Request.QueryString?["id"] ?? "0")))
                {
                    imp.AddColumn(grdItems);
                }
            }
        }


        private void FillExtraColumns()
        {
            var implementations = new SgConventionExecutor<IInventoryVoucherExtraColumn>().Implementations;

            foreach (var imp in implementations)
            {
                imp.FillExtraProperies(DataSource);
            }
        }

        private void grdItems_Init(object sender, EventArgs e)
        {
            AddExtraColumns();
        }

        private void sltPart_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {

            var slt = (SgSelector)sender;
            var ignores = ((IEnumerable)e.Context["IgnoreIDs"])
                .Cast<object>()
                .Select(x => Convert.ToInt64(x));

            slt.FilterExpression = i => !ignores.Contains(((PartInventory)i).PartRef);


            var storeRef = e.Context["storeRef"] ?? throw this.CreateException("Training.StoreManagement:Messages_SelectStoreToAddItem");
            slt.ViewParameters[0].Value = storeRef;


        }
    }
}
