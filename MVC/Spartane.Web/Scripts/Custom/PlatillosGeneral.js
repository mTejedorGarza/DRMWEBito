        function RemoveAttachmentMainImagen () {
            $("#hdnRemoveImagen").val("1");
            $("#divAttachmentImagen").hide();
        }


var MS_CaloriascountRowsChecked = 0;
function GetMS_CaloriasFromDataTable() {
    var MS_CaloriasData = [];
    debugger;

    var items = $("#ddlCaloriasMult").chosen().val();
    //es nuevo 
    if (MS_CaloriasDataDataTable == undefined || MS_CaloriasDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_CaloriasData.push({ 
                      Folio: 0
                      
, Calorias: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_CaloriasDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_CaloriasDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_CaloriasData.push({
                        Folio: MS_CaloriasDataDataTable[i].Folio
                        
                   , Calorias: MS_CaloriasDataDataTable[i].Calorias

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
                    for (var j = 0; j < MS_CaloriasDataDataTable.length; j++) {
                        if (items[i] == MS_CaloriasDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_CaloriasData.push({ 
                              Folio: 0
                              
, Calorias: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_CaloriasData;
}

//Used to Get Platillos Information
function GetMS_Calorias() {
    var form_data = new FormData();
    for (var i = 0; i < MS_CaloriasData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_CaloriasData[i].Folio);
       
      form_data.append('[' + i +'].Calorias',MS_CaloriasData[i].Calorias);


       form_data.append('[' + i + '].Removed', MS_CaloriasData[i].Removed);
    }
    return form_data;
}

var MS_Dificultad_PlatilloscountRowsChecked = 0;
function GetMS_Dificultad_PlatillosFromDataTable() {
    var MS_Dificultad_PlatillosData = [];
    debugger;

    var items = $("#ddlDificultadMult").chosen().val();
    //es nuevo 
    if (MS_Dificultad_PlatillosDataDataTable == undefined || MS_Dificultad_PlatillosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Dificultad_PlatillosData.push({ 
                      Folio: 0
                      
, Dificultad: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Dificultad_PlatillosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Dificultad_PlatillosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Dificultad_PlatillosData.push({
                        Folio: MS_Dificultad_PlatillosDataDataTable[i].Folio
                        
                   , Dificultad: MS_Dificultad_PlatillosDataDataTable[i].Dificultad

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
                    for (var j = 0; j < MS_Dificultad_PlatillosDataDataTable.length; j++) {
                        if (items[i] == MS_Dificultad_PlatillosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Dificultad_PlatillosData.push({ 
                              Folio: 0
                              
, Dificultad: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Dificultad_PlatillosData;
}

//Used to Get Platillos Information
function GetMS_Dificultad_Platillos() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Dificultad_PlatillosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Dificultad_PlatillosData[i].Folio);
       
      form_data.append('[' + i +'].Dificultad',MS_Dificultad_PlatillosData[i].Dificultad);


       form_data.append('[' + i + '].Removed', MS_Dificultad_PlatillosData[i].Removed);
    }
    return form_data;
}

var MS_PadecimientoscountRowsChecked = 0;
function GetMS_PadecimientosFromDataTable() {
    var MS_PadecimientosData = [];
    debugger;

    var items = $("#ddlCategoria_del_PlatilloMult").chosen().val();
    //es nuevo 
    if (MS_PadecimientosDataDataTable == undefined || MS_PadecimientosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_PadecimientosData.push({ 
                      Folio: 0
                      
, Categoria: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_PadecimientosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_PadecimientosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_PadecimientosData.push({
                        Folio: MS_PadecimientosDataDataTable[i].Folio
                        
                   , Categoria: MS_PadecimientosDataDataTable[i].Categoria

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
                    for (var j = 0; j < MS_PadecimientosDataDataTable.length; j++) {
                        if (items[i] == MS_PadecimientosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_PadecimientosData.push({ 
                              Folio: 0
                              
, Categoria: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_PadecimientosData;
}

//Used to Get Platillos Information
function GetMS_Padecimientos() {
    var form_data = new FormData();
    for (var i = 0; i < MS_PadecimientosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_PadecimientosData[i].Folio);
       
      form_data.append('[' + i +'].Categoria',MS_PadecimientosData[i].Categoria);


       form_data.append('[' + i + '].Removed', MS_PadecimientosData[i].Removed);
    }
    return form_data;
}

var MS_Tiempos_de_Comida_PlatilloscountRowsChecked = 0;
function GetMS_Tiempos_de_Comida_PlatillosFromDataTable() {
    var MS_Tiempos_de_Comida_PlatillosData = [];
    debugger;

    var items = $("#ddlTiempo_de_comidaMult").chosen().val();
    //es nuevo 
    if (MS_Tiempos_de_Comida_PlatillosDataDataTable == undefined || MS_Tiempos_de_Comida_PlatillosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Tiempos_de_Comida_PlatillosData.push({ 
                      Folio: 0
                      
, Tiempo_de_Comida: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Tiempos_de_Comida_PlatillosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Tiempos_de_Comida_PlatillosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Tiempos_de_Comida_PlatillosData.push({
                        Folio: MS_Tiempos_de_Comida_PlatillosDataDataTable[i].Folio
                        
                   , Tiempo_de_Comida: MS_Tiempos_de_Comida_PlatillosDataDataTable[i].Tiempo_de_Comida

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
                    for (var j = 0; j < MS_Tiempos_de_Comida_PlatillosDataDataTable.length; j++) {
                        if (items[i] == MS_Tiempos_de_Comida_PlatillosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Tiempos_de_Comida_PlatillosData.push({ 
                              Folio: 0
                              
, Tiempo_de_Comida: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Tiempos_de_Comida_PlatillosData;
}

//Used to Get Platillos Information
function GetMS_Tiempos_de_Comida_Platillos() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Tiempos_de_Comida_PlatillosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Tiempos_de_Comida_PlatillosData[i].Folio);
       
      form_data.append('[' + i +'].Tiempo_de_Comida',MS_Tiempos_de_Comida_PlatillosData[i].Tiempo_de_Comida);


       form_data.append('[' + i + '].Removed', MS_Tiempos_de_Comida_PlatillosData[i].Removed);
    }
    return form_data;
}

var MS_Caracteristicas_PlatillocountRowsChecked = 0;
function GetMS_Caracteristicas_PlatilloFromDataTable() {
    var MS_Caracteristicas_PlatilloData = [];
    debugger;

    var items = $("#ddlCaracteristicasMult").chosen().val();
    //es nuevo 
    if (MS_Caracteristicas_PlatilloDataDataTable == undefined || MS_Caracteristicas_PlatilloDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Caracteristicas_PlatilloData.push({ 
                      Folio: 0
                      
, Caracteristicas: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Caracteristicas_PlatilloDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Caracteristicas_PlatilloDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Caracteristicas_PlatilloData.push({
                        Folio: MS_Caracteristicas_PlatilloDataDataTable[i].Folio
                        
                   , Caracteristicas: MS_Caracteristicas_PlatilloDataDataTable[i].Caracteristicas

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
                    for (var j = 0; j < MS_Caracteristicas_PlatilloDataDataTable.length; j++) {
                        if (items[i] == MS_Caracteristicas_PlatilloDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Caracteristicas_PlatilloData.push({ 
                              Folio: 0
                              
, Caracteristicas: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Caracteristicas_PlatilloData;
}

//Used to Get Platillos Information
function GetMS_Caracteristicas_Platillo() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Caracteristicas_PlatilloData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Caracteristicas_PlatilloData[i].Folio);
       
      form_data.append('[' + i +'].Caracteristicas',MS_Caracteristicas_PlatilloData[i].Caracteristicas);


       form_data.append('[' + i + '].Removed', MS_Caracteristicas_PlatilloData[i].Removed);
    }
    return form_data;
}

//Begin Declarations for Foreigns fields for MR_Detalle_Platillo MultiRow
var MR_Detalle_PlatillocountRowsChecked = 0;

function GetMR_Detalle_Platillo_IngredientesName(Id) {
    for (var i = 0; i < MR_Detalle_Platillo_IngredientesItems.length; i++) {
        if (MR_Detalle_Platillo_IngredientesItems[i].Clave == Id) {
            return MR_Detalle_Platillo_IngredientesItems[i].Nombre_Ingrediente;
        }
    }
    return "";
}

function GetMR_Detalle_Platillo_IngredientesDropDown() {
    var MR_Detalle_Platillo_IngredientesDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Detalle_Platillo_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Detalle_Platillo_IngredientesDropdown);
    if(MR_Detalle_Platillo_IngredientesItems != null)
    {
       for (var i = 0; i < MR_Detalle_Platillo_IngredientesItems.length; i++) {
           $('<option />', { value: MR_Detalle_Platillo_IngredientesItems[i].Clave, text:    MR_Detalle_Platillo_IngredientesItems[i].Nombre_Ingrediente }).appendTo(MR_Detalle_Platillo_IngredientesDropdown);
       }
    }
    return MR_Detalle_Platillo_IngredientesDropdown;
}


function GetMR_Detalle_Platillo_Unidades_de_MedidaName(Id) {
    for (var i = 0; i < MR_Detalle_Platillo_Unidades_de_MedidaItems.length; i++) {
        if (MR_Detalle_Platillo_Unidades_de_MedidaItems[i].Clave == Id) {
            return MR_Detalle_Platillo_Unidades_de_MedidaItems[i].Unidad;
        }
    }
    return "";
}

function GetMR_Detalle_Platillo_Unidades_de_MedidaDropDown() {
    var MR_Detalle_Platillo_Unidades_de_MedidaDropdown = $('<select class="form-control" />');      var labelSelect = $("#MR_Detalle_Platillo_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(MR_Detalle_Platillo_Unidades_de_MedidaDropdown);
    if(MR_Detalle_Platillo_Unidades_de_MedidaItems != null)
    {
       for (var i = 0; i < MR_Detalle_Platillo_Unidades_de_MedidaItems.length; i++) {
           $('<option />', { value: MR_Detalle_Platillo_Unidades_de_MedidaItems[i].Clave, text:    MR_Detalle_Platillo_Unidades_de_MedidaItems[i].Unidad }).appendTo(MR_Detalle_Platillo_Unidades_de_MedidaDropdown);
       }
    }
    return MR_Detalle_Platillo_Unidades_de_MedidaDropdown;
}




function GetInsertMR_Detalle_PlatilloRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetMR_Detalle_Platillo_IngredientesDropDown()).addClass('MR_Detalle_Platillo_Ingrediente Ingrediente').attr('id', 'MR_Detalle_Platillo_Ingrediente_' + index).attr('data-field', 'Ingrediente').after($.parseHTML(addNew('MR_Detalle_Platillo', 'Ingredientes', 'Ingrediente', 260848)));
    columnData[1] = $($.parseHTML(inputData)).addClass('MR_Detalle_Platillo_Cantidad Cantidad').attr('id', 'MR_Detalle_Platillo_Cantidad_' + index).attr('data-field', 'Cantidad');
    columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('MR_Detalle_Platillo_Cantidad_en_Fraccion Cantidad_en_Fraccion').attr('id', 'MR_Detalle_Platillo_Cantidad_en_Fraccion_' + index).attr('data-field', 'Cantidad_en_Fraccion');
    columnData[3] = $(GetMR_Detalle_Platillo_Unidades_de_MedidaDropDown()).addClass('MR_Detalle_Platillo_Unidad Unidad').attr('id', 'MR_Detalle_Platillo_Unidad_' + index).attr('data-field', 'Unidad').after($.parseHTML(addNew('MR_Detalle_Platillo', 'Unidades_de_Medida', 'Unidad', 260851)));
    columnData[4] = $($.parseHTML(inputData)).addClass('MR_Detalle_Platillo_Cantidad_a_mostrar Cantidad_a_mostrar').attr('id', 'MR_Detalle_Platillo_Cantidad_a_mostrar_' + index).attr('data-field', 'Cantidad_a_mostrar');
    columnData[5] = $($.parseHTML(inputData)).addClass('MR_Detalle_Platillo_Ingrediente_a_mostrar Ingrediente_a_mostrar').attr('id', 'MR_Detalle_Platillo_Ingrediente_a_mostrar_' + index).attr('data-field', 'Ingrediente_a_mostrar');


    initiateUIControls();
    return columnData;
}

function MR_Detalle_PlatilloInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRMR_Detalle_Platillo("MR_Detalle_Platillo_", "_" + rowIndex)) {
    var iPage = MR_Detalle_PlatilloTable.fnPagingInfo().iPage;
    var nameOfGrid = 'MR_Detalle_Platillo';
    var prevData = MR_Detalle_PlatilloTable.fnGetData(rowIndex);
    var data = MR_Detalle_PlatilloTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Ingrediente:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad_en_Fraccion: data.childNodes[counter++].childNodes[0].value
        ,Unidad:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad_a_mostrar:  data.childNodes[counter++].childNodes[0].value
        ,Ingrediente_a_mostrar:  data.childNodes[counter++].childNodes[0].value

    }
    MR_Detalle_PlatilloTable.fnUpdate(newData, rowIndex, null, true);
    MR_Detalle_PlatillorowCreationGrid(data, newData, rowIndex);
    MR_Detalle_PlatilloTable.fnPageChange(iPage);
    MR_Detalle_PlatillocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRMR_Detalle_Platillo("MR_Detalle_Platillo_", "_" + rowIndex);
  }
}

function MR_Detalle_PlatilloCancelRow(rowIndex) {
    var prevData = MR_Detalle_PlatilloTable.fnGetData(rowIndex);
    var data = MR_Detalle_PlatilloTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        MR_Detalle_PlatilloTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        MR_Detalle_PlatillorowCreationGrid(data, prevData, rowIndex);
    }
	showMR_Detalle_PlatilloGrid(MR_Detalle_PlatilloTable.fnGetData());
    MR_Detalle_PlatillocountRowsChecked--;
	initiateUIControls();
}

function GetMR_Detalle_PlatilloFromDataTable() {
    var MR_Detalle_PlatilloData = [];
    var gridData = MR_Detalle_PlatilloTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            MR_Detalle_PlatilloData.push({
                Folio: gridData[i].Folio

                ,Ingrediente: gridData[i].Ingrediente
                ,Cantidad: gridData[i].Cantidad
                ,Cantidad_en_Fraccion: gridData[i].Cantidad_en_Fraccion
                ,Unidad: gridData[i].Unidad
                ,Cantidad_a_mostrar: gridData[i].Cantidad_a_mostrar
                ,Ingrediente_a_mostrar: gridData[i].Ingrediente_a_mostrar

                ,Removed: false
            });
    }

    for (i = 0; i < removedMR_Detalle_PlatilloData.length; i++) {
        if (removedMR_Detalle_PlatilloData[i] != null && removedMR_Detalle_PlatilloData[i].Folio > 0)
            MR_Detalle_PlatilloData.push({
                Folio: removedMR_Detalle_PlatilloData[i].Folio

                ,Ingrediente: removedMR_Detalle_PlatilloData[i].Ingrediente
                ,Cantidad: removedMR_Detalle_PlatilloData[i].Cantidad
                ,Cantidad_en_Fraccion: removedMR_Detalle_PlatilloData[i].Cantidad_en_Fraccion
                ,Unidad: removedMR_Detalle_PlatilloData[i].Unidad
                ,Cantidad_a_mostrar: removedMR_Detalle_PlatilloData[i].Cantidad_a_mostrar
                ,Ingrediente_a_mostrar: removedMR_Detalle_PlatilloData[i].Ingrediente_a_mostrar

                , Removed: true
            });
    }	

    return MR_Detalle_PlatilloData;
}

function MR_Detalle_PlatilloEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? MR_Detalle_PlatilloTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    MR_Detalle_PlatillocountRowsChecked++;
    var MR_Detalle_PlatilloRowElement = "MR_Detalle_Platillo_" + rowIndex.toString();
    var prevData = MR_Detalle_PlatilloTable.fnGetData(rowIndexTable );
    var row = MR_Detalle_PlatilloTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "MR_Detalle_Platillo_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = MR_Detalle_PlatilloGetUpdateRowControls(prevData, "MR_Detalle_Platillo_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + MR_Detalle_PlatilloRowElement + "')){ MR_Detalle_PlatilloInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='MR_Detalle_PlatilloCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#MR_Detalle_PlatilloGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#MR_Detalle_PlatilloGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setMR_Detalle_PlatilloValidation();
    initiateUIControls();
    $('.MR_Detalle_Platillo' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRMR_Detalle_Platillo(nameOfTable, rowIndexFormed);
    }
}

function MR_Detalle_PlatillofnOpenAddRowPopUp() {
    var currentRowIndex = MR_Detalle_PlatilloTable.fnGetData().length;
    MR_Detalle_PlatillofnClickAddRow();
    GetAddMR_Detalle_PlatilloPopup(currentRowIndex, 0);
}

function MR_Detalle_PlatilloEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = MR_Detalle_PlatilloTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var MR_Detalle_PlatilloRowElement = "MR_Detalle_Platillo_" + rowIndex.toString();
    var prevData = MR_Detalle_PlatilloTable.fnGetData(rowIndexTable);
    GetAddMR_Detalle_PlatilloPopup(rowIndex, 1, prevData.Folio);

    $('#MR_Detalle_PlatilloIngrediente').val(prevData.Ingrediente);
    $('#MR_Detalle_PlatilloCantidad').val(prevData.Cantidad);
    $('#MR_Detalle_PlatilloCantidad_en_Fraccion').val(prevData.Cantidad_en_Fraccion);
    $('#MR_Detalle_PlatilloUnidad').val(prevData.Unidad);
    $('#MR_Detalle_PlatilloCantidad_a_mostrar').val(prevData.Cantidad_a_mostrar);
    $('#MR_Detalle_PlatilloIngrediente_a_mostrar').val(prevData.Ingrediente_a_mostrar);

    initiateUIControls();








}

function MR_Detalle_PlatilloAddInsertRow() {
    if (MR_Detalle_PlatilloinsertRowCurrentIndex < 1)
    {
        MR_Detalle_PlatilloinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Ingrediente: ""
        ,Cantidad: ""
        ,Cantidad_en_Fraccion: ""
        ,Unidad: ""
        ,Cantidad_a_mostrar: ""
        ,Ingrediente_a_mostrar: ""

    }
}

function MR_Detalle_PlatillofnClickAddRow() {
    MR_Detalle_PlatillocountRowsChecked++;
    MR_Detalle_PlatilloTable.fnAddData(MR_Detalle_PlatilloAddInsertRow(), true);
    MR_Detalle_PlatilloTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#MR_Detalle_PlatilloGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#MR_Detalle_PlatilloGrid tbody tr:nth-of-type(' + (MR_Detalle_PlatilloinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRMR_Detalle_Platillo("MR_Detalle_Platillo_", "_" + MR_Detalle_PlatilloinsertRowCurrentIndex);
}

function MR_Detalle_PlatilloClearGridData() {
    MR_Detalle_PlatilloData = [];
    MR_Detalle_PlatillodeletedItem = [];
    MR_Detalle_PlatilloDataMain = [];
    MR_Detalle_PlatilloDataMainPages = [];
    MR_Detalle_PlatillonewItemCount = 0;
    MR_Detalle_PlatillomaxItemIndex = 0;
    $("#MR_Detalle_PlatilloGrid").DataTable().clear();
    $("#MR_Detalle_PlatilloGrid").DataTable().destroy();
}

//Used to Get Platillos Information
function GetMR_Detalle_Platillo() {
    var form_data = new FormData();
    for (var i = 0; i < MR_Detalle_PlatilloData.length; i++) {
        form_data.append('[' + i + '].Folio', MR_Detalle_PlatilloData[i].Folio);

        form_data.append('[' + i + '].Ingrediente', MR_Detalle_PlatilloData[i].Ingrediente);
        form_data.append('[' + i + '].Cantidad', MR_Detalle_PlatilloData[i].Cantidad);
        form_data.append('[' + i + '].Cantidad_en_Fraccion', MR_Detalle_PlatilloData[i].Cantidad_en_Fraccion);
        form_data.append('[' + i + '].Unidad', MR_Detalle_PlatilloData[i].Unidad);
        form_data.append('[' + i + '].Cantidad_a_mostrar', MR_Detalle_PlatilloData[i].Cantidad_a_mostrar);
        form_data.append('[' + i + '].Ingrediente_a_mostrar', MR_Detalle_PlatilloData[i].Ingrediente_a_mostrar);

        form_data.append('[' + i + '].Removed', MR_Detalle_PlatilloData[i].Removed);
    }
    return form_data;
}
function MR_Detalle_PlatilloInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRMR_Detalle_Platillo("MR_Detalle_PlatilloTable", rowIndex)) {
    var prevData = MR_Detalle_PlatilloTable.fnGetData(rowIndex);
    var data = MR_Detalle_PlatilloTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Ingrediente: $('#MR_Detalle_PlatilloIngrediente').val()
        ,Cantidad: $('#MR_Detalle_PlatilloCantidad').val()
        ,Cantidad_en_Fraccion: $('#MR_Detalle_PlatilloCantidad_en_Fraccion').val()
        ,Unidad: $('#MR_Detalle_PlatilloUnidad').val()
        ,Cantidad_a_mostrar: $('#MR_Detalle_PlatilloCantidad_a_mostrar').val()
        ,Ingrediente_a_mostrar: $('#MR_Detalle_PlatilloIngrediente_a_mostrar').val()

    }

    MR_Detalle_PlatilloTable.fnUpdate(newData, rowIndex, null, true);
    MR_Detalle_PlatillorowCreationGrid(data, newData, rowIndex);
    $('#AddMR_Detalle_Platillo-form').modal({ show: false });
    $('#AddMR_Detalle_Platillo-form').modal('hide');
    MR_Detalle_PlatilloEditRow(rowIndex);
    MR_Detalle_PlatilloInsertRow(rowIndex);
    //}
}
function MR_Detalle_PlatilloRemoveAddRow(rowIndex) {
    MR_Detalle_PlatilloTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for MR_Detalle_Platillo MultiRow


$(function () {
    function MS_CaloriasinitializeMainArray(totalCount) {
        if (MS_CaloriasDataMain.length != totalCount && !MS_CaloriasDataMainInitialized) {
            MS_CaloriasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_CaloriasDataMain[i] = null;
            }
        }
    }
    function MS_CaloriasremoveFromMainArray() {
        for (var j = 0; j < MS_CaloriasdeletedItem.length; j++) {
            for (var i = 0; i < MS_CaloriasDataMain.length; i++) {
                if (MS_CaloriasDataMain[i] != null && MS_CaloriasDataMain[i].Id == MS_CaloriasdeletedItem[j]) {
                    hMS_CaloriasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_CaloriascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_CaloriasDataMain.length; i++) {
            data[i] = MS_CaloriasDataMain[i];

        }
        return data;
    }
    function MS_CaloriasgetNewResult() {
        var newData = copyMainMS_CaloriasArray();

        for (var i = 0; i < MS_CaloriasData.length; i++) {
            if (MS_CaloriasData[i].Removed == null || MS_CaloriasData[i].Removed == false) {
                newData.splice(0, 0, MS_CaloriasData[i]);
            }
        }
        return newData;
    }
    function MS_CaloriaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_CaloriasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_CaloriasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Dificultad_PlatillosinitializeMainArray(totalCount) {
        if (MS_Dificultad_PlatillosDataMain.length != totalCount && !MS_Dificultad_PlatillosDataMainInitialized) {
            MS_Dificultad_PlatillosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Dificultad_PlatillosDataMain[i] = null;
            }
        }
    }
    function MS_Dificultad_PlatillosremoveFromMainArray() {
        for (var j = 0; j < MS_Dificultad_PlatillosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Dificultad_PlatillosDataMain.length; i++) {
                if (MS_Dificultad_PlatillosDataMain[i] != null && MS_Dificultad_PlatillosDataMain[i].Id == MS_Dificultad_PlatillosdeletedItem[j]) {
                    hMS_Dificultad_PlatillosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Dificultad_PlatilloscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Dificultad_PlatillosDataMain.length; i++) {
            data[i] = MS_Dificultad_PlatillosDataMain[i];

        }
        return data;
    }
    function MS_Dificultad_PlatillosgetNewResult() {
        var newData = copyMainMS_Dificultad_PlatillosArray();

        for (var i = 0; i < MS_Dificultad_PlatillosData.length; i++) {
            if (MS_Dificultad_PlatillosData[i].Removed == null || MS_Dificultad_PlatillosData[i].Removed == false) {
                newData.splice(0, 0, MS_Dificultad_PlatillosData[i]);
            }
        }
        return newData;
    }
    function MS_Dificultad_PlatillospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Dificultad_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Dificultad_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_PadecimientosinitializeMainArray(totalCount) {
        if (MS_PadecimientosDataMain.length != totalCount && !MS_PadecimientosDataMainInitialized) {
            MS_PadecimientosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_PadecimientosDataMain[i] = null;
            }
        }
    }
    function MS_PadecimientosremoveFromMainArray() {
        for (var j = 0; j < MS_PadecimientosdeletedItem.length; j++) {
            for (var i = 0; i < MS_PadecimientosDataMain.length; i++) {
                if (MS_PadecimientosDataMain[i] != null && MS_PadecimientosDataMain[i].Id == MS_PadecimientosdeletedItem[j]) {
                    hMS_PadecimientosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_PadecimientoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_PadecimientosDataMain.length; i++) {
            data[i] = MS_PadecimientosDataMain[i];

        }
        return data;
    }
    function MS_PadecimientosgetNewResult() {
        var newData = copyMainMS_PadecimientosArray();

        for (var i = 0; i < MS_PadecimientosData.length; i++) {
            if (MS_PadecimientosData[i].Removed == null || MS_PadecimientosData[i].Removed == false) {
                newData.splice(0, 0, MS_PadecimientosData[i]);
            }
        }
        return newData;
    }
    function MS_PadecimientospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Tiempos_de_Comida_PlatillosinitializeMainArray(totalCount) {
        if (MS_Tiempos_de_Comida_PlatillosDataMain.length != totalCount && !MS_Tiempos_de_Comida_PlatillosDataMainInitialized) {
            MS_Tiempos_de_Comida_PlatillosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Tiempos_de_Comida_PlatillosDataMain[i] = null;
            }
        }
    }
    function MS_Tiempos_de_Comida_PlatillosremoveFromMainArray() {
        for (var j = 0; j < MS_Tiempos_de_Comida_PlatillosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Tiempos_de_Comida_PlatillosDataMain.length; i++) {
                if (MS_Tiempos_de_Comida_PlatillosDataMain[i] != null && MS_Tiempos_de_Comida_PlatillosDataMain[i].Id == MS_Tiempos_de_Comida_PlatillosdeletedItem[j]) {
                    hMS_Tiempos_de_Comida_PlatillosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Tiempos_de_Comida_PlatilloscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Tiempos_de_Comida_PlatillosDataMain.length; i++) {
            data[i] = MS_Tiempos_de_Comida_PlatillosDataMain[i];

        }
        return data;
    }
    function MS_Tiempos_de_Comida_PlatillosgetNewResult() {
        var newData = copyMainMS_Tiempos_de_Comida_PlatillosArray();

        for (var i = 0; i < MS_Tiempos_de_Comida_PlatillosData.length; i++) {
            if (MS_Tiempos_de_Comida_PlatillosData[i].Removed == null || MS_Tiempos_de_Comida_PlatillosData[i].Removed == false) {
                newData.splice(0, 0, MS_Tiempos_de_Comida_PlatillosData[i]);
            }
        }
        return newData;
    }
    function MS_Tiempos_de_Comida_PlatillospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Tiempos_de_Comida_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Tiempos_de_Comida_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Caracteristicas_PlatilloinitializeMainArray(totalCount) {
        if (MS_Caracteristicas_PlatilloDataMain.length != totalCount && !MS_Caracteristicas_PlatilloDataMainInitialized) {
            MS_Caracteristicas_PlatilloDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Caracteristicas_PlatilloDataMain[i] = null;
            }
        }
    }
    function MS_Caracteristicas_PlatilloremoveFromMainArray() {
        for (var j = 0; j < MS_Caracteristicas_PlatillodeletedItem.length; j++) {
            for (var i = 0; i < MS_Caracteristicas_PlatilloDataMain.length; i++) {
                if (MS_Caracteristicas_PlatilloDataMain[i] != null && MS_Caracteristicas_PlatilloDataMain[i].Id == MS_Caracteristicas_PlatillodeletedItem[j]) {
                    hMS_Caracteristicas_PlatilloDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Caracteristicas_PlatillocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Caracteristicas_PlatilloDataMain.length; i++) {
            data[i] = MS_Caracteristicas_PlatilloDataMain[i];

        }
        return data;
    }
    function MS_Caracteristicas_PlatillogetNewResult() {
        var newData = copyMainMS_Caracteristicas_PlatilloArray();

        for (var i = 0; i < MS_Caracteristicas_PlatilloData.length; i++) {
            if (MS_Caracteristicas_PlatilloData[i].Removed == null || MS_Caracteristicas_PlatilloData[i].Removed == false) {
                newData.splice(0, 0, MS_Caracteristicas_PlatilloData[i]);
            }
        }
        return newData;
    }
    function MS_Caracteristicas_PlatillopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Caracteristicas_PlatilloDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Caracteristicas_PlatilloDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MR_Detalle_PlatilloinitializeMainArray(totalCount) {
        if (MR_Detalle_PlatilloDataMain.length != totalCount && !MR_Detalle_PlatilloDataMainInitialized) {
            MR_Detalle_PlatilloDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MR_Detalle_PlatilloDataMain[i] = null;
            }
        }
    }
    function MR_Detalle_PlatilloremoveFromMainArray() {
        for (var j = 0; j < MR_Detalle_PlatillodeletedItem.length; j++) {
            for (var i = 0; i < MR_Detalle_PlatilloDataMain.length; i++) {
                if (MR_Detalle_PlatilloDataMain[i] != null && MR_Detalle_PlatilloDataMain[i].Id == MR_Detalle_PlatillodeletedItem[j]) {
                    hMR_Detalle_PlatilloDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MR_Detalle_PlatillocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MR_Detalle_PlatilloDataMain.length; i++) {
            data[i] = MR_Detalle_PlatilloDataMain[i];

        }
        return data;
    }
    function MR_Detalle_PlatillogetNewResult() {
        var newData = copyMainMR_Detalle_PlatilloArray();

        for (var i = 0; i < MR_Detalle_PlatilloData.length; i++) {
            if (MR_Detalle_PlatilloData[i].Removed == null || MR_Detalle_PlatilloData[i].Removed == false) {
                newData.splice(0, 0, MR_Detalle_PlatilloData[i]);
            }
        }
        return newData;
    }
    function MR_Detalle_PlatillopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MR_Detalle_PlatilloDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MR_Detalle_PlatilloDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Platillos_cmbLabelSelect").val();
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
    $('#CreatePlatillos')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                   $('#ddlCaloriasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCaloriasMult').trigger('chosen:updated');
                   $('#ddlDificultadMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlDificultadMult').trigger('chosen:updated');
                   $('#ddlCategoria_del_PlatilloMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCategoria_del_PlatilloMult').trigger('chosen:updated');
                   $('#ddlTiempo_de_comidaMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlTiempo_de_comidaMult').trigger('chosen:updated');
                   $('#ddlCaracteristicasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCaracteristicasMult').trigger('chosen:updated');
                MR_Detalle_PlatilloClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePlatillos').trigger('reset');
    $('#CreatePlatillos').find(':input').each(function () {
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
    var $myForm = $('#CreatePlatillos');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_CaloriascountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Calorias();
        return false;
    }
    if (MS_Dificultad_PlatilloscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Dificultad_Platillos();
        return false;
    }
    if (MS_PadecimientoscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Padecimientos();
        return false;
    }
    if (MS_Tiempos_de_Comida_PlatilloscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Tiempos_de_Comida_Platillos();
        return false;
    }
    if (MS_Caracteristicas_PlatillocountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Caracteristicas_Platillo();
        return false;
    }
    if (MR_Detalle_PlatillocountRowsChecked > 0)
    {
        ShowMessagePendingRowMR_Detalle_Platillo();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePlatillos").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePlatillos").on('click', '#PlatillosCancelar', function () {
	  if (!isPartial) {
        PlatillosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePlatillos").on('click', '#PlatillosGuardar', function () {
		$('#PlatillosGuardar').attr('disabled', true);
		$('#PlatillosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPlatillosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial  && !viewInEframe)
						PlatillosBackToGrid();
					else if (viewInEframe) 
                    {
                        $('#PlatillosGuardar').removeAttr('disabled');
                        $('#PlatillosGuardar').bind()
                    }
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Platillos', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_PlatillosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#PlatillosGuardar').removeAttr('disabled');
					$('#PlatillosGuardar').bind()
				}
		}
		else {
			$('#PlatillosGuardar').removeAttr('disabled');
			$('#PlatillosGuardar').bind()
		}
    });
	$("form#CreatePlatillos").on('click', '#PlatillosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPlatillosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_CaloriasData();
                getMS_Dificultad_PlatillosData();
                getMS_PadecimientosData();
                getMS_Tiempos_de_Comida_PlatillosData();
                getMS_Caracteristicas_PlatilloData();
                getMR_Detalle_PlatilloData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Platillos', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PlatillosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
	
	/*CODMANINI-ADD*/
	var vsMultCalorias = null;
	var vsMultDificultad = null;
	var vsMultCategotia = null;
	var vsMultTiempos = null;
	var vsMultCarac = null;
	/*CODMANFIN-ADD*/		
    $("form#CreatePlatillos").on('click', '#PlatillosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPlatillosData(function (currentId) {
					$("#FolioId").val("0");
	                $('#ddlCaloriasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCaloriasMult').trigger('chosen:updated');
                   $('#ddlDificultadMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlDificultadMult').trigger('chosen:updated');
                   $('#ddlCategoria_del_PlatilloMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCategoria_del_PlatilloMult').trigger('chosen:updated');
                   $('#ddlTiempo_de_comidaMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlTiempo_de_comidaMult').trigger('chosen:updated');
                   $('#ddlCaracteristicasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlCaracteristicasMult').trigger('chosen:updated');
				    /*CODMANINI-ADD*/
				   	vsMultCalorias = $('#ddlCaloriasMult').val();
					vsMultDificultad = $('#ddlDificultadMult').val();
					vsMultCategotia = $('#ddlCategoria_del_PlatilloMult').val();
					vsMultTiempos = $('#ddlTiempo_de_comidaMult').val();
					vsMultCarac =  $('#ddlCaracteristicasMult').val();
				   /*CODMANFIN-ADD*/	
				   
                MR_Detalle_PlatilloClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getMS_CaloriasData();
                getMS_Dificultad_PlatillosData();
                getMS_PadecimientosData();
                getMS_Tiempos_de_Comida_PlatillosData();
                getMS_Caracteristicas_PlatilloData();
                getMR_Detalle_PlatilloData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Platillos',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PlatillosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);                          
					    }	
					}						
			setIsNew();
				});
				/*CODMANINI-ADD*/
			$('#ddlCaloriasMult').val(vsMultCalorias);
			$("#ddlCaloriasMult").trigger('chosen:updated');
			$('#ddlDificultadMult').val(vsMultDificultad);
			$("#ddlDificultadMult").trigger('chosen:updated');
			$('#ddlCategoria_del_PlatilloMult').val(vsMultCategotia);
			$("#ddlCategoria_del_PlatilloMult").trigger('chosen:updated');
			$('#ddlTiempo_de_comidaMult').val(vsMultTiempos);
			$("#ddlTiempo_de_comidaMult").trigger('chosen:updated');
			$('#ddlCaracteristicasMult').val(vsMultCarac);
			$("#ddlCaracteristicasMult").trigger('chosen:updated');
			 /*CODMANFIN-ADD*/	
			debugger;
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



var PlatillosisdisplayBusinessPropery = false;
PlatillosDisplayBusinessRuleButtons(PlatillosisdisplayBusinessPropery);
function PlatillosDisplayBusinessRule() {
    if (!PlatillosisdisplayBusinessPropery) {
        $('#CreatePlatillos').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="PlatillosdisplayBusinessPropery"><button onclick="PlatillosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#PlatillosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.PlatillosdisplayBusinessPropery').remove();
    }
    PlatillosDisplayBusinessRuleButtons(!PlatillosisdisplayBusinessPropery);
    PlatillosisdisplayBusinessPropery = (PlatillosisdisplayBusinessPropery ? false : true);
}
function PlatillosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

