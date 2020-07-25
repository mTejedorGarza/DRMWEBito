var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
	
//Validar RFC
 $( "#RFC" ).blur(function() { 
	var v = $('#' + nameOfTable + 'RFC' + rowIndex).val(); 
	if (v != ""){ 
		var valid = '^(([A-Z]|[a-z]){3})([0-9]{6})((([A-Z]|[a-z]|[0-9]){3}))'; 
		var validRfc=new RegExp(valid); 
		var matchArray=v.match(validRfc); 
		if (matchArray==null || v.length>12) { 
			$('#' + nameOfTable + 'RFC' + rowIndex).attr("placeholder", "El formato del RFC es incorrecto.").val("").focus().blur(); 
			return false; 
		} 
  }
});
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




//BusinessRuleId:171, Attribute:260059, Operation:Field, Event:None
$( "#C_P__Fiscal" ).blur(function(){
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'C_P__Fiscal' + rowIndex).val()>TryParseInt('9999', '9999') && $('#' + nameOfTable + 'C_P__Fiscal' + rowIndex).val()<TryParseInt('99999', '99999') ) 
{ } else {$('#' + nameOfTable + 'C_P__Fiscal' + rowIndex).attr("placeholder", "Código Postal inválido.").val("").focus().blur();}
});

//BusinessRuleId:171, Attribute:260059, Operation:Field, Event:None

//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None
$("form#CreateProveedores").on('keyup', '#Nombres', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None

//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None
$("form#CreateProveedores").on('keyup', '#Apellido_Paterno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery(" select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None

//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None
$("form#CreateProveedores").on('keyup', '#Apellido_Materno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:172, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:172, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:172, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:172, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:173, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Nombres' + rowIndex),EvaluaQuery("select '‎‎‎ ‎'‎", rowIndex, nameOfTable)); 
 AsignarValor($('#' + nameOfTable + 'Apellido_Paterno' + rowIndex),EvaluaQuery("select '‎‎‎ ‎'‎", rowIndex, nameOfTable)); 
 AsignarValor($('#' + nameOfTable + 'Apellido_Materno' + rowIndex),EvaluaQuery("select '‎‎‎ ‎'‎", rowIndex, nameOfTable));

}
//BusinessRuleId:173, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Sucursales_Proveedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}

