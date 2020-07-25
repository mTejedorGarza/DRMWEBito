

//Begin Declarations for Foreigns fields for MR_Padecimientos MultiRow
var MR_PadecimientoscountRowsChecked = 0;

function GetMR_Padecimientos_PadecimientosName(Id) {
    for (var i = 0; i < MR_Padecimientos_PadecimientosItems.length; i++) {
        if (MR_Padecimientos_PadecimientosItems[i].Clave == Id) {
            return MR_Padecimientos_PadecimientosItems[i].Descripcion;
        }
    }
    return "";
}

function GetMR_Padecimientos_PadecimientosDropDown() {
    var MR_Padecimientos_PadecimientosDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Padecimientos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Padecimientos_PadecimientosDropdown);
    if(MR_Padecimientos_PadecimientosItems != null)
    {
       for (var i = 0; i < MR_Padecimientos_PadecimientosItems.length; i++) {
           $('<option />', { value: MR_Padecimientos_PadecimientosItems[i].Clave, text:    MR_Padecimientos_PadecimientosItems[i].Descripcion }).appendTo(MR_Padecimientos_PadecimientosDropdown);
       }
    }
    return MR_Padecimientos_PadecimientosDropdown;
}


function GetInsertMR_PadecimientosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetMR_Padecimientos_PadecimientosDropDown()).addClass('MR_Padecimientos_Padecimiento Padecimiento').attr('id', 'MR_Padecimientos_Padecimiento_' + index).attr('data-field', 'Padecimiento').after($.parseHTML(addNew('MR_Padecimientos', 'Padecimientos', 'Padecimiento', 261317)));


    initiateUIControls();
    return columnData;
}

function MR_PadecimientosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRMR_Padecimientos("MR_Padecimientos_", "_" + rowIndex)) {
    var iPage = MR_PadecimientosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'MR_Padecimientos';
    var prevData = MR_PadecimientosTable.fnGetData(rowIndex);
    var data = MR_PadecimientosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Padecimiento:  data.childNodes[counter++].childNodes[0].value

    }
    MR_PadecimientosTable.fnUpdate(newData, rowIndex, null, true);
    MR_PadecimientosrowCreationGrid(data, newData, rowIndex);
    MR_PadecimientosTable.fnPageChange(iPage);
    MR_PadecimientoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRMR_Padecimientos("MR_Padecimientos_", "_" + rowIndex);
  }
}

function MR_PadecimientosCancelRow(rowIndex) {
    var prevData = MR_PadecimientosTable.fnGetData(rowIndex);
    var data = MR_PadecimientosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        MR_PadecimientosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        MR_PadecimientosrowCreationGrid(data, prevData, rowIndex);
    }
	showMR_PadecimientosGrid(MR_PadecimientosTable.fnGetData());
    MR_PadecimientoscountRowsChecked--;
	initiateUIControls();
}

function GetMR_PadecimientosFromDataTable() {
    var MR_PadecimientosData = [];
    var gridData = MR_PadecimientosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            MR_PadecimientosData.push({
                Folio: gridData[i].Folio

                ,Padecimiento: gridData[i].Padecimiento

                ,Removed: false
            });
    }

    for (i = 0; i < removedMR_PadecimientosData.length; i++) {
        if (removedMR_PadecimientosData[i] != null && removedMR_PadecimientosData[i].Folio > 0)
            MR_PadecimientosData.push({
                Folio: removedMR_PadecimientosData[i].Folio

                ,Padecimiento: removedMR_PadecimientosData[i].Padecimiento

                , Removed: true
            });
    }	

    return MR_PadecimientosData;
}

function MR_PadecimientosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? MR_PadecimientosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    MR_PadecimientoscountRowsChecked++;
    var MR_PadecimientosRowElement = "MR_Padecimientos_" + rowIndex.toString();
    var prevData = MR_PadecimientosTable.fnGetData(rowIndexTable );
    var row = MR_PadecimientosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "MR_Padecimientos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = MR_PadecimientosGetUpdateRowControls(prevData, "MR_Padecimientos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + MR_PadecimientosRowElement + "')){ MR_PadecimientosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='MR_PadecimientosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#MR_PadecimientosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#MR_PadecimientosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setMR_PadecimientosValidation();
    initiateUIControls();
    $('.MR_Padecimientos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRMR_Padecimientos(nameOfTable, rowIndexFormed);
    }
}

