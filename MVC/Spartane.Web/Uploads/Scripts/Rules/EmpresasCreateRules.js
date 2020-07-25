var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {




//Validar CP
$( "#CP_Fiscal" ).blur(function(){
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex).val()>TryParseInt('9999', '9999') && $('#' + nameOfTable + 'CP_Fiscal' + rowIndex).val()<TryParseInt('99999', '99999') ) 
{ } else {$('#' + nameOfTable + 'CP_Fiscal' + rowIndex).attr("placeholder", "Código Postal inválido.").val("").focus().blur();}
});


//BusinessRuleId:139, Attribute:258954, Operation:Field, Event:None
$("form#CreateEmpresas").on('change', '#Tipo_de_Empresa', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Empresa' + rowIndex).val()==TryParseInt('2', '2') || $('#' + nameOfTable + 'Tipo_de_Empresa' + rowIndex).val()==TryParseInt('3', '3') ) 
{ $("a[href='#tabSuscripcion']").css('display', 'block'); $("a[href='#tabDocumentacion']").css('display', 'block');} 
else { $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none');}
});

//BusinessRuleId:139, Attribute:258954, Operation:Field, Event:None











//BusinessRuleId:187, Attribute:258482, Operation:Field, Event:None
$("#Detalle_Suscripciones_EmpresaGrid").on('blur', '.Fecha_de_inicio', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Fecha_Fin' + rowIndex),EvaluaQuery(" declare @fecha2 date"
+" declare @duracion int"
+" declare @fecha3 nvarchar(10)"
+" declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion])"
+" set @fecha3 = (select convert(varchar, @fecha2, 105))"
+" select @fecha3", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_Fin" + rowIndex), ("true" == "true"));
	nameOfTable='';
	rowIndex='';
});
$("form#CreateDetalle_Suscripciones_Empresa").on('blur', '#Detalle_Suscripciones_EmpresaFecha_de_inicio', function () {
	nameOfTable='Detalle_Suscripciones_Empresa';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Fecha_Fin' + rowIndex),EvaluaQuery(" declare @fecha2 date"
+" declare @duracion int"
+" declare @fecha3 nvarchar(10)"
+" declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion])"
+" set @fecha3 = (select convert(varchar, @fecha2, 105))"
+" select @fecha3", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_Fin" + rowIndex), ("true" == "true"));
});
//BusinessRuleId:187, Attribute:258482, Operation:Field, Event:None







//BusinessRuleId:190, Attribute:258481, Operation:Field, Event:None
$("#Detalle_Suscripciones_EmpresaGrid").on('change', '.Suscripcion', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Fecha_Fin' + rowIndex),EvaluaQuery(" declare @fecha2 date declare @duracion int declare @fecha3 nvarchar(10) declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]' declare @FechaNueva nvarchar(10) set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion]) set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion]) set @fecha3 = (select convert(varchar, @fecha2, 105)) select @fecha3", rowIndex, nameOfTable));
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:190, Attribute:258481, Operation:Field, Event:None





//BusinessRuleId:189, Attribute:258481, Operation:Field, Event:None
$("#Detalle_Suscripciones_EmpresaGrid").on('change', '.Suscripcion', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Fecha_de_inicio' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1); AsignarValor($('#' + nameOfTable + 'Nombre_de_la_Suscripcion' + rowIndex),EvaluaQuery(" declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" declare @Fechainicio nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNuevainicio nvarchar(10)"
+" set @FechaNuevainicio = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" declare @fecha2 date"
+" declare @fecha3 nvarchar(10)"
+" declare @fechafin nvarchar(10)"
+" declare @duracion int"
+" DECLARE @suscripciontxt varchar(50)"
+" DECLARE @suscripcion varchar(100)"
+" declare @preciofinal decimal(10,2)"
+" declare @susID int"
+" "
+" set @susID = (select Folio from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @preciofinal = (select Precio_Final from Planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" SET @suscripciontxt = (select nombre_del_plan from planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion])"
+" set @fecha3 = (select convert(varchar, @fecha2, 105))"
+" set @fechafin = substring(@Fecha3,4,2) + '/' + left(@fecha3,2) + '/' + right(@fecha3,4)"
+" set @suscripcion = (select 'Suscripción' + ' ' + @suscripciontxt + ' ' + 'vigencia hasta' + ' ' + 'FLD[Fecha_Fin]'  + '.')"
+" select @suscripcion", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Nombre_de_la_Suscripcion" + rowIndex), ("true" == "true"));
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:189, Attribute:258481, Operation:Field, Event:None

