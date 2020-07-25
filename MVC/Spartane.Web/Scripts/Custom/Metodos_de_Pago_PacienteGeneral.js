

//Begin Declarations for Foreigns fields for MR_Tarjetas MultiRow
var MR_TarjetascountRowsChecked = 0;

function GetMR_Tarjetas_Tipo_de_TarjetaName(Id) {
    for (var i = 0; i < MR_Tarjetas_Tipo_de_TarjetaItems.length; i++) {
        if (MR_Tarjetas_Tipo_de_TarjetaItems[i].Clave == Id) {
            return MR_Tarjetas_Tipo_de_TarjetaItems[i].Descripcion;
        }
    }
    return "";
}

function GetMR_Tarjetas_Tipo_de_TarjetaDropDown() {
    var MR_Tarjetas_Tipo_de_TarjetaDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Tarjetas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Tarjetas_Tipo_de_TarjetaDropdown);
    if(MR_Tarjetas_Tipo_de_TarjetaItems != null)
    {
       for (var i = 0; i < MR_Tarjetas_Tipo_de_TarjetaItems.length; i++) {
           $('<option />', { value: MR_Tarjetas_Tipo_de_TarjetaItems[i].Clave, text:    MR_Tarjetas_Tipo_de_TarjetaItems[i].Descripcion }).appendTo(MR_Tarjetas_Tipo_de_TarjetaDropdown);
       }
    }
    return MR_Tarjetas_Tipo_de_TarjetaDropdown;
}





function GetMR_Tarjetas_EstatusName(Id) {
    for (var i = 0; i < MR_Tarjetas_EstatusItems.length; i++) {
        if (MR_Tarjetas_EstatusItems[i].Clave == Id) {
            return MR_Tarjetas_EstatusItems[i].Descripcion;
        }
    }
    return "";
}

function GetMR_Tarjetas_EstatusDropDown() {
    var MR_Tarjetas_EstatusDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Tarjetas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Tarjetas_EstatusDropdown);
    if(MR_Tarjetas_EstatusItems != null)
    {
       for (var i = 0; i < MR_Tarjetas_EstatusItems.length; i++) {
           $('<option />', { value: MR_Tarjetas_EstatusItems[i].Clave, text:    MR_Tarjetas_EstatusItems[i].Descripcion }).appendTo(MR_Tarjetas_EstatusDropdown);
       }
    }
    return MR_Tarjetas_EstatusDropdown;
}


function GetInsertMR_TarjetasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetMR_Tarjetas_Tipo_de_TarjetaDropDown()).addClass('MR_Tarjetas_Tipo_de_Tarjeta Tipo_de_Tarjeta').attr('id', 'MR_Tarjetas_Tipo_de_Tarjeta_' + index).attr('data-field', 'Tipo_de_Tarjeta').after($.parseHTML(addNew('MR_Tarjetas', 'Tipo_de_Tarjeta', 'Tipo_de_Tarjeta', 261287)));
    columnData[1] = $($.parseHTML(inputData)).addClass('MR_Tarjetas_Numero_de_Tarjeta Numero_de_Tarjeta').attr('id', 'MR_Tarjetas_Numero_de_Tarjeta_' + index).attr('data-field', 'Numero_de_Tarjeta');
    columnData[2] = $($.parseHTML(inputData)).addClass('MR_Tarjetas_Nombre_del_Titular Nombre_del_Titular').attr('id', 'MR_Tarjetas_Nombre_del_Titular_' + index).attr('data-field', 'Nombre_del_Titular');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('MR_Tarjetas_Ano_de_vigencia Ano_de_vigencia').attr('id', 'MR_Tarjetas_Ano_de_vigencia_' + index).attr('data-field', 'Ano_de_vigencia');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('MR_Tarjetas_Mes_de_vigencia Mes_de_vigencia').attr('id', 'MR_Tarjetas_Mes_de_vigencia_' + index).attr('data-field', 'Mes_de_vigencia');
    columnData[5] = $($.parseHTML(inputData)).addClass('MR_Tarjetas_Alias_de_la_Tarjeta Alias_de_la_Tarjeta').attr('id', 'MR_Tarjetas_Alias_de_la_Tarjeta_' + index).attr('data-field', 'Alias_de_la_Tarjeta');
    columnData[6] = $(GetMR_Tarjetas_EstatusDropDown()).addClass('MR_Tarjetas_Estatus Estatus').attr('id', 'MR_Tarjetas_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('MR_Tarjetas', 'Estatus', 'Estatus', 261293)));


    initiateUIControls();
    return columnData;
}

