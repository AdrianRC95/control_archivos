$(document).ready(function () {
    //Deshabilita el boton al cargar la pagina
    $("input[id$='Button1']").prop("disabled", true);

    $("input[id$='TextBox1']").change(function () {
        checkForm();
    });

    $("input[id$='TextBox2']").change(function () {
        checkForm();
    });

    $("input[id$='Button1']").click(function () {
        checkForm(); //Tiene algo de redundancia revisar despues de que se supone que revisa cada change() y se activa SOLO al estar bien todo pero bueno!!!!!
        //$('#signup')[0].reset(); //Reinicia el formulario NO RECOMENDADO
        alert("Control del formulario de registro de usuario funciona Correctamente |(");
    });

    function checkForm() {
        var longUser = $("input[id$='TextBox1']").val().length;
        var longPass = $("input[id$='TextBox2']").val().length;

        if (longUser !=0 && longPass !=0) {
            $("input[id$='Button1']").prop("disabled", false);
        }
        else {
            $("input[id$='Button1']").prop("disabled", true);
        }
    }

});