//BusinessRuleId:188, Attribute:258482, Operation:Field, Event:None
$("#Detalle_Suscripciones_EmpresaGrid").on('change', '.Fecha_de_inicio', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Nombre_de_la_Suscripcion' + rowIndex),EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" declare @Fechainicio nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNuevainicio nvarchar(10)"
+" set @FechaNuevainicio = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" declare @fecha2 date"
+" declare @fecha3 nvarchar(10)"
+" declare @fechafin nvarchar(10)"
+" declare @duracion int"
+" DECLARE @suscripciontxt varchar(50)"
+" DECLARE @suscripcion varchar(100)"
+" declare @preciofinal decimal(10,2)"
+" declare @susID int"
+" "
+" set @susID = (select Folio from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @preciofinal = (select Precio_Final from Planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" SET @suscripciontxt = (select nombre_del_plan from planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion])"
+" set @fecha3 = (select convert(varchar, @fecha2, 105))"
+" set @fechafin = substring(@Fecha3,4,2) + '/' + left(@fecha3,2) + '/' + right(@fecha3,4)"
+" set @suscripcion = (select 'Suscripción' + ' ' + @suscripciontxt + ' ' + 'vigencia hasta' + ' ' + 'FLD[Fecha_Fin]' + '.')"
+" select @suscripcion", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Nombre_de_la_Suscripcion" + rowIndex), ("true" == "true"));
	nameOfTable='';
	rowIndex='';
});
$("form#CreateDetalle_Suscripciones_Empresa").on('change', '#Detalle_Suscripciones_EmpresaFecha_de_inicio', function () {
	nameOfTable='Detalle_Suscripciones_Empresa';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_de_la_Suscripcion' + rowIndex),EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" declare @Fechainicio nvarchar(10) = 'FLD[Fecha_de_inicio]'"
+" declare @FechaNuevainicio nvarchar(10)"
+" set @FechaNuevainicio = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" declare @fecha2 date"
+" declare @fecha3 nvarchar(10)"
+" declare @fechafin nvarchar(10)"
+" declare @duracion int"
+" DECLARE @suscripciontxt varchar(50)"
+" DECLARE @suscripcion varchar(100)"
+" declare @preciofinal decimal(10,2)"
+" declare @susID int"
+" "
+" set @susID = (select Folio from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @preciofinal = (select Precio_Final from Planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" SET @suscripciontxt = (select nombre_del_plan from planes_de_suscripcion where Folio = FLD[Suscripcion])"
+" set @duracion = (select Duracion from Planes_de_Suscripcion where Folio = FLD[Suscripcion])"
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva) from Planes_de_suscripcion where folio = FLD[Suscripcion])"
+" set @fecha3 = (select convert(varchar, @fecha2, 105))"
+" set @fechafin = substring(@Fecha3,4,2) + '/' + left(@fecha3,2) + '/' + right(@fecha3,4)"
+" set @suscripcion = (select 'Suscripción' + ' ' + @suscripciontxt + ' ' + 'vigencia hasta' + ' ' + 'FLD[Fecha_Fin]' + '.')"
+" select @suscripcion", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Nombre_de_la_Suscripcion" + rowIndex), ("true" == "true"));
});
//BusinessRuleId:188, Attribute:258482, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]"
+" "
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]"
+" "
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING



//NO PERMITIR MÁS DE 5 DIGITOS EN CP
$("form#CreateEmpresas").on('keyup', '#CP', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CP' + rowIndex).val()<=TryParseInt('99999', '99999') ) {} else { $('#CP').attr("placeholder", "No se permiten más de 5 dígitos.").val("").focus().blur();}
});



