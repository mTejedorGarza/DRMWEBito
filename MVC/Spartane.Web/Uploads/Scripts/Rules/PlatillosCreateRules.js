var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {


//BusinessRuleId:228, Attribute:260849, Operation:Field, Event:None
$("#MR_Detalle_PlatilloGrid").on('keyup', '.Cantidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 AsignarValor($('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex),EvaluaQuery("select dbo.ufn_ConvertFracToDec ('FLD[Cantidad]')", rowIndex, nameOfTable));
	nameOfTable='';
	rowIndex='';
});
$("form#CreateMR_Detalle_Platillo").on('keyup', '#MR_Detalle_PlatilloCantidad', function () {
	nameOfTable='MR_Detalle_Platillo';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex),EvaluaQuery("select dbo.ufn_ConvertFracToDec ('FLD[Cantidad]')", rowIndex, nameOfTable));
});
//BusinessRuleId:228, Attribute:260849, Operation:Field, Event:None



//BusinessRuleId:234, Attribute:260851, Operation:Field, Event:None
$("#MR_Detalle_PlatilloGrid").on('change', '.Unidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( EvaluaQuery("SELECT dbo.IsDecimal (FLD[Cantidad_en_Fraccion])",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery("declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Fraccion from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});
$("#MR_Detalle_PlatilloGrid").on('change', '.Cantidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( EvaluaQuery("SELECT dbo.IsDecimal (FLD[Cantidad_en_Fraccion])",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery("declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Fraccion from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:235, Attribute:260851, Operation:Field, Event:None


//BusinessRuleId:236, Attribute:260848, Operation:Field, Event:None



//BusinessRuleId:237, Attribute:260851, Operation:Field, Event:None
$("#MR_Detalle_PlatilloGrid").on('change', '.Unidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Unidad' + rowIndex).val()==TryParseInt('29', '29') ) { AsignarValor($('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex),EvaluaQuery("declare @Ingrediente nvarchar(50)"
+" set @Ingrediente = (Select Ingrediente from Ingredientes where Clave = FLD[Ingrediente])"
+" select @Ingrediente + ' ' + 'al gusto'", rowIndex, nameOfTable));} else { AsignarValor($('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex),EvaluaQuery("Select Ingrediente from Ingredientes where Clave = FLD[Ingrediente]", rowIndex, nameOfTable));}
	nameOfTable='';
	rowIndex='';
});
$("#MR_Detalle_PlatilloGrid").on('change', '.Cantidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Unidad' + rowIndex).val()==TryParseInt('29', '29') ) { AsignarValor($('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex),EvaluaQuery("declare @Ingrediente nvarchar(50)"
+" set @Ingrediente = (Select Ingrediente from Ingredientes where Clave = FLD[Ingrediente])"
+" select @Ingrediente + ' ' + 'al gusto'", rowIndex, nameOfTable));} else { AsignarValor($('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex),EvaluaQuery("Select Ingrediente from Ingredientes where Clave = FLD[Ingrediente]", rowIndex, nameOfTable));}
	nameOfTable='';
	rowIndex='';
});
//BusinessRuleId:237, Attribute:260851, Operation:Field, Event:None



//BusinessRuleId:235, Attribute:260851, Operation:Field, Event:None
$("#MR_Detalle_PlatilloGrid").on('change', '.Unidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex).val()>TryParseInt('1', '1') && EvaluaQuery("SELECT dbo.IsInt (FLD[Cantidad_en_Fraccion])",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery(" declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Plural from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});
$("#MR_Detalle_PlatilloGrid").on('change', '.Cantidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex).val()>TryParseInt('1', '1') && EvaluaQuery("SELECT dbo.IsInt (FLD[Cantidad_en_Fraccion])",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery(" declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Plural from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});
//BusinessRuleId:235, Attribute:260851, Operation:Field, Event:None

//BusinessRuleId:233, Attribute:260851, Operation:Field, Event:None
$("#MR_Detalle_PlatilloGrid").on('change', '.Unidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex).val()==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery("declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Singular from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});
$("#MR_Detalle_PlatilloGrid").on('change', '.Cantidad', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Cantidad_en_Fraccion' + rowIndex).val()==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Cantidad_a_mostrar' + rowIndex),EvaluaQuery("declare @unidad nvarchar(50)"
+" set @unidad = (select Texto_Singular from Unidades_de_Medida where Clave = FLD[Unidad])"
+" select 'FLD[Cantidad]' + ' ' + @unidad", rowIndex, nameOfTable));} else {}
	nameOfTable='';
	rowIndex='';
});
//BusinessRuleId:233, Attribute:260851, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Categoria_del_Platillo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_comida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex));

}
//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Categoria_del_Platillo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_comida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex));

}
//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); $('#divCaracteristicas').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex)); $('#divCalificacion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex));

}
//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); $('#divCaracteristicas').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex)); $('#divCalificacion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex));

}
//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); $('#divCaracteristicas').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex)); $('#divCalificacion').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex));

}
//BusinessRuleId:409, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_de_Ingredientes//
}
function EjecutarValidacionesAlEliminarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_de_Ingredientes//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Platillos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Platillos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Platillos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Platillos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Platillos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Platillos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMR_Detalle_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MR_Detalle_Platillo// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMR_Detalle_Platillo(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MR_Detalle_Platillo// 
} 

