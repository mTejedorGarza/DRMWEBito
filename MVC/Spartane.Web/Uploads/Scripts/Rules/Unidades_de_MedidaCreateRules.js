var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//BusinessRuleId:412, Attribute:254444, Operation:Field, Event:None
$("form#CreateUnidades_de_Medida").on('keyup', '#Unidad', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Texto_Singular' + rowIndex),EvaluaQuery("select 'FLD[Unidad]' + ' ' + 'de'", rowIndex, nameOfTable));
});

//BusinessRuleId:412, Attribute:254444, Operation:Field, Event:None

//BusinessRuleId:413, Attribute:254444, Operation:Field, Event:None
$("form#CreateUnidades_de_Medida").on('keyup', '#Unidad', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Texto_Plural' + rowIndex),EvaluaQuery(" select 'FLD[Unidad]' + 's' + ' ' + 'de'", rowIndex, nameOfTable));
});

//BusinessRuleId:413, Attribute:254444, Operation:Field, Event:None

//BusinessRuleId:414, Attribute:254444, Operation:Field, Event:None
$("form#CreateUnidades_de_Medida").on('keyup', '#Unidad', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Texto_Fraccion' + rowIndex),EvaluaQuery(" select 'de' + ' ' + 'FLD[Unidad]' + ' ' + 'de'", rowIndex, nameOfTable));
});

//BusinessRuleId:414, Attribute:254444, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Abreviacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Singular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Plural' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Fraccion' + rowIndex));

}
//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Abreviacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Singular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Plural' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Fraccion' + rowIndex));

}
//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Abreviacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Singular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Plural' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_Fraccion' + rowIndex));

}
//BusinessRuleId:411, Attribute:0, Operation:Object, Event:SCREENOPENING

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
//NEWBUSINESSRULE_AFTERSAVING//
}


