var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//Validar Email
	$('#Email').change(function(){ 
		let email = $('#Email').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
		} 
	});
	
	//Validar Email Contacto
	$('#Email_de_contacto').blur(function(){ 
		let email = $('#Email_de_contacto').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email_de_contacto').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
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

//Validar CP
$( "#CP_Fiscal" ).blur(function(){
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex).val()>TryParseInt('9999', '9999') && $('#' + nameOfTable + 'CP_Fiscal' + rowIndex).val()<TryParseInt('99999', '99999') ) 
{ } else {$('#' + nameOfTable + 'CP_Fiscal' + rowIndex).attr("placeholder", "Código Postal inválido.").val("").focus().blur();}
});
	
//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Nombres', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None

//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Apellido_Paterno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery(" select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None

//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Apellido_Materno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None









$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex));
 $('#divEmail_institucional').css('display', 'none'); 
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex)); 
 $("a[href='#tabDatos_de_Contacto']").css('display', 'none'); 
 $("a[href='#tabDatos_Profesionales']").css('display', 'none');
 $("a[href='#tabDatos_Fiscales']").css('display', 'none'); 
 $("a[href='#tabDocumentacion']").css('display', 'none');
 $("a[href='#tabCodigos_de_Referencia']").css('display', 'none'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'none'); 
 $("a[href='#tabDatos_Bancarios']").css('display', 'none'); $("a[href='#tabFacturacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex));

});





//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None



//BusinessRuleId:132, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('4', '4') ) { $("a[href='#tabDatos_de_Contacto']").css('display', 'block'); 
$("a[href='#tabDatos_Fiscales']").css('display', 'block'); $("a[href='#tabCodigos_de_Referencia']").css('display', 'block'); 
$("a[href='#tabDatos_Bancarios']").css('display', 'block'); $("a[href='#tabFacturacion']").css('display', 'block');
$("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'block');} else {}
});


//BusinessRuleId:132, Attribute:258468, Operation:Field, Event:None

//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('2', '2') ) { 
$("a[href='#tabDatos_de_Contacto']").css('display', 'block'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'block');} 
else { }
});


//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None

//BusinessRuleId:131, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('3', '3') ) { $("a[href='#tabDatos_Fiscales']").css('display', 'block'); 
$("a[href='#tabCodigos_de_Referencia']").css('display', 'block'); $("a[href='#tabFacturacion']").css('display', 'block');
$("a[href='#tabDatos_Bancarios']").css('display', 'block');} else {}
});


//BusinessRuleId:131, Attribute:258468, Operation:Field, Event:None




//BusinessRuleId:397, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
 $("a[href='#tabDatos_Profesionales']").css('display', 'block');
});


//BusinessRuleId:397, Attribute:258468, Operation:Field, Event:None

//BusinessRuleId:398, Attribute:258267, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Profesion', function () {
	nameOfTable='';
	rowIndex='';
 var valor = $('#' + nameOfTable + 'Especialidad' + rowIndex).val();   $('#' + nameOfTable + 'Especialidad' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Especialidad' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Especialidad' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Especialidad' + rowIndex).val(valor).trigger('change');
});


//BusinessRuleId:398, Attribute:258267, Operation:Field, Event:None













//BusinessRuleId:400, Attribute:258860, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Email_ppal_publico', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex).val()==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Email_de_contacto' + rowIndex),EvaluaQuery("select 'FLD[Email]'", rowIndex, nameOfTable));} else { AsignarValor($('#' + nameOfTable + 'Email_de_contacto' + rowIndex),EvaluaQuery("Select ' '", rowIndex, nameOfTable));}
});


//BusinessRuleId:400, Attribute:258860, Operation:Field, Event:None



