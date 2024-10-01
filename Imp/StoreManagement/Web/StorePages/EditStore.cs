using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using SystemGroup.Framework.Business;
using SystemGroup.Framework.Service;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.Dialog;
using SystemGroup.Web;
using SystemGroup.Web.UI;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Pages.EditorPage;
using Telerik.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.StorePages
{
    public partial class EditStore : SgEditorView<Store>
    {
        private SgEntityDataSource<PartStore> dsPartStore =>
            (SgEntityDataSource<PartStore>)FindDataSource(".PartStores");

        protected override IEnumerable<string> ClientSideDetailDataSources
        {
            get { yield return ".PartStores"; }
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
            var dict = args.Context;
            var list = ((IEnumerable)dict["IgnoreIDs"]).Cast<object>().Select(o => Convert.ToInt64(o));


            ((SgSelector)sender).FilterExpression = part => !list.Contains(((Part)part).ID);
        }

        private void grdPart_onCommand(object sender, SgGridCommandEventArgs args)
        {
            var selectedParts = dsPartStore.Entities.Select(ps => ps.PartRef).ToArray();
            var key = ShortTermSessionState.Current.Add(selectedParts);
            //SgWindow.ShowModalDialog(typeof(AddPartDialog),$"partsRefKey={key}", "PartSelectionDialog",this,null);
            SgWindow.ShowModalDialog<PartSelectionDialog>(
                $"partsKey={key}",
                "PartSelectionDialog",
                argument: null,
                //queryString:
                onClientClose: "PartSelection_OnClientClose",
                features: "height: 420, width: 817, visibleStatusbar: false, caption:'انتخاب گروهی کالا'");
        }

        private void btnPartSelection_onClick(object sender, EventArgs e)
        {
            var key = hiddenFieldPartIdSelection.Value as string;
            var ids = (long[])ShortTermSessionState.Current[key];

            var list = ServiceFactory.Create<IPartBusiness>()
                .FetchByID(ids)
                .ToList()
                .Select(part => new PartStore
                {
                    PartRef = part.ID,
                    PartCode = part.Code,
                    PartTitle = part.Title,
                });

            foreach (var partStore in list)
            {
                dsPartStore.AssignTemporaryID(partStore);
                if (!dsPartStore.Entities.Any((ps => ps.PartRef == partStore.PartRef)))
                {
                    dsPartStore.Entities.Add(partStore);
                }
            }

            dsPartStore.UpdateClientData();
            grdParts.DataBind();
        }
    }
}