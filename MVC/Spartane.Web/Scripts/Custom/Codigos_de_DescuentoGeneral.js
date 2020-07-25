

var MS_Planes_por_Codigo_de_DescuentocountRowsChecked = 0;
function GetMS_Planes_por_Codigo_de_DescuentoFromDataTable() {
    var MS_Planes_por_Codigo_de_DescuentoData = [];
    debugger;

    var items = $("#ddlProductosMult").chosen().val();
    //es nuevo 
    if (MS_Planes_por_Codigo_de_DescuentoDataDataTable == undefined || MS_Planes_por_Codigo_de_DescuentoDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Planes_por_Codigo_de_DescuentoData.push({ 
                      Folio: 0
                      
, Planes_de_Suscripcion: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Planes_por_Codigo_de_DescuentoDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Planes_por_Codigo_de_DescuentoDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Planes_por_Codigo_de_DescuentoData.push({
                        Folio: MS_Planes_por_Codigo_de_DescuentoDataDataTable[i].Folio
                        
                   , Planes_de_Suscripcion: MS_Planes_por_Codigo_de_DescuentoDataDataTable[i].Planes_de_Suscripcion

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
                    for (var j = 0; j < MS_Planes_por_Codigo_de_DescuentoDataDataTable.length; j++) {
                        if (items[i] == MS_Planes_por_Codigo_de_DescuentoDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Planes_por_Codigo_de_DescuentoData.push({ 
                              Folio: 0
                              
, Planes_de_Suscripcion: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Planes_por_Codigo_de_DescuentoData;
}

//Used to Get Códigos de Descuento Information
function GetMS_Planes_por_Codigo_de_Descuento() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Planes_por_Codigo_de_DescuentoData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Planes_por_Codigo_de_DescuentoData[i].Folio);
       
      form_data.append('[' + i +'].Planes_de_Suscripcion',MS_Planes_por_Codigo_de_DescuentoData[i].Planes_de_Suscripcion);


       form_data.append('[' + i + '].Removed', MS_Planes_por_Codigo_de_DescuentoData[i].Removed);
    }
    return form_data;
}

//Begin Declarations for Foreigns fields for MR_Referenciados_Codigo_de_Descuento MultiRow
var MR_Referenciados_Codigo_de_DescuentocountRowsChecked = 0;

function GetMR_Referenciados_Codigo_de_Descuento_Tipo_PacienteName(Id) {
    for (var i = 0; i < MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems.length; i++) {
        if (MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems[i].Clave == Id) {
            return MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems[i].Descripcion;
        }
    }
    return "";
}

function GetMR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropDown() {
    var MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Referenciados_Codigo_de_Descuento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropdown);
    if(MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems != null)
    {
       for (var i = 0; i < MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems.length; i++) {
           $('<option />', { value: MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems[i].Clave, text:    MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteItems[i].Descripcion }).appendTo(MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropdown);
       }
    }
    return MR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropdown;
}
function GetMR_Referenciados_Codigo_de_Descuento_Spartan_UserName(Id) {
    for (var i = 0; i < MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems.length; i++) {
        if (MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems[i].Id_User == Id) {
            return MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetMR_Referenciados_Codigo_de_Descuento_Spartan_UserDropDown() {
    var MR_Referenciados_Codigo_de_Descuento_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Referenciados_Codigo_de_Descuento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Referenciados_Codigo_de_Descuento_Spartan_UserDropdown);
    if(MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems != null)
    {
       for (var i = 0; i < MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems.length; i++) {
           $('<option />', { value: MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems[i].Id_User, text:    MR_Referenciados_Codigo_de_Descuento_Spartan_UserItems[i].Name }).appendTo(MR_Referenciados_Codigo_de_Descuento_Spartan_UserDropdown);
       }
    }
    return MR_Referenciados_Codigo_de_Descuento_Spartan_UserDropdown;
}




function GetInsertMR_Referenciados_Codigo_de_DescuentoRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetMR_Referenciados_Codigo_de_Descuento_Tipo_PacienteDropDown()).addClass('MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario Tipo_de_usuario').attr('id', 'MR_Referenciados_Codigo_de_Descuento_Tipo_de_usuario_' + index).attr('data-field', 'Tipo_de_usuario').after($.parseHTML(addNew('MR_Referenciados_Codigo_de_Descuento', 'Tipo_Paciente', 'Tipo_de_usuario', 260935)));
    columnData[1] = $(GetMR_Referenciados_Codigo_de_Descuento_Spartan_UserDropDown()).addClass('MR_Referenciados_Codigo_de_Descuento_Usuario Usuario').attr('id', 'MR_Referenciados_Codigo_de_Descuento_Usuario_' + index).attr('data-field', 'Usuario').after($.parseHTML(addNew('MR_Referenciados_Codigo_de_Descuento', 'Spartan_User', 'Usuario', 260936)));
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('MR_Referenciados_Codigo_de_Descuento_Fecha_de_aplicacion Fecha_de_aplicacion').attr('id', 'MR_Referenciados_Codigo_de_Descuento_Fecha_de_aplicacion_' + index).attr('data-field', 'Fecha_de_aplicacion');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('MR_Referenciados_Codigo_de_Descuento_Descuento_Total Descuento_Total').attr('id', 'MR_Referenciados_Codigo_de_Descuento_Descuento_Total_' + index).attr('data-field', 'Descuento_Total');


    initiateUIControls();
    return columnData;
}

function MR_Referenciados_Codigo_de_DescuentoInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRMR_Referenciados_Codigo_de_Descuento("MR_Referenciados_Codigo_de_Descuento_", "_" + rowIndex)) {
    var iPage = MR_Referenciados_Codigo_de_DescuentoTable.fnPagingInfo().iPage;
    var nameOfGrid = 'MR_Referenciados_Codigo_de_Descuento';
    var prevData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData(rowIndex);
    var data = MR_Referenciados_Codigo_de_DescuentoTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_usuario:  data.childNodes[counter++].childNodes[0].value
        ,Usuario:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_aplicacion:  data.childNodes[counter++].childNodes[0].value
        ,Descuento_Total: data.childNodes[counter++].childNodes[0].value

    }
    MR_Referenciados_Codigo_de_DescuentoTable.fnUpdate(newData, rowIndex, null, true);
    MR_Referenciados_Codigo_de_DescuentorowCreationGrid(data, newData, rowIndex);
    MR_Referenciados_Codigo_de_DescuentoTable.fnPageChange(iPage);
    MR_Referenciados_Codigo_de_DescuentocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRMR_Referenciados_Codigo_de_Descuento("MR_Referenciados_Codigo_de_Descuento_", "_" + rowIndex);
  }
}

function MR_Referenciados_Codigo_de_DescuentoCancelRow(rowIndex) {
    var prevData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData(rowIndex);
    var data = MR_Referenciados_Codigo_de_DescuentoTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        MR_Referenciados_Codigo_de_DescuentoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        MR_Referenciados_Codigo_de_DescuentorowCreationGrid(data, prevData, rowIndex);
    }
	showMR_Referenciados_Codigo_de_DescuentoGrid(MR_Referenciados_Codigo_de_DescuentoTable.fnGetData());
    MR_Referenciados_Codigo_de_DescuentocountRowsChecked--;
	initiateUIControls();
}

function GetMR_Referenciados_Codigo_de_DescuentoFromDataTable() {
    var MR_Referenciados_Codigo_de_DescuentoData = [];
    var gridData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            MR_Referenciados_Codigo_de_DescuentoData.push({
                Folio: gridData[i].Folio

                ,Tipo_de_usuario: gridData[i].Tipo_de_usuario
                ,Usuario: gridData[i].Usuario
                ,Fecha_de_aplicacion: gridData[i].Fecha_de_aplicacion
                ,Descuento_Total: gridData[i].Descuento_Total

                ,Removed: false
            });
    }

    for (i = 0; i < removedMR_Referenciados_Codigo_de_DescuentoData.length; i++) {
        if (removedMR_Referenciados_Codigo_de_DescuentoData[i] != null && removedMR_Referenciados_Codigo_de_DescuentoData[i].Folio > 0)
            MR_Referenciados_Codigo_de_DescuentoData.push({
                Folio: removedMR_Referenciados_Codigo_de_DescuentoData[i].Folio

                ,Tipo_de_usuario: removedMR_Referenciados_Codigo_de_DescuentoData[i].Tipo_de_usuario
                ,Usuario: removedMR_Referenciados_Codigo_de_DescuentoData[i].Usuario
                ,Fecha_de_aplicacion: removedMR_Referenciados_Codigo_de_DescuentoData[i].Fecha_de_aplicacion
                ,Descuento_Total: removedMR_Referenciados_Codigo_de_DescuentoData[i].Descuento_Total

                , Removed: true
            });
    }	

    return MR_Referenciados_Codigo_de_DescuentoData;
}

