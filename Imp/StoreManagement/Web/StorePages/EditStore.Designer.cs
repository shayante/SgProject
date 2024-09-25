﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Views;

namespace SystemGroup.Training.StoreManagement.Web.StorePages
{
    public partial class EditStore
    {

        private const string VgGrid = "vgGrid";


        #region Controls

        SgTextBox txtCode;
        SgTextBox txtName;

        #endregion

        #region Methods

        private void AddControls()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>()
                .OnRealized((o) =>
                {
                    ((Control)o).ClientIDMode = ClientIDMode.Static;
                });
            var layout = fieldSet.Add<DynamicFieldLayoutView>();

            var row = layout.AddRow();
            row.SetLabelByKey("Store_Code".GetKey(), true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtCode);
            row.SetRequiredValidator();


            row = layout.AddRow();
            row.SetLabelByKey("Store_Name".GetKey(), true);
            row.SetInput<TextBoxView>().RealizedIn(() => txtName);
            row.SetRequiredValidator();

            AddPartGrid();

        }

        private void AddPartGrid()
        {
            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>()
                .OnRealized(fst => ((SgFieldSet)fst).ClientIDMode = ClientIDMode.Static);


            var grid = fieldSet.Add<GridView<PartStore>>()
                .ID("GridPartStores")
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
                ;

            grid.Columns.AddText()
                .PropertyName("PartCode")
                .HeaderText("PartStore_PartCode")
                .AllowEdit(false)
                ;

        }

        private void BindControls(SgDataSourceEditorBindingContext<Store> context)
        {
            context.BindProperty(store => store.Code).To(txtCode);
            context.BindProperty(store => store.Name).To(txtName);

        }

        #endregion
    }
}
