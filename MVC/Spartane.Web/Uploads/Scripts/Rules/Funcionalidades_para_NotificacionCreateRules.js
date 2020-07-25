var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
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



function EjecutarValidacionesAntesDeGuardarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Roles_de_Usuario_Notificacion// 
} 

function EjecutarValidacionesAlEliminarMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Roles_de_Usuario_Notificacion// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Roles_de_Usuario_Notificacion(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Roles_de_Usuario_Notificacion// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Campos_por_Funcionalidad(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Campos_por_Funcionalidad// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Campos_por_Funcionalidad(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Campos_por_Funcionalidad// 
} 

function EjecutarValidacionesAlEliminarMRMS_Campos_por_Funcionalidad(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Campos_por_Funcionalidad// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Campos_por_Funcionalidad(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Campos_por_Funcionalidad// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Campos_por_Funcionalidad(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Campos_por_Funcionalidad// 
 return result; 
} 
