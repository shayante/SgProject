using System;
using System.Linq;
using SystemGroup.Framework.Frontend.Extensions;
using SystemGroup.Framework.Service;
using SystemGroup.General.PartyManagement.Common;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Extension
{
    public partial class StoreKeeperExtension : SgEditorPageExtensionControl<Party>
    {
        private static IStoreKeeperBusiness SotreKeeperBiz => ServiceFactory.Create<IStoreKeeperBusiness>();

        //private StoreKeeper CurrentExtensionEntity => SotreKeeperBiz
        //    .FetchAll()
        //    .FirstOrDefault(sk => sk.PartyRef == Page.CurrentEntity.ID)
        //    ;

        //TODO remove view state and fetch every time
        private StoreKeeper CurrentExtensionEntity
        {
            get
            {
                if (ViewState["CurrentExtensionEntity"] == null)
                {
                    ViewState["CurrentExtensionEntity"] = SotreKeeperBiz
                        .FetchAll()
                        .FirstOrDefault(sk => sk.PartyRef == Page.CurrentEntity.ID);
                }

                return (StoreKeeper)ViewState["CurrentExtensionEntity"];
            }

        }

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
            //var current = CurrentExtensionEntity;

            if (CurrentExtensionEntity != null)
            {
                chkStoreKeeper.Checked = CurrentExtensionEntity != null;
                chkStoreKeeper.Enabled = !SotreKeeperBiz.FetchVouchersOFStoreKeeper(current.ID).Any();
                chkStoreKeeper.DataBind();
            }
            else
            {
                chkStoreKeeper.Checked = false;
            }
        }

        public void Page_EntitySaving(object sender, EntitySavingEventArgs e)
        {
            //var current = CurrentExtensionEntity();
            var isStoreKeeper = chkStoreKeeper.Checked;
            if (isStoreKeeper)
            {
                if (CurrentExtensionEntity == null)
                {
                    e.ExtensionEntities["StoreKeeper"] = new StoreKeeper();
                }
                else
                {
                    e.ExtensionEntities["StoreKeeper"] = CurrentExtensionEntity;
                }
                
            }
            else
            {
                if (CurrentExtensionEntity != null)
                {
                    e.DeletedExtensionEntities["StoreKeeper"] = CurrentExtensionEntity;
                }


            }
        }

        public void Page_EntityDeleting(object sender, EntityDeletingEventArgs e)
        {
            if (CurrentExtensionEntity != null)
            {
                e.ExtensionEntities["StoreKeeper"] = CurrentExtensionEntity;
            }

        }

    }
}