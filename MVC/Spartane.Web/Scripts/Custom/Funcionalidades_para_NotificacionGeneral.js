

var MS_Campos_por_FuncionalidadcountRowsChecked = 0;
function GetMS_Campos_por_FuncionalidadFromDataTable() {
    var MS_Campos_por_FuncionalidadData = [];
    debugger;

    var items = $("#ddlCampos_para_VigenciaMult").chosen().val();
    //es nuevo 
    if (MS_Campos_por_FuncionalidadDataDataTable == undefined || MS_Campos_por_FuncionalidadDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Campos_por_FuncionalidadData.push({ 
                      Folio: 0
                      
, Campo: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Campos_por_FuncionalidadDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Campos_por_FuncionalidadDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Campos_por_FuncionalidadData.push({
                        Folio: MS_Campos_por_FuncionalidadDataDataTable[i].Folio
                        
                   , Campo: MS_Campos_por_FuncionalidadDataDataTable[i].Campo

                        , Removed: true
                    });
                }
        }

        if (items != null)
        {
            if (items.length > 0) {
                // Se agregan los nuevoss 
                for (var i = 0; i < items.length; i++) {
                    var existe = false;
                    for (var j = 0; j < MS_Campos_por_FuncionalidadDataDataTable.length; j++) {
                        if (items[i] == MS_Campos_por_FuncionalidadDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Campos_por_FuncionalidadData.push({ 
                              Folio: 0
                              
, Campo: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Campos_por_FuncionalidadData;
}

//Used to Get Funcionalidades para Notificación Information
function GetMS_Campos_por_Funcionalidad() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Campos_por_FuncionalidadData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Campos_por_FuncionalidadData[i].Folio);
       
      form_data.append('[' + i +'].Campo',MS_Campos_por_FuncionalidadData[i].Campo);


       form_data.append('[' + i + '].Removed', MS_Campos_por_FuncionalidadData[i].Removed);
    }
    return form_data;
}



$(function () {
    function MS_Campos_por_FuncionalidadinitializeMainArray(totalCount) {
        if (MS_Campos_por_FuncionalidadDataMain.length != totalCount && !MS_Campos_por_FuncionalidadDataMainInitialized) {
            MS_Campos_por_FuncionalidadDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Campos_por_FuncionalidadDataMain[i] = null;
            }
        }
    }
    function MS_Campos_por_FuncionalidadremoveFromMainArray() {
        for (var j = 0; j < MS_Campos_por_FuncionalidaddeletedItem.length; j++) {
            for (var i = 0; i < MS_Campos_por_FuncionalidadDataMain.length; i++) {
                if (MS_Campos_por_FuncionalidadDataMain[i] != null && MS_Campos_por_FuncionalidadDataMain[i].Id == MS_Campos_por_FuncionalidaddeletedItem[j]) {
                    hMS_Campos_por_FuncionalidadDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Campos_por_FuncionalidadcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Campos_por_FuncionalidadDataMain.length; i++) {
            data[i] = MS_Campos_por_FuncionalidadDataMain[i];

        }
        return data;
    }
    function MS_Campos_por_FuncionalidadgetNewResult() {
        var newData = copyMainMS_Campos_por_FuncionalidadArray();

        for (var i = 0; i < MS_Campos_por_FuncionalidadData.length; i++) {
            if (MS_Campos_por_FuncionalidadData[i].Removed == null || MS_Campos_por_FuncionalidadData[i].Removed == false) {
                newData.splice(0, 0, MS_Campos_por_FuncionalidadData[i]);
            }
        }
        return newData;
    }
    function MS_Campos_por_FuncionalidadpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Campos_por_FuncionalidadDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Campos_por_FuncionalidadDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Funcionalidades_para_Notificacion_cmbLabelSelect").val();
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">' + labelSelect + '</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' >";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control'  data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field, id) {
    
    var dataMain = data == null ? "Select" : data;
    id ==  (id==null   || id==undefined)? "":id;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id +"'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceFolio").val("0");
    $('#CreateFuncionalidades_para_Notificacion')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                   $('#ddlCampos_para_VigenciaMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCampos_para_VigenciaMult').trigger('chosen:updated');

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateFuncionalidades_para_Notificacion').trigger('reset');
    $('#CreateFuncionalidades_para_Notificacion').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
				for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                    CKEDITOR.instances[instance].setData('');
                }
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateFuncionalidades_para_Notificacion');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_Campos_por_FuncionalidadcountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Campos_por_Funcionalidad();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateFuncionalidades_para_Notificacion").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateFuncionalidades_para_Notificacion").on('click', '#Funcionalidades_para_NotificacionCancelar', function () {
	  if (!isPartial) {
        Funcionalidades_para_NotificacionBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateFuncionalidades_para_Notificacion").on('click', '#Funcionalidades_para_NotificacionGuardar', function () {
		$('#Funcionalidades_para_NotificacionGuardar').attr('disabled', true);
		$('#Funcionalidades_para_NotificacionGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendFuncionalidades_para_NotificacionData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Funcionalidades_para_NotificacionBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Funcionalidades_para_Notificacion', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Funcionalidades_para_NotificacionGuardar').removeAttr('disabled');
					$('#Funcionalidades_para_NotificacionGuardar').bind()
				}
		}
		else {
			$('#Funcionalidades_para_NotificacionGuardar').removeAttr('disabled');
			$('#Funcionalidades_para_NotificacionGuardar').bind()
		}
    });
	$("form#CreateFuncionalidades_para_Notificacion").on('click', '#Funcionalidades_para_NotificacionGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendFuncionalidades_para_NotificacionData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_Campos_por_FuncionalidadData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Funcionalidades_para_Notificacion', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateFuncionalidades_para_Notificacion").on('click', '#Funcionalidades_para_NotificacionGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendFuncionalidades_para_NotificacionData(function (currentId) {
					$("#FolioId").val("0");
	                   $('#ddlCampos_para_VigenciaMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCampos_para_VigenciaMult').trigger('chosen:updated');

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMS_Campos_por_FuncionalidadData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Funcionalidades_para_Notificacion',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Funcionalidades_para_NotificacionDropDown().get(0)').innerHTML);                          
					    }	
					}						
			setIsNew();
				});
		}
    });
});

