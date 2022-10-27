function pintar(objConfiguracion) {
    fetch(objConfiguracion.url)
        .then(res => res.json())
        .then(res => {
            var contenido = "<table class='table'>";
            contenido += "<tr>";
            for (var i = 0; i < objConfiguracion.cabeceras.length; i++) {
                contenido += "<th>" + objConfiguracion.cabeceras[i] +"</th>";
            }
            contenido += "</tr>";
            var fila;
            var propiedadActual;
            for (var j = 0; j < res.length; j++) {
                fila = res[j];
                contenido += "<tr>";
                for (var k = 0; k < objConfiguracion.cabeceras.length; k++) {
                    propiedadActual = objConfiguracion.propiedades[k];
                    contenido += "<td>" + fila[propiedadActual] + "</td>";
                }
                //contenido += "<td>" + fila.id + "</td>";
                //contenido += "<td>" + fila.nombre + "</td>";
                //contenido += "<td>" + fila.descripcion + "</td>";
                contenido += "</tr>";
            }
            contenido += "</table>";
            document.getElementById(objConfiguracion.id).innerHTML = contenido;
            //alert(res)
        })
}