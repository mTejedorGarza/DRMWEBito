var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:405, Attribute:261270, Operation:Field, Event:None
$("#Detalle_Laboratorios_ClinicosGrid").on('change', '.Indicador', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Unidad' + rowIndex),EvaluaQuery("select Unidad_de_Medida from indicadores_laboratorio where Folio = FLD[Indicador]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Intervalo_de_referencia' + rowIndex),EvaluaQuery(" DECLARE @mybin1 int, @mybin2 int SET @mybin1 = (select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]) SET @mybin2 = (select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]) SELECT CAST(@mybin1 AS varchar(5)) + '-' + CAST(@mybin2 AS varchar(5))", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Intervalo_de_referencia" + rowIndex), ("true" == "true"));
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:405, Attribute:261270, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {


//BusinessRuleId:135, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Evento" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Actividad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Descripcion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_fin" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tiene_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_fin_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Ubicacion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tipo_de_Actividad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Quien_imparte" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Especialidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Duracion_maxima_por_Paciente_mins" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:135, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:135, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Evento" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Actividad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Descripcion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_fin" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tiene_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_fin_receso" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Ubicacion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tipo_de_Actividad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Quien_imparte" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Especialidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Duracion_maxima_por_Paciente_mins" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:135, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:134, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); $('.Hora_inicioHeader').css('display', 'none');
var index = $('.Hora_inicioHeader').index();
 eval($('.Hora_inicioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); $('.Hora_finHeader').css('display', 'none');
var index = $('.Hora_finHeader').index();
 eval($('.Hora_finHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); $('.Codigo_de_ReservacionHeader').css('display', 'none');
var index = $('.Codigo_de_ReservacionHeader').index();
 eval($('.Codigo_de_ReservacionHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:134, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:134, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); $('.Hora_inicioHeader').css('display', 'none');
var index = $('.Hora_inicioHeader').index();
 eval($('.Hora_inicioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); $('.Hora_finHeader').css('display', 'none');
var index = $('.Hora_finHeader').index();
 eval($('.Hora_finHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); $('.Codigo_de_ReservacionHeader').css('display', 'none');
var index = $('.Codigo_de_ReservacionHeader').index();
 eval($('.Codigo_de_ReservacionHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:134, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Horarios_Actividad(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Horarios_Actividad//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Horarios_Actividad(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Horarios_Actividad//
}
function EjecutarValidacionesAlEliminarMRDetalle_Horarios_Actividad(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Horarios_Actividad//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Horarios_Actividad(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Horarios_Actividad//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Horarios_Actividad(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Horarios_Actividad//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndex){ 
 var result= true; 
























//BusinessRuleId:403, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()<EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery(" select 'Bajo'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:403, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:403, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()<EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery(" select 'Bajo'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:403, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:402, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery(" select 'Alto'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:402, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:402, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery(" select 'Alto'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:402, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:401, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>=EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Resultado' + rowIndex).val()<=EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery("select 'Normal'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:401, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:401, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>=EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Resultado' + rowIndex).val()<=EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { AsignarValor($('#' + nameOfTable + 'Estatus_Indicador' + rowIndex),EvaluaQuery("select 'Normal'", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:401, Attribute:261276, Operation:Object, Event:BEFORESAVINGMR

//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Laboratorios_Clinicos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Laboratorios_Clinicos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Laboratorios_Clinicos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:NEWROWMR

//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Laboratorios_Clinicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:EDITROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:EDITROWMR

//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:404, Attribute:261276, Operation:Object, Event:EDITROWMR

//NEWBUSINESSRULE_EDITROWMR_Detalle_Laboratorios_Clinicos// 
 return result; 
} 
