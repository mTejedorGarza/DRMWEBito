

var MS_Beneficiarios_SuscripcioncountRowsChecked = 0;
function GetMS_Beneficiarios_SuscripcionFromDataTable() {
    var MS_Beneficiarios_SuscripcionData = [];
    debugger;

    var items = $("#ddlTipo_de_BeneficiarioMult").chosen().val();
    //es nuevo 
    if (MS_Beneficiarios_SuscripcionDataDataTable == undefined || MS_Beneficiarios_SuscripcionDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Beneficiarios_SuscripcionData.push({ 
                      Folio: 0
                      
, Beneficiario: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Beneficiarios_SuscripcionDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Beneficiarios_SuscripcionDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Beneficiarios_SuscripcionData.push({
                        Folio: MS_Beneficiarios_SuscripcionDataDataTable[i].Folio
                        
                   , Beneficiario: MS_Beneficiarios_SuscripcionDataDataTable[i].Beneficiario

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
                    for (var j = 0; j < MS_Beneficiarios_SuscripcionDataDataTable.length; j++) {
                        if (items[i] == MS_Beneficiarios_SuscripcionDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Beneficiarios_SuscripcionData.push({ 
                              Folio: 0
                              
, Beneficiario: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Beneficiarios_SuscripcionData;
}

//Used to Get Planes de Suscripción Information
function GetMS_Beneficiarios_Suscripcion() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Beneficiarios_SuscripcionData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Beneficiarios_SuscripcionData[i].Folio);
       
      form_data.append('[' + i +'].Beneficiario',MS_Beneficiarios_SuscripcionData[i].Beneficiario);


       form_data.append('[' + i + '].Removed', MS_Beneficiarios_SuscripcionData[i].Removed);
    }
    return form_data;
}

var MS_Semanas_PlanescountRowsChecked = 0;
function GetMS_Semanas_PlanesFromDataTable() {
    var MS_Semanas_PlanesData = [];
    debugger;

    var items = $("#ddlSemanas_del_PlanMult").chosen().val();
    //es nuevo 
    if (MS_Semanas_PlanesDataDataTable == undefined || MS_Semanas_PlanesDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Semanas_PlanesData.push({ 
                      Folio: 0
                      
, Semanas: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Semanas_PlanesDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Semanas_PlanesDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Semanas_PlanesData.push({
                        Folio: MS_Semanas_PlanesDataDataTable[i].Folio
                        
                   , Semanas: MS_Semanas_PlanesDataDataTable[i].Semanas

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
                    for (var j = 0; j < MS_Semanas_PlanesDataDataTable.length; j++) {
                        if (items[i] == MS_Semanas_PlanesDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Semanas_PlanesData.push({ 
                              Folio: 0
                              
, Semanas: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Semanas_PlanesData;
}

//Used to Get Planes de Suscripción Information
function GetMS_Semanas_Planes() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Semanas_PlanesData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Semanas_PlanesData[i].Folio);
       
      form_data.append('[' + i +'].Semanas',MS_Semanas_PlanesData[i].Semanas);


       form_data.append('[' + i + '].Removed', MS_Semanas_PlanesData[i].Removed);
    }
    return form_data;
}



$(function () {
    function MS_Beneficiarios_SuscripcioninitializeMainArray(totalCount) {
        if (MS_Beneficiarios_SuscripcionDataMain.length != totalCount && !MS_Beneficiarios_SuscripcionDataMainInitialized) {
            MS_Beneficiarios_SuscripcionDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Beneficiarios_SuscripcionDataMain[i] = null;
            }
        }
    }
    function MS_Beneficiarios_SuscripcionremoveFromMainArray() {
        for (var j = 0; j < MS_Beneficiarios_SuscripciondeletedItem.length; j++) {
            for (var i = 0; i < MS_Beneficiarios_SuscripcionDataMain.length; i++) {
                if (MS_Beneficiarios_SuscripcionDataMain[i] != null && MS_Beneficiarios_SuscripcionDataMain[i].Id == MS_Beneficiarios_SuscripciondeletedItem[j]) {
                    hMS_Beneficiarios_SuscripcionDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Beneficiarios_SuscripcioncopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Beneficiarios_SuscripcionDataMain.length; i++) {
            data[i] = MS_Beneficiarios_SuscripcionDataMain[i];

        }
        return data;
    }
    function MS_Beneficiarios_SuscripciongetNewResult() {
        var newData = copyMainMS_Beneficiarios_SuscripcionArray();

        for (var i = 0; i < MS_Beneficiarios_SuscripcionData.length; i++) {
            if (MS_Beneficiarios_SuscripcionData[i].Removed == null || MS_Beneficiarios_SuscripcionData[i].Removed == false) {
                newData.splice(0, 0, MS_Beneficiarios_SuscripcionData[i]);
            }
        }
        return newData;
    }
    function MS_Beneficiarios_SuscripcionpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Beneficiarios_SuscripcionDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Beneficiarios_SuscripcionDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Semanas_PlanesinitializeMainArray(totalCount) {
        if (MS_Semanas_PlanesDataMain.length != totalCount && !MS_Semanas_PlanesDataMainInitialized) {
            MS_Semanas_PlanesDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Semanas_PlanesDataMain[i] = null;
            }
        }
    }
    function MS_Semanas_PlanesremoveFromMainArray() {
        for (var j = 0; j < MS_Semanas_PlanesdeletedItem.length; j++) {
            for (var i = 0; i < MS_Semanas_PlanesDataMain.length; i++) {
                if (MS_Semanas_PlanesDataMain[i] != null && MS_Semanas_PlanesDataMain[i].Id == MS_Semanas_PlanesdeletedItem[j]) {
                    hMS_Semanas_PlanesDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Semanas_PlanescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Semanas_PlanesDataMain.length; i++) {
            data[i] = MS_Semanas_PlanesDataMain[i];

        }
        return data;
    }
    function MS_Semanas_PlanesgetNewResult() {
        var newData = copyMainMS_Semanas_PlanesArray();

        for (var i = 0; i < MS_Semanas_PlanesData.length; i++) {
            if (MS_Semanas_PlanesData[i].Removed == null || MS_Semanas_PlanesData[i].Removed == false) {
                newData.splice(0, 0, MS_Semanas_PlanesData[i]);
            }
        }
        return newData;
    }
    function MS_Semanas_PlanespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Semanas_PlanesDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Semanas_PlanesDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Planes_de_Suscripcion_cmbLabelSelect").val();
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
    $('#CreatePlanes_de_Suscripcion')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                   $('#ddlTipo_de_BeneficiarioMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlTipo_de_BeneficiarioMult').trigger('chosen:updated');
                   $('#ddlSemanas_del_PlanMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlSemanas_del_PlanMult').trigger('chosen:updated');

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePlanes_de_Suscripcion').trigger('reset');
    $('#CreatePlanes_de_Suscripcion').find(':input').each(function () {
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
    var $myForm = $('#CreatePlanes_de_Suscripcion');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_Beneficiarios_SuscripcioncountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Beneficiarios_Suscripcion();
        return false;
    }
    if (MS_Semanas_PlanescountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Semanas_Planes();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePlanes_de_Suscripcion").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePlanes_de_Suscripcion").on('click', '#Planes_de_SuscripcionCancelar', function () {
	  if (!isPartial) {
        Planes_de_SuscripcionBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePlanes_de_Suscripcion").on('click', '#Planes_de_SuscripcionGuardar', function () {
		$('#Planes_de_SuscripcionGuardar').attr('disabled', true);
		$('#Planes_de_SuscripcionGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPlanes_de_SuscripcionData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Planes_de_SuscripcionBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Planes_de_Suscripcion', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Planes_de_SuscripcionGuardar').removeAttr('disabled');
					$('#Planes_de_SuscripcionGuardar').bind()
				}
		}
		else {
			$('#Planes_de_SuscripcionGuardar').removeAttr('disabled');
			$('#Planes_de_SuscripcionGuardar').bind()
		}
    });
	$("form#CreatePlanes_de_Suscripcion").on('click', '#Planes_de_SuscripcionGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPlanes_de_SuscripcionData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_Beneficiarios_SuscripcionData();
                getMS_Semanas_PlanesData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_de_Suscripcion', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreatePlanes_de_Suscripcion").on('click', '#Planes_de_SuscripcionGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPlanes_de_SuscripcionData(function (currentId) {
					$("#FolioId").val("0");
	                   $('#ddlTipo_de_BeneficiarioMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlTipo_de_BeneficiarioMult').trigger('chosen:updated');
                   $('#ddlSemanas_del_PlanMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlSemanas_del_PlanMult').trigger('chosen:updated');

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMS_Beneficiarios_SuscripcionData();
                getMS_Semanas_PlanesData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_de_Suscripcion',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Planes_de_SuscripcionDropDown().get(0)').innerHTML);                          
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



var Planes_de_SuscripcionisdisplayBusinessPropery = false;
Planes_de_SuscripcionDisplayBusinessRuleButtons(Planes_de_SuscripcionisdisplayBusinessPropery);
function Planes_de_SuscripcionDisplayBusinessRule() {
    if (!Planes_de_SuscripcionisdisplayBusinessPropery) {
        $('#CreatePlanes_de_Suscripcion').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Planes_de_SuscripciondisplayBusinessPropery"><button onclick="Planes_de_SuscripcionGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Planes_de_SuscripcionBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Planes_de_SuscripciondisplayBusinessPropery').remove();
    }
    Planes_de_SuscripcionDisplayBusinessRuleButtons(!Planes_de_SuscripcionisdisplayBusinessPropery);
    Planes_de_SuscripcionisdisplayBusinessPropery = (Planes_de_SuscripcionisdisplayBusinessPropery ? false : true);
}
function Planes_de_SuscripcionDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

