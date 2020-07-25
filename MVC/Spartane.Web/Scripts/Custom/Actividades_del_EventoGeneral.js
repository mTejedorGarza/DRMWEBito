﻿

//Begin Declarations for Foreigns fields for Detalle_Horarios_Actividad MultiRow
var Detalle_Horarios_ActividadcountRowsChecked = 0;






function GetDetalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoName(Id) {
    for (var i = 0; i < Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems.length; i++) {
        if (Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems[i].Folio == Id) {
            return Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems[i].Codigo_Reservacion;
        }
    }
    return "";
}

function GetDetalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropDown() {
    var Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Horarios_Actividad_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropdown);
    if(Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems != null)
    {
       for (var i = 0; i < Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems.length; i++) {
           $('<option />', { value: Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems[i].Folio, text:    Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoItems[i].Codigo_Reservacion }).appendTo(Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropdown);
       }
    }
    return Detalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropdown;
}



function GetDetalle_Horarios_Actividad_Parentescos_EmpleadosName(Id) {
    for (var i = 0; i < Detalle_Horarios_Actividad_Parentescos_EmpleadosItems.length; i++) {
        if (Detalle_Horarios_Actividad_Parentescos_EmpleadosItems[i].Folio == Id) {
            return Detalle_Horarios_Actividad_Parentescos_EmpleadosItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Horarios_Actividad_Parentescos_EmpleadosDropDown() {
    var Detalle_Horarios_Actividad_Parentescos_EmpleadosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Horarios_Actividad_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Horarios_Actividad_Parentescos_EmpleadosDropdown);
    if(Detalle_Horarios_Actividad_Parentescos_EmpleadosItems != null)
    {
       for (var i = 0; i < Detalle_Horarios_Actividad_Parentescos_EmpleadosItems.length; i++) {
           $('<option />', { value: Detalle_Horarios_Actividad_Parentescos_EmpleadosItems[i].Folio, text:    Detalle_Horarios_Actividad_Parentescos_EmpleadosItems[i].Descripcion }).appendTo(Detalle_Horarios_Actividad_Parentescos_EmpleadosDropdown);
       }
    }
    return Detalle_Horarios_Actividad_Parentescos_EmpleadosDropdown;
}
function GetDetalle_Horarios_Actividad_SexoName(Id) {
    for (var i = 0; i < Detalle_Horarios_Actividad_SexoItems.length; i++) {
        if (Detalle_Horarios_Actividad_SexoItems[i].Clave == Id) {
            return Detalle_Horarios_Actividad_SexoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Horarios_Actividad_SexoDropDown() {
    var Detalle_Horarios_Actividad_SexoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Horarios_Actividad_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Horarios_Actividad_SexoDropdown);
    if(Detalle_Horarios_Actividad_SexoItems != null)
    {
       for (var i = 0; i < Detalle_Horarios_Actividad_SexoItems.length; i++) {
           $('<option />', { value: Detalle_Horarios_Actividad_SexoItems[i].Clave, text:    Detalle_Horarios_Actividad_SexoItems[i].Descripcion }).appendTo(Detalle_Horarios_Actividad_SexoDropdown);
       }
    }
    return Detalle_Horarios_Actividad_SexoDropdown;
}

function GetDetalle_Horarios_Actividad_Estatus_Reservaciones_ActividadName(Id) {
    for (var i = 0; i < Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems.length; i++) {
        if (Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems[i].Folio == Id) {
            return Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropDown() {
    var Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Horarios_Actividad_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropdown);
    if(Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems != null)
    {
       for (var i = 0; i < Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems.length; i++) {
           $('<option />', { value: Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems[i].Folio, text:    Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadItems[i].Descripcion }).appendTo(Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropdown);
       }
    }
    return Detalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropdown;
}











function GetInsertDetalle_Horarios_ActividadRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Horarios_Actividad_Reservada Reservada').attr('id', 'Detalle_Horarios_Actividad_Reservada_' + index).attr('data-field', 'Reservada');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Numero_de_Cita Numero_de_Cita').attr('id', 'Detalle_Horarios_Actividad_Numero_de_Cita_' + index).attr('data-field', 'Numero_de_Cita');
    columnData[2] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Horarios_Actividad_Hora_inicio Hora_inicio').attr('id', 'Detalle_Horarios_Actividad_Hora_inicio_' + index).attr('data-field', 'Hora_inicio');
    columnData[3] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Horarios_Actividad_Hora_fin Hora_fin').attr('id', 'Detalle_Horarios_Actividad_Hora_fin_' + index).attr('data-field', 'Hora_fin');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Horarios_Actividad_Horario Horario').attr('id', 'Detalle_Horarios_Actividad_Horario_' + index).attr('data-field', 'Horario');
    columnData[5] = $(GetDetalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoDropDown()).addClass('Detalle_Horarios_Actividad_Codigo_de_Reservacion Codigo_de_Reservacion').attr('id', 'Detalle_Horarios_Actividad_Codigo_de_Reservacion_' + index).attr('data-field', 'Codigo_de_Reservacion').after($.parseHTML(addNew('Detalle_Horarios_Actividad', 'Detalle_Registro_en_Actividad_Evento', 'Codigo_de_Reservacion', 258769)));
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Horarios_Actividad_Numero_de_Empleado Numero_de_Empleado').attr('id', 'Detalle_Horarios_Actividad_Numero_de_Empleado_' + index).attr('data-field', 'Numero_de_Empleado');
    columnData[7] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Horarios_Actividad_Familiar_del_Empleado Familiar_del_Empleado').attr('id', 'Detalle_Horarios_Actividad_Familiar_del_Empleado_' + index).attr('data-field', 'Familiar_del_Empleado');
    columnData[8] = $($.parseHTML(inputData)).addClass('Detalle_Horarios_Actividad_Nombre_Completo Nombre_Completo').attr('id', 'Detalle_Horarios_Actividad_Nombre_Completo_' + index).attr('data-field', 'Nombre_Completo');
    columnData[9] = $(GetDetalle_Horarios_Actividad_Parentescos_EmpleadosDropDown()).addClass('Detalle_Horarios_Actividad_Parentesco_con_el_Empleado Parentesco_con_el_Empleado').attr('id', 'Detalle_Horarios_Actividad_Parentesco_con_el_Empleado_' + index).attr('data-field', 'Parentesco_con_el_Empleado').after($.parseHTML(addNew('Detalle_Horarios_Actividad', 'Parentescos_Empleados', 'Parentesco_con_el_Empleado', 258773)));
    columnData[10] = $(GetDetalle_Horarios_Actividad_SexoDropDown()).addClass('Detalle_Horarios_Actividad_Sexo Sexo').attr('id', 'Detalle_Horarios_Actividad_Sexo_' + index).attr('data-field', 'Sexo').after($.parseHTML(addNew('Detalle_Horarios_Actividad', 'Sexo', 'Sexo', 258774)));
    columnData[11] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Edad Edad').attr('id', 'Detalle_Horarios_Actividad_Edad_' + index).attr('data-field', 'Edad');
    columnData[12] = $(GetDetalle_Horarios_Actividad_Estatus_Reservaciones_ActividadDropDown()).addClass('Detalle_Horarios_Actividad_Estatus_de_la_Reservacion Estatus_de_la_Reservacion').attr('id', 'Detalle_Horarios_Actividad_Estatus_de_la_Reservacion_' + index).attr('data-field', 'Estatus_de_la_Reservacion').after($.parseHTML(addNew('Detalle_Horarios_Actividad', 'Estatus_Reservaciones_Actividad', 'Estatus_de_la_Reservacion', 258776)));
    columnData[13] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Horarios_Actividad_Asistio Asistio').attr('id', 'Detalle_Horarios_Actividad_Asistio_' + index).attr('data-field', 'Asistio');
    columnData[14] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Frecuencia_Cardiaca_ppm Frecuencia_Cardiaca_ppm').attr('id', 'Detalle_Horarios_Actividad_Frecuencia_Cardiaca_ppm_' + index).attr('data-field', 'Frecuencia_Cardiaca_ppm');
    columnData[15] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Presion_sistolica_mm_Hg Presion_sistolica_mm_Hg').attr('id', 'Detalle_Horarios_Actividad_Presion_sistolica_mm_Hg_' + index).attr('data-field', 'Presion_sistolica_mm_Hg');
    columnData[16] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Presion_diastolica_mm_Hg Presion_diastolica_mm_Hg').attr('id', 'Detalle_Horarios_Actividad_Presion_diastolica_mm_Hg_' + index).attr('data-field', 'Presion_diastolica_mm_Hg');
    columnData[17] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Peso_actual_kg Peso_actual_kg').attr('id', 'Detalle_Horarios_Actividad_Peso_actual_kg_' + index).attr('data-field', 'Peso_actual_kg');
    columnData[18] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Estatura_m Estatura_m').attr('id', 'Detalle_Horarios_Actividad_Estatura_m_' + index).attr('data-field', 'Estatura_m');
    columnData[19] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Circunferencia_de_cintura_cm Circunferencia_de_cintura_cm').attr('id', 'Detalle_Horarios_Actividad_Circunferencia_de_cintura_cm_' + index).attr('data-field', 'Circunferencia_de_cintura_cm');
    columnData[20] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Horarios_Actividad_Circunferencia_de_cadera_cm Circunferencia_de_cadera_cm').attr('id', 'Detalle_Horarios_Actividad_Circunferencia_de_cadera_cm_' + index).attr('data-field', 'Circunferencia_de_cadera_cm');
    columnData[21] = $($.parseHTML(inputData)).addClass('Detalle_Horarios_Actividad_Diagnostico Diagnostico').attr('id', 'Detalle_Horarios_Actividad_Diagnostico_' + index).attr('data-field', 'Diagnostico');


    initiateUIControls();
    return columnData;
}

function Detalle_Horarios_ActividadInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Horarios_Actividad("Detalle_Horarios_Actividad_", "_" + rowIndex)) {
    var iPage = Detalle_Horarios_ActividadTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Horarios_Actividad';
    var prevData = Detalle_Horarios_ActividadTable.fnGetData(rowIndex);
    var data = Detalle_Horarios_ActividadTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Reservada: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Numero_de_Cita: data.childNodes[counter++].childNodes[0].value
        ,Hora_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Hora_fin:  data.childNodes[counter++].childNodes[0].value
        ,Horario:  data.childNodes[counter++].childNodes[0].value
        ,Codigo_de_Reservacion:  data.childNodes[counter++].childNodes[0].value
        ,Numero_de_Empleado:  data.childNodes[counter++].childNodes[0].value
        ,Familiar_del_Empleado: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Nombre_Completo:  data.childNodes[counter++].childNodes[0].value
        ,Parentesco_con_el_Empleado:  data.childNodes[counter++].childNodes[0].value
        ,Sexo:  data.childNodes[counter++].childNodes[0].value
        ,Edad: data.childNodes[counter++].childNodes[0].value
        ,Estatus_de_la_Reservacion:  data.childNodes[counter++].childNodes[0].value
        ,Asistio: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Frecuencia_Cardiaca_ppm: data.childNodes[counter++].childNodes[0].value
        ,Presion_sistolica_mm_Hg: data.childNodes[counter++].childNodes[0].value
        ,Presion_diastolica_mm_Hg: data.childNodes[counter++].childNodes[0].value
        ,Peso_actual_kg: data.childNodes[counter++].childNodes[0].value
        ,Estatura_m: data.childNodes[counter++].childNodes[0].value
        ,Circunferencia_de_cintura_cm: data.childNodes[counter++].childNodes[0].value
        ,Circunferencia_de_cadera_cm: data.childNodes[counter++].childNodes[0].value
        ,Diagnostico:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Horarios_ActividadTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Horarios_ActividadrowCreationGrid(data, newData, rowIndex);
    Detalle_Horarios_ActividadTable.fnPageChange(iPage);
    Detalle_Horarios_ActividadcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Horarios_Actividad("Detalle_Horarios_Actividad_", "_" + rowIndex);
  }
}

function Detalle_Horarios_ActividadCancelRow(rowIndex) {
    var prevData = Detalle_Horarios_ActividadTable.fnGetData(rowIndex);
    var data = Detalle_Horarios_ActividadTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Horarios_ActividadTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Horarios_ActividadrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Horarios_ActividadGrid(Detalle_Horarios_ActividadTable.fnGetData());
    Detalle_Horarios_ActividadcountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Horarios_ActividadFromDataTable() {
    var Detalle_Horarios_ActividadData = [];
    var gridData = Detalle_Horarios_ActividadTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Horarios_ActividadData.push({
                Folio: gridData[i].Folio

                ,Reservada: gridData[i].Reservada
                ,Numero_de_Cita: gridData[i].Numero_de_Cita
                ,Hora_inicio: gridData[i].Hora_inicio
                ,Hora_fin: gridData[i].Hora_fin
                ,Horario: gridData[i].Horario
                ,Codigo_de_Reservacion: gridData[i].Codigo_de_Reservacion
                ,Numero_de_Empleado: gridData[i].Numero_de_Empleado
                ,Familiar_del_Empleado: gridData[i].Familiar_del_Empleado
                ,Nombre_Completo: gridData[i].Nombre_Completo
                ,Parentesco_con_el_Empleado: gridData[i].Parentesco_con_el_Empleado
                ,Sexo: gridData[i].Sexo
                ,Edad: gridData[i].Edad
                ,Estatus_de_la_Reservacion: gridData[i].Estatus_de_la_Reservacion
                ,Asistio: gridData[i].Asistio
                ,Frecuencia_Cardiaca_ppm: gridData[i].Frecuencia_Cardiaca_ppm
                ,Presion_sistolica_mm_Hg: gridData[i].Presion_sistolica_mm_Hg
                ,Presion_diastolica_mm_Hg: gridData[i].Presion_diastolica_mm_Hg
                ,Peso_actual_kg: gridData[i].Peso_actual_kg
                ,Estatura_m: gridData[i].Estatura_m
                ,Circunferencia_de_cintura_cm: gridData[i].Circunferencia_de_cintura_cm
                ,Circunferencia_de_cadera_cm: gridData[i].Circunferencia_de_cadera_cm
                ,Diagnostico: gridData[i].Diagnostico

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Horarios_ActividadData.length; i++) {
        if (removedDetalle_Horarios_ActividadData[i] != null && removedDetalle_Horarios_ActividadData[i].Folio > 0)
            Detalle_Horarios_ActividadData.push({
                Folio: removedDetalle_Horarios_ActividadData[i].Folio

                ,Reservada: removedDetalle_Horarios_ActividadData[i].Reservada
                ,Numero_de_Cita: removedDetalle_Horarios_ActividadData[i].Numero_de_Cita
                ,Hora_inicio: removedDetalle_Horarios_ActividadData[i].Hora_inicio
                ,Hora_fin: removedDetalle_Horarios_ActividadData[i].Hora_fin
                ,Horario: removedDetalle_Horarios_ActividadData[i].Horario
                ,Codigo_de_Reservacion: removedDetalle_Horarios_ActividadData[i].Codigo_de_Reservacion
                ,Numero_de_Empleado: removedDetalle_Horarios_ActividadData[i].Numero_de_Empleado
                ,Familiar_del_Empleado: removedDetalle_Horarios_ActividadData[i].Familiar_del_Empleado
                ,Nombre_Completo: removedDetalle_Horarios_ActividadData[i].Nombre_Completo
                ,Parentesco_con_el_Empleado: removedDetalle_Horarios_ActividadData[i].Parentesco_con_el_Empleado
                ,Sexo: removedDetalle_Horarios_ActividadData[i].Sexo
                ,Edad: removedDetalle_Horarios_ActividadData[i].Edad
                ,Estatus_de_la_Reservacion: removedDetalle_Horarios_ActividadData[i].Estatus_de_la_Reservacion
                ,Asistio: removedDetalle_Horarios_ActividadData[i].Asistio
                ,Frecuencia_Cardiaca_ppm: removedDetalle_Horarios_ActividadData[i].Frecuencia_Cardiaca_ppm
                ,Presion_sistolica_mm_Hg: removedDetalle_Horarios_ActividadData[i].Presion_sistolica_mm_Hg
                ,Presion_diastolica_mm_Hg: removedDetalle_Horarios_ActividadData[i].Presion_diastolica_mm_Hg
                ,Peso_actual_kg: removedDetalle_Horarios_ActividadData[i].Peso_actual_kg
                ,Estatura_m: removedDetalle_Horarios_ActividadData[i].Estatura_m
                ,Circunferencia_de_cintura_cm: removedDetalle_Horarios_ActividadData[i].Circunferencia_de_cintura_cm
                ,Circunferencia_de_cadera_cm: removedDetalle_Horarios_ActividadData[i].Circunferencia_de_cadera_cm
                ,Diagnostico: removedDetalle_Horarios_ActividadData[i].Diagnostico

                , Removed: true
            });
    }	

    return Detalle_Horarios_ActividadData;
}

function Detalle_Horarios_ActividadEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Horarios_ActividadTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Horarios_ActividadcountRowsChecked++;
    var Detalle_Horarios_ActividadRowElement = "Detalle_Horarios_Actividad_" + rowIndex.toString();
    var prevData = Detalle_Horarios_ActividadTable.fnGetData(rowIndexTable );
    var row = Detalle_Horarios_ActividadTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Horarios_Actividad_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Horarios_ActividadGetUpdateRowControls(prevData, "Detalle_Horarios_Actividad_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Horarios_ActividadRowElement + "')){ Detalle_Horarios_ActividadInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Horarios_ActividadCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Horarios_ActividadGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Horarios_ActividadGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Horarios_ActividadValidation();
    initiateUIControls();
    $('.Detalle_Horarios_Actividad' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Horarios_Actividad(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Horarios_ActividadfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Horarios_ActividadTable.fnGetData().length;
    Detalle_Horarios_ActividadfnClickAddRow();
    GetAddDetalle_Horarios_ActividadPopup(currentRowIndex, 0);
}

function Detalle_Horarios_ActividadEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Horarios_ActividadTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Horarios_ActividadRowElement = "Detalle_Horarios_Actividad_" + rowIndex.toString();
    var prevData = Detalle_Horarios_ActividadTable.fnGetData(rowIndexTable);
    GetAddDetalle_Horarios_ActividadPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Horarios_ActividadReservada').prop('checked', prevData.Reservada);
    $('#Detalle_Horarios_ActividadNumero_de_Cita').val(prevData.Numero_de_Cita);
    $('#Detalle_Horarios_ActividadHora_inicio').val(prevData.Hora_inicio);
    $('#Detalle_Horarios_ActividadHora_fin').val(prevData.Hora_fin);
    $('#Detalle_Horarios_ActividadHorario').val(prevData.Horario);
    $('#Detalle_Horarios_ActividadCodigo_de_Reservacion').val(prevData.Codigo_de_Reservacion);
    $('#Detalle_Horarios_ActividadNumero_de_Empleado').val(prevData.Numero_de_Empleado);
    $('#Detalle_Horarios_ActividadFamiliar_del_Empleado').prop('checked', prevData.Familiar_del_Empleado);
    $('#Detalle_Horarios_ActividadNombre_Completo').val(prevData.Nombre_Completo);
    $('#Detalle_Horarios_ActividadParentesco_con_el_Empleado').val(prevData.Parentesco_con_el_Empleado);
    $('#Detalle_Horarios_ActividadSexo').val(prevData.Sexo);
    $('#Detalle_Horarios_ActividadEdad').val(prevData.Edad);
    $('#Detalle_Horarios_ActividadEstatus_de_la_Reservacion').val(prevData.Estatus_de_la_Reservacion);
    $('#Detalle_Horarios_ActividadAsistio').prop('checked', prevData.Asistio);
    $('#Detalle_Horarios_ActividadFrecuencia_Cardiaca_ppm').val(prevData.Frecuencia_Cardiaca_ppm);
    $('#Detalle_Horarios_ActividadPresion_sistolica_mm_Hg').val(prevData.Presion_sistolica_mm_Hg);
    $('#Detalle_Horarios_ActividadPresion_diastolica_mm_Hg').val(prevData.Presion_diastolica_mm_Hg);
    $('#Detalle_Horarios_ActividadPeso_actual_kg').val(prevData.Peso_actual_kg);
    $('#Detalle_Horarios_ActividadEstatura_m').val(prevData.Estatura_m);
    $('#Detalle_Horarios_ActividadCircunferencia_de_cintura_cm').val(prevData.Circunferencia_de_cintura_cm);
    $('#Detalle_Horarios_ActividadCircunferencia_de_cadera_cm').val(prevData.Circunferencia_de_cadera_cm);
    $('#Detalle_Horarios_ActividadDiagnostico').val(prevData.Diagnostico);

    initiateUIControls();
























}

function Detalle_Horarios_ActividadAddInsertRow() {
    if (Detalle_Horarios_ActividadinsertRowCurrentIndex < 1)
    {
        Detalle_Horarios_ActividadinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Reservada: ""
        ,Numero_de_Cita: ""
        ,Hora_inicio: ""
        ,Hora_fin: ""
        ,Horario: ""
        ,Codigo_de_Reservacion: ""
        ,Numero_de_Empleado: ""
        ,Familiar_del_Empleado: ""
        ,Nombre_Completo: ""
        ,Parentesco_con_el_Empleado: ""
        ,Sexo: ""
        ,Edad: ""
        ,Estatus_de_la_Reservacion: ""
        ,Asistio: ""
        ,Frecuencia_Cardiaca_ppm: ""
        ,Presion_sistolica_mm_Hg: ""
        ,Presion_diastolica_mm_Hg: ""
        ,Peso_actual_kg: ""
        ,Estatura_m: ""
        ,Circunferencia_de_cintura_cm: ""
        ,Circunferencia_de_cadera_cm: ""
        ,Diagnostico: ""

    }
}

function Detalle_Horarios_ActividadfnClickAddRow() {
    Detalle_Horarios_ActividadcountRowsChecked++;
    Detalle_Horarios_ActividadTable.fnAddData(Detalle_Horarios_ActividadAddInsertRow(), true);
    Detalle_Horarios_ActividadTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Horarios_ActividadGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Horarios_ActividadGrid tbody tr:nth-of-type(' + (Detalle_Horarios_ActividadinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Horarios_Actividad("Detalle_Horarios_Actividad_", "_" + Detalle_Horarios_ActividadinsertRowCurrentIndex);
}

function Detalle_Horarios_ActividadClearGridData() {
    Detalle_Horarios_ActividadData = [];
    Detalle_Horarios_ActividaddeletedItem = [];
    Detalle_Horarios_ActividadDataMain = [];
    Detalle_Horarios_ActividadDataMainPages = [];
    Detalle_Horarios_ActividadnewItemCount = 0;
    Detalle_Horarios_ActividadmaxItemIndex = 0;
    $("#Detalle_Horarios_ActividadGrid").DataTable().clear();
    $("#Detalle_Horarios_ActividadGrid").DataTable().destroy();
}

//Used to Get Actividades del Evento Information
function GetDetalle_Horarios_Actividad() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Horarios_ActividadData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Horarios_ActividadData[i].Folio);

        form_data.append('[' + i + '].Reservada', Detalle_Horarios_ActividadData[i].Reservada);
        form_data.append('[' + i + '].Numero_de_Cita', Detalle_Horarios_ActividadData[i].Numero_de_Cita);
        form_data.append('[' + i + '].Hora_inicio', Detalle_Horarios_ActividadData[i].Hora_inicio);
        form_data.append('[' + i + '].Hora_fin', Detalle_Horarios_ActividadData[i].Hora_fin);
        form_data.append('[' + i + '].Horario', Detalle_Horarios_ActividadData[i].Horario);
        form_data.append('[' + i + '].Codigo_de_Reservacion', Detalle_Horarios_ActividadData[i].Codigo_de_Reservacion);
        form_data.append('[' + i + '].Numero_de_Empleado', Detalle_Horarios_ActividadData[i].Numero_de_Empleado);
        form_data.append('[' + i + '].Familiar_del_Empleado', Detalle_Horarios_ActividadData[i].Familiar_del_Empleado);
        form_data.append('[' + i + '].Nombre_Completo', Detalle_Horarios_ActividadData[i].Nombre_Completo);
        form_data.append('[' + i + '].Parentesco_con_el_Empleado', Detalle_Horarios_ActividadData[i].Parentesco_con_el_Empleado);
        form_data.append('[' + i + '].Sexo', Detalle_Horarios_ActividadData[i].Sexo);
        form_data.append('[' + i + '].Edad', Detalle_Horarios_ActividadData[i].Edad);
        form_data.append('[' + i + '].Estatus_de_la_Reservacion', Detalle_Horarios_ActividadData[i].Estatus_de_la_Reservacion);
        form_data.append('[' + i + '].Asistio', Detalle_Horarios_ActividadData[i].Asistio);
        form_data.append('[' + i + '].Frecuencia_Cardiaca_ppm', Detalle_Horarios_ActividadData[i].Frecuencia_Cardiaca_ppm);
        form_data.append('[' + i + '].Presion_sistolica_mm_Hg', Detalle_Horarios_ActividadData[i].Presion_sistolica_mm_Hg);
        form_data.append('[' + i + '].Presion_diastolica_mm_Hg', Detalle_Horarios_ActividadData[i].Presion_diastolica_mm_Hg);
        form_data.append('[' + i + '].Peso_actual_kg', Detalle_Horarios_ActividadData[i].Peso_actual_kg);
        form_data.append('[' + i + '].Estatura_m', Detalle_Horarios_ActividadData[i].Estatura_m);
        form_data.append('[' + i + '].Circunferencia_de_cintura_cm', Detalle_Horarios_ActividadData[i].Circunferencia_de_cintura_cm);
        form_data.append('[' + i + '].Circunferencia_de_cadera_cm', Detalle_Horarios_ActividadData[i].Circunferencia_de_cadera_cm);
        form_data.append('[' + i + '].Diagnostico', Detalle_Horarios_ActividadData[i].Diagnostico);

        form_data.append('[' + i + '].Removed', Detalle_Horarios_ActividadData[i].Removed);
    }
    return form_data;
}
function Detalle_Horarios_ActividadInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Horarios_Actividad("Detalle_Horarios_ActividadTable", rowIndex)) {
    var prevData = Detalle_Horarios_ActividadTable.fnGetData(rowIndex);
    var data = Detalle_Horarios_ActividadTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Reservada: $('#Detalle_Horarios_ActividadReservada').is(':checked')
        ,Numero_de_Cita: $('#Detalle_Horarios_ActividadNumero_de_Cita').val()

        ,Hora_inicio: $('#Detalle_Horarios_ActividadHora_inicio').val()
        ,Hora_fin: $('#Detalle_Horarios_ActividadHora_fin').val()
        ,Horario: $('#Detalle_Horarios_ActividadHorario').val()
        ,Codigo_de_Reservacion: $('#Detalle_Horarios_ActividadCodigo_de_Reservacion').val()
        ,Numero_de_Empleado: $('#Detalle_Horarios_ActividadNumero_de_Empleado').val()
        ,Familiar_del_Empleado: $('#Detalle_Horarios_ActividadFamiliar_del_Empleado').is(':checked')
        ,Nombre_Completo: $('#Detalle_Horarios_ActividadNombre_Completo').val()
        ,Parentesco_con_el_Empleado: $('#Detalle_Horarios_ActividadParentesco_con_el_Empleado').val()
        ,Sexo: $('#Detalle_Horarios_ActividadSexo').val()
        ,Edad: $('#Detalle_Horarios_ActividadEdad').val()

        ,Estatus_de_la_Reservacion: $('#Detalle_Horarios_ActividadEstatus_de_la_Reservacion').val()
        ,Asistio: $('#Detalle_Horarios_ActividadAsistio').is(':checked')
        ,Frecuencia_Cardiaca_ppm: $('#Detalle_Horarios_ActividadFrecuencia_Cardiaca_ppm').val()

        ,Presion_sistolica_mm_Hg: $('#Detalle_Horarios_ActividadPresion_sistolica_mm_Hg').val()

        ,Presion_diastolica_mm_Hg: $('#Detalle_Horarios_ActividadPresion_diastolica_mm_Hg').val()

        ,Peso_actual_kg: $('#Detalle_Horarios_ActividadPeso_actual_kg').val()
        ,Estatura_m: $('#Detalle_Horarios_ActividadEstatura_m').val()
        ,Circunferencia_de_cintura_cm: $('#Detalle_Horarios_ActividadCircunferencia_de_cintura_cm').val()

        ,Circunferencia_de_cadera_cm: $('#Detalle_Horarios_ActividadCircunferencia_de_cadera_cm').val()

        ,Diagnostico: $('#Detalle_Horarios_ActividadDiagnostico').val()

    }

    Detalle_Horarios_ActividadTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Horarios_ActividadrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Horarios_Actividad-form').modal({ show: false });
    $('#AddDetalle_Horarios_Actividad-form').modal('hide');
    Detalle_Horarios_ActividadEditRow(rowIndex);
    Detalle_Horarios_ActividadInsertRow(rowIndex);
    //}
}
function Detalle_Horarios_ActividadRemoveAddRow(rowIndex) {
    Detalle_Horarios_ActividadTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Horarios_Actividad MultiRow
//Begin Declarations for Foreigns fields for Detalle_Laboratorios_Clinicos MultiRow
var Detalle_Laboratorios_ClinicoscountRowsChecked = 0;





function GetDetalle_Laboratorios_Clinicos_Indicadores_LaboratorioName(Id) {
    for (var i = 0; i < Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems.length; i++) {
        if (Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems[i].Folio == Id) {
            return Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems[i].Indicador;
        }
    }
    return "";
}

function GetDetalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropDown() {
    var Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Laboratorios_Clinicos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropdown);
    if(Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems != null)
    {
       for (var i = 0; i < Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems.length; i++) {
           $('<option />', { value: Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems[i].Folio, text:    Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioItems[i].Indicador }).appendTo(Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropdown);
       }
    }
    return Detalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropdown;
}







