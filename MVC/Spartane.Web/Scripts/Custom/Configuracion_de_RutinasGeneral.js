

//Begin Declarations for Foreigns fields for Detalle_Secuencia_de_Ejercicios MultiRow
var Detalle_Secuencia_de_EjercicioscountRowsChecked = 0;

function GetDetalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasName(Id) {
    for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems.length; i++) {
        if (Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems[i].Folio == Id) {
            return Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropDown() {
    var Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Secuencia_de_Ejercicios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropdown);
    if(Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems != null)
    {
       for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems.length; i++) {
           $('<option />', { value: Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems[i].Folio, text:    Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasItems[i].Descripcion }).appendTo(Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropdown);
       }
    }
    return Detalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropdown;
}
function GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaName(Id) {
    for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems.length; i++) {
        if (Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems[i].Folio == Id) {
            return Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems[i].Nombre_para_Secuencia;
        }
    }
    return "";
}

function GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropDown() {
    var Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Secuencia_de_Ejercicios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropdown);
    if(Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems != null)
    {
       for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems.length; i++) {
           $('<option />', { value: Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems[i].Folio, text:    Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaItems[i].Nombre_para_Secuencia }).appendTo(Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropdown);
       }
    }
    return Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropdown;
}
function GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioName(Id) {
    for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems.length; i++) {
        if (Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems[i].Folio == Id) {
            return Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropDown() {
    var Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Secuencia_de_Ejercicios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropdown);
    if(Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems != null)
    {
       for (var i = 0; i < Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems.length; i++) {
           $('<option />', { value: Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems[i].Folio, text:    Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioItems[i].Descripcion }).appendTo(Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropdown);
       }
    }
    return Detalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropdown;
}



function GetInsertDetalle_Secuencia_de_EjerciciosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Secuencia_de_Ejercicios_Secuencia_de_Ejercicios_en_RutinasDropDown()).addClass('Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio Orden_del_Ejercicio').attr('id', 'Detalle_Secuencia_de_Ejercicios_Orden_del_Ejercicio_' + index).attr('data-field', 'Orden_del_Ejercicio').after($.parseHTML(addNew('Detalle_Secuencia_de_Ejercicios', 'Secuencia_de_Ejercicios_en_Rutinas', 'Orden_del_Ejercicio', 260145)));
    columnData[1] = $(GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_RutinaDropDown()).addClass('Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio Tipo_de_Ejercicio').attr('id', 'Detalle_Secuencia_de_Ejercicios_Tipo_de_Ejercicio_' + index).attr('data-field', 'Tipo_de_Ejercicio').after($.parseHTML(addNew('Detalle_Secuencia_de_Ejercicios', 'Tipo_de_Ejercicio_Rutina', 'Tipo_de_Ejercicio', 260146)));
    columnData[2] = $(GetDetalle_Secuencia_de_Ejercicios_Tipo_de_Enfoque_del_EjercicioDropDown()).addClass('Detalle_Secuencia_de_Ejercicios_Enfoque Enfoque').attr('id', 'Detalle_Secuencia_de_Ejercicios_Enfoque_' + index).attr('data-field', 'Enfoque').after($.parseHTML(addNew('Detalle_Secuencia_de_Ejercicios', 'Tipo_de_Enfoque_del_Ejercicio', 'Enfoque', 260147)));
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Secuencia_de_Ejercicios_Secuencia_del_Ejercicio Secuencia_del_Ejercicio').attr('id', 'Detalle_Secuencia_de_Ejercicios_Secuencia_del_Ejercicio_' + index).attr('data-field', 'Secuencia_del_Ejercicio');


    initiateUIControls();
    return columnData;
}

function Detalle_Secuencia_de_EjerciciosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Secuencia_de_Ejercicios("Detalle_Secuencia_de_Ejercicios_", "_" + rowIndex)) {
    var iPage = Detalle_Secuencia_de_EjerciciosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Secuencia_de_Ejercicios';
    var prevData = Detalle_Secuencia_de_EjerciciosTable.fnGetData(rowIndex);
    var data = Detalle_Secuencia_de_EjerciciosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Orden_del_Ejercicio:  data.childNodes[counter++].childNodes[0].value
        ,Tipo_de_Ejercicio:  data.childNodes[counter++].childNodes[0].value
        ,Enfoque:  data.childNodes[counter++].childNodes[0].value
        ,Secuencia_del_Ejercicio:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Secuencia_de_EjerciciosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Secuencia_de_EjerciciosrowCreationGrid(data, newData, rowIndex);
    Detalle_Secuencia_de_EjerciciosTable.fnPageChange(iPage);
    Detalle_Secuencia_de_EjercicioscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Secuencia_de_Ejercicios("Detalle_Secuencia_de_Ejercicios_", "_" + rowIndex);
  }
}

