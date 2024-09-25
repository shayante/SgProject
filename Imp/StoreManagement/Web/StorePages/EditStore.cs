using System;
using System.Collections.Generic;
using System.Web.UI;
using SystemGroup.Framework.Business;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Pages.EditorPage;
using Telerik.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.StorePages
{
    public partial class EditStore : SgEditorView<Store>
    {


        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get
            {

                yield return ".PartStores";
            }
        }

        public override DetailLoadOptions EntityLoadOptions 
            => LoadOptions.With<Store>(store => store.PartStores);

        protected override void OnInit(EventArgs e)
        {
            ScriptManager.Scripts.Add(new ScriptReference("Edit.js"));
            base.OnInit(e);

           
        }

        protected override void OnCreateViews()
        {
            AddControls();
        }

        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Store> context)
        {
            BindControls(context);
        }


        protected override void OnEntityLoaded(object sender, EntityLoadedEventArgs e)
        {
            base.OnEntityLoaded(sender, e);
            CurrentEntity.LoadParts();
        }

        private void sltPart_onItemRequested(object sender, RadComboBoxItemsRequestedEventArgs args)
        {

            //var slt = (SgSelector)sender;
            //slt.

        }
    }
}
