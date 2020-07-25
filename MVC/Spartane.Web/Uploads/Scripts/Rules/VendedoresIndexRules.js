var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {



//BusinessRuleId:232, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( EvaluaQuery("select GLOBAL[USERROLEID] ",rowIndex, nameOfTable)==TryParseInt('21', '21') ) { MRWhere=ReplaceQuery("Vendedores.Usuario_que_registra=GLOBAL[USERID]");} else {}

}
//BusinessRuleId:232, Attribute:3, Operation:Object, Event:None

//NEWBUSINESSRULE_BEFORECREATIONLIST//
});

function EjecutarValidacionesDespuesDeCrearLista()
{
//NEWBUSINESSRULE_AFTERCREATIONLIST//
}
