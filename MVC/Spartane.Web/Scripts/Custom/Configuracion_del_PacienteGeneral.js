

//Begin Declarations for Foreigns fields for Detalle_Notificaciones_Paciente MultiRow
var Detalle_Notificaciones_PacientecountRowsChecked = 0;

function GetDetalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionName(Id) {
    for (var i = 0; i < Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems.length; i++) {
        if (Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems[i].Folio == Id) {
            return Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems[i].Funcionalidad;
        }
    }
    return "";
}

function GetDetalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropDown() {
    var Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Notificaciones_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropdown);
    if(Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems != null)
    {
       for (var i = 0; i < Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems.length; i++) {
           $('<option />', { value: Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems[i].Folio, text:    Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionItems[i].Funcionalidad }).appendTo(Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropdown);
       }
    }
    return Detalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropdown;
}


function GetInsertDetalle_Notificaciones_PacienteRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Notificaciones_Paciente_Funcionalidades_para_NotificacionDropDown()).addClass('Detalle_Notificaciones_Paciente_Funcionalidad Funcionalidad').attr('id', 'Detalle_Notificaciones_Paciente_Funcionalidad_' + index).attr('data-field', 'Funcionalidad').after($.parseHTML(addNew('Detalle_Notificaciones_Paciente', 'Funcionalidades_para_Notificacion', 'Funcionalidad', 260589)));


    initiateUIControls();
    return columnData;
}

function Detalle_Notificaciones_PacienteInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Notificaciones_Paciente("Detalle_Notificaciones_Paciente_", "_" + rowIndex)) {
    var iPage = Detalle_Notificaciones_PacienteTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Notificaciones_Paciente';
    var prevData = Detalle_Notificaciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Notificaciones_PacienteTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Funcionalidad:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Notificaciones_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Notificaciones_PacienterowCreationGrid(data, newData, rowIndex);
    Detalle_Notificaciones_PacienteTable.fnPageChange(iPage);
    Detalle_Notificaciones_PacientecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Notificaciones_Paciente("Detalle_Notificaciones_Paciente_", "_" + rowIndex);
  }
}

