﻿



$(function () {

});



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' readonly='readonly'>";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control' readonly='readonly' data-autoclose='true'>";
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

function GetGridAutoComplete(data,field) {
    
    var dataMain = data == null ? "Select" : data;
    
    return "<select class='" + field + " form-control' style='width: 250px'><option>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceFormatFieldId").val("0");
    $('#CreateSpartan_Format_Field')[0].reset();
    ClearFormControls();
    $("#FormatFieldIdId").val("0");

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_Format_Field').trigger('reset');
    $('#CreateSpartan_Format_Field').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateSpartan_Format_Field');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFormatFieldId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_Format_Field").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateSpartan_Format_Field").on('click', '#Spartan_Format_FieldCancelar', function () {
        BackToGrid();
    });
	$("form#CreateSpartan_Format_Field").on('click', '#Spartan_Format_FieldGuardar', function () {
        EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendSpartan_Format_FieldData(function () {
                EjecutarValidacionesDespuesDeGuardar();
                BackToGrid();
            });
    });
	$("form#CreateSpartan_Format_Field").on('click', '#Spartan_Format_FieldGuardarYNuevo', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation()) {
            SendSpartan_Format_FieldData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();

				EjecutarValidacionesDespuesDeGuardar();
            });
        }
    });
    $("form#CreateSpartan_Format_Field").on('click', '#Spartan_Format_FieldGuardarYCopia', function () {
		EjecutarValidacionesAntesDeGuardar();
        if (CheckValidation())
            SendSpartan_Format_FieldData(function (currentId) {
                $("#FormatFieldIdId").val("0");

                ResetClaveLabel();
                $("#ReferenceFormatFieldId").val(currentId);

				EjecutarValidacionesDespuesDeGuardar();
            });
    });
});
var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}
function setRequired(elementNumber, element, elementType) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        childElementObject[elementNumber].IsRequired = (childElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!childElementObject[elementNumber].IsVisible && childElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (childElementObject[elementNumber].IsReadOnly && childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && childElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsVisible = (childElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    }
}
function setReadOnly(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && !childElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsReadOnly = (childElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    }
}
function setDefaultValue(elementNumber, element, elementType) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Default Value');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Help Text');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue() {
    //debugger;
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
            childElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            childElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(elementNumber) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (childElementObject[elementNumber].IsRequired == true ? "Required" : "Not Required") + '" onclick="setRequired(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (childElementObject[elementNumber].IsVisible == true ? "Visible" : "In Visible") + '" onclick="setVisible(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (childElementObject[elementNumber].IsReadOnly == true ? "Disabled" : "Enabled") + '" onclick="setReadOnly(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + elementNumber.toString() + '" class="defaultValueClick" title="' + (childElementObject[elementNumber].DefaultValue) + '" onclick="setDefaultValue(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].DefaultValue != '' && childElementObject[elementNumber].DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + elementNumber.toString() + '" class="helpTextClick" title="' + (childElementObject[elementNumber].HelpText) + '" onclick="setHelpText(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].HelpText != '' && childElementObject[elementNumber].HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}
var Spartan_Format_FieldisdisplayBusinessPropery = false;
Spartan_Format_FieldDisplayBusinessRuleButtons(Spartan_Format_FieldisdisplayBusinessPropery);
function Spartan_Format_FieldDisplayBusinessRule() {
    if (!Spartan_Format_FieldisdisplayBusinessPropery) {
        $('#CreateSpartan_Format_Field').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = $(this).data('field-id');
            var fieldName = $(this).data('field-name');
            var attribute = $(this).data('attribute');
            mainElementAttributes += '<div class="Spartan_Format_FielddisplayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Spartan_Format_FieldPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Spartan_Format_FielddisplayBusinessPropery').remove();
    }
    Spartan_Format_FieldDisplayBusinessRuleButtons(!Spartan_Format_FieldisdisplayBusinessPropery);
    Spartan_Format_FieldisdisplayBusinessPropery = (Spartan_Format_FieldisdisplayBusinessPropery ? false : true);
}
function Spartan_Format_FieldDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}