function MR_Referenciados_Codigo_de_DescuentoEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? MR_Referenciados_Codigo_de_DescuentoTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    MR_Referenciados_Codigo_de_DescuentocountRowsChecked++;
    var MR_Referenciados_Codigo_de_DescuentoRowElement = "MR_Referenciados_Codigo_de_Descuento_" + rowIndex.toString();
    var prevData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData(rowIndexTable );
    var row = MR_Referenciados_Codigo_de_DescuentoTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "MR_Referenciados_Codigo_de_Descuento_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = MR_Referenciados_Codigo_de_DescuentoGetUpdateRowControls(prevData, "MR_Referenciados_Codigo_de_Descuento_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + MR_Referenciados_Codigo_de_DescuentoRowElement + "')){ MR_Referenciados_Codigo_de_DescuentoInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='MR_Referenciados_Codigo_de_DescuentoCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#MR_Referenciados_Codigo_de_DescuentoGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#MR_Referenciados_Codigo_de_DescuentoGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setMR_Referenciados_Codigo_de_DescuentoValidation();
    initiateUIControls();
    $('.MR_Referenciados_Codigo_de_Descuento' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRMR_Referenciados_Codigo_de_Descuento(nameOfTable, rowIndexFormed);
    }
}

function MR_Referenciados_Codigo_de_DescuentofnOpenAddRowPopUp() {
    var currentRowIndex = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData().length;
    MR_Referenciados_Codigo_de_DescuentofnClickAddRow();
    GetAddMR_Referenciados_Codigo_de_DescuentoPopup(currentRowIndex, 0);
}

