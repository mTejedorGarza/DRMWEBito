var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRMR_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_MR_Padecimientos//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRMR_Padecimientos(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_MR_Padecimientos//
}
function EjecutarValidacionesAlEliminarMRMR_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_MR_Padecimientos//
    return result;
}
function EjecutarValidacionesNewRowMRMR_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_MR_Padecimientos//
    return result;
}
function EjecutarValidacionesEditRowMRMR_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_MR_Padecimientos//
    return result;
}

