var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:215, Attribute:260601, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Notificar_por_correo', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Notificar_por_correo' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_que_llevara_el_correo').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));} else { $('#divTexto_que_llevara_el_correo').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));}
});
//BusinessRuleId:216, Attribute:260601, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Notificacion_push', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Notificacion_push' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));} else { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));}
});
//BusinessRuleId:215, Attribute:260601, Operation:Field, Event:None



//BusinessRuleId:218, Attribute:260607, Operation:Field, Event:None
$("#Detalle_Frecuencia_NotificacionesGrid").on('change', '.Frecuencia', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Frecuencia' + rowIndex).val()==TryParseInt('1', '1') ) { $('.DiaHeader').css('display', 'none');
var index = $('.DiaHeader').index();
 eval($('.DiaHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); SetNotRequiredToControl( $('#' + nameOfTable + 'Dia' + rowIndex));} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Dia' + rowIndex)); $('.DiaHeader').css('display', 'block');}
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:218, Attribute:260607, Operation:Field, Event:None

















//BusinessRuleId:221, Attribute:260592, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Tipo_de_Notificacion', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divTipo_de_Accion').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'true'", rowIndex, nameOfTable)); $('#divTipo_de_Recordatorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('true' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
}} else {}
});

//BusinessRuleId:221, Attribute:260592, Operation:Field, Event:None

//BusinessRuleId:222, Attribute:260592, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Tipo_de_Notificacion', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divTipo_de_Recordatorio').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('false' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
} $('#divTipo_de_Accion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'false'", rowIndex, nameOfTable));} else {}
});

//BusinessRuleId:222, Attribute:260592, Operation:Field, Event:None

//BusinessRuleId:223, Attribute:260557, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Es_permanente', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Es_permanente' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); $('#divCantidad_de_dias_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));} else { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); $('#divFecha_fin').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
});

//BusinessRuleId:223, Attribute:260557, Operation:Field, Event:None













//BusinessRuleId:219, Attribute:260596, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Notificaciones").on('change', '#Tiene_fecha_de_finalizacion_definida', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida'  + ':checked').val()==TryParseInt('true', 'true') ) { $('#divFecha_fin').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); $('#divCantidad_de_dias_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex));} else { $('#divCantidad_de_dias_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
});

//BusinessRuleId:219, Attribute:260596, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
	
	if(operation == 'Update'){
if( $('#' + nameOfTable + 'Frecuencia' + rowIndex).val()==TryParseInt('1', '1') ) { $('.DiaHeader').css('display', 'none');
var index = $('.DiaHeader').index();
 eval($('.DiaHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); SetNotRequiredToControl( $('#' + nameOfTable + 'Dia' + rowIndex));} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Dia' + rowIndex)); $('.DiaHeader').css('display', 'block');}
	nameOfTable='';
	rowIndex='';


}

//219
if(operation == 'New'){
if( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida'  + ':checked').val()==TryParseInt('true', 'true') ) { $('#divFecha_fin').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); $('#divCantidad_de_dias_a_validar').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex));} 
else { $('#divCantidad_de_dias_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
$('#divFecha_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida'  + ':checked').val()==TryParseInt('true', 'true') ) { $('#divFecha_fin').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); $('#divCantidad_de_dias_a_validar').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex));} 
else { $('#divCantidad_de_dias_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
$('#divFecha_a_validar').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
}

//223
if(operation == 'New'){
if( $('#' + nameOfTable + 'Es_permanente' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); 
$('#divCantidad_de_dias_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
$('#divFecha_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));} 
else { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); 
$('#divFecha_fin').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Es_permanente' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); 
$('#divCantidad_de_dias_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); 
$('#divFecha_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); $('#divFecha_fin').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));} 
else { $('#divTiene_fecha_de_finalizacion_definida').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); 
$('#divFecha_fin').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Fecha_fin' + rowIndex));}
}

//222 2
if(operation == 'New'){
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divTipo_de_Recordatorio').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('false' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
} $('#divTipo_de_Accion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'false'", rowIndex, nameOfTable));} else {}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divTipo_de_Recordatorio').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('false' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
} $('#divTipo_de_Accion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'false'", rowIndex, nameOfTable));} else {}
}

//221
if(operation == 'New'){
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divTipo_de_Accion').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'true'", rowIndex, nameOfTable)); $('#divTipo_de_Recordatorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('true' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
}} else {}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Tipo_de_Notificacion' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divTipo_de_Accion').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Es_permanente' + rowIndex),EvaluaQuery("select 'true'", rowIndex, nameOfTable)); $('#divTipo_de_Recordatorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); if('true' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
}} else {}
}


//BusinessRuleId:217, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Notificar_por_correo' + ':checked').val()==TryParseInt('true', 'true') ) { 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); $('#divTexto_que_llevara_el_correo').css('display', 'block');} else {}

}
//BusinessRuleId:217, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Notificacion_push' + ':checked').val()==TryParseInt('true', 'true') ) { 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'block');} else {}


}
//215 
if(operation == 'New'){
if( $('#' + nameOfTable + 'Notificar_por_correo' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_que_llevara_el_correo').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));} else { $('#divTexto_que_llevara_el_correo').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Notificar_por_correo' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_que_llevara_el_correo').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));} else { $('#divTexto_que_llevara_el_correo').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex));}
}

//216
if(operation == 'New'){
if( $('#' + nameOfTable + 'Notificacion_push' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));} else { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));}
}
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Notificacion_push' + ':checked').val()==TryParseInt('true', 'true') ) { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'block'); 
SetRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));} else { $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'none'); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex));}
}
//BusinessRuleId:217, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:216, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divTexto_que_llevara_el_correo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_que_llevara_el_correo' + rowIndex)); $('#divTexto_a_mostrar_en_la_notificacion_Push').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_a_mostrar_en_la_notificacion_Push' + rowIndex)); $('#divTipo_de_Accion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Accion' + rowIndex)); $('#divTipo_de_Recordatorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Recordatorio' + rowIndex)); $('#divTiene_fecha_de_finalizacion_definida').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tiene_fecha_de_finalizacion_definida' + rowIndex)); $('#divCantidad_de_dias_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_dias_a_validar' + rowIndex)); $('#divFecha_a_validar').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_a_validar' + rowIndex)); if('true' == 'true')
{
	$('#divFrecuencia_Notificacion').css('display', 'none');
}
else
{
	$('#divFrecuencia_Notificacion').css('display', 'block');
} AsignarValor($('#' + nameOfTable + 'Fecha_inicio' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable));

}
//BusinessRuleId:216, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//

//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); 
DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); 


}
//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:213, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); 
DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); 


}
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Frecuencia_Notificaciones//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Frecuencia_Notificaciones//
}
function EjecutarValidacionesAlEliminarMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Frecuencia_Notificaciones//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Frecuencia_Notificaciones//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Frecuencia_Notificaciones//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Roles_de_Usuario_Notificacion// 
} 

function EjecutarValidacionesAlEliminarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Roles_de_Usuario_Notificacion// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRRoles_para_Notificar(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Roles_para_Notificar// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRRoles_para_Notificar(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Roles_para_Notificar// 
} 

function EjecutarValidacionesAlEliminarMRRoles_para_Notificar(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Roles_para_Notificar// 
 return result; 
} 

function EjecutarValidacionesNewRowMRRoles_para_Notificar(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Roles_para_Notificar// 
  return result; 
} 

function EjecutarValidacionesEditRowMRRoles_para_Notificar(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Roles_para_Notificar// 
 return result; 
} 
