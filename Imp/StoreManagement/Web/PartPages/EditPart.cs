﻿using System;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Pages.EditorPage;

namespace SystemGroup.Training.StoreManagement.Web.PartPages
{
    public partial class EditPart : SgEditorView<Part>
    {
        protected override void OnCreateBindings(SgDataSourceEditorBindingContext<Part> context)
        {
            BindControls(context);
        }

        protected override void OnCreateViews()
        {
            AddControls();
        }
    }
}