function MR_Referenciados_Codigo_de_DescuentoEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = MR_Referenciados_Codigo_de_DescuentoTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var MR_Referenciados_Codigo_de_DescuentoRowElement = "MR_Referenciados_Codigo_de_Descuento_" + rowIndex.toString();
    var prevData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData(rowIndexTable);
    GetAddMR_Referenciados_Codigo_de_DescuentoPopup(rowIndex, 1, prevData.Folio);

    $('#MR_Referenciados_Codigo_de_DescuentoTipo_de_usuario').val(prevData.Tipo_de_usuario);
    $('#MR_Referenciados_Codigo_de_DescuentoUsuario').val(prevData.Usuario);
    $('#MR_Referenciados_Codigo_de_DescuentoFecha_de_aplicacion').val(prevData.Fecha_de_aplicacion);
    $('#MR_Referenciados_Codigo_de_DescuentoDescuento_Total').val(prevData.Descuento_Total);

    initiateUIControls();






}

function MR_Referenciados_Codigo_de_DescuentoAddInsertRow() {
    if (MR_Referenciados_Codigo_de_DescuentoinsertRowCurrentIndex < 1)
    {
        MR_Referenciados_Codigo_de_DescuentoinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tipo_de_usuario: ""
        ,Usuario: ""
        ,Fecha_de_aplicacion: ""
        ,Descuento_Total: ""

    }
}

