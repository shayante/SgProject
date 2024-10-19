using System;
using SystemGroup.Web.UI;

namespace SystemGroup.Training.StoreManagement.Web.Dialog
{
    public partial class PartSelectionDialog : SgUserControl
    {
        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            elParts.ViewParameters[0].Value = new long[] { };

        }

        #endregion
    }
}