function GetInsertDetalle_Laboratorios_ClinicosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Titular Numero_de_Empleado_Titular').attr('id', 'Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Titular_' + index).attr('data-field', 'Numero_de_Empleado_Titular');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Nombre_Completo Nombre_Completo').attr('id', 'Detalle_Laboratorios_Clinicos_Nombre_Completo_' + index).attr('data-field', 'Nombre_Completo');
    columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Laboratorios_Clinicos_Familiar_del_Empleado Familiar_del_Empleado').attr('id', 'Detalle_Laboratorios_Clinicos_Familiar_del_Empleado_' + index).attr('data-field', 'Familiar_del_Empleado');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Beneficiario Numero_de_Empleado_Beneficiario').attr('id', 'Detalle_Laboratorios_Clinicos_Numero_de_Empleado_Beneficiario_' + index).attr('data-field', 'Numero_de_Empleado_Beneficiario');
    columnData[4] = $(GetDetalle_Laboratorios_Clinicos_Indicadores_LaboratorioDropDown()).addClass('Detalle_Laboratorios_Clinicos_Indicador Indicador').attr('id', 'Detalle_Laboratorios_Clinicos_Indicador_' + index).attr('data-field', 'Indicador').after($.parseHTML(addNew('Detalle_Laboratorios_Clinicos', 'Indicadores_Laboratorio', 'Indicador', 261270)));
    columnData[5] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Laboratorios_Clinicos_Resultado Resultado').attr('id', 'Detalle_Laboratorios_Clinicos_Resultado_' + index).attr('data-field', 'Resultado');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Unidad Unidad').attr('id', 'Detalle_Laboratorios_Clinicos_Unidad_' + index).attr('data-field', 'Unidad');
    columnData[7] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Intervalo_de_referencia Intervalo_de_referencia').attr('id', 'Detalle_Laboratorios_Clinicos_Intervalo_de_referencia_' + index).attr('data-field', 'Intervalo_de_referencia');
    columnData[8] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Laboratorios_Clinicos_Fecha_de_Resultado Fecha_de_Resultado').attr('id', 'Detalle_Laboratorios_Clinicos_Fecha_de_Resultado_' + index).attr('data-field', 'Fecha_de_Resultado');
    columnData[9] = $($.parseHTML(inputData)).addClass('Detalle_Laboratorios_Clinicos_Estatus_Indicador Estatus_Indicador').attr('id', 'Detalle_Laboratorios_Clinicos_Estatus_Indicador_' + index).attr('data-field', 'Estatus_Indicador');


    initiateUIControls();
    return columnData;
}