function MR_Referenciados_Codigo_de_DescuentofnClickAddRow() {
    MR_Referenciados_Codigo_de_DescuentocountRowsChecked++;
    MR_Referenciados_Codigo_de_DescuentoTable.fnAddData(MR_Referenciados_Codigo_de_DescuentoAddInsertRow(), true);
    MR_Referenciados_Codigo_de_DescuentoTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#MR_Referenciados_Codigo_de_DescuentoGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#MR_Referenciados_Codigo_de_DescuentoGrid tbody tr:nth-of-type(' + (MR_Referenciados_Codigo_de_DescuentoinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRMR_Referenciados_Codigo_de_Descuento("MR_Referenciados_Codigo_de_Descuento_", "_" + MR_Referenciados_Codigo_de_DescuentoinsertRowCurrentIndex);
}

function MR_Referenciados_Codigo_de_DescuentoClearGridData() {
    MR_Referenciados_Codigo_de_DescuentoData = [];
    MR_Referenciados_Codigo_de_DescuentodeletedItem = [];
    MR_Referenciados_Codigo_de_DescuentoDataMain = [];
    MR_Referenciados_Codigo_de_DescuentoDataMainPages = [];
    MR_Referenciados_Codigo_de_DescuentonewItemCount = 0;
    MR_Referenciados_Codigo_de_DescuentomaxItemIndex = 0;
    $("#MR_Referenciados_Codigo_de_DescuentoGrid").DataTable().clear();
    $("#MR_Referenciados_Codigo_de_DescuentoGrid").DataTable().destroy();
}

