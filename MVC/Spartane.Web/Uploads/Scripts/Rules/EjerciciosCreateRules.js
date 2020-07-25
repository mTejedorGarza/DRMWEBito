var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:155, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:155, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:155, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:155, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:166, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Ejercicio' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Ejercicio' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Nivel_de_dificultad' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Sexo' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Musculos_trabajados' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Video' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Descripcion_del_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));

}
//BusinessRuleId:166, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:166, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Ejercicio' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Ejercicio' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Nivel_de_dificultad' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Sexo' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Musculos_trabajados' + rowIndex)); SetRequiredToControl( $('#' + nameOfTable + 'Video' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Imagen' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Descripcion_del_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));

}
//BusinessRuleId:166, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:167, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);

}
//BusinessRuleId:167, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRMS_Musculos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Musculos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Musculos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Musculos// 
} 

function EjecutarValidacionesAlEliminarMRMS_Musculos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Musculos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Musculos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Musculos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Musculos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Musculos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Equipamiento_para_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Equipamiento_para_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Equipamiento_para_Ejercicios(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Equipamiento_para_Ejercicios// 
} 

function EjecutarValidacionesAlEliminarMRMS_Equipamiento_para_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Equipamiento_para_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Equipamiento_para_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Equipamiento_para_Ejercicios// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Equipamiento_para_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Equipamiento_para_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Sexo_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Sexo_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Sexo_Ejercicios(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Sexo_Ejercicios// 
} 

function EjecutarValidacionesAlEliminarMRMS_Sexo_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Sexo_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Sexo_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Sexo_Ejercicios// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Sexo_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Sexo_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Equipamiento_Alterno_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Equipamiento_Alterno_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Equipamiento_Alterno_Ejercicios(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Equipamiento_Alterno_Ejercicios// 
} 

function EjecutarValidacionesAlEliminarMRMS_Equipamiento_Alterno_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Equipamiento_Alterno_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Equipamiento_Alterno_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Equipamiento_Alterno_Ejercicios// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Equipamiento_Alterno_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Equipamiento_Alterno_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Uso_del_Ejercicio(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Uso_del_Ejercicio// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Uso_del_Ejercicio(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Uso_del_Ejercicio// 
} 

function EjecutarValidacionesAlEliminarMRMS_Uso_del_Ejercicio(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Uso_del_Ejercicio// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Uso_del_Ejercicio(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Uso_del_Ejercicio// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Uso_del_Ejercicio(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Uso_del_Ejercicio// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Dificultad_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Dificultad_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Dificultad_Ejercicios(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Dificultad_Ejercicios// 
} 

function EjecutarValidacionesAlEliminarMRMS_Dificultad_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Dificultad_Ejercicios// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Dificultad_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Dificultad_Ejercicios// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Dificultad_Ejercicios(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Dificultad_Ejercicios// 
 return result; 
} 
