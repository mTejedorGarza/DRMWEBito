        function RemoveAttachmentMainImagen () {
            $("#hdnRemoveImagen").val("1");
            $("#divAttachmentImagen").hide();
        }
        function RemoveAttachmentMainVideo () {
            $("#hdnRemoveVideo").val("1");
            $("#divAttachmentVideo").hide();
        }


var MS_Uso_del_EjerciciocountRowsChecked = 0;
function GetMS_Uso_del_EjercicioFromDataTable() {
    var MS_Uso_del_EjercicioData = [];
    debugger;

    var items = $("#ddlEl_ejercicio_se_usa_paraMult").chosen().val();
    //es nuevo 
    if (MS_Uso_del_EjercicioDataDataTable == undefined || MS_Uso_del_EjercicioDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Uso_del_EjercicioData.push({ 
                      Folio: 0
                      
, Uso_del_Ejercicio: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Uso_del_EjercicioDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Uso_del_EjercicioDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Uso_del_EjercicioData.push({
                        Folio: MS_Uso_del_EjercicioDataDataTable[i].Folio
                        
                   , Uso_del_Ejercicio: MS_Uso_del_EjercicioDataDataTable[i].Uso_del_Ejercicio

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
                    for (var j = 0; j < MS_Uso_del_EjercicioDataDataTable.length; j++) {
                        if (items[i] == MS_Uso_del_EjercicioDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Uso_del_EjercicioData.push({ 
                              Folio: 0
                              
, Uso_del_Ejercicio: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Uso_del_EjercicioData;
}

//Used to Get Ejercicios Information
function GetMS_Uso_del_Ejercicio() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Uso_del_EjercicioData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Uso_del_EjercicioData[i].Folio);
       
      form_data.append('[' + i +'].Uso_del_Ejercicio',MS_Uso_del_EjercicioData[i].Uso_del_Ejercicio);


       form_data.append('[' + i + '].Removed', MS_Uso_del_EjercicioData[i].Removed);
    }
    return form_data;
}

var MS_MusculoscountRowsChecked = 0;
function GetMS_MusculosFromDataTable() {
    var MS_MusculosData = [];
    debugger;

    var items = $("#ddlMusculos_trabajadosMult").chosen().val();
    //es nuevo 
    if (MS_MusculosDataDataTable == undefined || MS_MusculosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_MusculosData.push({ 
                      Folio: 0
                      
, Musculo: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_MusculosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_MusculosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_MusculosData.push({
                        Folio: MS_MusculosDataDataTable[i].Folio
                        
                   , Musculo: MS_MusculosDataDataTable[i].Musculo

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
                    for (var j = 0; j < MS_MusculosDataDataTable.length; j++) {
                        if (items[i] == MS_MusculosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_MusculosData.push({ 
                              Folio: 0
                              
, Musculo: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_MusculosData;
}

//Used to Get Ejercicios Information
function GetMS_Musculos() {
    var form_data = new FormData();
    for (var i = 0; i < MS_MusculosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_MusculosData[i].Folio);
       
      form_data.append('[' + i +'].Musculo',MS_MusculosData[i].Musculo);


       form_data.append('[' + i + '].Removed', MS_MusculosData[i].Removed);
    }
    return form_data;
}

var MS_Equipamiento_para_EjercicioscountRowsChecked = 0;
function GetMS_Equipamiento_para_EjerciciosFromDataTable() {
    var MS_Equipamiento_para_EjerciciosData = [];
    debugger;

    var items = $("#ddlEquipamientoMult").chosen().val();
    //es nuevo 
    if (MS_Equipamiento_para_EjerciciosDataDataTable == undefined || MS_Equipamiento_para_EjerciciosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Equipamiento_para_EjerciciosData.push({ 
                      Folio: 0
                      
, Equipamento: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Equipamiento_para_EjerciciosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Equipamiento_para_EjerciciosData.push({
                        Folio: MS_Equipamiento_para_EjerciciosDataDataTable[i].Folio
                        
                   , Equipamento: MS_Equipamiento_para_EjerciciosDataDataTable[i].Equipamento

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
                    for (var j = 0; j < MS_Equipamiento_para_EjerciciosDataDataTable.length; j++) {
                        if (items[i] == MS_Equipamiento_para_EjerciciosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Equipamiento_para_EjerciciosData.push({ 
                              Folio: 0
                              
, Equipamento: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Equipamiento_para_EjerciciosData;
}

//Used to Get Ejercicios Information
function GetMS_Equipamiento_para_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Equipamiento_para_EjerciciosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Equipamiento_para_EjerciciosData[i].Folio);
       
      form_data.append('[' + i +'].Equipamento',MS_Equipamiento_para_EjerciciosData[i].Equipamento);


       form_data.append('[' + i + '].Removed', MS_Equipamiento_para_EjerciciosData[i].Removed);
    }
    return form_data;
}

var MS_Equipamiento_Alterno_EjercicioscountRowsChecked = 0;
function GetMS_Equipamiento_Alterno_EjerciciosFromDataTable() {
    var MS_Equipamiento_Alterno_EjerciciosData = [];
    debugger;

    var items = $("#ddlEquipamiento_AlternoMult").chosen().val();
    //es nuevo 
    if (MS_Equipamiento_Alterno_EjerciciosDataDataTable == undefined || MS_Equipamiento_Alterno_EjerciciosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Equipamiento_Alterno_EjerciciosData.push({ 
                      Folio: 0
                      
, Equipamiento_Alterno: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Equipamiento_Alterno_EjerciciosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Equipamiento_Alterno_EjerciciosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Equipamiento_Alterno_EjerciciosData.push({
                        Folio: MS_Equipamiento_Alterno_EjerciciosDataDataTable[i].Folio
                        
                   , Equipamiento_Alterno: MS_Equipamiento_Alterno_EjerciciosDataDataTable[i].Equipamiento_Alterno

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
                    for (var j = 0; j < MS_Equipamiento_Alterno_EjerciciosDataDataTable.length; j++) {
                        if (items[i] == MS_Equipamiento_Alterno_EjerciciosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Equipamiento_Alterno_EjerciciosData.push({ 
                              Folio: 0
                              
, Equipamiento_Alterno: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Equipamiento_Alterno_EjerciciosData;
}

//Used to Get Ejercicios Information
function GetMS_Equipamiento_Alterno_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Equipamiento_Alterno_EjerciciosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Equipamiento_Alterno_EjerciciosData[i].Folio);
       
      form_data.append('[' + i +'].Equipamiento_Alterno',MS_Equipamiento_Alterno_EjerciciosData[i].Equipamiento_Alterno);


       form_data.append('[' + i + '].Removed', MS_Equipamiento_Alterno_EjerciciosData[i].Removed);
    }
    return form_data;
}

var MS_Sexo_EjercicioscountRowsChecked = 0;
function GetMS_Sexo_EjerciciosFromDataTable() {
    var MS_Sexo_EjerciciosData = [];
    debugger;

    var items = $("#ddlSexoMult").chosen().val();
    //es nuevo 
    if (MS_Sexo_EjerciciosDataDataTable == undefined || MS_Sexo_EjerciciosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Sexo_EjerciciosData.push({ 
                      Folio: 0
                      
, Sexo: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Sexo_EjerciciosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Sexo_EjerciciosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Sexo_EjerciciosData.push({
                        Folio: MS_Sexo_EjerciciosDataDataTable[i].Folio
                        
                   , Sexo: MS_Sexo_EjerciciosDataDataTable[i].Sexo

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
                    for (var j = 0; j < MS_Sexo_EjerciciosDataDataTable.length; j++) {
                        if (items[i] == MS_Sexo_EjerciciosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Sexo_EjerciciosData.push({ 
                              Folio: 0
                              
, Sexo: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Sexo_EjerciciosData;
}

//Used to Get Ejercicios Information
function GetMS_Sexo_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Sexo_EjerciciosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Sexo_EjerciciosData[i].Folio);
       
      form_data.append('[' + i +'].Sexo',MS_Sexo_EjerciciosData[i].Sexo);


       form_data.append('[' + i + '].Removed', MS_Sexo_EjerciciosData[i].Removed);
    }
    return form_data;
}

var MS_Dificultad_EjercicioscountRowsChecked = 0;
function GetMS_Dificultad_EjerciciosFromDataTable() {
    var MS_Dificultad_EjerciciosData = [];
    debugger;

    var items = $("#ddlNivel_de_dificultadMult").chosen().val();
    //es nuevo 
    if (MS_Dificultad_EjerciciosDataDataTable == undefined || MS_Dificultad_EjerciciosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Dificultad_EjerciciosData.push({ 
                      Folio: 0
                      
, Nivel_de_Dificultad: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Dificultad_EjerciciosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Dificultad_EjerciciosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Dificultad_EjerciciosData.push({
                        Folio: MS_Dificultad_EjerciciosDataDataTable[i].Folio
                        
                   , Nivel_de_Dificultad: MS_Dificultad_EjerciciosDataDataTable[i].Nivel_de_Dificultad

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
                    for (var j = 0; j < MS_Dificultad_EjerciciosDataDataTable.length; j++) {
                        if (items[i] == MS_Dificultad_EjerciciosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Dificultad_EjerciciosData.push({ 
                              Folio: 0
                              
, Nivel_de_Dificultad: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Dificultad_EjerciciosData;
}

//Used to Get Ejercicios Information
function GetMS_Dificultad_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Dificultad_EjerciciosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Dificultad_EjerciciosData[i].Folio);
       
      form_data.append('[' + i +'].Nivel_de_Dificultad',MS_Dificultad_EjerciciosData[i].Nivel_de_Dificultad);


       form_data.append('[' + i + '].Removed', MS_Dificultad_EjerciciosData[i].Removed);
    }
    return form_data;
}



$(function () {
    function MS_Uso_del_EjercicioinitializeMainArray(totalCount) {
        if (MS_Uso_del_EjercicioDataMain.length != totalCount && !MS_Uso_del_EjercicioDataMainInitialized) {
            MS_Uso_del_EjercicioDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Uso_del_EjercicioDataMain[i] = null;
            }
        }
    }
    function MS_Uso_del_EjercicioremoveFromMainArray() {
        for (var j = 0; j < MS_Uso_del_EjerciciodeletedItem.length; j++) {
            for (var i = 0; i < MS_Uso_del_EjercicioDataMain.length; i++) {
                if (MS_Uso_del_EjercicioDataMain[i] != null && MS_Uso_del_EjercicioDataMain[i].Id == MS_Uso_del_EjerciciodeletedItem[j]) {
                    hMS_Uso_del_EjercicioDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Uso_del_EjerciciocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Uso_del_EjercicioDataMain.length; i++) {
            data[i] = MS_Uso_del_EjercicioDataMain[i];

        }
        return data;
    }
    function MS_Uso_del_EjerciciogetNewResult() {
        var newData = copyMainMS_Uso_del_EjercicioArray();

        for (var i = 0; i < MS_Uso_del_EjercicioData.length; i++) {
            if (MS_Uso_del_EjercicioData[i].Removed == null || MS_Uso_del_EjercicioData[i].Removed == false) {
                newData.splice(0, 0, MS_Uso_del_EjercicioData[i]);
            }
        }
        return newData;
    }
    function MS_Uso_del_EjerciciopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Uso_del_EjercicioDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Uso_del_EjercicioDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_MusculosinitializeMainArray(totalCount) {
        if (MS_MusculosDataMain.length != totalCount && !MS_MusculosDataMainInitialized) {
            MS_MusculosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_MusculosDataMain[i] = null;
            }
        }
    }
    function MS_MusculosremoveFromMainArray() {
        for (var j = 0; j < MS_MusculosdeletedItem.length; j++) {
            for (var i = 0; i < MS_MusculosDataMain.length; i++) {
                if (MS_MusculosDataMain[i] != null && MS_MusculosDataMain[i].Id == MS_MusculosdeletedItem[j]) {
                    hMS_MusculosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_MusculoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_MusculosDataMain.length; i++) {
            data[i] = MS_MusculosDataMain[i];

        }
        return data;
    }
    function MS_MusculosgetNewResult() {
        var newData = copyMainMS_MusculosArray();

        for (var i = 0; i < MS_MusculosData.length; i++) {
            if (MS_MusculosData[i].Removed == null || MS_MusculosData[i].Removed == false) {
                newData.splice(0, 0, MS_MusculosData[i]);
            }
        }
        return newData;
    }
    function MS_MusculospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_MusculosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_MusculosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Equipamiento_para_EjerciciosinitializeMainArray(totalCount) {
        if (MS_Equipamiento_para_EjerciciosDataMain.length != totalCount && !MS_Equipamiento_para_EjerciciosDataMainInitialized) {
            MS_Equipamiento_para_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Equipamiento_para_EjerciciosDataMain[i] = null;
            }
        }
    }
    function MS_Equipamiento_para_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < MS_Equipamiento_para_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataMain.length; i++) {
                if (MS_Equipamiento_para_EjerciciosDataMain[i] != null && MS_Equipamiento_para_EjerciciosDataMain[i].Id == MS_Equipamiento_para_EjerciciosdeletedItem[j]) {
                    hMS_Equipamiento_para_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Equipamiento_para_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataMain.length; i++) {
            data[i] = MS_Equipamiento_para_EjerciciosDataMain[i];

        }
        return data;
    }
    function MS_Equipamiento_para_EjerciciosgetNewResult() {
        var newData = copyMainMS_Equipamiento_para_EjerciciosArray();

        for (var i = 0; i < MS_Equipamiento_para_EjerciciosData.length; i++) {
            if (MS_Equipamiento_para_EjerciciosData[i].Removed == null || MS_Equipamiento_para_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, MS_Equipamiento_para_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function MS_Equipamiento_para_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Equipamiento_para_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Equipamiento_para_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Equipamiento_Alterno_EjerciciosinitializeMainArray(totalCount) {
        if (MS_Equipamiento_Alterno_EjerciciosDataMain.length != totalCount && !MS_Equipamiento_Alterno_EjerciciosDataMainInitialized) {
            MS_Equipamiento_Alterno_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Equipamiento_Alterno_EjerciciosDataMain[i] = null;
            }
        }
    }
    function MS_Equipamiento_Alterno_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < MS_Equipamiento_Alterno_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Equipamiento_Alterno_EjerciciosDataMain.length; i++) {
                if (MS_Equipamiento_Alterno_EjerciciosDataMain[i] != null && MS_Equipamiento_Alterno_EjerciciosDataMain[i].Id == MS_Equipamiento_Alterno_EjerciciosdeletedItem[j]) {
                    hMS_Equipamiento_Alterno_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Equipamiento_Alterno_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Equipamiento_Alterno_EjerciciosDataMain.length; i++) {
            data[i] = MS_Equipamiento_Alterno_EjerciciosDataMain[i];

        }
        return data;
    }
    function MS_Equipamiento_Alterno_EjerciciosgetNewResult() {
        var newData = copyMainMS_Equipamiento_Alterno_EjerciciosArray();

        for (var i = 0; i < MS_Equipamiento_Alterno_EjerciciosData.length; i++) {
            if (MS_Equipamiento_Alterno_EjerciciosData[i].Removed == null || MS_Equipamiento_Alterno_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, MS_Equipamiento_Alterno_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function MS_Equipamiento_Alterno_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Equipamiento_Alterno_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Equipamiento_Alterno_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Sexo_EjerciciosinitializeMainArray(totalCount) {
        if (MS_Sexo_EjerciciosDataMain.length != totalCount && !MS_Sexo_EjerciciosDataMainInitialized) {
            MS_Sexo_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Sexo_EjerciciosDataMain[i] = null;
            }
        }
    }
    function MS_Sexo_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < MS_Sexo_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Sexo_EjerciciosDataMain.length; i++) {
                if (MS_Sexo_EjerciciosDataMain[i] != null && MS_Sexo_EjerciciosDataMain[i].Id == MS_Sexo_EjerciciosdeletedItem[j]) {
                    hMS_Sexo_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Sexo_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Sexo_EjerciciosDataMain.length; i++) {
            data[i] = MS_Sexo_EjerciciosDataMain[i];

        }
        return data;
    }
    function MS_Sexo_EjerciciosgetNewResult() {
        var newData = copyMainMS_Sexo_EjerciciosArray();

        for (var i = 0; i < MS_Sexo_EjerciciosData.length; i++) {
            if (MS_Sexo_EjerciciosData[i].Removed == null || MS_Sexo_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, MS_Sexo_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function MS_Sexo_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Sexo_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Sexo_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Dificultad_EjerciciosinitializeMainArray(totalCount) {
        if (MS_Dificultad_EjerciciosDataMain.length != totalCount && !MS_Dificultad_EjerciciosDataMainInitialized) {
            MS_Dificultad_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Dificultad_EjerciciosDataMain[i] = null;
            }
        }
    }
    function MS_Dificultad_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < MS_Dificultad_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Dificultad_EjerciciosDataMain.length; i++) {
                if (MS_Dificultad_EjerciciosDataMain[i] != null && MS_Dificultad_EjerciciosDataMain[i].Id == MS_Dificultad_EjerciciosdeletedItem[j]) {
                    hMS_Dificultad_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Dificultad_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Dificultad_EjerciciosDataMain.length; i++) {
            data[i] = MS_Dificultad_EjerciciosDataMain[i];

        }
        return data;
    }
    function MS_Dificultad_EjerciciosgetNewResult() {
        var newData = copyMainMS_Dificultad_EjerciciosArray();

        for (var i = 0; i < MS_Dificultad_EjerciciosData.length; i++) {
            if (MS_Dificultad_EjerciciosData[i].Removed == null || MS_Dificultad_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, MS_Dificultad_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function MS_Dificultad_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Dificultad_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Dificultad_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
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
    var labelSelect = $("#Ejercicios_cmbLabelSelect").val();
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
    $("#ReferenceClave").val("0");
    $('#CreateEjercicios')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
                   $('#ddlEl_ejercicio_se_usa_paraMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEl_ejercicio_se_usa_paraMult').trigger('chosen:updated');
                   $('#ddlMusculos_trabajadosMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlMusculos_trabajadosMult').trigger('chosen:updated');
                   $('#ddlEquipamientoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamientoMult').trigger('chosen:updated');
                   $('#ddlEquipamiento_AlternoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamiento_AlternoMult').trigger('chosen:updated');
                   $('#ddlSexoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlSexoMult').trigger('chosen:updated');
                   $('#ddlNivel_de_dificultadMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlNivel_de_dificultadMult').trigger('chosen:updated');

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateEjercicios').trigger('reset');
    $('#CreateEjercicios').find(':input').each(function () {
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
    var $myForm = $('#CreateEjercicios');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_Uso_del_EjerciciocountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Uso_del_Ejercicio();
        return false;
    }
    if (MS_MusculoscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Musculos();
        return false;
    }
    if (MS_Equipamiento_para_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Equipamiento_para_Ejercicios();
        return false;
    }
    if (MS_Equipamiento_Alterno_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Equipamiento_Alterno_Ejercicios();
        return false;
    }
    if (MS_Sexo_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Sexo_Ejercicios();
        return false;
    }
    if (MS_Dificultad_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Dificultad_Ejercicios();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateEjercicios").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosCancelar', function () {
	  if (!isPartial) {
        EjerciciosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosGuardar', function () {
		$('#EjerciciosGuardar').attr('disabled', true);
		$('#EjerciciosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendEjerciciosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						EjerciciosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Ejercicios', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_EjerciciosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#EjerciciosGuardar').removeAttr('disabled');
					$('#EjerciciosGuardar').bind()
				}
		}
		else {
			$('#EjerciciosGuardar').removeAttr('disabled');
			$('#EjerciciosGuardar').bind()
		}
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendEjerciciosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_Uso_del_EjercicioData();
                getMS_MusculosData();
                getMS_Equipamiento_para_EjerciciosData();
                getMS_Equipamiento_Alterno_EjerciciosData();
                getMS_Sexo_EjerciciosData();
                getMS_Dificultad_EjerciciosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ejercicios', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EjerciciosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateEjercicios").on('click', '#EjerciciosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendEjerciciosData(function (currentId) {
					$("#ClaveId").val("0");
	                   $('#ddlEl_ejercicio_se_usa_paraMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEl_ejercicio_se_usa_paraMult').trigger('chosen:updated');
                   $('#ddlMusculos_trabajadosMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlMusculos_trabajadosMult').trigger('chosen:updated');
                   $('#ddlEquipamientoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamientoMult').trigger('chosen:updated');
                   $('#ddlEquipamiento_AlternoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamiento_AlternoMult').trigger('chosen:updated');
                   $('#ddlSexoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlSexoMult').trigger('chosen:updated');
                   $('#ddlNivel_de_dificultadMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlNivel_de_dificultadMult').trigger('chosen:updated');

					ResetClaveLabel();
					$("#ReferenceClave").val(currentId);
	                getMS_Uso_del_EjercicioData();
                getMS_MusculosData();
                getMS_Equipamiento_para_EjerciciosData();
                getMS_Equipamiento_Alterno_EjerciciosData();
                getMS_Sexo_EjerciciosData();
                getMS_Dificultad_EjerciciosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ejercicios',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EjerciciosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);                          
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



var EjerciciosisdisplayBusinessPropery = false;
EjerciciosDisplayBusinessRuleButtons(EjerciciosisdisplayBusinessPropery);
function EjerciciosDisplayBusinessRule() {
    if (!EjerciciosisdisplayBusinessPropery) {
        $('#CreateEjercicios').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="EjerciciosdisplayBusinessPropery"><button onclick="EjerciciosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#EjerciciosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.EjerciciosdisplayBusinessPropery').remove();
    }
    EjerciciosDisplayBusinessRuleButtons(!EjerciciosisdisplayBusinessPropery);
    EjerciciosisdisplayBusinessPropery = (EjerciciosisdisplayBusinessPropery ? false : true);
}
function EjerciciosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

