var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:418, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 var valor = $('#' + nameOfTable + 'Paciente' + rowIndex).val();   $('#' + nameOfTable + 'Paciente' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Paciente' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Paciente' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select id_User, Name from Spartan_User with(nolock) where Role=16 or Role=17", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Paciente' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select id_User, Name from Spartan_User with(nolock) where Role=16 or Role=17", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Paciente' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Paciente' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:418, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:418, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Paciente' + rowIndex).val();   $('#' + nameOfTable + 'Paciente' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Paciente' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Paciente' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select id_User, Name from Spartan_User with(nolock) where Role=16 or Role=17", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Paciente' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select id_User, Name from Spartan_User with(nolock) where Role=16 or Role=17", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Paciente' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Paciente' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:418, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRMR_Tarjetas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_MR_Tarjetas//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRMR_Tarjetas(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_MR_Tarjetas//
}
function EjecutarValidacionesAlEliminarMRMR_Tarjetas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_MR_Tarjetas//
    return result;
}
function EjecutarValidacionesNewRowMRMR_Tarjetas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_MR_Tarjetas//
    return result;
}
function EjecutarValidacionesEditRowMRMR_Tarjetas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_MR_Tarjetas//
    return result;
}

