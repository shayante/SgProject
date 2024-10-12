function sltPart_onSelectedIndexChanged(sender, _args) {
    const grid = $find("mainContainer_grdInventoryVoucherItem");
    const temp = grid.get_tempEntity();
    if (temp) {

        Sys.Observer.setValue(temp, "PartTitle", sender.getSelectedDataProperty("Title"));
        Sys.Observer.setValue(temp, "PartCode", sender.getSelectedDataProperty("Code"));
        Sys.Observer.setValue(temp, "UnitTitle", sender.getSelectedDataProperty("Unit"));
    }
}

function sltPart_ontItemsRequesting(_sender, args) {
    const grid = $find("mainContainer_grdInventoryVoucherItem");
    const selectedItems = grid.get_dataSourceObject().get_entityList().map(iv => iv.PartRef);

    const editIndex = grid.get_editIndex();


    if (editIndex > -1) {
        selectedItems.splice(editIndex, 1);
    }


    args.get_context()["IgnoreIDs"] = selectedItems;

    args.get_context()["storeRef"] = $find("sltStore").get_selectedID();
}

function sltStore_onSelectedIndexChanged(_sender, _args) {
    sltPart = $find("sltPart");
    sltPart.clearCache();
    sltPart.clearItems();
    sltPart.clearSelection();
}

function ds_onInsertedEntity(sender, _args) {
    $find("sltStore").disable();
    updateItemSum(sender.get_entityList());

}


function ds_onRemovedEntity(sender, _args) {
    const list = sender.get_entityList();

    if (list.length == 0) {
        $find("sltStore").enable();
    }

    updateItemSum(list);
}

function ds_onUpdatedEntity(sender, _args) {
    updateItemSum(sender.get_entityList());
}

function updateItemSum(list) {

    $find("txtItemsCount").set_textBoxValue(list.length);
    $find("txtQuantitesSum").set_textBoxValue(list.map(i => i.Quantity).reduce((acc, item) => SgMath.add(acc,item), "0"));//TODO use sgMath
}

function decQuntity_ValidationFunction(sender, args) {

    args.IsValid = args.Value.length > 0 && SgMath.compare(args.Value, 0) > 0
}