function MR_PadecimientosfnOpenAddRowPopUp() {
    var currentRowIndex = MR_PadecimientosTable.fnGetData().length;
    MR_PadecimientosfnClickAddRow();
    GetAddMR_PadecimientosPopup(currentRowIndex, 0);
}

function MR_PadecimientosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = MR_PadecimientosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var MR_PadecimientosRowElement = "MR_Padecimientos_" + rowIndex.toString();
    var prevData = MR_PadecimientosTable.fnGetData(rowIndexTable);
    GetAddMR_PadecimientosPopup(rowIndex, 1, prevData.Folio);

    $('#MR_PadecimientosPadecimiento').val(prevData.Padecimiento);

    initiateUIControls();



}

function MR_PadecimientosAddInsertRow() {
    if (MR_PadecimientosinsertRowCurrentIndex < 1)
    {
        MR_PadecimientosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Padecimiento: ""

    }
}

function MR_PadecimientosfnClickAddRow() {
    MR_PadecimientoscountRowsChecked++;
    MR_PadecimientosTable.fnAddData(MR_PadecimientosAddInsertRow(), true);
    MR_PadecimientosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#MR_PadecimientosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#MR_PadecimientosGrid tbody tr:nth-of-type(' + (MR_PadecimientosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRMR_Padecimientos("MR_Padecimientos_", "_" + MR_PadecimientosinsertRowCurrentIndex);
}

function MR_PadecimientosClearGridData() {
    MR_PadecimientosData = [];
    MR_PadecimientosdeletedItem = [];
    MR_PadecimientosDataMain = [];
    MR_PadecimientosDataMainPages = [];
    MR_PadecimientosnewItemCount = 0;
    MR_PadecimientosmaxItemIndex = 0;
    $("#MR_PadecimientosGrid").DataTable().clear();
    $("#MR_PadecimientosGrid").DataTable().destroy();
}

