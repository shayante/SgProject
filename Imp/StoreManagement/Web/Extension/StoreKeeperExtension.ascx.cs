using System;
using System.Linq;
using SystemGroup.Framework.Frontend.Extensions;
using SystemGroup.Framework.Service;
using SystemGroup.General.PartyManagement.Common;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Extension{
    public partial class StoreKeeperExtension : SgEditorPageExtensionControl<Party>
    {
        private static IStoreKeeperBusiness SotreKeeperBiz => ServiceFactory.Create<IStoreKeeperBusiness>();

        private StoreKeeper FetchCurrentEntity() => SotreKeeperBiz
            .FetchAll()
            .Where(sk => sk.PartyRef == Page.CurrentEntity.ID)
            .FirstOrDefault();

        //private StoreKeeper Current { get;set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Page.Load += Page_EntityLoaded;
            Page.EntityLoaded += Page_EntityLoaded;
            Page.EntitySaving += Page_EntitySaving;
            Page.EntityDeleting += Page_EntityDeleting;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }


        public void Page_EntityLoaded(object sender, EventArgs e)
        {
            var current = FetchCurrentEntity();
            
            if (current != null)
            {
                chkStoreKeeper.Checked = current != null;
                chkStoreKeeper.Enabled = SotreKeeperBiz.FetchVouchersOfStoreKeeper(current.ID).Any();
                chkStoreKeeper.DataBind();
            }
            else
            {
                chkStoreKeeper.Checked = false;
            }
        }

        public void Page_EntitySaving(object sender, EntitySavingEventArgs e)
        {
            var current = FetchCurrentEntity();
            var isStoreKeeper = chkStoreKeeper.Checked;
            if (isStoreKeeper)
            {
                if (current == null)
                {
                    current = new StoreKeeper();
                }

                e.ExtensionEntities["StoreKeeper"] = current;
            }
            else
            {
                if (current != null)
                {
                    e.DeletedExtensionEntities["StoreKeeper"] = current;
                }


            }
        }

        public void Page_EntityDeleting(object sender, EntityDeletingEventArgs e)
        {
            var current = FetchCurrentEntity();
            if (current != null)
            {
                e.ExtensionEntities["StoreKeeper"] = current;
            }

        }

    }
}