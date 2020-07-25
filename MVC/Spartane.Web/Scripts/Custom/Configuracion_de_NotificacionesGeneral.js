

var Roles_para_NotificarcountRowsChecked = 0;
function GetRoles_para_NotificarFromDataTable() {
    var Roles_para_NotificarData = [];
    debugger;

    var items = $("#ddlDirigido_aMult").chosen().val();
    //es nuevo 
    if (Roles_para_NotificarDataDataTable == undefined || Roles_para_NotificarDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                Roles_para_NotificarData.push({ 
                      Folio: 0
                      
, Rol: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < Roles_para_NotificarDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (Roles_para_NotificarDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    Roles_para_NotificarData.push({
                        Folio: Roles_para_NotificarDataDataTable[i].Folio
                        
                   , Rol: Roles_para_NotificarDataDataTable[i].Rol

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
                    for (var j = 0; j < Roles_para_NotificarDataDataTable.length; j++) {
                        if (items[i] == Roles_para_NotificarDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        Roles_para_NotificarData.push({ 
                              Folio: 0
                              
, Rol: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return Roles_para_NotificarData;
}

//Used to Get Configuración de Notificaciones Information
function GetRoles_para_Notificar() {
    var form_data = new FormData();
    for (var i = 0; i < Roles_para_NotificarData.length; i++) {
       form_data.append('[' + i + '].Folio', Roles_para_NotificarData[i].Folio);
       
      form_data.append('[' + i +'].Rol',Roles_para_NotificarData[i].Rol);


       form_data.append('[' + i + '].Removed', Roles_para_NotificarData[i].Removed);
    }
    return form_data;
}

//Begin Declarations for Foreigns fields for Detalle_Frecuencia_Notificaciones MultiRow
var Detalle_Frecuencia_NotificacionescountRowsChecked = 0;

function GetDetalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionName(Id) {
    for (var i = 0; i < Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems.length; i++) {
        if (Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems[i].Clave == Id) {
            return Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropDown() {
    var Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Frecuencia_Notificaciones_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropdown);
    if(Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems != null)
    {
       for (var i = 0; i < Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems.length; i++) {
           $('<option />', { value: Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems[i].Clave, text:    Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionItems[i].Descripcion }).appendTo(Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropdown);
       }
    }
    return Detalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropdown;
}
function GetDetalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionName(Id) {
    for (var i = 0; i < Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems.length; i++) {
        if (Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems[i].Clave == Id) {
            return Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropDown() {
    var Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Frecuencia_Notificaciones_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropdown);
    if(Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems != null)
    {
       for (var i = 0; i < Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems.length; i++) {
           $('<option />', { value: Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems[i].Clave, text:    Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionItems[i].Descripcion }).appendTo(Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropdown);
       }
    }
    return Detalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropdown;
}



function GetInsertDetalle_Frecuencia_NotificacionesRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Frecuencia_Notificaciones_Tipo_Frecuencia_NotificacionDropDown()).addClass('Detalle_Frecuencia_Notificaciones_Frecuencia Frecuencia').attr('id', 'Detalle_Frecuencia_Notificaciones_Frecuencia_' + index).attr('data-field', 'Frecuencia').after($.parseHTML(addNew('Detalle_Frecuencia_Notificaciones', 'Tipo_Frecuencia_Notificacion', 'Frecuencia', 260607)));
    columnData[1] = $(GetDetalle_Frecuencia_Notificaciones_Tipo_Dia_NotificacionDropDown()).addClass('Detalle_Frecuencia_Notificaciones_Dia Dia').attr('id', 'Detalle_Frecuencia_Notificaciones_Dia_' + index).attr('data-field', 'Dia').after($.parseHTML(addNew('Detalle_Frecuencia_Notificaciones', 'Tipo_Dia_Notificacion', 'Dia', 260608)));
    columnData[2] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Frecuencia_Notificaciones_Hora Hora').attr('id', 'Detalle_Frecuencia_Notificaciones_Hora_' + index).attr('data-field', 'Hora');


    initiateUIControls();
    return columnData;
}

function Detalle_Frecuencia_NotificacionesInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Frecuencia_Notificaciones("Detalle_Frecuencia_Notificaciones_", "_" + rowIndex)) {
    var iPage = Detalle_Frecuencia_NotificacionesTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Frecuencia_Notificaciones';
    var prevData = Detalle_Frecuencia_NotificacionesTable.fnGetData(rowIndex);
    var data = Detalle_Frecuencia_NotificacionesTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Frecuencia:  data.childNodes[counter++].childNodes[0].value
        ,Dia:  data.childNodes[counter++].childNodes[0].value
        ,Hora:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Frecuencia_NotificacionesTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Frecuencia_NotificacionesrowCreationGrid(data, newData, rowIndex);
    Detalle_Frecuencia_NotificacionesTable.fnPageChange(iPage);
    Detalle_Frecuencia_NotificacionescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Frecuencia_Notificaciones("Detalle_Frecuencia_Notificaciones_", "_" + rowIndex);
  }
}

function Detalle_Frecuencia_NotificacionesCancelRow(rowIndex) {
    var prevData = Detalle_Frecuencia_NotificacionesTable.fnGetData(rowIndex);
    var data = Detalle_Frecuencia_NotificacionesTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Frecuencia_NotificacionesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Frecuencia_NotificacionesrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Frecuencia_NotificacionesGrid(Detalle_Frecuencia_NotificacionesTable.fnGetData());
    Detalle_Frecuencia_NotificacionescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Frecuencia_NotificacionesFromDataTable() {
    var Detalle_Frecuencia_NotificacionesData = [];
    var gridData = Detalle_Frecuencia_NotificacionesTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Frecuencia_NotificacionesData.push({
                Folio: gridData[i].Folio

                ,Frecuencia: gridData[i].Frecuencia
                ,Dia: gridData[i].Dia
                ,Hora: gridData[i].Hora

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Frecuencia_NotificacionesData.length; i++) {
        if (removedDetalle_Frecuencia_NotificacionesData[i] != null && removedDetalle_Frecuencia_NotificacionesData[i].Folio > 0)
            Detalle_Frecuencia_NotificacionesData.push({
                Folio: removedDetalle_Frecuencia_NotificacionesData[i].Folio

                ,Frecuencia: removedDetalle_Frecuencia_NotificacionesData[i].Frecuencia
                ,Dia: removedDetalle_Frecuencia_NotificacionesData[i].Dia
                ,Hora: removedDetalle_Frecuencia_NotificacionesData[i].Hora

                , Removed: true
            });
    }	

    return Detalle_Frecuencia_NotificacionesData;
}

function Detalle_Frecuencia_NotificacionesEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Frecuencia_NotificacionesTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Frecuencia_NotificacionescountRowsChecked++;
    var Detalle_Frecuencia_NotificacionesRowElement = "Detalle_Frecuencia_Notificaciones_" + rowIndex.toString();
    var prevData = Detalle_Frecuencia_NotificacionesTable.fnGetData(rowIndexTable );
    var row = Detalle_Frecuencia_NotificacionesTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Frecuencia_Notificaciones_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Frecuencia_NotificacionesGetUpdateRowControls(prevData, "Detalle_Frecuencia_Notificaciones_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Frecuencia_NotificacionesRowElement + "')){ Detalle_Frecuencia_NotificacionesInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Frecuencia_NotificacionesCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Frecuencia_NotificacionesGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Frecuencia_NotificacionesGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Frecuencia_NotificacionesValidation();
    initiateUIControls();
    $('.Detalle_Frecuencia_Notificaciones' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Frecuencia_Notificaciones(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Frecuencia_NotificacionesfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Frecuencia_NotificacionesTable.fnGetData().length;
    Detalle_Frecuencia_NotificacionesfnClickAddRow();
    GetAddDetalle_Frecuencia_NotificacionesPopup(currentRowIndex, 0);
}

function Detalle_Frecuencia_NotificacionesEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Frecuencia_NotificacionesTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Frecuencia_NotificacionesRowElement = "Detalle_Frecuencia_Notificaciones_" + rowIndex.toString();
    var prevData = Detalle_Frecuencia_NotificacionesTable.fnGetData(rowIndexTable);
    GetAddDetalle_Frecuencia_NotificacionesPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Frecuencia_NotificacionesFrecuencia').val(prevData.Frecuencia);
    $('#Detalle_Frecuencia_NotificacionesDia').val(prevData.Dia);
    $('#Detalle_Frecuencia_NotificacionesHora').val(prevData.Hora);

    initiateUIControls();





}

function Detalle_Frecuencia_NotificacionesAddInsertRow() {
    if (Detalle_Frecuencia_NotificacionesinsertRowCurrentIndex < 1)
    {
        Detalle_Frecuencia_NotificacionesinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Frecuencia: ""
        ,Dia: ""
        ,Hora: ""

    }
}

function Detalle_Frecuencia_NotificacionesfnClickAddRow() {
    Detalle_Frecuencia_NotificacionescountRowsChecked++;
    Detalle_Frecuencia_NotificacionesTable.fnAddData(Detalle_Frecuencia_NotificacionesAddInsertRow(), true);
    Detalle_Frecuencia_NotificacionesTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Frecuencia_NotificacionesGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Frecuencia_NotificacionesGrid tbody tr:nth-of-type(' + (Detalle_Frecuencia_NotificacionesinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Frecuencia_Notificaciones("Detalle_Frecuencia_Notificaciones_", "_" + Detalle_Frecuencia_NotificacionesinsertRowCurrentIndex);
}

function Detalle_Frecuencia_NotificacionesClearGridData() {
    Detalle_Frecuencia_NotificacionesData = [];
    Detalle_Frecuencia_NotificacionesdeletedItem = [];
    Detalle_Frecuencia_NotificacionesDataMain = [];
    Detalle_Frecuencia_NotificacionesDataMainPages = [];
    Detalle_Frecuencia_NotificacionesnewItemCount = 0;
    Detalle_Frecuencia_NotificacionesmaxItemIndex = 0;
    $("#Detalle_Frecuencia_NotificacionesGrid").DataTable().clear();
    $("#Detalle_Frecuencia_NotificacionesGrid").DataTable().destroy();
}

//Used to Get Configuración de Notificaciones Information
function GetDetalle_Frecuencia_Notificaciones() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Frecuencia_NotificacionesData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Frecuencia_NotificacionesData[i].Folio);

        form_data.append('[' + i + '].Frecuencia', Detalle_Frecuencia_NotificacionesData[i].Frecuencia);
        form_data.append('[' + i + '].Dia', Detalle_Frecuencia_NotificacionesData[i].Dia);
        form_data.append('[' + i + '].Hora', Detalle_Frecuencia_NotificacionesData[i].Hora);

        form_data.append('[' + i + '].Removed', Detalle_Frecuencia_NotificacionesData[i].Removed);
    }
    return form_data;
}
function Detalle_Frecuencia_NotificacionesInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Frecuencia_Notificaciones("Detalle_Frecuencia_NotificacionesTable", rowIndex)) {
    var prevData = Detalle_Frecuencia_NotificacionesTable.fnGetData(rowIndex);
    var data = Detalle_Frecuencia_NotificacionesTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Frecuencia: $('#Detalle_Frecuencia_NotificacionesFrecuencia').val()
        ,Dia: $('#Detalle_Frecuencia_NotificacionesDia').val()
        ,Hora: $('#Detalle_Frecuencia_NotificacionesHora').val()

    }

    Detalle_Frecuencia_NotificacionesTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Frecuencia_NotificacionesrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Frecuencia_Notificaciones-form').modal({ show: false });
    $('#AddDetalle_Frecuencia_Notificaciones-form').modal('hide');
    Detalle_Frecuencia_NotificacionesEditRow(rowIndex);
    Detalle_Frecuencia_NotificacionesInsertRow(rowIndex);
    //}
}
function Detalle_Frecuencia_NotificacionesRemoveAddRow(rowIndex) {
    Detalle_Frecuencia_NotificacionesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Frecuencia_Notificaciones MultiRow


$(function () {
    function Roles_para_NotificarinitializeMainArray(totalCount) {
        if (Roles_para_NotificarDataMain.length != totalCount && !Roles_para_NotificarDataMainInitialized) {
            Roles_para_NotificarDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Roles_para_NotificarDataMain[i] = null;
            }
        }
    }
    function Roles_para_NotificarremoveFromMainArray() {
        for (var j = 0; j < Roles_para_NotificardeletedItem.length; j++) {
            for (var i = 0; i < Roles_para_NotificarDataMain.length; i++) {
                if (Roles_para_NotificarDataMain[i] != null && Roles_para_NotificarDataMain[i].Id == Roles_para_NotificardeletedItem[j]) {
                    hRoles_para_NotificarDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Roles_para_NotificarcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Roles_para_NotificarDataMain.length; i++) {
            data[i] = Roles_para_NotificarDataMain[i];

        }
        return data;
    }
    function Roles_para_NotificargetNewResult() {
        var newData = copyMainRoles_para_NotificarArray();

        for (var i = 0; i < Roles_para_NotificarData.length; i++) {
            if (Roles_para_NotificarData[i].Removed == null || Roles_para_NotificarData[i].Removed == false) {
                newData.splice(0, 0, Roles_para_NotificarData[i]);
            }
        }
        return newData;
    }
    function Roles_para_NotificarpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Roles_para_NotificarDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Roles_para_NotificarDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Frecuencia_NotificacionesinitializeMainArray(totalCount) {
        if (Detalle_Frecuencia_NotificacionesDataMain.length != totalCount && !Detalle_Frecuencia_NotificacionesDataMainInitialized) {
            Detalle_Frecuencia_NotificacionesDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Frecuencia_NotificacionesDataMain[i] = null;
            }
        }
    }
    function Detalle_Frecuencia_NotificacionesremoveFromMainArray() {
        for (var j = 0; j < Detalle_Frecuencia_NotificacionesdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Frecuencia_NotificacionesDataMain.length; i++) {
                if (Detalle_Frecuencia_NotificacionesDataMain[i] != null && Detalle_Frecuencia_NotificacionesDataMain[i].Id == Detalle_Frecuencia_NotificacionesdeletedItem[j]) {
                    hDetalle_Frecuencia_NotificacionesDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Frecuencia_NotificacionescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Frecuencia_NotificacionesDataMain.length; i++) {
            data[i] = Detalle_Frecuencia_NotificacionesDataMain[i];

        }
        return data;
    }
    function Detalle_Frecuencia_NotificacionesgetNewResult() {
        var newData = copyMainDetalle_Frecuencia_NotificacionesArray();

        for (var i = 0; i < Detalle_Frecuencia_NotificacionesData.length; i++) {
            if (Detalle_Frecuencia_NotificacionesData[i].Removed == null || Detalle_Frecuencia_NotificacionesData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Frecuencia_NotificacionesData[i]);
            }
        }
        return newData;
    }
    function Detalle_Frecuencia_NotificacionespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Frecuencia_NotificacionesDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Frecuencia_NotificacionesDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Configuracion_de_Notificaciones_cmbLabelSelect").val();
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
    $('#CreateConfiguracion_de_Notificaciones')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                   $('#ddlDirigido_aMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlDirigido_aMult').trigger('chosen:updated');
                Detalle_Frecuencia_NotificacionesClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateConfiguracion_de_Notificaciones').trigger('reset');
    $('#CreateConfiguracion_de_Notificaciones').find(':input').each(function () {
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
    var $myForm = $('#CreateConfiguracion_de_Notificaciones');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Roles_para_NotificarcountRowsChecked > 0)
    {
        ShowMessagePendingRowRoles_para_Notificar();
        return false;
    }
    if (Detalle_Frecuencia_NotificacionescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Frecuencia_Notificaciones();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateConfiguracion_de_Notificaciones").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateConfiguracion_de_Notificaciones").on('click', '#Configuracion_de_NotificacionesCancelar', function () {
	  if (!isPartial) {
        Configuracion_de_NotificacionesBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateConfiguracion_de_Notificaciones").on('click', '#Configuracion_de_NotificacionesGuardar', function () {
		$('#Configuracion_de_NotificacionesGuardar').attr('disabled', true);
		$('#Configuracion_de_NotificacionesGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendConfiguracion_de_NotificacionesData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Configuracion_de_NotificacionesBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Configuracion_de_Notificaciones', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Configuracion_de_NotificacionesGuardar').removeAttr('disabled');
					$('#Configuracion_de_NotificacionesGuardar').bind()
				}
		}
		else {
			$('#Configuracion_de_NotificacionesGuardar').removeAttr('disabled');
			$('#Configuracion_de_NotificacionesGuardar').bind()
		}
    });
	$("form#CreateConfiguracion_de_Notificaciones").on('click', '#Configuracion_de_NotificacionesGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendConfiguracion_de_NotificacionesData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getRoles_para_NotificarData();
                getDetalle_Frecuencia_NotificacionesData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_de_Notificaciones', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateConfiguracion_de_Notificaciones").on('click', '#Configuracion_de_NotificacionesGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendConfiguracion_de_NotificacionesData(function (currentId) {
					$("#FolioId").val("0");
	                   $('#ddlDirigido_aMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlDirigido_aMult').trigger('chosen:updated');
                Detalle_Frecuencia_NotificacionesClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getRoles_para_NotificarData();
                getDetalle_Frecuencia_NotificacionesData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_de_Notificaciones',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_NotificacionesDropDown().get(0)').innerHTML);                          
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



var Configuracion_de_NotificacionesisdisplayBusinessPropery = false;
Configuracion_de_NotificacionesDisplayBusinessRuleButtons(Configuracion_de_NotificacionesisdisplayBusinessPropery);
function Configuracion_de_NotificacionesDisplayBusinessRule() {
    if (!Configuracion_de_NotificacionesisdisplayBusinessPropery) {
        $('#CreateConfiguracion_de_Notificaciones').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Configuracion_de_NotificacionesdisplayBusinessPropery"><button onclick="Configuracion_de_NotificacionesGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Configuracion_de_NotificacionesBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Configuracion_de_NotificacionesdisplayBusinessPropery').remove();
    }
    Configuracion_de_NotificacionesDisplayBusinessRuleButtons(!Configuracion_de_NotificacionesisdisplayBusinessPropery);
    Configuracion_de_NotificacionesisdisplayBusinessPropery = (Configuracion_de_NotificacionesisdisplayBusinessPropery ? false : true);
}
function Configuracion_de_NotificacionesDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