function Detalle_Secuencia_de_EjerciciosCancelRow(rowIndex) {
    var prevData = Detalle_Secuencia_de_EjerciciosTable.fnGetData(rowIndex);
    var data = Detalle_Secuencia_de_EjerciciosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Secuencia_de_EjerciciosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Secuencia_de_EjerciciosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Secuencia_de_EjerciciosGrid(Detalle_Secuencia_de_EjerciciosTable.fnGetData());
    Detalle_Secuencia_de_EjercicioscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Secuencia_de_EjerciciosFromDataTable() {
    var Detalle_Secuencia_de_EjerciciosData = [];
    var gridData = Detalle_Secuencia_de_EjerciciosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Secuencia_de_EjerciciosData.push({
                Folio: gridData[i].Folio

                ,Orden_del_Ejercicio: gridData[i].Orden_del_Ejercicio
                ,Tipo_de_Ejercicio: gridData[i].Tipo_de_Ejercicio
                ,Enfoque: gridData[i].Enfoque
                ,Secuencia_del_Ejercicio: gridData[i].Secuencia_del_Ejercicio

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Secuencia_de_EjerciciosData.length; i++) {
        if (removedDetalle_Secuencia_de_EjerciciosData[i] != null && removedDetalle_Secuencia_de_EjerciciosData[i].Folio > 0)
            Detalle_Secuencia_de_EjerciciosData.push({
                Folio: removedDetalle_Secuencia_de_EjerciciosData[i].Folio

                ,Orden_del_Ejercicio: removedDetalle_Secuencia_de_EjerciciosData[i].Orden_del_Ejercicio
                ,Tipo_de_Ejercicio: removedDetalle_Secuencia_de_EjerciciosData[i].Tipo_de_Ejercicio
                ,Enfoque: removedDetalle_Secuencia_de_EjerciciosData[i].Enfoque
                ,Secuencia_del_Ejercicio: removedDetalle_Secuencia_de_EjerciciosData[i].Secuencia_del_Ejercicio

                , Removed: true
            });
    }	

    return Detalle_Secuencia_de_EjerciciosData;
}

function Detalle_Secuencia_de_EjerciciosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Secuencia_de_EjerciciosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Secuencia_de_EjercicioscountRowsChecked++;
    var Detalle_Secuencia_de_EjerciciosRowElement = "Detalle_Secuencia_de_Ejercicios_" + rowIndex.toString();
    var prevData = Detalle_Secuencia_de_EjerciciosTable.fnGetData(rowIndexTable );
    var row = Detalle_Secuencia_de_EjerciciosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Secuencia_de_Ejercicios_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Secuencia_de_EjerciciosGetUpdateRowControls(prevData, "Detalle_Secuencia_de_Ejercicios_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Secuencia_de_EjerciciosRowElement + "')){ Detalle_Secuencia_de_EjerciciosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Secuencia_de_EjerciciosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Secuencia_de_EjerciciosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Secuencia_de_EjerciciosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Secuencia_de_EjerciciosValidation();
    initiateUIControls();
    $('.Detalle_Secuencia_de_Ejercicios' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Secuencia_de_Ejercicios(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Secuencia_de_EjerciciosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Secuencia_de_EjerciciosTable.fnGetData().length;
    Detalle_Secuencia_de_EjerciciosfnClickAddRow();
    GetAddDetalle_Secuencia_de_EjerciciosPopup(currentRowIndex, 0);
}

function Detalle_Secuencia_de_EjerciciosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Secuencia_de_EjerciciosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Secuencia_de_EjerciciosRowElement = "Detalle_Secuencia_de_Ejercicios_" + rowIndex.toString();
    var prevData = Detalle_Secuencia_de_EjerciciosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Secuencia_de_EjerciciosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Secuencia_de_EjerciciosOrden_del_Ejercicio').val(prevData.Orden_del_Ejercicio);
    $('#Detalle_Secuencia_de_EjerciciosTipo_de_Ejercicio').val(prevData.Tipo_de_Ejercicio);
    $('#Detalle_Secuencia_de_EjerciciosEnfoque').val(prevData.Enfoque);
    $('#Detalle_Secuencia_de_EjerciciosSecuencia_del_Ejercicio').val(prevData.Secuencia_del_Ejercicio);

    initiateUIControls();






}

function Detalle_Secuencia_de_EjerciciosAddInsertRow() {
    if (Detalle_Secuencia_de_EjerciciosinsertRowCurrentIndex < 1)
    {
        Detalle_Secuencia_de_EjerciciosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Orden_del_Ejercicio: ""
        ,Tipo_de_Ejercicio: ""
        ,Enfoque: ""
        ,Secuencia_del_Ejercicio: ""

    }
}

function Detalle_Secuencia_de_EjerciciosfnClickAddRow() {
    Detalle_Secuencia_de_EjercicioscountRowsChecked++;
    Detalle_Secuencia_de_EjerciciosTable.fnAddData(Detalle_Secuencia_de_EjerciciosAddInsertRow(), true);
    Detalle_Secuencia_de_EjerciciosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Secuencia_de_EjerciciosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Secuencia_de_EjerciciosGrid tbody tr:nth-of-type(' + (Detalle_Secuencia_de_EjerciciosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Secuencia_de_Ejercicios("Detalle_Secuencia_de_Ejercicios_", "_" + Detalle_Secuencia_de_EjerciciosinsertRowCurrentIndex);
}

function Detalle_Secuencia_de_EjerciciosClearGridData() {
    Detalle_Secuencia_de_EjerciciosData = [];
    Detalle_Secuencia_de_EjerciciosdeletedItem = [];
    Detalle_Secuencia_de_EjerciciosDataMain = [];
    Detalle_Secuencia_de_EjerciciosDataMainPages = [];
    Detalle_Secuencia_de_EjerciciosnewItemCount = 0;
    Detalle_Secuencia_de_EjerciciosmaxItemIndex = 0;
    $("#Detalle_Secuencia_de_EjerciciosGrid").DataTable().clear();
    $("#Detalle_Secuencia_de_EjerciciosGrid").DataTable().destroy();
}

//Used to Get Configuración de Rutinas Information
function GetDetalle_Secuencia_de_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Secuencia_de_EjerciciosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Secuencia_de_EjerciciosData[i].Folio);

        form_data.append('[' + i + '].Orden_del_Ejercicio', Detalle_Secuencia_de_EjerciciosData[i].Orden_del_Ejercicio);
        form_data.append('[' + i + '].Tipo_de_Ejercicio', Detalle_Secuencia_de_EjerciciosData[i].Tipo_de_Ejercicio);
        form_data.append('[' + i + '].Enfoque', Detalle_Secuencia_de_EjerciciosData[i].Enfoque);
        form_data.append('[' + i + '].Secuencia_del_Ejercicio', Detalle_Secuencia_de_EjerciciosData[i].Secuencia_del_Ejercicio);

        form_data.append('[' + i + '].Removed', Detalle_Secuencia_de_EjerciciosData[i].Removed);
    }
    return form_data;
}
function Detalle_Secuencia_de_EjerciciosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Secuencia_de_Ejercicios("Detalle_Secuencia_de_EjerciciosTable", rowIndex)) {
    var prevData = Detalle_Secuencia_de_EjerciciosTable.fnGetData(rowIndex);
    var data = Detalle_Secuencia_de_EjerciciosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Orden_del_Ejercicio: $('#Detalle_Secuencia_de_EjerciciosOrden_del_Ejercicio').val()
        ,Tipo_de_Ejercicio: $('#Detalle_Secuencia_de_EjerciciosTipo_de_Ejercicio').val()
        ,Enfoque: $('#Detalle_Secuencia_de_EjerciciosEnfoque').val()
        ,Secuencia_del_Ejercicio: $('#Detalle_Secuencia_de_EjerciciosSecuencia_del_Ejercicio').val()

    }

    Detalle_Secuencia_de_EjerciciosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Secuencia_de_EjerciciosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Secuencia_de_Ejercicios-form').modal({ show: false });
    $('#AddDetalle_Secuencia_de_Ejercicios-form').modal('hide');
    Detalle_Secuencia_de_EjerciciosEditRow(rowIndex);
    Detalle_Secuencia_de_EjerciciosInsertRow(rowIndex);
    //}
}
function Detalle_Secuencia_de_EjerciciosRemoveAddRow(rowIndex) {
    Detalle_Secuencia_de_EjerciciosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Secuencia_de_Ejercicios MultiRow


$(function () {
    function Detalle_Secuencia_de_EjerciciosinitializeMainArray(totalCount) {
        if (Detalle_Secuencia_de_EjerciciosDataMain.length != totalCount && !Detalle_Secuencia_de_EjerciciosDataMainInitialized) {
            Detalle_Secuencia_de_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Secuencia_de_EjerciciosDataMain[i] = null;
            }
        }
    }
    function Detalle_Secuencia_de_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Secuencia_de_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Secuencia_de_EjerciciosDataMain.length; i++) {
                if (Detalle_Secuencia_de_EjerciciosDataMain[i] != null && Detalle_Secuencia_de_EjerciciosDataMain[i].Id == Detalle_Secuencia_de_EjerciciosdeletedItem[j]) {
                    hDetalle_Secuencia_de_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Secuencia_de_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Secuencia_de_EjerciciosDataMain.length; i++) {
            data[i] = Detalle_Secuencia_de_EjerciciosDataMain[i];

        }
        return data;
    }
    function Detalle_Secuencia_de_EjerciciosgetNewResult() {
        var newData = copyMainDetalle_Secuencia_de_EjerciciosArray();

        for (var i = 0; i < Detalle_Secuencia_de_EjerciciosData.length; i++) {
            if (Detalle_Secuencia_de_EjerciciosData[i].Removed == null || Detalle_Secuencia_de_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Secuencia_de_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Secuencia_de_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Secuencia_de_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Secuencia_de_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Configuracion_de_Rutinas_cmbLabelSelect").val();
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
    $('#CreateConfiguracion_de_Rutinas')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Secuencia_de_EjerciciosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateConfiguracion_de_Rutinas').trigger('reset');
    $('#CreateConfiguracion_de_Rutinas').find(':input').each(function () {
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
    var $myForm = $('#CreateConfiguracion_de_Rutinas');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Secuencia_de_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Secuencia_de_Ejercicios();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateConfiguracion_de_Rutinas").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateConfiguracion_de_Rutinas").on('click', '#Configuracion_de_RutinasCancelar', function () {
	  if (!isPartial) {
        Configuracion_de_RutinasBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateConfiguracion_de_Rutinas").on('click', '#Configuracion_de_RutinasGuardar', function () {
		$('#Configuracion_de_RutinasGuardar').attr('disabled', true);
		$('#Configuracion_de_RutinasGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendConfiguracion_de_RutinasData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Configuracion_de_RutinasBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Configuracion_de_Rutinas', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Configuracion_de_RutinasGuardar').removeAttr('disabled');
					$('#Configuracion_de_RutinasGuardar').bind()
				}
		}
		else {
			$('#Configuracion_de_RutinasGuardar').removeAttr('disabled');
			$('#Configuracion_de_RutinasGuardar').bind()
		}
    });
	$("form#CreateConfiguracion_de_Rutinas").on('click', '#Configuracion_de_RutinasGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendConfiguracion_de_RutinasData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Secuencia_de_EjerciciosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_de_Rutinas', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateConfiguracion_de_Rutinas").on('click', '#Configuracion_de_RutinasGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendConfiguracion_de_RutinasData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Secuencia_de_EjerciciosClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Secuencia_de_EjerciciosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Configuracion_de_Rutinas',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Configuracion_de_RutinasDropDown().get(0)').innerHTML);                          
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



var Configuracion_de_RutinasisdisplayBusinessPropery = false;
Configuracion_de_RutinasDisplayBusinessRuleButtons(Configuracion_de_RutinasisdisplayBusinessPropery);
function Configuracion_de_RutinasDisplayBusinessRule() {
    if (!Configuracion_de_RutinasisdisplayBusinessPropery) {
        $('#CreateConfiguracion_de_Rutinas').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Configuracion_de_RutinasdisplayBusinessPropery"><button onclick="Configuracion_de_RutinasGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Configuracion_de_RutinasBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Configuracion_de_RutinasdisplayBusinessPropery').remove();
    }
    Configuracion_de_RutinasDisplayBusinessRuleButtons(!Configuracion_de_RutinasisdisplayBusinessPropery);
    Configuracion_de_RutinasisdisplayBusinessPropery = (Configuracion_de_RutinasisdisplayBusinessPropery ? false : true);
}
function Configuracion_de_RutinasDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

