﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Views;

namespace SystemGroup.Training.StoreManagement.Web.UnitPages
{
    public partial class EditUnit
    {


        #region Controls

        SgTextBox txtTitle;

        #endregion

        #region Methods

        private void AddControls()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>();
            var layout = fieldSet.Add<DynamicFieldLayoutView>()
                ;
                //.NumberOfColumns(1)
                //.LabelCellWidth(150)
                //.InputCellWidth(200)
                //.ValidationCellWidth(30);

            var row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:Unit_Title", true);
            row.SetInput<TextBoxView>()
                //.Width(180)
                .RealizedIn(() => txtTitle);
            
            row.SetRequiredValidator();

            
            
        }

        private void BindControls(SgDataSourceEditorBindingContext<Unit> context)
        {
            context.BindProperty(unit=> unit.Title).To(txtTitle);
        }

        #endregion
    }
}