function Detalle_Laboratorios_ClinicosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Laboratorios_Clinicos("Detalle_Laboratorios_Clinicos_", "_" + rowIndex)) {
    var iPage = Detalle_Laboratorios_ClinicosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Laboratorios_Clinicos';
    var prevData = Detalle_Laboratorios_ClinicosTable.fnGetData(rowIndex);
    var data = Detalle_Laboratorios_ClinicosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Empleado_Titular:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_Completo:  data.childNodes[counter++].childNodes[0].value
        ,Familiar_del_Empleado: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Numero_de_Empleado_Beneficiario:  data.childNodes[counter++].childNodes[0].value
        ,Indicador:  data.childNodes[counter++].childNodes[0].value
        ,Resultado: data.childNodes[counter++].childNodes[0].value
        ,Unidad:  data.childNodes[counter++].childNodes[0].value
        ,Intervalo_de_referencia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Resultado:  data.childNodes[counter++].childNodes[0].value
        ,Estatus_Indicador:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Laboratorios_ClinicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Laboratorios_ClinicosrowCreationGrid(data, newData, rowIndex);
    Detalle_Laboratorios_ClinicosTable.fnPageChange(iPage);
    Detalle_Laboratorios_ClinicoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Laboratorios_Clinicos("Detalle_Laboratorios_Clinicos_", "_" + rowIndex);
  }
}

