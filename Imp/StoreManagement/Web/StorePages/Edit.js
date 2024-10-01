function sltPart_onSelectIndexChanged(sender, args) {
    var grid = $find("mainContainer_GridPartStores");
    var temp = grid.get_tempEntity();
    if (temp != null) {
        
        Sys.Observer.setValue(temp, "PartTitle", sender.getSelectedDataProperty("Title"));
        Sys.Observer.setValue(temp, "PartCode", sender.getSelectedDataProperty("Code"));
    }

}

function sltPart_onItemRequesting(sender, args) {
    var grid = $find("mainContainer_GridPartStores");
    var selectedItems = grid.get_dataSourceObject().get_entityList().map(function (ps) {
        return ps.PartRef;
    });

    var editIndex = grid.get_editIndex();


    if (editIndex > -1) {
        selectedItems.splice(editIndex, 1);
    }


    args.get_context()["IgnoreIDs"] = selectedItems;

}

function PartSelection_OnClientClose(sender, args) {
    var result = sender.get_returnValue();
    if (result != null) {
        var hiddenFieldPartIdSelection = $find("hiddenFieldPartIdSelection");
        hiddenFieldPartIdSelection.set_value(result);
        setTimeout("$get('btnPartSelection').click()", 1);
    }
}

function btnOK_ClientClick(ev) {
    SgCancelBrowserEvent(ev);
    var win = Sg.Window.getCurrent();
    win.close(ev);
}

function btnCancel_ClientClick(ev) {
    var win = Sg.Window.getCurrent();
    SgCancelBrowserEvent(ev);
    win.close(null);
}