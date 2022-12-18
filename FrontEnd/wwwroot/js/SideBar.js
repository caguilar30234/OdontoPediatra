function openSideBar() {
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementById("mainContent").style.marginLeft = "250px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
}

function closeSideBar() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("mainContent").style.marginLeft = "0";
    document.body.style.backgroundColor = "white";
}

function EnableDisableTextBox(TipoID) {
    var selectedValue = TipoID.options[TipoID.selectedIndex].value;
    var Identificacion = document.getElementById("Identificacion");
    Identificacion.disabled = selectedValue > 0 ? false : true;
    if (!Identificacion.disabled) {
        Identificacion.focus();
    }
}