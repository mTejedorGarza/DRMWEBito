var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//BusinessRuleId:240, Attribute:260906, Operation:Field, Event:None
$("form#CreateCodigos_de_Descuento").on('change', '#Tipo_de_Vendedor', function () {
	nameOfTable='';
	rowIndex='';
 var valor = $('#' + nameOfTable + 'Vendedor' + rowIndex).val();   $('#' + nameOfTable + 'Vendedor' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Vendedor' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Vendedor' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Vendedor' + rowIndex).val(valor).trigger('change');
});

//BusinessRuleId:240, Attribute:260906, Operation:Field, Event:None





















//BusinessRuleId:243, Attribute:260909, Operation:Field, Event:None
$("form#CreateCodigos_de_Descuento").on('blur', '#Descuento', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Descuento' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Descuento' + rowIndex).val()>TryParseInt('100', '100') ) 
{ $('#Descuento').attr("placeholder", "Debes introducir un número menor a 100.").val("").focus().blur(); } else {}
});

//BusinessRuleId:243, Attribute:260909, Operation:Field, Event:None

//BusinessRuleId:242, Attribute:260909, Operation:Field, Event:None
$("form#CreateCodigos_de_Descuento").on('keyup', '#Descuento', function () {
	nameOfTable='';
	rowIndex='';
if( EvaluaQuery("select dbo.IsInt(FLD[Descuento])",rowIndex, nameOfTable)==TryParseInt('0', '0') ) 
{ $('#Descuento').attr("placeholder", "Debes introducir un número entero y no letras.").val("").focus().blur(); } else {}
});

//BusinessRuleId:242, Attribute:260909, Operation:Field, Event:None





//BusinessRuleId:254, Attribute:260907, Operation:Field, Event:None
$("form#CreateCodigos_de_Descuento").on('change', '#Vendedor', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Codigo_de_descuento' + rowIndex),EvaluaQuery(""
+" DECLARE @4random nvarchar(4)"
+" Set @4random =(SELECT Cast(RAND()*(9999-1000)+1000 as int))"
+" DECLARE @valor nvarchar(5) "
+" set @valor= UPPER(left(replace(newid(),'-',''),5)) "
+" DECLARE @Vendedor nvarchar(50)"
+" SET @Vendedor = (SELECT Name FROM Spartan_User WHERE Id_user = FLD[Vendedor])"
+" DECLARE @3cifras	 nvarchar(3)"
+" SET @3CIFRAS = (Select upper(left(cast(@Vendedor as varchar), 3)))"
+" "
+" SELECT @4random + @3cifras + @valor", rowIndex, nameOfTable));
});

//BusinessRuleId:254, Attribute:260907, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:241, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 var valor = $('#' + nameOfTable + 'Vendedor' + rowIndex).val();   $('#' + nameOfTable + 'Vendedor' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Vendedor' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Vendedor' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Vendedor' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:241, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:241, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Vendedor' + rowIndex).val();   $('#' + nameOfTable + 'Vendedor' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Vendedor' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Vendedor' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role = (select Clave_Rol from Tipos_de_Vendedor where Clave = FLD[Tipo_de_Vendedor])", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Vendedor' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Vendedor' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:241, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_promocional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_vigencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_maxima_de_referenciados' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));

}
//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_promocional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_vigencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_maxima_de_referenciados' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));

}
//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Texto_promocional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_fin_vigencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_maxima_de_referenciados' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));

}
//BusinessRuleId:244, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:245, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('21', '21') ) { AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);} else {}

}
//BusinessRuleId:245, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:246, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),2);} else {}

}
//BusinessRuleId:246, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:239, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Codigo_de_descuento" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:239, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:239, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Codigo_de_descuento" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:239, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:257, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_autoriza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_autoriza" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:257, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:257, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Fecha_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Hora_de_autorizacion' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_autorizacion" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Usuario_que_autoriza' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]"
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Usuario_que_autoriza" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:257, Attribute:0, Operation:Object, Event:SCREENOPENING































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































































//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:258, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:259, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:260, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:261, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:262, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:263, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:264, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:265, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:266, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:267, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:268, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:269, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:270, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:271, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:272, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:273, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:274, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:276, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:277, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:278, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:285, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:287, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:288, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:289, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:290, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:292, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:294, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:296, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:298, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:300, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:302, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:304, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:306, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:307, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:308, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:309, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:311, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:313, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:315, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:317, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:318, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:319, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:320, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:322, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:324, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:326, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:328, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:330, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) {} else {}

}
//BusinessRuleId:332, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:334, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:336, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:338, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:340, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:342, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:344, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:346, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:348, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:350, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:352, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:354, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:356, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:358, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:360, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('display', 'none'); $("a[href='#tabReferenciados']").css('display', 'none');} else {}

}
//BusinessRuleId:362, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) { $("a[href='#tabReferenciados']").css('display', 'none'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:364, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '3'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:366, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '4'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:368, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '5'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:370, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '6'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:372, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '7'",rowIndex, nameOfTable) ) { $("a[href='#tabAutorizacion']").css('pointer-events', 'none');
$("a[href='#tabAutorizacion']").css('background-color', '#ddd'); $("a[href='#tabDatos_Generales']").css('pointer-events', 'none');
$("a[href='#tabDatos_Generales']").css('background-color', '#ddd'); $("a[href='#tabReferenciados']").css('pointer-events', 'none');
$("a[href='#tabReferenciados']").css('background-color', '#ddd');} else {}

}
//BusinessRuleId:374, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRMS_Planes_por_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Planes_por_Codigo_de_Descuento// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Planes_por_Codigo_de_Descuento(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Planes_por_Codigo_de_Descuento// 
} 

function EjecutarValidacionesAlEliminarMRMS_Planes_por_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Planes_por_Codigo_de_Descuento// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Planes_por_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Planes_por_Codigo_de_Descuento// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Planes_por_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Planes_por_Codigo_de_Descuento// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MR_Referenciados_Codigo_de_Descuento// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MR_Referenciados_Codigo_de_Descuento// 
} 

function EjecutarValidacionesAlEliminarMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MR_Referenciados_Codigo_de_Descuento// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MR_Referenciados_Codigo_de_Descuento// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MR_Referenciados_Codigo_de_Descuento// 
 return result; 
} 