//VALIDAR CORREO
	$('#Email').change(function(){ 
		let email = $('#Email').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
		} 
	});

//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex));

}
//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex));

}
//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); $("a[href='#tabDatos Fiscales']").css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex));

}
//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); $("a[href='#tabDatos Fiscales']").css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex));

}
//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:138, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);

}
//BusinessRuleId:138, Attribute:0, Operation:Object, Event:SCREENOPENING


//BusinessRuleId:194, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:194, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 CreateSessionVar('VariableContrasena', EvaluaQuery(" declare @valor nvarchar(5) set @valor= lower(left(replace(newid(),'-',''),5)) select @valor", rowIndex, nameOfTable));

}
//BusinessRuleId:194, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:194, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 CreateSessionVar('VariableContrasena', EvaluaQuery(" declare @valor nvarchar(5) set @valor= lower(left(replace(newid(),'-',''),5)) select @valor", rowIndex, nameOfTable));

}
//BusinessRuleId:194, Attribute:0, Operation:Object, Event:SCREENOPENING









//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
        nameOfTable = '';
        rowIndex = '';
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){




//BusinessRuleId:212, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
	const date = Date.now();
  let currentDate = null;
  do {
    currentDate = Date.now();
  } while (currentDate - date < 2000);
 EvaluaQuery("exec InsertSpartanEmpresas GLOBAL[KeyValueInserted], 'GLOBAL[VariableContrasena]', FLD[Tipo_de_Empresa]", rowIndex, nameOfTable);

}
//BusinessRuleId:212, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}



function EjecutarValidacionesAntesDeGuardarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 












//BusinessRuleId:174, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){

}
//BusinessRuleId:174, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:174, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){

}
//BusinessRuleId:174, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( EvaluaQuery("select COUNT(Email) from Spartan_User where Email = 'FLD[Correo]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { alert(DecodifyText('El correo ingresado ya está registrado en el sistema.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( EvaluaQuery("select COUNT(Email) from Spartan_User where Email = 'FLD[Correo]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { alert(DecodifyText('El correo ingresado ya está registrado en el sistema.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Contactos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),2);

}
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR

//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),2);

}
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR

