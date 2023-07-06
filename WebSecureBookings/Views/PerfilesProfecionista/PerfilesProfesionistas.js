document.addEventListener("DOMContentLoaded", function () {
    // Obtener el elemento del botón por su ID
    var btnLimpiar = document.getElementById("btnLimpiarFiltro");

    // Verificar si el elemento existe antes de intentar ocultarlo
    if (btnLimpiar) {
        // Ocultar el botón estableciendo la propiedad "display" a "none"
        btnLimpiar.style.display = "none";
    }

    //Llama a la función GetProfesionistas()
    GetProfesionistas();
    GetProfesion();
    GetCiudades();

    $("#btnBuscar").click(function () {
        fn_getBusqueda();
    });
});


//Función para llenar el combo de selección de liga
function GetProfesionistas() {
    fn_block();
    $("#div-profesionales").html("");
    //Realiza una solicitud AJAX utilizando jQuery
    $.ajax({
        url: "PerfilesProfesionistas.aspx/GetProfesionistas", // URL de la solicitud
        data: "", // Datos a enviar (vacío en este caso)
        type: "POST", // Método de la solicitud (POST en este caso)
        dataType: "JSON", // Tipo de datos esperado en la respuesta (JSON en este caso)
        contentType: "application/json; charset=utf-8", // Tipo de contenido de la solicitud
        success: function (data) { // Función que se ejecuta cuando la solicitud es exitosa
            //Acceder a las propiedades del objeto dentro del array
            var obj = data.d[0];

            if (obj.StatusCode == 200) {
                $("#div-profesionales").html(obj.Resultado);
            } else {
                console.log(obj.StatusCode);
                console.log(obj.Message);
            }
        },
        error: function (xhr, status, error) { // Función que se ejecuta cuando hay un error en la solicitud
            console.log(status); // Imprime el estado del error
        }
    });
    fn_unBlock();
}

//Función para llenar el combo de selección de Profesión
function GetProfesion() {
    fn_block();
    $("#cboProfeciones").html("");
    //Realiza una solicitud AJAX utilizando jQuery
    $.ajax({
        url: "PerfilesProfesionistas.aspx/GetProfesiones", // URL de la solicitud
        data: "", // Datos a enviar (vacío en este caso)
        type: "POST", // Método de la solicitud (POST en este caso)
        dataType: "JSON", // Tipo de datos esperado en la respuesta (JSON en este caso)
        contentType: "application/json; charset=utf-8", // Tipo de contenido de la solicitud
        success: function (data) { // Función que se ejecuta cuando la solicitud es exitosa
            //Acceder a las propiedades del objeto dentro del array
            var obj = data.d[0];

            if (obj.StatusCode == 200) {
                $("#cboProfeciones").html(obj.Resultado);
            } else {
                console.log(obj.StatusCode);
                console.log(obj.Message);
            }
        },
        error: function (xhr, status, error) { // Función que se ejecuta cuando hay un error en la solicitud
            console.log(status); // Imprime el estado del error
        }
    });
    fn_unBlock();
}

function GetCiudades() {
    fn_block();
    $("#cboCiudades").html("");
    //Realiza una solicitud AJAX utilizando jQuery
    $.ajax({
        url: "PerfilesProfesionistas.aspx/GetCiudades", // URL de la solicitud
        data: "", // Datos a enviar (vacío en este caso)
        type: "POST", // Método de la solicitud (POST en este caso)
        dataType: "JSON", // Tipo de datos esperado en la respuesta (JSON en este caso)
        contentType: "application/json; charset=utf-8", // Tipo de contenido de la solicitud
        success: function (data) { // Función que se ejecuta cuando la solicitud es exitosa
            //Acceder a las propiedades del objeto dentro del array
            var obj = data.d[0];

            if (obj.StatusCode == 200) {
                $("#cboCiudades").html(obj.Resultado);
            } else {
                console.log(obj.StatusCode);
                console.log(obj.Message);
            }
        },
        error: function (xhr, status, error) { // Función que se ejecuta cuando hay un error en la solicitud
            console.log(status); // Imprime el estado del error
        }
    });
    fn_unBlock();
}

function fn_getBusqueda() {
    fn_block();
    // Obtener el elemento select por su ID
    var cboProfesion = document.getElementById("cboProfeciones");
    // Obtener el valor seleccionado
    var sProfesion = cboProfesion.value;

    var cboCiudad = document.getElementById("cboCiudades");
    // Obtener el valor seleccionado
    var sCiudad = cboCiudad.value;
    // Mostrar el valor seleccionado en la consola
    if (sCiudad != 0 || sProfesion != 0) {
        $("#div-profesionales").html("");
        //Realiza una solicitud AJAX utilizando jQuery
        $.ajax({
            url: "PerfilesProfesionistas.aspx/GetProfesionistasFiltro", // URL de la solicitud
            data: JSON.stringify({ sProfesion: sProfesion, sEstado: sCiudad }), // Datos a enviar (vacío en este caso)
            type: "POST", // Método de la solicitud (POST en este caso)
            dataType: "JSON", // Tipo de datos esperado en la respuesta (JSON en este caso)
            contentType: "application/json; charset=utf-8", // Tipo de contenido de la solicitud
            success: function (data) { // Función que se ejecuta cuando la solicitud es exitosa
                //Acceder a las propiedades del objeto dentro del array
                var obj = data.d[0];

                if (obj.StatusCode == 200) {
                    $("#div-profesionales").html(obj.Resultado);
                } else {
                    console.log(obj.StatusCode);
                    console.log(obj.Message);
                }
            },
            error: function (xhr, status, error) { // Función que se ejecuta cuando hay un error en la solicitud
                console.log(status); // Imprime el estado del error
            }
        });
    } else {
        error = '<br /><span style="color: red;">Favor de seleccionar almenos una profesión o ciudad</span>';
        $('#btnBuscar').after($(error).fadeOut(2500));
    }
    fn_unBlock();
}