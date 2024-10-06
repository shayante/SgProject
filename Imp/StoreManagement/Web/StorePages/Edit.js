function sltPart_onSelectIndexChanged(sender, args) {
    const grid = $find("mainContainer_GridPartStores");
    const temp = grid.get_tempEntity();
    if (temp) {
        
        Sys.Observer.setValue(temp, "PartTitle", sender.getSelectedDataProperty("Title"));
        Sys.Observer.setValue(temp, "PartCode", sender.getSelectedDataProperty("Code"));
    }

}

function sltPart_onItemRequesting(sender, args) {
    const grid = $find("mainContainer_GridPartStores");
    const selectedItems = grid.get_dataSourceObject().get_entityList().map(ps => ps.PartRef);

    const editIndex = grid.get_editIndex();


    if (editIndex > -1) {
        selectedItems.splice(editIndex, 1);
    }


    args.get_context()["IgnoreIDs"] = selectedItems;

}

function PartSelection_OnClientClose(sender, args) {
    const result = sender.get_returnValue();
    if (result) {
        const hiddenFieldPartIdSelection = $find("hiddenFieldPartIdSelection");
        hiddenFieldPartIdSelection.set_value(result);
        setTimeout("$get('btnPartSelection').click()", 1);
    }
}

function btnOK_ClientClick(ev) {
    SgCancelBrowserEvent(ev);
    Sg.Window.getCurrent().close(ev);
}

function btnCancel_ClientClick(ev) {
    SgCancelBrowserEvent(ev);
    Sg.Window.getCurrent().close(null);
}