//Used to Get Rangos Pediatría por Platillos Information
function GetMR_Padecimientos() {
    var form_data = new FormData();
    for (var i = 0; i < MR_PadecimientosData.length; i++) {
        form_data.append('[' + i + '].Folio', MR_PadecimientosData[i].Folio);

        form_data.append('[' + i + '].Padecimiento', MR_PadecimientosData[i].Padecimiento);

        form_data.append('[' + i + '].Removed', MR_PadecimientosData[i].Removed);
    }
    return form_data;
}
function MR_PadecimientosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRMR_Padecimientos("MR_PadecimientosTable", rowIndex)) {
    var prevData = MR_PadecimientosTable.fnGetData(rowIndex);
    var data = MR_PadecimientosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Padecimiento: $('#MR_PadecimientosPadecimiento').val()

    }

    MR_PadecimientosTable.fnUpdate(newData, rowIndex, null, true);
    MR_PadecimientosrowCreationGrid(data, newData, rowIndex);
    $('#AddMR_Padecimientos-form').modal({ show: false });
    $('#AddMR_Padecimientos-form').modal('hide');
    MR_PadecimientosEditRow(rowIndex);
    MR_PadecimientosInsertRow(rowIndex);
    //}
}
function MR_PadecimientosRemoveAddRow(rowIndex) {
    MR_PadecimientosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for MR_Padecimientos MultiRow


$(function () {
    function MR_PadecimientosinitializeMainArray(totalCount) {
        if (MR_PadecimientosDataMain.length != totalCount && !MR_PadecimientosDataMainInitialized) {
            MR_PadecimientosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MR_PadecimientosDataMain[i] = null;
            }
        }
    }
    function MR_PadecimientosremoveFromMainArray() {
        for (var j = 0; j < MR_PadecimientosdeletedItem.length; j++) {
            for (var i = 0; i < MR_PadecimientosDataMain.length; i++) {
                if (MR_PadecimientosDataMain[i] != null && MR_PadecimientosDataMain[i].Id == MR_PadecimientosdeletedItem[j]) {
                    hMR_PadecimientosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MR_PadecimientoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MR_PadecimientosDataMain.length; i++) {
            data[i] = MR_PadecimientosDataMain[i];

        }
        return data;
    }
    function MR_PadecimientosgetNewResult() {
        var newData = copyMainMR_PadecimientosArray();

        for (var i = 0; i < MR_PadecimientosData.length; i++) {
            if (MR_PadecimientosData[i].Removed == null || MR_PadecimientosData[i].Removed == false) {
                newData.splice(0, 0, MR_PadecimientosData[i]);
            }
        }
        return newData;
    }
    function MR_PadecimientospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MR_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MR_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Rangos_Pediatria_por_Platillos_cmbLabelSelect").val();
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
    $('#CreateRangos_Pediatria_por_Platillos')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                MR_PadecimientosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateRangos_Pediatria_por_Platillos').trigger('reset');
    $('#CreateRangos_Pediatria_por_Platillos').find(':input').each(function () {
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
    var $myForm = $('#CreateRangos_Pediatria_por_Platillos');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MR_PadecimientoscountRowsChecked > 0)
    {
        ShowMessagePendingRowMR_Padecimientos();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateRangos_Pediatria_por_Platillos").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateRangos_Pediatria_por_Platillos").on('click', '#Rangos_Pediatria_por_PlatillosCancelar', function () {
	  if (!isPartial) {
        Rangos_Pediatria_por_PlatillosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateRangos_Pediatria_por_Platillos").on('click', '#Rangos_Pediatria_por_PlatillosGuardar', function () {
		$('#Rangos_Pediatria_por_PlatillosGuardar').attr('disabled', true);
		$('#Rangos_Pediatria_por_PlatillosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendRangos_Pediatria_por_PlatillosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial  && !viewInEframe)
						Rangos_Pediatria_por_PlatillosBackToGrid();
					else if (viewInEframe) 
                    {
                        $('#Rangos_Pediatria_por_PlatillosGuardar').removeAttr('disabled');
                        $('#Rangos_Pediatria_por_PlatillosGuardar').bind()
                    }
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Rangos_Pediatria_por_Platillos', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Rangos_Pediatria_por_PlatillosGuardar').removeAttr('disabled');
					$('#Rangos_Pediatria_por_PlatillosGuardar').bind()
				}
		}
		else {
			$('#Rangos_Pediatria_por_PlatillosGuardar').removeAttr('disabled');
			$('#Rangos_Pediatria_por_PlatillosGuardar').bind()
		}
    });
	$("form#CreateRangos_Pediatria_por_Platillos").on('click', '#Rangos_Pediatria_por_PlatillosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendRangos_Pediatria_por_PlatillosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMR_PadecimientosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Rangos_Pediatria_por_Platillos', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateRangos_Pediatria_por_Platillos").on('click', '#Rangos_Pediatria_por_PlatillosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendRangos_Pediatria_por_PlatillosData(function (currentId) {
					$("#FolioId").val("0");
	                MR_PadecimientosClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMR_PadecimientosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Rangos_Pediatria_por_Platillos',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Rangos_Pediatria_por_PlatillosDropDown().get(0)').innerHTML);                          
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



var Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery = false;
Rangos_Pediatria_por_PlatillosDisplayBusinessRuleButtons(Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery);
function Rangos_Pediatria_por_PlatillosDisplayBusinessRule() {
    if (!Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery) {
        $('#CreateRangos_Pediatria_por_Platillos').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Rangos_Pediatria_por_PlatillosdisplayBusinessPropery"><button onclick="Rangos_Pediatria_por_PlatillosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Rangos_Pediatria_por_PlatillosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Rangos_Pediatria_por_PlatillosdisplayBusinessPropery').remove();
    }
    Rangos_Pediatria_por_PlatillosDisplayBusinessRuleButtons(!Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery);
    Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery = (Rangos_Pediatria_por_PlatillosisdisplayBusinessPropery ? false : true);
}
function Rangos_Pediatria_por_PlatillosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