function Detalle_Laboratorios_ClinicosCancelRow(rowIndex) {
    var prevData = Detalle_Laboratorios_ClinicosTable.fnGetData(rowIndex);
    var data = Detalle_Laboratorios_ClinicosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Laboratorios_ClinicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Laboratorios_ClinicosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Laboratorios_ClinicosGrid(Detalle_Laboratorios_ClinicosTable.fnGetData());
    Detalle_Laboratorios_ClinicoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Laboratorios_ClinicosFromDataTable() {
    var Detalle_Laboratorios_ClinicosData = [];
    var gridData = Detalle_Laboratorios_ClinicosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Laboratorios_ClinicosData.push({
                Folio: gridData[i].Folio

                ,Numero_de_Empleado_Titular: gridData[i].Numero_de_Empleado_Titular
                ,Nombre_Completo: gridData[i].Nombre_Completo
                ,Familiar_del_Empleado: gridData[i].Familiar_del_Empleado
                ,Numero_de_Empleado_Beneficiario: gridData[i].Numero_de_Empleado_Beneficiario
                ,Indicador: gridData[i].Indicador
                ,Resultado: gridData[i].Resultado
                ,Unidad: gridData[i].Unidad
                ,Intervalo_de_referencia: gridData[i].Intervalo_de_referencia
                ,Fecha_de_Resultado: gridData[i].Fecha_de_Resultado
                ,Estatus_Indicador: gridData[i].Estatus_Indicador

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Laboratorios_ClinicosData.length; i++) {
        if (removedDetalle_Laboratorios_ClinicosData[i] != null && removedDetalle_Laboratorios_ClinicosData[i].Folio > 0)
            Detalle_Laboratorios_ClinicosData.push({
                Folio: removedDetalle_Laboratorios_ClinicosData[i].Folio

                ,Numero_de_Empleado_Titular: removedDetalle_Laboratorios_ClinicosData[i].Numero_de_Empleado_Titular
                ,Nombre_Completo: removedDetalle_Laboratorios_ClinicosData[i].Nombre_Completo
                ,Familiar_del_Empleado: removedDetalle_Laboratorios_ClinicosData[i].Familiar_del_Empleado
                ,Numero_de_Empleado_Beneficiario: removedDetalle_Laboratorios_ClinicosData[i].Numero_de_Empleado_Beneficiario
                ,Indicador: removedDetalle_Laboratorios_ClinicosData[i].Indicador
                ,Resultado: removedDetalle_Laboratorios_ClinicosData[i].Resultado
                ,Unidad: removedDetalle_Laboratorios_ClinicosData[i].Unidad
                ,Intervalo_de_referencia: removedDetalle_Laboratorios_ClinicosData[i].Intervalo_de_referencia
                ,Fecha_de_Resultado: removedDetalle_Laboratorios_ClinicosData[i].Fecha_de_Resultado
                ,Estatus_Indicador: removedDetalle_Laboratorios_ClinicosData[i].Estatus_Indicador

                , Removed: true
            });
    }	

    return Detalle_Laboratorios_ClinicosData;
}

function Detalle_Laboratorios_ClinicosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Laboratorios_ClinicosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Laboratorios_ClinicoscountRowsChecked++;
    var Detalle_Laboratorios_ClinicosRowElement = "Detalle_Laboratorios_Clinicos_" + rowIndex.toString();
    var prevData = Detalle_Laboratorios_ClinicosTable.fnGetData(rowIndexTable );
    var row = Detalle_Laboratorios_ClinicosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Laboratorios_Clinicos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Laboratorios_ClinicosGetUpdateRowControls(prevData, "Detalle_Laboratorios_Clinicos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Laboratorios_ClinicosRowElement + "')){ Detalle_Laboratorios_ClinicosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Laboratorios_ClinicosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Laboratorios_ClinicosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Laboratorios_ClinicosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Laboratorios_ClinicosValidation();
    initiateUIControls();
    $('.Detalle_Laboratorios_Clinicos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Laboratorios_Clinicos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Laboratorios_ClinicosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Laboratorios_ClinicosTable.fnGetData().length;
    Detalle_Laboratorios_ClinicosfnClickAddRow();
    GetAddDetalle_Laboratorios_ClinicosPopup(currentRowIndex, 0);
}

function Detalle_Laboratorios_ClinicosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Laboratorios_ClinicosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Laboratorios_ClinicosRowElement = "Detalle_Laboratorios_Clinicos_" + rowIndex.toString();
    var prevData = Detalle_Laboratorios_ClinicosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Laboratorios_ClinicosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Laboratorios_ClinicosNumero_de_Empleado_Titular').val(prevData.Numero_de_Empleado_Titular);
    $('#Detalle_Laboratorios_ClinicosNombre_Completo').val(prevData.Nombre_Completo);
    $('#Detalle_Laboratorios_ClinicosFamiliar_del_Empleado').prop('checked', prevData.Familiar_del_Empleado);
    $('#Detalle_Laboratorios_ClinicosNumero_de_Empleado_Beneficiario').val(prevData.Numero_de_Empleado_Beneficiario);
    $('#Detalle_Laboratorios_ClinicosIndicador').val(prevData.Indicador);
    $('#Detalle_Laboratorios_ClinicosResultado').val(prevData.Resultado);
    $('#Detalle_Laboratorios_ClinicosUnidad').val(prevData.Unidad);
    $('#Detalle_Laboratorios_ClinicosIntervalo_de_referencia').val(prevData.Intervalo_de_referencia);
    $('#Detalle_Laboratorios_ClinicosFecha_de_Resultado').val(prevData.Fecha_de_Resultado);
    $('#Detalle_Laboratorios_ClinicosEstatus_Indicador').val(prevData.Estatus_Indicador);

    initiateUIControls();












}

function Detalle_Laboratorios_ClinicosAddInsertRow() {
    if (Detalle_Laboratorios_ClinicosinsertRowCurrentIndex < 1)
    {
        Detalle_Laboratorios_ClinicosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Numero_de_Empleado_Titular: ""
        ,Nombre_Completo: ""
        ,Familiar_del_Empleado: ""
        ,Numero_de_Empleado_Beneficiario: ""
        ,Indicador: ""
        ,Resultado: ""
        ,Unidad: ""
        ,Intervalo_de_referencia: ""
        ,Fecha_de_Resultado: ""
        ,Estatus_Indicador: ""

    }
}

function Detalle_Laboratorios_ClinicosfnClickAddRow() {
    Detalle_Laboratorios_ClinicoscountRowsChecked++;
    Detalle_Laboratorios_ClinicosTable.fnAddData(Detalle_Laboratorios_ClinicosAddInsertRow(), true);
    Detalle_Laboratorios_ClinicosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Laboratorios_ClinicosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Laboratorios_ClinicosGrid tbody tr:nth-of-type(' + (Detalle_Laboratorios_ClinicosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Laboratorios_Clinicos("Detalle_Laboratorios_Clinicos_", "_" + Detalle_Laboratorios_ClinicosinsertRowCurrentIndex);
}

function Detalle_Laboratorios_ClinicosClearGridData() {
    Detalle_Laboratorios_ClinicosData = [];
    Detalle_Laboratorios_ClinicosdeletedItem = [];
    Detalle_Laboratorios_ClinicosDataMain = [];
    Detalle_Laboratorios_ClinicosDataMainPages = [];
    Detalle_Laboratorios_ClinicosnewItemCount = 0;
    Detalle_Laboratorios_ClinicosmaxItemIndex = 0;
    $("#Detalle_Laboratorios_ClinicosGrid").DataTable().clear();
    $("#Detalle_Laboratorios_ClinicosGrid").DataTable().destroy();
}

//Used to Get Actividades del Evento Information
function GetDetalle_Laboratorios_Clinicos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Laboratorios_ClinicosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Laboratorios_ClinicosData[i].Folio);

        form_data.append('[' + i + '].Numero_de_Empleado_Titular', Detalle_Laboratorios_ClinicosData[i].Numero_de_Empleado_Titular);
        form_data.append('[' + i + '].Nombre_Completo', Detalle_Laboratorios_ClinicosData[i].Nombre_Completo);
        form_data.append('[' + i + '].Familiar_del_Empleado', Detalle_Laboratorios_ClinicosData[i].Familiar_del_Empleado);
        form_data.append('[' + i + '].Numero_de_Empleado_Beneficiario', Detalle_Laboratorios_ClinicosData[i].Numero_de_Empleado_Beneficiario);
        form_data.append('[' + i + '].Indicador', Detalle_Laboratorios_ClinicosData[i].Indicador);
        form_data.append('[' + i + '].Resultado', Detalle_Laboratorios_ClinicosData[i].Resultado);
        form_data.append('[' + i + '].Unidad', Detalle_Laboratorios_ClinicosData[i].Unidad);
        form_data.append('[' + i + '].Intervalo_de_referencia', Detalle_Laboratorios_ClinicosData[i].Intervalo_de_referencia);
        form_data.append('[' + i + '].Fecha_de_Resultado', Detalle_Laboratorios_ClinicosData[i].Fecha_de_Resultado);
        form_data.append('[' + i + '].Estatus_Indicador', Detalle_Laboratorios_ClinicosData[i].Estatus_Indicador);

        form_data.append('[' + i + '].Removed', Detalle_Laboratorios_ClinicosData[i].Removed);
    }
    return form_data;
}
function Detalle_Laboratorios_ClinicosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Laboratorios_Clinicos("Detalle_Laboratorios_ClinicosTable", rowIndex)) {
    var prevData = Detalle_Laboratorios_ClinicosTable.fnGetData(rowIndex);
    var data = Detalle_Laboratorios_ClinicosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Empleado_Titular: $('#Detalle_Laboratorios_ClinicosNumero_de_Empleado_Titular').val()
        ,Nombre_Completo: $('#Detalle_Laboratorios_ClinicosNombre_Completo').val()
        ,Familiar_del_Empleado: $('#Detalle_Laboratorios_ClinicosFamiliar_del_Empleado').is(':checked')
        ,Numero_de_Empleado_Beneficiario: $('#Detalle_Laboratorios_ClinicosNumero_de_Empleado_Beneficiario').val()
        ,Indicador: $('#Detalle_Laboratorios_ClinicosIndicador').val()
        ,Resultado: $('#Detalle_Laboratorios_ClinicosResultado').val()

        ,Unidad: $('#Detalle_Laboratorios_ClinicosUnidad').val()
        ,Intervalo_de_referencia: $('#Detalle_Laboratorios_ClinicosIntervalo_de_referencia').val()
        ,Fecha_de_Resultado: $('#Detalle_Laboratorios_ClinicosFecha_de_Resultado').val()
        ,Estatus_Indicador: $('#Detalle_Laboratorios_ClinicosEstatus_Indicador').val()

    }

    Detalle_Laboratorios_ClinicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Laboratorios_ClinicosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Laboratorios_Clinicos-form').modal({ show: false });
    $('#AddDetalle_Laboratorios_Clinicos-form').modal('hide');
    Detalle_Laboratorios_ClinicosEditRow(rowIndex);
    Detalle_Laboratorios_ClinicosInsertRow(rowIndex);
    //}
}
function Detalle_Laboratorios_ClinicosRemoveAddRow(rowIndex) {
    Detalle_Laboratorios_ClinicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Laboratorios_Clinicos MultiRow


$(function () {
    function Detalle_Horarios_ActividadinitializeMainArray(totalCount) {
        if (Detalle_Horarios_ActividadDataMain.length != totalCount && !Detalle_Horarios_ActividadDataMainInitialized) {
            Detalle_Horarios_ActividadDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Horarios_ActividadDataMain[i] = null;
            }
        }
    }
    function Detalle_Horarios_ActividadremoveFromMainArray() {
        for (var j = 0; j < Detalle_Horarios_ActividaddeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Horarios_ActividadDataMain.length; i++) {
                if (Detalle_Horarios_ActividadDataMain[i] != null && Detalle_Horarios_ActividadDataMain[i].Id == Detalle_Horarios_ActividaddeletedItem[j]) {
                    hDetalle_Horarios_ActividadDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Horarios_ActividadcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Horarios_ActividadDataMain.length; i++) {
            data[i] = Detalle_Horarios_ActividadDataMain[i];

        }
        return data;
    }
    function Detalle_Horarios_ActividadgetNewResult() {
        var newData = copyMainDetalle_Horarios_ActividadArray();

        for (var i = 0; i < Detalle_Horarios_ActividadData.length; i++) {
            if (Detalle_Horarios_ActividadData[i].Removed == null || Detalle_Horarios_ActividadData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Horarios_ActividadData[i]);
            }
        }
        return newData;
    }
    function Detalle_Horarios_ActividadpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Horarios_ActividadDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Horarios_ActividadDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Laboratorios_ClinicosinitializeMainArray(totalCount) {
        if (Detalle_Laboratorios_ClinicosDataMain.length != totalCount && !Detalle_Laboratorios_ClinicosDataMainInitialized) {
            Detalle_Laboratorios_ClinicosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Laboratorios_ClinicosDataMain[i] = null;
            }
        }
    }
    function Detalle_Laboratorios_ClinicosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Laboratorios_ClinicosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Laboratorios_ClinicosDataMain.length; i++) {
                if (Detalle_Laboratorios_ClinicosDataMain[i] != null && Detalle_Laboratorios_ClinicosDataMain[i].Id == Detalle_Laboratorios_ClinicosdeletedItem[j]) {
                    hDetalle_Laboratorios_ClinicosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Laboratorios_ClinicoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Laboratorios_ClinicosDataMain.length; i++) {
            data[i] = Detalle_Laboratorios_ClinicosDataMain[i];

        }
        return data;
    }
    function Detalle_Laboratorios_ClinicosgetNewResult() {
        var newData = copyMainDetalle_Laboratorios_ClinicosArray();

        for (var i = 0; i < Detalle_Laboratorios_ClinicosData.length; i++) {
            if (Detalle_Laboratorios_ClinicosData[i].Removed == null || Detalle_Laboratorios_ClinicosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Laboratorios_ClinicosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Laboratorios_ClinicospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Laboratorios_ClinicosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Laboratorios_ClinicosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Actividades_del_Evento_cmbLabelSelect").val();
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
    $('#CreateActividades_del_Evento')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Horarios_ActividadClearGridData();
                Detalle_Laboratorios_ClinicosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateActividades_del_Evento').trigger('reset');
    $('#CreateActividades_del_Evento').find(':input').each(function () {
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
    var $myForm = $('#CreateActividades_del_Evento');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Horarios_ActividadcountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Horarios_Actividad();
        return false;
    }
    if (Detalle_Laboratorios_ClinicoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Laboratorios_Clinicos();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateActividades_del_Evento").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateActividades_del_Evento").on('click', '#Actividades_del_EventoCancelar', function () {
	  if (!isPartial) {
        Actividades_del_EventoBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateActividades_del_Evento").on('click', '#Actividades_del_EventoGuardar', function () {
		$('#Actividades_del_EventoGuardar').attr('disabled', true);
		$('#Actividades_del_EventoGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendActividades_del_EventoData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial  && !viewInEframe)
						Actividades_del_EventoBackToGrid();
					else if (viewInEframe) 
                    {
                        $('#Actividades_del_EventoGuardar').removeAttr('disabled');
                        $('#Actividades_del_EventoGuardar').bind()
                    }
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Actividades_del_Evento', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Actividades_del_EventoItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Actividades_del_EventoDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Actividades_del_EventoGuardar').removeAttr('disabled');
					$('#Actividades_del_EventoGuardar').bind()
				}
		}
		else {
			$('#Actividades_del_EventoGuardar').removeAttr('disabled');
			$('#Actividades_del_EventoGuardar').bind()
		}
    });
	$("form#CreateActividades_del_Evento").on('click', '#Actividades_del_EventoGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendActividades_del_EventoData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Horarios_ActividadData();
                getDetalle_Laboratorios_ClinicosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Actividades_del_Evento', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Actividades_del_EventoItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Actividades_del_EventoDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateActividades_del_Evento").on('click', '#Actividades_del_EventoGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendActividades_del_EventoData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Horarios_ActividadClearGridData();
                Detalle_Laboratorios_ClinicosClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Horarios_ActividadData();
                getDetalle_Laboratorios_ClinicosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Actividades_del_Evento',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Actividades_del_EventoItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Actividades_del_EventoDropDown().get(0)').innerHTML);                          
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



var Actividades_del_EventoisdisplayBusinessPropery = false;
Actividades_del_EventoDisplayBusinessRuleButtons(Actividades_del_EventoisdisplayBusinessPropery);
function Actividades_del_EventoDisplayBusinessRule() {
    if (!Actividades_del_EventoisdisplayBusinessPropery) {
        $('#CreateActividades_del_Evento').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Actividades_del_EventodisplayBusinessPropery"><button onclick="Actividades_del_EventoGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Actividades_del_EventoBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Actividades_del_EventodisplayBusinessPropery').remove();
    }
    Actividades_del_EventoDisplayBusinessRuleButtons(!Actividades_del_EventoisdisplayBusinessPropery);
    Actividades_del_EventoisdisplayBusinessPropery = (Actividades_del_EventoisdisplayBusinessPropery ? false : true);
}
function Actividades_del_EventoDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

