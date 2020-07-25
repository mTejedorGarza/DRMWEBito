var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:281, Attribute:260132, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Rutinas").on('change', '#Tipo_de_Rutina', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Rutina' + rowIndex).val()==TryParseInt('11', '11') ) { AsignarValor($('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex),EvaluaQuery("select 'true'", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex),EvaluaQuery(" select 'true'", rowIndex, nameOfTable));} else { AsignarValor($('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex),EvaluaQuery(" select 'false'", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex),EvaluaQuery("  select 'false'", rowIndex, nameOfTable));}
});

//BusinessRuleId:281, Attribute:260132, Operation:Field, Event:None

//BusinessRuleId:420, Attribute:260132, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Rutinas").on('change', '#Tipo_de_Rutina', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Rutina' + rowIndex).val()==EvaluaQuery("select 1",rowIndex, nameOfTable) ) { $('#divLleva_Calentamiento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex)); $('#divLleva_Enfriamiento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex));} else { $('#divLleva_Calentamiento').css('display', 'block'); $('#divLleva_Enfriamiento').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex));}
});

//BusinessRuleId:420, Attribute:260132, Operation:Field, Event:None

//BusinessRuleId:421, Attribute:260132, Operation:Field, Event:None
$("form#CreateConfiguracion_de_Rutinas").on('change', '#Tipo_de_Rutina', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Rutina' + rowIndex).val()==EvaluaQuery("select 2",rowIndex, nameOfTable) ) { $('#divLleva_Calentamiento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex)); $('#divLleva_Enfriamiento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Calentamiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lleva_Enfriamiento' + rowIndex));} else {}
});

//BusinessRuleId:421, Attribute:260132, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {








//BusinessRuleId:279, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); $('#divTexto_Ejercicios').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Ejercicios' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Ejercicios' + rowIndex));

}
//BusinessRuleId:279, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:279, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); $('#divTexto_Ejercicios').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Ejercicios' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Ejercicios' + rowIndex));

}
//BusinessRuleId:279, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:280, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);

}
//BusinessRuleId:280, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:422, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_series' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_repeticiones' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Descanso_segundos' + rowIndex));

}
//BusinessRuleId:422, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:422, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_series' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_de_repeticiones' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Descanso_segundos' + rowIndex));

}
//BusinessRuleId:422, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Secuencia_de_Ejercicios//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Secuencia_de_Ejercicios//
}
function EjecutarValidacionesAlEliminarMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Secuencia_de_Ejercicios//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndex){
    var result = true;
    //BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR

//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR

//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR
if(operation == 'Consult'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Secuencia_de_Ejercicios//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndex){
    var result = true;
    //BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR
if(operation == 'New'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR

//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR

//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR
if(operation == 'Consult'){
 var valor = $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val();   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("declare @cantidad int"
+" set @cantidad = FLDP[Cantidad_de_ejercicios]"
+" select Folio, Descripcion from Secuencia_de_Ejercicios_en_Rutinas where Folio <= @cantidad", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Orden_del_Ejercicio' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:282, Attribute:260149, Operation:Object, Event:EDITROWMR

//NEWBUSINESSRULE_EDITROWMR_Detalle_Secuencia_de_Ejercicios//
    return result;
}