function setIsNew() {
    $('#hdnIsNew').val("True");
	$('#Operation').val("New");
	operation = "New";
}



var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}

function getElementTable(elementNumber, table) {

    for (var j = 0; j < childElementObject.length; j++) {
        if (childElementObject[j].table == table) {
            return childElementObject[j].elements[elementNumber];
            break;
        }
    }
}

function setRequired(elementNumber, element, elementType, table) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!getElementTable(elementNumber, table).IsVisible && getElementTable(elementNumber, table).IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (getElementTable(elementNumber, table).IsReadOnly && getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ?GetTraduction('Disabled') : GetTraduction('Enabled')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? GetTraduction('Disabled') : GetTraduction('Enabled')));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('DefaultValue'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType, table) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('HelpText'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue(table) {
    debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            getElementTable($('#hdnAttributNumber').val(), table).DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            getElementTable($('#hdnAttributNumber').val(), table).HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(element, table, number) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? GetTraduction("Required") : GetTraduction("NotRequired")) + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? GetTraduction("Visible") : GetTraduction("InVisible")) + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ?GetTraduction("Disabled") :GetTraduction("Enabled")) + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}



var Funcionalidades_para_NotificacionisdisplayBusinessPropery = false;
Funcionalidades_para_NotificacionDisplayBusinessRuleButtons(Funcionalidades_para_NotificacionisdisplayBusinessPropery);
function Funcionalidades_para_NotificacionDisplayBusinessRule() {
    if (!Funcionalidades_para_NotificacionisdisplayBusinessPropery) {
        $('#CreateFuncionalidades_para_Notificacion').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Funcionalidades_para_NotificaciondisplayBusinessPropery"><button onclick="Funcionalidades_para_NotificacionGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Funcionalidades_para_NotificacionBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Funcionalidades_para_NotificaciondisplayBusinessPropery').remove();
    }
    Funcionalidades_para_NotificacionDisplayBusinessRuleButtons(!Funcionalidades_para_NotificacionisdisplayBusinessPropery);
    Funcionalidades_para_NotificacionisdisplayBusinessPropery = (Funcionalidades_para_NotificacionisdisplayBusinessPropery ? false : true);
}
function Funcionalidades_para_NotificacionDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

