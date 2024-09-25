function sltPart_onSelectIndexChanged(sender, args) {
    var grid = $find("mainContainer_GridPartStores");
    var temp = grid.get_tempEntity();
    if (temp != null) {
        
        Sys.Observer.setValue(temp, "PartTitle", sender.getSelectedDataProperty("Title"));
        Sys.Observer.setValue(temp, "PartCode", sender.getSelectedDataProperty("Code"));
    }

}

function sltPart_onItemRequesting(sender, args) {

}