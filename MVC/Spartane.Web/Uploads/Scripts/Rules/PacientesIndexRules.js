var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {



//BusinessRuleId:250, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('16', '16') || EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('17', '17') ) { MRWhere=ReplaceQuery("Pacientes.Usuario_que_Registra=GLOBAL[USERID]");} else {}

}
//BusinessRuleId:250, Attribute:3, Operation:Object, Event:None

//NEWBUSINESSRULE_BEFORECREATIONLIST//
});

function EjecutarValidacionesDespuesDeCrearLista()
{
//NEWBUSINESSRULE_AFTERCREATIONLIST//
}