function MR_TarjetasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRMR_Tarjetas("MR_Tarjetas_", "_" + rowIndex)) {
    var iPage = MR_TarjetasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'MR_Tarjetas';
    var prevData = MR_TarjetasTable.fnGetData(rowIndex);
    var data = MR_TarjetasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Tarjeta:  data.childNodes[counter++].childNodes[0].value
        ,Numero_de_Tarjeta:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_del_Titular:  data.childNodes[counter++].childNodes[0].value
        ,Ano_de_vigencia: data.childNodes[counter++].childNodes[0].value
        ,Mes_de_vigencia: data.childNodes[counter++].childNodes[0].value
        ,Alias_de_la_Tarjeta:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    MR_TarjetasTable.fnUpdate(newData, rowIndex, null, true);
    MR_TarjetasrowCreationGrid(data, newData, rowIndex);
    MR_TarjetasTable.fnPageChange(iPage);
    MR_TarjetascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRMR_Tarjetas("MR_Tarjetas_", "_" + rowIndex);
  }
}

function MR_TarjetasCancelRow(rowIndex) {
    var prevData = MR_TarjetasTable.fnGetData(rowIndex);
    var data = MR_TarjetasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        MR_TarjetasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        MR_TarjetasrowCreationGrid(data, prevData, rowIndex);
    }
	showMR_TarjetasGrid(MR_TarjetasTable.fnGetData());
    MR_TarjetascountRowsChecked--;
	initiateUIControls();
}

function GetMR_TarjetasFromDataTable() {
    var MR_TarjetasData = [];
    var gridData = MR_TarjetasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            MR_TarjetasData.push({
                Folio: gridData[i].Folio

                ,Tipo_de_Tarjeta: gridData[i].Tipo_de_Tarjeta
                ,Numero_de_Tarjeta: gridData[i].Numero_de_Tarjeta
                ,Nombre_del_Titular: gridData[i].Nombre_del_Titular
                ,Ano_de_vigencia: gridData[i].Ano_de_vigencia
                ,Mes_de_vigencia: gridData[i].Mes_de_vigencia
                ,Alias_de_la_Tarjeta: gridData[i].Alias_de_la_Tarjeta
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedMR_TarjetasData.length; i++) {
        if (removedMR_TarjetasData[i] != null && removedMR_TarjetasData[i].Folio > 0)
            MR_TarjetasData.push({
                Folio: removedMR_TarjetasData[i].Folio

                ,Tipo_de_Tarjeta: removedMR_TarjetasData[i].Tipo_de_Tarjeta
                ,Numero_de_Tarjeta: removedMR_TarjetasData[i].Numero_de_Tarjeta
                ,Nombre_del_Titular: removedMR_TarjetasData[i].Nombre_del_Titular
                ,Ano_de_vigencia: removedMR_TarjetasData[i].Ano_de_vigencia
                ,Mes_de_vigencia: removedMR_TarjetasData[i].Mes_de_vigencia
                ,Alias_de_la_Tarjeta: removedMR_TarjetasData[i].Alias_de_la_Tarjeta
                ,Estatus: removedMR_TarjetasData[i].Estatus

                , Removed: true
            });
    }	

    return MR_TarjetasData;
}

function MR_TarjetasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? MR_TarjetasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    MR_TarjetascountRowsChecked++;
    var MR_TarjetasRowElement = "MR_Tarjetas_" + rowIndex.toString();
    var prevData = MR_TarjetasTable.fnGetData(rowIndexTable );
    var row = MR_TarjetasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "MR_Tarjetas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = MR_TarjetasGetUpdateRowControls(prevData, "MR_Tarjetas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + MR_TarjetasRowElement + "')){ MR_TarjetasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='MR_TarjetasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#MR_TarjetasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#MR_TarjetasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setMR_TarjetasValidation();
    initiateUIControls();
    $('.MR_Tarjetas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRMR_Tarjetas(nameOfTable, rowIndexFormed);
    }
}

function MR_TarjetasfnOpenAddRowPopUp() {
    var currentRowIndex = MR_TarjetasTable.fnGetData().length;
    MR_TarjetasfnClickAddRow();
    GetAddMR_TarjetasPopup(currentRowIndex, 0);
}

function MR_TarjetasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = MR_TarjetasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var MR_TarjetasRowElement = "MR_Tarjetas_" + rowIndex.toString();
    var prevData = MR_TarjetasTable.fnGetData(rowIndexTable);
    GetAddMR_TarjetasPopup(rowIndex, 1, prevData.Folio);

    $('#MR_TarjetasTipo_de_Tarjeta').val(prevData.Tipo_de_Tarjeta);
    $('#MR_TarjetasNumero_de_Tarjeta').val(prevData.Numero_de_Tarjeta);
    $('#MR_TarjetasNombre_del_Titular').val(prevData.Nombre_del_Titular);
    $('#MR_TarjetasAno_de_vigencia').val(prevData.Ano_de_vigencia);
    $('#MR_TarjetasMes_de_vigencia').val(prevData.Mes_de_vigencia);
    $('#MR_TarjetasAlias_de_la_Tarjeta').val(prevData.Alias_de_la_Tarjeta);
    $('#MR_TarjetasEstatus').val(prevData.Estatus);

    initiateUIControls();









}