function Detalle_Notificaciones_PacienteCancelRow(rowIndex) {
    var prevData = Detalle_Notificaciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Notificaciones_PacienteTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Notificaciones_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Notificaciones_PacienterowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Notificaciones_PacienteGrid(Detalle_Notificaciones_PacienteTable.fnGetData());
    Detalle_Notificaciones_PacientecountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Notificaciones_PacienteFromDataTable() {
    var Detalle_Notificaciones_PacienteData = [];
    var gridData = Detalle_Notificaciones_PacienteTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Notificaciones_PacienteData.push({
                Folio: gridData[i].Folio

                ,Funcionalidad: gridData[i].Funcionalidad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Notificaciones_PacienteData.length; i++) {
        if (removedDetalle_Notificaciones_PacienteData[i] != null && removedDetalle_Notificaciones_PacienteData[i].Folio > 0)
            Detalle_Notificaciones_PacienteData.push({
                Folio: removedDetalle_Notificaciones_PacienteData[i].Folio

                ,Funcionalidad: removedDetalle_Notificaciones_PacienteData[i].Funcionalidad

                , Removed: true
            });
    }	

    return Detalle_Notificaciones_PacienteData;
}

function Detalle_Notificaciones_PacienteEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Notificaciones_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Notificaciones_PacientecountRowsChecked++;
    var Detalle_Notificaciones_PacienteRowElement = "Detalle_Notificaciones_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Notificaciones_PacienteTable.fnGetData(rowIndexTable );
    var row = Detalle_Notificaciones_PacienteTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Notificaciones_Paciente_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Notificaciones_PacienteGetUpdateRowControls(prevData, "Detalle_Notificaciones_Paciente_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Notificaciones_PacienteRowElement + "')){ Detalle_Notificaciones_PacienteInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Notificaciones_PacienteCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Notificaciones_PacienteGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Notificaciones_PacienteGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Notificaciones_PacienteValidation();
    initiateUIControls();
    $('.Detalle_Notificaciones_Paciente' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Notificaciones_Paciente(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Notificaciones_PacientefnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Notificaciones_PacienteTable.fnGetData().length;
    Detalle_Notificaciones_PacientefnClickAddRow();
    GetAddDetalle_Notificaciones_PacientePopup(currentRowIndex, 0);
}

function Detalle_Notificaciones_PacienteEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Notificaciones_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Notificaciones_PacienteRowElement = "Detalle_Notificaciones_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Notificaciones_PacienteTable.fnGetData(rowIndexTable);
    GetAddDetalle_Notificaciones_PacientePopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Notificaciones_PacienteFuncionalidad').val(prevData.Funcionalidad);

    initiateUIControls();



}

function Detalle_Notificaciones_PacienteAddInsertRow() {
    if (Detalle_Notificaciones_PacienteinsertRowCurrentIndex < 1)
    {
        Detalle_Notificaciones_PacienteinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Funcionalidad: ""

    }
}

function Detalle_Notificaciones_PacientefnClickAddRow() {
    Detalle_Notificaciones_PacientecountRowsChecked++;
    Detalle_Notificaciones_PacienteTable.fnAddData(Detalle_Notificaciones_PacienteAddInsertRow(), true);
    Detalle_Notificaciones_PacienteTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Notificaciones_PacienteGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Notificaciones_PacienteGrid tbody tr:nth-of-type(' + (Detalle_Notificaciones_PacienteinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Notificaciones_Paciente("Detalle_Notificaciones_Paciente_", "_" + Detalle_Notificaciones_PacienteinsertRowCurrentIndex);
}

function Detalle_Notificaciones_PacienteClearGridData() {
    Detalle_Notificaciones_PacienteData = [];
    Detalle_Notificaciones_PacientedeletedItem = [];
    Detalle_Notificaciones_PacienteDataMain = [];
    Detalle_Notificaciones_PacienteDataMainPages = [];
    Detalle_Notificaciones_PacientenewItemCount = 0;
    Detalle_Notificaciones_PacientemaxItemIndex = 0;
    $("#Detalle_Notificaciones_PacienteGrid").DataTable().clear();
    $("#Detalle_Notificaciones_PacienteGrid").DataTable().destroy();
}

//Used to Get Configuración del Paciente Information
function GetDetalle_Notificaciones_Paciente() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Notificaciones_PacienteData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Notificaciones_PacienteData[i].Folio);

        form_data.append('[' + i + '].Funcionalidad', Detalle_Notificaciones_PacienteData[i].Funcionalidad);

        form_data.append('[' + i + '].Removed', Detalle_Notificaciones_PacienteData[i].Removed);
    }
    return form_data;
}
function Detalle_Notificaciones_PacienteInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Notificaciones_Paciente("Detalle_Notificaciones_PacienteTable", rowIndex)) {
    var prevData = Detalle_Notificaciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Notificaciones_PacienteTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Funcionalidad: $('#Detalle_Notificaciones_PacienteFuncionalidad').val()

    }

    Detalle_Notificaciones_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Notificaciones_PacienterowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Notificaciones_Paciente-form').modal({ show: false });
    $('#AddDetalle_Notificaciones_Paciente-form').modal('hide');
    Detalle_Notificaciones_PacienteEditRow(rowIndex);
    Detalle_Notificaciones_PacienteInsertRow(rowIndex);
    //}
}
function Detalle_Notificaciones_PacienteRemoveAddRow(rowIndex) {
    Detalle_Notificaciones_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Notificaciones_Paciente MultiRow


$(function () {
    function Detalle_Notificaciones_PacienteinitializeMainArray(totalCount) {
        if (Detalle_Notificaciones_PacienteDataMain.length != totalCount && !Detalle_Notificaciones_PacienteDataMainInitialized) {
            Detalle_Notificaciones_PacienteDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Notificaciones_PacienteDataMain[i] = null;
            }
        }
    }
    function Detalle_Notificaciones_PacienteremoveFromMainArray() {
        for (var j = 0; j < Detalle_Notificaciones_PacientedeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Notificaciones_PacienteDataMain.length; i++) {
                if (Detalle_Notificaciones_PacienteDataMain[i] != null && Detalle_Notificaciones_PacienteDataMain[i].Id == Detalle_Notificaciones_PacientedeletedItem[j]) {
                    hDetalle_Notificaciones_PacienteDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Notificaciones_PacientecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Notificaciones_PacienteDataMain.length; i++) {
            data[i] = Detalle_Notificaciones_PacienteDataMain[i];

        }
        return data;
    }
    function Detalle_Notificaciones_PacientegetNewResult() {
        var newData = copyMainDetalle_Notificaciones_PacienteArray();

        for (var i = 0; i < Detalle_Notificaciones_PacienteData.length; i++) {
            if (Detalle_Notificaciones_PacienteData[i].Removed == null || Detalle_Notificaciones_PacienteData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Notificaciones_PacienteData[i]);
            }
        }
        return newData;
    }
    function Detalle_Notificaciones_PacientepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Notificaciones_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Notificaciones_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Configuracion_del_Paciente_cmbLabelSelect").val();
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
    $('#CreateConfiguracion_del_Paciente')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Notificaciones_PacienteClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateConfiguracion_del_Paciente').trigger('reset');
    $('#CreateConfiguracion_del_Paciente').find(':input').each(function () {
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
    var $myForm = $('#CreateConfiguracion_del_Paciente');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Notificaciones_PacientecountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Notificaciones_Paciente();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateConfiguracion_del_Paciente").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateConfiguracion_del_Paciente").on('click', '#Configuracion_del_PacienteCancelar', function () {
	  if (!isPartial) {
        Configuracion_del_PacienteBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateConfiguracion_del_Paciente").on('click', '#Configuracion_del_PacienteGuardar', function () {
		$('#Configuracion_del_PacienteGuardar').attr('disabled', true);
		$('#Configuracion_del_PacienteGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendConfiguracion_del_PacienteData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Configuracion_del_PacienteBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Configuracion_del_Paciente', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Configuracion_del_PacienteGuardar').removeAttr('disabled');
					$('#Configuracion_del_PacienteGuardar').bind()
				}
		}
		else {
			$('#Configuracion_del_PacienteGuardar').removeAttr('disabled');
			$('#Configuracion_del_PacienteGuardar').bind()
		}
    });
	$("form#CreateConfiguracion_del_Paciente").on('click', '#Configuracion_del_PacienteGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendConfiguracion_del_PacienteData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Notificaciones_PacienteData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_del_Paciente', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateConfiguracion_del_Paciente").on('click', '#Configuracion_del_PacienteGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendConfiguracion_del_PacienteData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Notificaciones_PacienteClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Notificaciones_PacienteData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_del_Paciente',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Configuracion_del_PacienteDropDown().get(0)').innerHTML);                          
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



var Configuracion_del_PacienteisdisplayBusinessPropery = false;
Configuracion_del_PacienteDisplayBusinessRuleButtons(Configuracion_del_PacienteisdisplayBusinessPropery);
function Configuracion_del_PacienteDisplayBusinessRule() {
    if (!Configuracion_del_PacienteisdisplayBusinessPropery) {
        $('#CreateConfiguracion_del_Paciente').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Configuracion_del_PacientedisplayBusinessPropery"><button onclick="Configuracion_del_PacienteGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Configuracion_del_PacienteBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Configuracion_del_PacientedisplayBusinessPropery').remove();
    }
    Configuracion_del_PacienteDisplayBusinessRuleButtons(!Configuracion_del_PacienteisdisplayBusinessPropery);
    Configuracion_del_PacienteisdisplayBusinessPropery = (Configuracion_del_PacienteisdisplayBusinessPropery ? false : true);
}
function Configuracion_del_PacienteDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

