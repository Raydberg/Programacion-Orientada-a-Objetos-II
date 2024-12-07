
document.getElementById("viajesSelect").addEventListener("change",
    function() {
        console.log("Viaje Selecionado :" + this.value);
    });
document.getElementById("rutasSelect").addEventListener("change",
    function() {
        console.log("Codigo de ruta selecinado :" + this.value);
    });

document.getElementById("chofersSelect").addEventListener("change",
    function() {
        console.log("El id del chofer selecionado : " + this.value);
    });

$(document).ready(function() {
    $("#viajesSelect, #rutasSelect, #chofersSelect").change(function() {
        var cod_rut = $("#rutasSelect").val();
        var cod_chof = $("#chofersSelect").val();
        var hrs_sal = $("#viajesSelect").val();

        $.ajax({
            url: '@Url.Action("ListarViajesPersonalizado", "ListarViajes")',
            type: "GET",
            data: {
                cod_rut: cod_rut,
                cod_chof: cod_chof,
                hrs_sal: hrs_sal
            },
            success: function(result) {
                $("#viajesTable").html($(result).find("#viajesTable").html());
            }

        });


    });


});