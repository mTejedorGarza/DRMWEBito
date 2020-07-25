var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {






//BusinessRuleId:248, Attribute:260950, Operation:Field, Event:None
$("form#CreateSolicitud_de_Pago_de_Facturas").on('change', '#Fecha_fin_del_periodo_facturado', function () {
	nameOfTable='';
	rowIndex='';
if( EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_periodo_facturado]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" declare @Fechafin nvarchar(10) = 'FLD[Fecha_fin_del_periodo_facturado]'"
+" declare @FechaNuevafin nvarchar(10)"
+" set @FechaNuevafin = substring(@Fechafin,4,2) + '/' + left(@fechafin,2) + '/' + right(@fechafin,4)"
+" "
+" SELECT DATEDIFF(Day, @FechaNueva, @FechaNuevafin)",rowIndex, nameOfTable)<=TryParseInt('0', '0') ) { alert(DecodifyText('La fecha fin tiene que ser mayor a fecha inicio.', rowIndex, nameOfTable));} else {}
});

//BusinessRuleId:248, Attribute:260950, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:247, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(""
+" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:247, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:247, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(""
+" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:247, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:284, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_autorizacion' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_autoriza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_autoriza" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_programacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_programacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_programacion' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_programacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_programa' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_programa" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_actualizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_actualizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_actualizacion' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_actualizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_actualiza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_actualiza" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:284, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:284, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_autorizacion' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_autoriza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_autoriza" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_programacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_programacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_programacion' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_programacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_programa' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_programa" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_actualizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_actualizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_actualizacion' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_actualizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_actualiza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_actualiza" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:284, Attribute:0, Operation:Object, Event:SCREENOPENING



























































































//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:376, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:377, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:378, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:379, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:380, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:381, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:382, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:383, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:384, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:385, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:386, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:388, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:390, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:392, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:394, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_inicio_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_XML' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_PDF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Recibo_de_Solicitud_de_Pago' + rowIndex));

}
//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_inicio_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_XML' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_PDF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Recibo_de_Solicitud_de_Pago' + rowIndex));

}
//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_inicio_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_del_periodo_facturado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_XML' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_PDF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Recibo_de_Solicitud_de_Pago' + rowIndex));

}
//BusinessRuleId:283, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//BusinessRuleId:249, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'New'){
if( EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_periodo_facturado]' declare @FechaNueva nvarchar(10) set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) declare @Fechafin nvarchar(10) = 'FLD[Fecha_fin_del_periodo_facturado]' declare @FechaNuevafin nvarchar(10) set @FechaNuevafin = substring(@Fechafin,4,2) + '/' + left(@fechafin,2) + '/' + right(@fechafin,4) SELECT DATEDIFF(Day, @FechaNueva, @FechaNuevafin)",rowIndex, nameOfTable)<=TryParseInt('0', '0') ) { alert(DecodifyText('La fecha fin tiene que ser mayor a fecha inicio.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:249, Attribute:2, Operation:Object, Event:BEFORESAVING

//BusinessRuleId:249, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'Update'){
if( EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_periodo_facturado]' declare @FechaNueva nvarchar(10) set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) declare @Fechafin nvarchar(10) = 'FLD[Fecha_fin_del_periodo_facturado]' declare @FechaNuevafin nvarchar(10) set @FechaNuevafin = substring(@Fechafin,4,2) + '/' + left(@fechafin,2) + '/' + right(@fechafin,4) SELECT DATEDIFF(Day, @FechaNueva, @FechaNuevafin)",rowIndex, nameOfTable)<=TryParseInt('0', '0') ) { alert(DecodifyText('La fecha fin tiene que ser mayor a fecha inicio.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:249, Attribute:2, Operation:Object, Event:BEFORESAVING

//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}