//BusinessRuleId:427, Attribute:258246, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Titulo_Personal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});
$("form#CreateMedicos").on('keyup', '#Apellido_Materno', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});
$("form#CreateMedicos").on('keyup', '#Apellido_Paterno', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});
$("form#CreateMedicos").on('keyup', '#Nombres', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});
$("form#CreateMedicos").on('keyup', '#Titulo_Personal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});
//BusinessRuleId:427, Attribute:258246, Operation:Field, Event:None

//BusinessRuleId:426, Attribute:258470, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#En_Hospital', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'En_Hospital' + rowIndex).val()==EvaluaQuery("select 1",rowIndex, nameOfTable) ) { $('#divNombre_del_Hospital').css('display', 'block'); $('#divPiso_hospital').css('display', 'block'); $('#divNumero_de_consultorio').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex));} else { $('#divNombre_del_Hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); $('#divPiso_hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); $('#divNumero_de_consultorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex));}
});


//BusinessRuleId:426, Attribute:258470, Operation:Field, Event:None

//BusinessRuleId:428, Attribute:258858, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Titulo_Personal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo' + rowIndex),EvaluaQuery(" SELECT (select Descripcion from Titulos_Personales where Clave = FLD[Titulo_Personal]) + ' ' + 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});


//BusinessRuleId:428, Attribute:258858, Operation:Field, Event:None

//BusinessRuleId:432, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==EvaluaQuery("select 4",rowIndex, nameOfTable) ) { SetRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));}
});


//BusinessRuleId:432, Attribute:258468, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));


}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));


}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING



























//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex));
 $('#divEmail_institucional').css('display', 'none'); 
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex)); 
 $("a[href='#tabDatos_de_Contacto']").css('display', 'none'); 
 $("a[href='#tabDatos_Profesionales']").css('display', 'none');
 $("a[href='#tabDatos_Fiscales']").css('display', 'none'); 
 $("a[href='#tabDocumentacion']").css('display', 'none');
 $("a[href='#tabCodigos_de_Referencia']").css('display', 'none'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'none'); 
 $("a[href='#tabDatos_Bancarios']").css('display', 'none'); $("a[href='#tabFacturacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex));


}
//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '8'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '8'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '8'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '9'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '9'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '9'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '10'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '10'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '10'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '11'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '11'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '11'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '12'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '12'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '12'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '13'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '13'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '13'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '14'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '14'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '14'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '15'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '15'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '15'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '16'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '16'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '16'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:396, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $("a[href='#tabDatos_Profesionales']").css('display', 'block');


}
//BusinessRuleId:396, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:399, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Especialidad' + rowIndex).val();   $('#' + nameOfTable + 'Especialidad' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Especialidad' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Especialidad' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Especialidad' + rowIndex).val(valor).trigger('change');


}
//BusinessRuleId:399, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); $('#divEstatus_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); $('#divTipo_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); $('#divNombre_del_Hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); $('#divPiso_hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); $('#divNumero_de_consultorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex));


}
//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); $('#divEstatus_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); $('#divTipo_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); $('#divNombre_del_Hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); $('#divPiso_hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); $('#divNumero_de_consultorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex));


}
//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:429, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 CreateSessionVar('VariableContrasena', EvaluaQuery(" declare @valor nvarchar(5) set @valor= lower(left(replace(newid(),'-',''),5)) select @valor", rowIndex, nameOfTable));


}
//BusinessRuleId:429, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Celular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entidad_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));


}
//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Celular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entidad_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));


}
//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Celular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entidad_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));


}
//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:434, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divNombre_de_usuario').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_de_usuario' + rowIndex)); $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex));

}
//BusinessRuleId:434, Attribute:0, Operation:Object, Event:SCREENOPENING





































//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
        nameOfTable = '';
        rowIndex = '';

 return result;
}

//NEWBUSINESSRULE_BEFORESAVING//
   

function EjecutarValidacionesDespuesDeGuardar(){
//BusinessRuleId:430, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 EvaluaQuery(" exec InsertSpartanEspecialistas GLOBAL[KeyValueInserted], 'GLOBAL[VariableContrasena]'", rowIndex, nameOfTable);


}
//BusinessRuleId:430, Attribute:2, Operation:Object, Event:AFTERSAVING





//BusinessRuleId:431, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
SendEmailQuery('contraseña', EvaluaQuery("select 'FLD[Email]'"), "Tu contraseña de acceso es: GLOBAL[VariableContrasena]",rowIndex,nameOfTable);

}
//BusinessRuleId:431, Attribute:2, Operation:Object, Event:AFTERSAVING



