using System;
using SystemGroup.Training.StoreManagement.Web.StorePages;
using SystemGroup.Web;
using SystemGroup.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Dialog
{
    public partial class PartSelectionDialog : SgPage
    {
        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            elParts.ViewParameters[0].Value = ShortTermSessionState.Current[Request.QueryString["partsKey"]];
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            var selectedIDs = elParts.SelectedRecordIDs;
            var key = ShortTermSessionState.Current.Add(selectedIDs);
            System.Web.UI.ScriptManager.RegisterStartupScript(
                this,
                typeof(EditStore),
                "PartSelection_OnClientClose",
                $"btnOK_ClientClick('{key}')",
                true);
        }


        #endregion
    }
}