//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Folio_Usuario' + rowIndex)); $('.Folio_UsuarioHeader').css('display', 'none');
var index = $('.Folio_UsuarioHeader').index();
 eval($('.Folio_UsuarioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:NEWROWMR

//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Folio_Usuario' + rowIndex)); $('.Folio_UsuarioHeader').css('display', 'none');
var index = $('.Folio_UsuarioHeader').index();
 eval($('.Folio_UsuarioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Contactos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:EDITROWMR
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Folio_Usuario' + rowIndex)); $('.Folio_UsuarioHeader').css('display', 'none');
var index = $('.Folio_UsuarioHeader').index();
 eval($('.Folio_UsuarioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:EDITROWMR

//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Folio_Usuario' + rowIndex)); $('.Folio_UsuarioHeader').css('display', 'none');
var index = $('.Folio_UsuarioHeader').index();
 eval($('.Folio_UsuarioHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:211, Attribute:258519, Operation:Object, Event:EDITROWMR

//NEWBUSINESSRULE_EDITROWMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 




//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 

//BusinessRuleId:192, Attribute:258520, Operation:Object, Event:AFTERSAVINGMR










//BusinessRuleId:406, Attribute:258520, Operation:Object, Event:AFTERSAVINGMR
if(operation == 'New'){
	debugger;
 fillMRFromQuery('Detalle_Pagos_Empresa', "declare @tblMR table(Folio int, Folio_Empresas int, Suscripcion int, Concepto_de_Pago nvarchar(50), Fecha_de_Suscripcion datetime, Numero_de_Pago int, De_Total_de_Pagos int,Fecha_Limite_de_Pago datetime,Recordatorio_dias int,Forma_de_Pago int, Fecha_de_Pago datetime,Estatus int)"
+" "
+" DECLARE @NumeroPago INT"
+" SET @NumeroPago = 1"
+" declare @FRecuencia int, @contador int"
+" set  @frecuencia=12 "
+" set @contador=1"
+" "
+" while (@contador<=@frecuencia)"
+" begin"
+"     insert into @tblMR(Folio, Folio_Empresas, Suscripcion, Concepto_de_Pago, Fecha_de_Suscripcion, Numero_de_Pago, De_Total_de_Pagos,Fecha_Limite_de_Pago,Recordatorio_dias,Forma_de_Pago, Fecha_de_Pago,Estatus)"
+"     select NULL as Folio, NULL as Folio_Empresas, 1 as Suscripcion, 'Concepto de pago' as Concepto_de_Pago, GETDATE() as Fecha_de_Suscripcion, @NumeroPago as Numero_de_Pago, 12 as De_Total_de_Pagos, NULL as Fecha_Limite_de_Pago, NULL as Recordatorio_dias, NULL as Forma_de_Pago, NULL as Fecha_de_Pago, NULL as Estatus"
+" "
+" "
+"     set @contador = @contador + 1"
+" 	SET @NumeroPago = @NumeroPago + 1"
+" end"
+" "
+" select * from @tblMR ");

}
//BusinessRuleId:406, Attribute:258520, Operation:Object, Event:AFTERSAVINGMR

//BusinessRuleId:406, Attribute:258520, Operation:Object, Event:AFTERSAVINGMR
if(operation == 'Update'){
 fillMRFromQuery('Detalle_Pagos_Empresa', "declare @tblMR table(Folio int, Folio_Empresas int, Suscripcion int, Concepto_de_Pago nvarchar(50), Fecha_de_Suscripcion datetime, Numero_de_Pago int, De_Total_de_Pagos int,Fecha_Limite_de_Pago datetime,Recordatorio_dias int,Forma_de_Pago int, Fecha_de_Pago datetime,Estatus int)"
+" "
+" DECLARE @NumeroPago INT"
+" SET @NumeroPago = 1"
+" declare @FRecuencia int, @contador int"
+" set  @frecuencia=12 "
+" set @contador=1"
+" "
+" while (@contador<=@frecuencia)"
+" begin"
+"     insert into @tblMR(Folio, Folio_Empresas, Suscripcion, Concepto_de_Pago, Fecha_de_Suscripcion, Numero_de_Pago, De_Total_de_Pagos,Fecha_Limite_de_Pago,Recordatorio_dias,Forma_de_Pago, Fecha_de_Pago,Estatus)"
+"     select NULL as Folio, NULL as Folio_Empresas, 1 as Suscripcion, 'Concepto de pago' as Concepto_de_Pago, GETDATE() as Fecha_de_Suscripcion, @NumeroPago as Numero_de_Pago, 12 as De_Total_de_Pagos, NULL as Fecha_Limite_de_Pago, NULL as Recordatorio_dias, NULL as Forma_de_Pago, NULL as Fecha_de_Pago, NULL as Estatus"
+" "
+" "
+"     set @contador = @contador + 1"
+" 	SET @NumeroPago = @NumeroPago + 1"
+" end"
+" "
+" select * from @tblMR ");

}
//BusinessRuleId:406, Attribute:258520, Operation:Object, Event:AFTERSAVINGMR

//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Suscripciones_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 




//BusinessRuleId:191, Attribute:258520, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Fecha_Fin" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_de_la_Suscripcion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_inicio' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable));

}
//BusinessRuleId:191, Attribute:258520, Operation:Object, Event:NEWROWMR

//BusinessRuleId:191, Attribute:258520, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Fecha_Fin" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_de_la_Suscripcion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Fecha_de_inicio' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable));

}
//BusinessRuleId:191, Attribute:258520, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Suscripciones_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Pagos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Pagos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Contratos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Contratos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Registro_Beneficiarios_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Registro_Beneficiarios_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_Beneficiarios_Titulares_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Registro_Beneficiarios_Titulares_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_Beneficiarios_Titulares_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Registro_Beneficiarios_Titulares_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Registro_Beneficiarios_Titulares_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Registro_Beneficiarios_Titulares_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Registro_Beneficiarios_Titulares_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Registro_Beneficiarios_Titulares_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Registro_Beneficiarios_Titulares_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Registro_Beneficiarios_Titulares_Empresa// 
 return result; 
} 
