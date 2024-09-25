using System;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Pages.EditorPage;

namespace SystemGroup.Training.StoreManagement.Web.UnitPages
{
    public partial class EditUnit : SgEditorView<Unit>
    {
        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Unit> context)
        {
            BindControls(context);
        }

        protected override void OnCreateViews()
        {
           AddControls();
        }
    }
}