function MR_TarjetasAddInsertRow() {
    if (MR_TarjetasinsertRowCurrentIndex < 1)
    {
        MR_TarjetasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tipo_de_Tarjeta: ""
        ,Numero_de_Tarjeta: ""
        ,Nombre_del_Titular: ""
        ,Ano_de_vigencia: ""
        ,Mes_de_vigencia: ""
        ,Alias_de_la_Tarjeta: ""
        ,Estatus: ""

    }
}

function MR_TarjetasfnClickAddRow() {
    MR_TarjetascountRowsChecked++;
    MR_TarjetasTable.fnAddData(MR_TarjetasAddInsertRow(), true);
    MR_TarjetasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#MR_TarjetasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#MR_TarjetasGrid tbody tr:nth-of-type(' + (MR_TarjetasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRMR_Tarjetas("MR_Tarjetas_", "_" + MR_TarjetasinsertRowCurrentIndex);
}

function MR_TarjetasClearGridData() {
    MR_TarjetasData = [];
    MR_TarjetasdeletedItem = [];
    MR_TarjetasDataMain = [];
    MR_TarjetasDataMainPages = [];
    MR_TarjetasnewItemCount = 0;
    MR_TarjetasmaxItemIndex = 0;
    $("#MR_TarjetasGrid").DataTable().clear();
    $("#MR_TarjetasGrid").DataTable().destroy();
}

