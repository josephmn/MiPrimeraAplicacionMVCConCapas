window.onload = function () {
    listarCama();
}

function listarCama() {
    pintar({
        url: "Cama/listarCama",
        id: "divTabla",
        cabeceras: ["Id Cama", "Nombre", "Descripcion"],
        propiedades: ["idcama", "nombre", "descripcion"]
    })
}