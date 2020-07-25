var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
	
	
	
//Validar Email
	$('#Email').change(function(){ 
		let email = $('#Email').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
		} 
	});

//Validar celular
$( "#Celular" ).blur(function(){
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Celular' + rowIndex).val()>TryParseInt('999999999', '999999999') && $('#' + nameOfTable + 'Celular' + rowIndex).val()<TryParseInt('9999999999', '9999999999') ) 
{ } else {$('#' + nameOfTable + 'Celular' + rowIndex).attr("placeholder", "Celular inválido.").val("").focus().blur();}
});

//Validar CLABE
$( "#CLABE_Interbancaria" ).blur(function(){
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex).val()>TryParseInt('99999999999999999', '99999999999999999') && 
$('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex).val()<TryParseInt('999999999999999999', '999999999999999999') ) 
{ } else {$('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex).attr("placeholder", "CLABE inválida.").val("").focus().blur();}
});

//BusinessRuleId:171, Attribute:260059, Operation:Field, Event:None

//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None
$('#Nombres').change(function() {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None

//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None
$('#Apellido_Paterno').change(function() {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None

//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None
$('#Apellido_Materno').change(function(){
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
	if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));
}
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));
}
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Codigos_de_Referencia_Vendedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Facturacion_Vendedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Facturacion_Vendedores//
    return result;
}

