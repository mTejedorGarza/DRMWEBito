var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {








//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_Registrado' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_Registrado" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Rol' + rowIndex),EvaluaQuery("select Description from Spartan_User_Role where User_Role_Id = GLOBAL[USERROLEID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Rol" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_Registrado' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_Registrado" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Rol' + rowIndex),EvaluaQuery("select Description from Spartan_User_Role where User_Role_Id = GLOBAL[USERROLEID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Rol" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;












//BusinessRuleId:227, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'New'){
if( $('#' + nameOfTable + 'Permite_notificaciones_por_email' + rowIndex).val()==EvaluaQuery("select 'false'",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Permite_notificaciones_push' + rowIndex).val()==EvaluaQuery("select 'false'",rowIndex, nameOfTable) ) { alert(DecodifyText('Debes seleccionar al menos una forma de notificación.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:227, Attribute:2, Operation:Object, Event:BEFORESAVING

//BusinessRuleId:227, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Permite_notificaciones_por_email' + rowIndex).val()==EvaluaQuery("select 'false'",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Permite_notificaciones_push' + rowIndex).val()==EvaluaQuery("select 'false'",rowIndex, nameOfTable) ) { alert(DecodifyText('Debes seleccionar al menos una forma de notificación.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:227, Attribute:2, Operation:Object, Event:BEFORESAVING

//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Notificaciones_Paciente//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Notificaciones_Paciente//
}
function EjecutarValidacionesAlEliminarMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Notificaciones_Paciente//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Notificaciones_Paciente//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Notificaciones_Paciente//
    return result;
}