//BusinessRuleId:433, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
 EvaluaQuery(" exec UpdateSpartanEspecialidades FLDD[lblFolio]", rowIndex, nameOfTable);


}
//BusinessRuleId:433, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}



function EjecutarValidacionesAntesDeGuardarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Identificacion_Oficial_Medicos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Identificacion_Oficial_Medicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Titulos_Medicos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Titulos_Medicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR

//NEWBUSINESSRULE_EDITROWMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Convenio_Medicos_Aseguradoras// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Convenio_Medicos_Aseguradoras// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Codigos_Referidos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Codigos_Referidos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Planes_de_Suscripcion_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Planes_de_Suscripcion_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Pagos_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Pagos_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Datos_Bancarios_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Datos_Bancarios_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Redes_Sociales_Especialista// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Redes_Sociales_Especialista// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Facturacion_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Facturacion_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 


/***************************************************************************************************************************************************************** */

//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None












































function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));


}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));


}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING



























//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex));
 $('#divEmail_institucional').css('display', 'none'); 
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex)); 
 $("a[href='#tabDatos_de_Contacto']").css('display', 'none'); 
 $("a[href='#tabDatos_Profesionales']").css('display', 'none');
 $("a[href='#tabDatos_Fiscales']").css('display', 'none'); 
 $("a[href='#tabDocumentacion']").css('display', 'none');
 $("a[href='#tabCodigos_de_Referencia']").css('display', 'none'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'none'); 
 $("a[href='#tabDatos_Bancarios']").css('display', 'none'); $("a[href='#tabFacturacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex));


}
//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:195, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:196, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:197, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:198, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:199, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:200, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:201, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '8'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:202, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '8'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '9'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:203, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '9'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '10'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:204, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '10'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '11'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:205, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '11'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '12'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:206, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '12'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '13'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:207, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '13'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '14'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:208, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '14'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '15'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:209, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '15'",rowIndex, nameOfTable) ) {} else {}


}


//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '16'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:210, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '16'",rowIndex, nameOfTable) ) {} else {}


}






//BusinessRuleId:396, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $("a[href='#tabDatos_Profesionales']").css('display', 'block');


}
//BusinessRuleId:396, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:399, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Especialidad' + rowIndex).val();   $('#' + nameOfTable + 'Especialidad' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Especialidad' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Especialidad' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("Select Clave, Especialidad from Especialidades where Profesion = FLD[Profesion]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Especialidad' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Especialidad' + rowIndex).val(valor).trigger('change');


}
//BusinessRuleId:399, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); $('#divEstatus_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); $('#divTipo_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); $('#divNombre_del_Hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); $('#divPiso_hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); $('#divNumero_de_consultorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex));


}
//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); $('#divEstatus_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); $('#divTipo_WF').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); $('#divNombre_del_Hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); $('#divPiso_hospital').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); $('#divNumero_de_consultorio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex));


}
//BusinessRuleId:423, Attribute:0, Operation:Object, Event:SCREENOPENING









//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Celular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entidad_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));


}
//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:424, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Celular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entidad_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_WF' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex));


}


//BusinessRuleId:434, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divNombre_de_usuario').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_de_usuario' + rowIndex)); $('#divUsuario_Registrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex));

}
//BusinessRuleId:434, Attribute:0, Operation:Object, Event:SCREENOPENING





































//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:435, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:436, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:437, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:438, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:439, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:441, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
        nameOfTable = '';
        rowIndex = '';

 return result;
}

//NEWBUSINESSRULE_BEFORESAVING//
   

function EjecutarValidacionesDespuesDeGuardar(){




//BusinessRuleId:433, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
 EvaluaQuery(" exec UpdateSpartanEspecialidades FLDD[lblFolio]", rowIndex, nameOfTable);


}
//BusinessRuleId:433, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}







function EjecutarValidacionesNewRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}


//NEWBUSINESSRULE_NEWROWMR_Detalle_Titulos_Medicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}
//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR

//BusinessRuleId:425, Attribute:258473, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Titulacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cedula' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Expedicion' + rowIndex));


}}