function EjecutarValidacionesAlEliminarMRMR_Detalle_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MR_Detalle_Platillo// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMR_Detalle_Platillo(nameOfTable, rowIndex){ 
 var result= true; 























//BusinessRuleId:236, Attribute:260854, Operation:Object, Event:NEWROWMR














//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR

//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR

//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR
if(operation == 'Consult'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_MR_Detalle_Platillo// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMR_Detalle_Platillo(nameOfTable, rowIndex){ 
 var result= true; 




































//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR

//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR

//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR
if(operation == 'Consult'){
 DisabledControl($("#" + nameOfTable + "Cantidad_en_Fraccion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_a_mostrar" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Ingrediente_a_mostrar' + rowIndex));

}
//BusinessRuleId:229, Attribute:260854, Operation:Object, Event:EDITROWMR

//NEWBUSINESSRULE_EDITROWMR_MR_Detalle_Platillo// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Calorias(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Calorias// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Calorias(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Calorias// 
} 

function EjecutarValidacionesAlEliminarMRMS_Calorias(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Calorias// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Calorias(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Calorias// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Calorias(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Calorias// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Padecimientos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Padecimientos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Padecimientos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Padecimientos// 
} 

function EjecutarValidacionesAlEliminarMRMS_Padecimientos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Padecimientos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Padecimientos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Padecimientos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Padecimientos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Padecimientos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Dificultad_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Dificultad_Platillos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Dificultad_Platillos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Dificultad_Platillos// 
} 

function EjecutarValidacionesAlEliminarMRMS_Dificultad_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Dificultad_Platillos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Dificultad_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Dificultad_Platillos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Dificultad_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Dificultad_Platillos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Tiempos_de_Comida_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Tiempos_de_Comida_Platillos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Tiempos_de_Comida_Platillos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Tiempos_de_Comida_Platillos// 
} 

function EjecutarValidacionesAlEliminarMRMS_Tiempos_de_Comida_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Tiempos_de_Comida_Platillos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Tiempos_de_Comida_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Tiempos_de_Comida_Platillos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Tiempos_de_Comida_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Tiempos_de_Comida_Platillos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Caracteristicas_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Caracteristicas_Platillo// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Caracteristicas_Platillo(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Caracteristicas_Platillo// 
} 

function EjecutarValidacionesAlEliminarMRMS_Caracteristicas_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Caracteristicas_Platillo// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Caracteristicas_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Caracteristicas_Platillo// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Caracteristicas_Platillo(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Caracteristicas_Platillo// 
 return result; 
} 
