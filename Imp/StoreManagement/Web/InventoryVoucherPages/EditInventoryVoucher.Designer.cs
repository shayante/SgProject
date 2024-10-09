﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using SystemGroup.Framework.Security;
using SystemGroup.Training.StoreManagement.Common;
using SystemGroup.Web.UI.Bindings;
using SystemGroup.Web.UI.Controls;
using SystemGroup.Web.UI.Views;

namespace SystemGroup.Training.StoreManagement.Web.InventoryVoucherPages
{
    public partial class EditInventoryVoucher
    {

        private const string vgGrid = "vgGrid";

        private SgNumberingTextBox nrgNumber;
        private SgSelector sltStore;
        private SgDatePicker dpDate;
        private SgLookup lkpType;
        private SgSelector sltStoreKeeper;
        private SgTextBox txtItemCount;
        private SgTextBox txtQuantitySum;

        private void AddControls()
        {

            var layout = GetMainPlaceHolder()
                .Add<FieldSetView>().LegendKey("Labels_InventoryInfo")
                .Add<DynamicFieldLayoutView>();

            var row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:InventoryVoucher_Number");
            row.SetInput<NumberingTextBoxView>()
                .RealizedIn(() => nrgNumber)
                .EntityType(typeof(InventoryVoucher));

            row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:InventoryVoucher_StoreRef", true);
            row.SetInput<SelectorView>()
                .ID("sltStore")
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static)
                .ComponentName("SystemGroup.Training.StoreManagement")
                .EntityView<Store>("AllStores")
                .OnClientSelectedIndexChanged("sltStore_onSelectedIndexChanged")
                .RealizedIn(() => sltStore);
            row.SetRequiredValidator();

            row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:InventoryVoucher_StoreKeeperRef", true);
            row.SetInput<SelectorView>()
                .ComponentName("SystemGroup.Training.StoreManagement")
                .EntityView<StoreKeeper>("AllStoreKeepers")
                .RealizedIn(() => sltStoreKeeper);
            row.SetRequiredValidator();

            row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:InventoryVoucher_Date", true);
            row.SetInput<DatePickerView>().RealizedIn(() => dpDate);
            row.SetRequiredValidator();

            row = layout.AddRow();
            row.SetLabelByKey("Training.StoreManagement:InventoryVoucher_Type", true);
            row.SetInput<LookupView>().RealizedIn(() => lkpType).LookupType("InventoryVoucherType");
            row.SetRequiredValidator();

            AddItemsGrid();
        }

        private void AddItemsGrid()
        {

            var fieldSet = GetMainPlaceHolder().Add<FieldSetView>().LegendKey("Labels_ItemGrid");
            var grid = fieldSet.Add<GridView<InventoryVoucherItem>>()
                .AllowDelete(true)
                .AllowEdit(true)
                .AllowInsert(true)
                .AllowScroll(true)
                .ValidationGroup(vgGrid)
                .DataSourceID(".InventoryVoucherItems")
                .GridType(SgGridType.ClientSide)
                .ID("grdInventoryVoucherItem")
                .OnRealized((o) => ((Control)o).ClientIDMode = ClientIDMode.Predictable);

            var columnEditor = grid.Columns.AddSelector()
                .HeaderText("InventoryVoucherItem_PartTitle")
                .PropertyName("PartTitle")
                .Required(true)
                .EditItemTemplate;

            columnEditor.Add<SelectorView>()
                .ComponentName("SystemGroup.Training.StoreManagement")
                .EntityView<Part>("PartInventoryByStore")
                .CbSelectedID("{binding PartRef}")
                .ID("sltPart")
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static)
                .OnClientSelectedIndexChanged("sltPart_onSelectedIndexChanged")
                .OnClientItemsRequesting("sltPart_ontItemsRequesting")
                .OnItemsRequested(sltPart_OnItemsRequested)
                .Properties(factory =>
                {
                    factory.Add(nameof(Part.Title)).ClientSide();
                    factory.Add(nameof(Part.Code)).ClientSide();
                    factory.Add("Unit").ClientSide();
                })
                .ViewParameter("storeRef")
                ;

            columnEditor.Add<RequiredFieldValidatorView>()
                .ControlToValidate("sltPart")
                .ValidationGroup(vgGrid)
                .ErrorMessageKey("Messages_SelectPart")
                ;

            grid.Columns.AddText()
                .HeaderText("InventoryVoucherItem_PartCode")
                .PropertyName("PartCode")
                .AllowEdit(false)
                ;


            grid.Columns.AddText()
                .HeaderText("InventoryVoucherItem_UnitTitle")
                .PropertyName("UnitTitle")
                .AllowEdit(false)
                ;

            columnEditor = grid.Columns.AddDecimal()
                .HeaderText("InventoryVoucherItem_Quantity")
                .Property(iv => iv.Quantity)
                .GroupSize(3)
                .EditItemTemplate;

            columnEditor.Add<DecimalInputView>()
                .GroupSize(3)
                .Precision(3)
                .ID("decQuntity")
                //.OnClientValueChanged("decQuntity_onValueChanged")
                .CbValue("{binding Quantity}");

            columnEditor.Add<RangeValidatorView>()
                .MinimumValue("1")
                .MaximumValue("9999999")
                .ErrorMessageKey("Messages_QuntityIsOutOfRange")
                .ControlToValidate("decQuntity")
                .ValidationGroup(vgGrid)
                ;



            var layout = fieldSet
                .Add<FieldSetView>()
                .Add<DynamicFieldLayoutView>();
            var row = layout.AddRow();
            row.SetLabelByKey("Labels_ItemsCount");
            row.SetInput<TextBoxView>()
                .Enabled(false)
                .ID("txtItemsCount")
                .RealizedIn(() => txtItemCount)
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static);

            row = layout.AddRow();
            row.SetLabelByKey("Labels_QuantitesSum");
            row.SetInput<TextBoxView>()
                .Enabled(false)
                .ID("txtQuantitesSum")
                .RealizedIn(() => txtQuantitySum)
                .OnRealized(o => ((Control)o).ClientIDMode = ClientIDMode.Static);

        }

        private void BindControls(SgDataSourceEditorBindingContext<InventoryVoucher> context)
        {

            context.BindProperty(iv => iv.Number).To(nrgNumber);
            context.BindValueTypeProperty(iv => iv.StoreRef).To(sltStore);
            context.BindValueTypeProperty(iv => iv.Date).To(dpDate);
            context.BindValueTypeProperty(iv => iv.Type).To(lkpType);
            context.BindValueTypeProperty(iv => iv.StoreKeeperRef).To(sltStoreKeeper);

        }

    }
}