//Used to Get Códigos de Descuento Information
function GetMR_Referenciados_Codigo_de_Descuento() {
    var form_data = new FormData();
    for (var i = 0; i < MR_Referenciados_Codigo_de_DescuentoData.length; i++) {
        form_data.append('[' + i + '].Folio', MR_Referenciados_Codigo_de_DescuentoData[i].Folio);

        form_data.append('[' + i + '].Tipo_de_usuario', MR_Referenciados_Codigo_de_DescuentoData[i].Tipo_de_usuario);
        form_data.append('[' + i + '].Usuario', MR_Referenciados_Codigo_de_DescuentoData[i].Usuario);
        form_data.append('[' + i + '].Fecha_de_aplicacion', MR_Referenciados_Codigo_de_DescuentoData[i].Fecha_de_aplicacion);
        form_data.append('[' + i + '].Descuento_Total', MR_Referenciados_Codigo_de_DescuentoData[i].Descuento_Total);

        form_data.append('[' + i + '].Removed', MR_Referenciados_Codigo_de_DescuentoData[i].Removed);
    }
    return form_data;
}
function MR_Referenciados_Codigo_de_DescuentoInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRMR_Referenciados_Codigo_de_Descuento("MR_Referenciados_Codigo_de_DescuentoTable", rowIndex)) {
    var prevData = MR_Referenciados_Codigo_de_DescuentoTable.fnGetData(rowIndex);
    var data = MR_Referenciados_Codigo_de_DescuentoTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_usuario: $('#MR_Referenciados_Codigo_de_DescuentoTipo_de_usuario').val()
        ,Usuario: $('#MR_Referenciados_Codigo_de_DescuentoUsuario').val()
        ,Fecha_de_aplicacion: $('#MR_Referenciados_Codigo_de_DescuentoFecha_de_aplicacion').val()
        ,Descuento_Total: $('#MR_Referenciados_Codigo_de_DescuentoDescuento_Total').val()

    }

    MR_Referenciados_Codigo_de_DescuentoTable.fnUpdate(newData, rowIndex, null, true);
    MR_Referenciados_Codigo_de_DescuentorowCreationGrid(data, newData, rowIndex);
    $('#AddMR_Referenciados_Codigo_de_Descuento-form').modal({ show: false });
    $('#AddMR_Referenciados_Codigo_de_Descuento-form').modal('hide');
    MR_Referenciados_Codigo_de_DescuentoEditRow(rowIndex);
    MR_Referenciados_Codigo_de_DescuentoInsertRow(rowIndex);
    //}
}
function MR_Referenciados_Codigo_de_DescuentoRemoveAddRow(rowIndex) {
    MR_Referenciados_Codigo_de_DescuentoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for MR_Referenciados_Codigo_de_Descuento MultiRow


$(function () {
    function MS_Planes_por_Codigo_de_DescuentoinitializeMainArray(totalCount) {
        if (MS_Planes_por_Codigo_de_DescuentoDataMain.length != totalCount && !MS_Planes_por_Codigo_de_DescuentoDataMainInitialized) {
            MS_Planes_por_Codigo_de_DescuentoDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Planes_por_Codigo_de_DescuentoDataMain[i] = null;
            }
        }
    }
    function MS_Planes_por_Codigo_de_DescuentoremoveFromMainArray() {
        for (var j = 0; j < MS_Planes_por_Codigo_de_DescuentodeletedItem.length; j++) {
            for (var i = 0; i < MS_Planes_por_Codigo_de_DescuentoDataMain.length; i++) {
                if (MS_Planes_por_Codigo_de_DescuentoDataMain[i] != null && MS_Planes_por_Codigo_de_DescuentoDataMain[i].Id == MS_Planes_por_Codigo_de_DescuentodeletedItem[j]) {
                    hMS_Planes_por_Codigo_de_DescuentoDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Planes_por_Codigo_de_DescuentocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Planes_por_Codigo_de_DescuentoDataMain.length; i++) {
            data[i] = MS_Planes_por_Codigo_de_DescuentoDataMain[i];

        }
        return data;
    }
    function MS_Planes_por_Codigo_de_DescuentogetNewResult() {
        var newData = copyMainMS_Planes_por_Codigo_de_DescuentoArray();

        for (var i = 0; i < MS_Planes_por_Codigo_de_DescuentoData.length; i++) {
            if (MS_Planes_por_Codigo_de_DescuentoData[i].Removed == null || MS_Planes_por_Codigo_de_DescuentoData[i].Removed == false) {
                newData.splice(0, 0, MS_Planes_por_Codigo_de_DescuentoData[i]);
            }
        }
        return newData;
    }
    function MS_Planes_por_Codigo_de_DescuentopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Planes_por_Codigo_de_DescuentoDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Planes_por_Codigo_de_DescuentoDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MR_Referenciados_Codigo_de_DescuentoinitializeMainArray(totalCount) {
        if (MR_Referenciados_Codigo_de_DescuentoDataMain.length != totalCount && !MR_Referenciados_Codigo_de_DescuentoDataMainInitialized) {
            MR_Referenciados_Codigo_de_DescuentoDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MR_Referenciados_Codigo_de_DescuentoDataMain[i] = null;
            }
        }
    }
    function MR_Referenciados_Codigo_de_DescuentoremoveFromMainArray() {
        for (var j = 0; j < MR_Referenciados_Codigo_de_DescuentodeletedItem.length; j++) {
            for (var i = 0; i < MR_Referenciados_Codigo_de_DescuentoDataMain.length; i++) {
                if (MR_Referenciados_Codigo_de_DescuentoDataMain[i] != null && MR_Referenciados_Codigo_de_DescuentoDataMain[i].Id == MR_Referenciados_Codigo_de_DescuentodeletedItem[j]) {
                    hMR_Referenciados_Codigo_de_DescuentoDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MR_Referenciados_Codigo_de_DescuentocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MR_Referenciados_Codigo_de_DescuentoDataMain.length; i++) {
            data[i] = MR_Referenciados_Codigo_de_DescuentoDataMain[i];

        }
        return data;
    }
    function MR_Referenciados_Codigo_de_DescuentogetNewResult() {
        var newData = copyMainMR_Referenciados_Codigo_de_DescuentoArray();

        for (var i = 0; i < MR_Referenciados_Codigo_de_DescuentoData.length; i++) {
            if (MR_Referenciados_Codigo_de_DescuentoData[i].Removed == null || MR_Referenciados_Codigo_de_DescuentoData[i].Removed == false) {
                newData.splice(0, 0, MR_Referenciados_Codigo_de_DescuentoData[i]);
            }
        }
        return newData;
    }
    function MR_Referenciados_Codigo_de_DescuentopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MR_Referenciados_Codigo_de_DescuentoDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MR_Referenciados_Codigo_de_DescuentoDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Codigos_de_Descuento_cmbLabelSelect").val();
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
    $('#CreateCodigos_de_Descuento')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                   $('#ddlProductosMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlProductosMult').trigger('chosen:updated');
                MR_Referenciados_Codigo_de_DescuentoClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateCodigos_de_Descuento').trigger('reset');
    $('#CreateCodigos_de_Descuento').find(':input').each(function () {
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
    var $myForm = $('#CreateCodigos_de_Descuento');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_Planes_por_Codigo_de_DescuentocountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Planes_por_Codigo_de_Descuento();
        return false;
    }
    if (MR_Referenciados_Codigo_de_DescuentocountRowsChecked > 0)
    {
        ShowMessagePendingRowMR_Referenciados_Codigo_de_Descuento();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateCodigos_de_Descuento").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateCodigos_de_Descuento").on('click', '#Codigos_de_DescuentoCancelar', function () {
	  if (!isPartial) {
        Codigos_de_DescuentoBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateCodigos_de_Descuento").on('click', '#Codigos_de_DescuentoGuardar', function () {
		$('#Codigos_de_DescuentoGuardar').attr('disabled', true);
		$('#Codigos_de_DescuentoGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendCodigos_de_DescuentoData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Codigos_de_DescuentoBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Codigos_de_Descuento', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Codigos_de_DescuentoGuardar').removeAttr('disabled');
					$('#Codigos_de_DescuentoGuardar').bind()
				}
		}
		else {
			$('#Codigos_de_DescuentoGuardar').removeAttr('disabled');
			$('#Codigos_de_DescuentoGuardar').bind()
		}
    });
	$("form#CreateCodigos_de_Descuento").on('click', '#Codigos_de_DescuentoGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendCodigos_de_DescuentoData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_Planes_por_Codigo_de_DescuentoData();
                getMR_Referenciados_Codigo_de_DescuentoData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Codigos_de_Descuento', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateCodigos_de_Descuento").on('click', '#Codigos_de_DescuentoGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendCodigos_de_DescuentoData(function (currentId) {
					$("#FolioId").val("0");
	                   $('#ddlProductosMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlProductosMult').trigger('chosen:updated');
                MR_Referenciados_Codigo_de_DescuentoClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMS_Planes_por_Codigo_de_DescuentoData();
                getMR_Referenciados_Codigo_de_DescuentoData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Codigos_de_Descuento',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Codigos_de_DescuentoDropDown().get(0)').innerHTML);                          
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



var Codigos_de_DescuentoisdisplayBusinessPropery = false;
Codigos_de_DescuentoDisplayBusinessRuleButtons(Codigos_de_DescuentoisdisplayBusinessPropery);
function Codigos_de_DescuentoDisplayBusinessRule() {
    if (!Codigos_de_DescuentoisdisplayBusinessPropery) {
        $('#CreateCodigos_de_Descuento').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Codigos_de_DescuentodisplayBusinessPropery"><button onclick="Codigos_de_DescuentoGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Codigos_de_DescuentoBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Codigos_de_DescuentodisplayBusinessPropery').remove();
    }
    Codigos_de_DescuentoDisplayBusinessRuleButtons(!Codigos_de_DescuentoisdisplayBusinessPropery);
    Codigos_de_DescuentoisdisplayBusinessPropery = (Codigos_de_DescuentoisdisplayBusinessPropery ? false : true);
}
function Codigos_de_DescuentoDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

