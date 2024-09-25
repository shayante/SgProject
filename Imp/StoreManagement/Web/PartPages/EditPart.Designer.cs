using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Views;

namespace SystemGroup.Training.StoreManagement.Web.PartPages
{
    public partial class EditPart
    {
        #region Controls
        SgTextBox txtCode;
        SgTextBox txtTitle;
        SgSelector sltUnitRef;
        #endregion

        #region Methods
        private void AddControls()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>();
            var layout = fieldSet.Add<DynamicFieldLayoutView>().NumberOfColumns(1);

            var row = layout.AddRow();
            row.SetLabelByKey("Part_Code".GetKey(), true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtCode);
            row.SetRequiredValidator();

            row = layout.AddRow();
            row.SetLabelByKey("Part_Title".GetKey(), true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtTitle);
            row.SetRequiredValidator();


            row = layout.AddRow();
            row.SetLabelByKey("Part_UnitRef".GetKey(), true);
            row.SetInput<SelectorView>().RealizedIn(() => sltUnitRef)
                .ComponentName("SystemGroup.Training.StoreManagement")
                .EntityView<Unit>("AllUnits");
            row.SetRequiredValidator();

        }


        private void BindControls(SgDataSourceEditorBindingContext<Part> context)
        {
            context.BindProperty(part => part.Code).To(txtCode);
            context.BindProperty(part => part.Title).To(txtTitle);
            context.BindValueTypeProperty(part=>part.UnitRef).To(sltUnitRef);

        }



        #endregion

    }
}