//Used to Get Métodos de Pago Paciente Information
function GetMR_Tarjetas() {
    var form_data = new FormData();
    for (var i = 0; i < MR_TarjetasData.length; i++) {
        form_data.append('[' + i + '].Folio', MR_TarjetasData[i].Folio);

        form_data.append('[' + i + '].Tipo_de_Tarjeta', MR_TarjetasData[i].Tipo_de_Tarjeta);
        form_data.append('[' + i + '].Numero_de_Tarjeta', MR_TarjetasData[i].Numero_de_Tarjeta);
        form_data.append('[' + i + '].Nombre_del_Titular', MR_TarjetasData[i].Nombre_del_Titular);
        form_data.append('[' + i + '].Ano_de_vigencia', MR_TarjetasData[i].Ano_de_vigencia);
        form_data.append('[' + i + '].Mes_de_vigencia', MR_TarjetasData[i].Mes_de_vigencia);
        form_data.append('[' + i + '].Alias_de_la_Tarjeta', MR_TarjetasData[i].Alias_de_la_Tarjeta);
        form_data.append('[' + i + '].Estatus', MR_TarjetasData[i].Estatus);

        form_data.append('[' + i + '].Removed', MR_TarjetasData[i].Removed);
    }
    return form_data;
}
function MR_TarjetasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRMR_Tarjetas("MR_TarjetasTable", rowIndex)) {
    var prevData = MR_TarjetasTable.fnGetData(rowIndex);
    var data = MR_TarjetasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Tarjeta: $('#MR_TarjetasTipo_de_Tarjeta').val()
        ,Numero_de_Tarjeta: $('#MR_TarjetasNumero_de_Tarjeta').val()
        ,Nombre_del_Titular: $('#MR_TarjetasNombre_del_Titular').val()
        ,Ano_de_vigencia: $('#MR_TarjetasAno_de_vigencia').val()

        ,Mes_de_vigencia: $('#MR_TarjetasMes_de_vigencia').val()

        ,Alias_de_la_Tarjeta: $('#MR_TarjetasAlias_de_la_Tarjeta').val()
        ,Estatus: $('#MR_TarjetasEstatus').val()

    }

    MR_TarjetasTable.fnUpdate(newData, rowIndex, null, true);
    MR_TarjetasrowCreationGrid(data, newData, rowIndex);
    $('#AddMR_Tarjetas-form').modal({ show: false });
    $('#AddMR_Tarjetas-form').modal('hide');
    MR_TarjetasEditRow(rowIndex);
    MR_TarjetasInsertRow(rowIndex);
    //}
}
function MR_TarjetasRemoveAddRow(rowIndex) {
    MR_TarjetasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for MR_Tarjetas MultiRow


$(function () {
    function MR_TarjetasinitializeMainArray(totalCount) {
        if (MR_TarjetasDataMain.length != totalCount && !MR_TarjetasDataMainInitialized) {
            MR_TarjetasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MR_TarjetasDataMain[i] = null;
            }
        }
    }
    function MR_TarjetasremoveFromMainArray() {
        for (var j = 0; j < MR_TarjetasdeletedItem.length; j++) {
            for (var i = 0; i < MR_TarjetasDataMain.length; i++) {
                if (MR_TarjetasDataMain[i] != null && MR_TarjetasDataMain[i].Id == MR_TarjetasdeletedItem[j]) {
                    hMR_TarjetasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MR_TarjetascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MR_TarjetasDataMain.length; i++) {
            data[i] = MR_TarjetasDataMain[i];

        }
        return data;
    }
    function MR_TarjetasgetNewResult() {
        var newData = copyMainMR_TarjetasArray();

        for (var i = 0; i < MR_TarjetasData.length; i++) {
            if (MR_TarjetasData[i].Removed == null || MR_TarjetasData[i].Removed == false) {
                newData.splice(0, 0, MR_TarjetasData[i]);
            }
        }
        return newData;
    }
    function MR_TarjetaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MR_TarjetasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MR_TarjetasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Metodos_de_Pago_Paciente_cmbLabelSelect").val();
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
    $('#CreateMetodos_de_Pago_Paciente')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                MR_TarjetasClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateMetodos_de_Pago_Paciente').trigger('reset');
    $('#CreateMetodos_de_Pago_Paciente').find(':input').each(function () {
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
    var $myForm = $('#CreateMetodos_de_Pago_Paciente');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MR_TarjetascountRowsChecked > 0)
    {
        ShowMessagePendingRowMR_Tarjetas();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateMetodos_de_Pago_Paciente").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateMetodos_de_Pago_Paciente").on('click', '#Metodos_de_Pago_PacienteCancelar', function () {
	  if (!isPartial) {
        Metodos_de_Pago_PacienteBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateMetodos_de_Pago_Paciente").on('click', '#Metodos_de_Pago_PacienteGuardar', function () {
		$('#Metodos_de_Pago_PacienteGuardar').attr('disabled', true);
		$('#Metodos_de_Pago_PacienteGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendMetodos_de_Pago_PacienteData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial  && !viewInEframe)
						Metodos_de_Pago_PacienteBackToGrid();
					else if (viewInEframe) 
                    {
                        $('#Metodos_de_Pago_PacienteGuardar').removeAttr('disabled');
                        $('#Metodos_de_Pago_PacienteGuardar').bind()
                    }
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Metodos_de_Pago_Paciente', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Metodos_de_Pago_PacienteGuardar').removeAttr('disabled');
					$('#Metodos_de_Pago_PacienteGuardar').bind()
				}
		}
		else {
			$('#Metodos_de_Pago_PacienteGuardar').removeAttr('disabled');
			$('#Metodos_de_Pago_PacienteGuardar').bind()
		}
    });
	$("form#CreateMetodos_de_Pago_Paciente").on('click', '#Metodos_de_Pago_PacienteGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendMetodos_de_Pago_PacienteData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMR_TarjetasData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Metodos_de_Pago_Paciente', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateMetodos_de_Pago_Paciente").on('click', '#Metodos_de_Pago_PacienteGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendMetodos_de_Pago_PacienteData(function (currentId) {
					$("#FolioId").val("0");
	                MR_TarjetasClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMR_TarjetasData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Metodos_de_Pago_Paciente',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Metodos_de_Pago_PacienteDropDown().get(0)').innerHTML);                          
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



var Metodos_de_Pago_PacienteisdisplayBusinessPropery = false;
Metodos_de_Pago_PacienteDisplayBusinessRuleButtons(Metodos_de_Pago_PacienteisdisplayBusinessPropery);
function Metodos_de_Pago_PacienteDisplayBusinessRule() {
    if (!Metodos_de_Pago_PacienteisdisplayBusinessPropery) {
        $('#CreateMetodos_de_Pago_Paciente').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Metodos_de_Pago_PacientedisplayBusinessPropery"><button onclick="Metodos_de_Pago_PacienteGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Metodos_de_Pago_PacienteBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Metodos_de_Pago_PacientedisplayBusinessPropery').remove();
    }
    Metodos_de_Pago_PacienteDisplayBusinessRuleButtons(!Metodos_de_Pago_PacienteisdisplayBusinessPropery);
    Metodos_de_Pago_PacienteisdisplayBusinessPropery = (Metodos_de_Pago_PacienteisdisplayBusinessPropery ? false : true);
}
function Metodos_de_Pago_PacienteDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

