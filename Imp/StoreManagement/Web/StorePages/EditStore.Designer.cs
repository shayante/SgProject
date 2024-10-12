using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Training.StoreManagement.Web.Dialog;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Localization;
using SystemGroup.Web.UI.Views;

namespace SystemGroup.Training.StoreManagement.Web.StorePages
{
    public partial class EditStore
    {

        private const string VgGrid = "vgGrid";


        #region Controls

        SgFieldSet fsMain;
        SgTextBox txtCode;
        SgTextBox txtName;
        SgGrid grdParts;
        SgHiddenField hiddenFieldPartIdSelection;
        SgEntityList elParts;

        #endregion

        #region Methods

        private void AddControls()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>()
                .RealizedIn(()=>fsMain)
                .OnRealized((o) => ((Control)o).ClientIDMode = ClientIDMode.Static);
            var layout = fieldSet.Add<DynamicFieldLayoutView>();

            var row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:Store_Code", true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtCode);
            row.SetRequiredValidator();


            row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:Store_Name", true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtName);
            row.SetRequiredValidator();

            AddPartGrid();
            //AddDialog();

        }

        private void AddPartGrid()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>()
                .OnRealized(fst => ((SgFieldSet)fst).ClientIDMode = ClientIDMode.Static);


            var grid = fieldSet.Add<GridView<PartStore>>()
                .ID("GridPartStores")
                .RealizedIn(() => grdParts)
                .OnRealized((o) =>
                {
                    ((Control)o).ClientIDMode = ClientIDMode.Predictable;
                })
                .AllowScroll(true)
                .AllowInsert(true)
                .AllowEdit(true)
                .AllowDelete(true)
                .GridType(SgGridType.ClientSide)
                .ValidationGroup(VgGrid)
                .DataSourceID(".PartStores")
                .OnCommand(grdPart_onCommand)
                ;

            

            grid.AddCommand("AddMultiple")
                .TextKey("Labels_AddMultipleParts")
                .ImageUrl("~/Training/StoreManagement/Icons/List.gif")
                ;

            var column = grid.Columns.AddSelector()
                .Property(ps => ps.PartTitle)
                .Required(true)
                .HeaderText("PartStore_PartTitle")
                .EditItemTemplate;

            column.Add<SelectorView>()
                .ComponentName("SystemGroup.Training.StoreManagement")
                .EntityView<Part>("AllParts")
                .CbSelectedID("{binding PartRef}")
                .OnClientSelectedIndexChanged("sltPart_onSelectIndexChanged")
                .OnClientItemsRequesting("sltPart_onItemRequesting")
                .OnItemsRequested(sltPart_onItemRequested)
                .Properties(factory =>
                {
                    factory.Add(nameof(Part.Title)).ClientSide();
                    factory.Add(nameof(Part.Code)).ClientSide();
                })
                .ID("sltPart")
                ;

            column.Add<RequiredFieldValidatorView>()
                .ControlToValidate("sltPart")
                .ValidationGroup(VgGrid)
                .ErrorMessageKey("Messages_SelectPart")
                ;

            grid.Columns.AddText()
                .PropertyName("PartCode")
                .HeaderText("PartStore_PartCode")
                .AllowEdit(false)
                ;

            var updHidden = GetMainPlaceHolder().Add<UpdatePanelView>();
            updHidden.Add<HiddenFieldView>()
                .ID("hiddenFieldPartIdSelection")
                .RealizedIn(() => hiddenFieldPartIdSelection)
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static)
                .ValueType(typeof(String));

            updHidden.Add<ButtonView>()
                .ID("btnPartSelection")
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static)
                .OnClick(btnPartSelection_onClick)
                .Style((s) => s.Display("none"));

        }

        private void  AddDialog()
        {
            GetMainPlaceHolder().Add<UpdatePanelView>()
                .ContentTemplate
                .Add<DialogLayoutView>()
                .ID("dlgPartSelection")
                
                .OnRealized(o =>
                {
                    ((Control)o).ClientIDMode = ClientIDMode.Static;
                    //((Control)o).Visible = false;
                })
                //.Add<DynamicFieldLayoutView>()

                
                //.AddRow()
                //.AddCell()
                //.Add<TextBoxView>()
                //.Text("Test");
            .Add<EntityListView>()
            //.ID("elParts")
            .AllowMultiRowSelection(true)
            .AllowGrouping(false)
            ////.Visible(false)
            .ComponentName("SystemGroup.Training.StoreManagement")
            .EntityView<Part>("AvailablePartForStore")
            
            .RealizedIn(()=>elParts)
            .OnRealized(o =>
            {
                
                ((Control)o).ClientIDMode = ClientIDMode.Static;
                elParts.ViewParameters.Add(new SgViewParameter
                {
                    Name = "igonreIDs",
                    Value = new long[] { 1 }
                });
            });


        }

        private void BindControls(SgDataSourceEditorBindingContext<Store> context)
        {
            context.BindProperty(store => store.Code).To(txtCode);
            context.BindProperty(store => store.Name).To(txtName);

        }

        #endregion
    }
}
