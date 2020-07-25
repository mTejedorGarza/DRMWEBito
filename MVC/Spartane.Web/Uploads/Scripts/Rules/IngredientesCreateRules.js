var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//BusinessRuleId:230, Attribute:259610, Operation:Field, Event:None
$("form#CreateIngredientes").on('keyup', '#Cantidad_sugerida', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Cantidad_Sugerida_Decimal' + rowIndex),EvaluaQuery("select dbo.ufn_ConvertFracToDec ('FLD[Cantidad_sugerida]')", rowIndex, nameOfTable));
});

//BusinessRuleId:230, Attribute:259610, Operation:Field, Event:None

//BusinessRuleId:238, Attribute:260976, Operation:Field, Event:None
$("form#CreateIngredientes").on('change', '#Es_un_ingrediente_de_SMAE', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Es_un_ingrediente_de_SMAE' + ':checked').val()==EvaluaQuery("select 'true'",rowIndex, nameOfTable) ) { SetRequiredToControl( $('#' + nameOfTable + 'Clasificacion' + rowIndex)); 
SetRequiredToControl( $('#' + nameOfTable + 'Subgrupo' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex)); 
$('#divNombre_Ingrediente').css('display', 'block');} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Clasificacion' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Subgrupo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex)); 
$('#divNombre_Ingrediente').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex));}
});

//BusinessRuleId:238, Attribute:260976, Operation:Field, Event:None

//BusinessRuleId:251, Attribute:254520, Operation:Field, Event:None
$("form#CreateIngredientes").on('keyup', '#Nombre_Ingrediente', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Ingrediente' + rowIndex),EvaluaQuery("SELECT 'FLD[Nombre_Ingrediente]'", rowIndex, nameOfTable));
});

//BusinessRuleId:251, Attribute:254520, Operation:Field, Event:None

//BusinessRuleId:255, Attribute:257539, Operation:Field, Event:None
$("form#CreateIngredientes").on('change', '#Clasificacion', function () {
	nameOfTable='';
	rowIndex='';
 var valor = $('#' + nameOfTable + 'Subgrupo' + rowIndex).val();   $('#' + nameOfTable + 'Subgrupo' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Subgrupo' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Subgrupo' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Folio, Nombre from Subgrupos_Ingredientes where Clasificacion = FLD[Clasificacion]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Subgrupo' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Folio, Nombre from Subgrupos_Ingredientes where Clasificacion = FLD[Clasificacion]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Subgrupo' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Subgrupo' + rowIndex).val(valor).trigger('change');
});

//BusinessRuleId:255, Attribute:257539, Operation:Field, Event:None



//BusinessRuleId:410, Attribute:259611, Operation:Field, Event:None
$("form#CreateIngredientes").on('change', '#Unidad', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Unidad' + rowIndex).val()==TryParseInt('29', '29') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_sugerida' + rowIndex),0); AsignarValor($('#' + nameOfTable + 'Cantidad_Sugerida_Decimal' + rowIndex),0); AsignarValor($('#' + nameOfTable + 'Peso_bruto_redondeado_g' + rowIndex),0); AsignarValor($('#' + nameOfTable + 'Peso_neto_g' + rowIndex),0); DisabledControl($("#" + nameOfTable + "Cantidad_sugerida" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_Sugerida_Decimal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Peso_bruto_redondeado_g" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Peso_neto_g" + rowIndex), ("true" == "true"));} else { DisabledControl($("#" + nameOfTable + "Cantidad_sugerida" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_Sugerida_Decimal" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Peso_bruto_redondeado_g" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Peso_neto_g" + rowIndex), ("false" == "true"));}
});

//BusinessRuleId:410, Attribute:259611, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Cantidad_Sugerida_Decimal" + rowIndex), ("true" == "true"));

}
if(operation == 'New'){
	if( $('#' + nameOfTable + 'Es_un_ingrediente_de_SMAE' + ':checked').val()==EvaluaQuery("select 'true'",rowIndex, nameOfTable) ) { SetRequiredToControl( $('#' + nameOfTable + 'Clasificacion' + rowIndex)); 
SetRequiredToControl( $('#' + nameOfTable + 'Subgrupo' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex)); 
$('#divNombre_Ingrediente').css('display', 'block');} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Clasificacion' + rowIndex)); 
SetNotRequiredToControl( $('#' + nameOfTable + 'Subgrupo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex)); 
$('#divNombre_Ingrediente').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Ingrediente' + rowIndex));}}

//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Cantidad_Sugerida_Decimal" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 DisabledControl($("#" + nameOfTable + "Cantidad_Sugerida_Decimal" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:231, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:256, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Subgrupo' + rowIndex).val();   $('#' + nameOfTable + 'Subgrupo' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Subgrupo' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Subgrupo' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Folio, Nombre from Subgrupos_Ingredientes where Clasificacion = FLD[Clasificacion]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Subgrupo' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Folio, Nombre from Subgrupos_Ingredientes where Clasificacion = FLD[Clasificacion]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Subgrupo' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Subgrupo' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:256, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_sugerida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_Sugerida_Decimal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_bruto_redondeado_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_neto_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex));

}
//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_sugerida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_Sugerida_Decimal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_bruto_redondeado_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_neto_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex));

}
//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_sugerida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_Sugerida_Decimal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_bruto_redondeado_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_neto_g' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex));

}
//BusinessRuleId:252, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Caracteristicas_Ingrediente// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Caracteristicas_Ingrediente// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 
