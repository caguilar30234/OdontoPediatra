// Variables

var baseDeDatos;



function callback(response) {
    baseDeDatos = response;
}

function obtenerServicios() {
    return $.ajax({
        type: "GET",
        url: "/Treatment/ConsultarTratamientosJson",
        data: "{}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: callback,
    })
};



var descuentototal;
let carrito = [];
const divisa = '₡';
var DOMitems = document.querySelector('#items');
var DOMcarrito = document.querySelector('#carrito');
var DOMtotal = document.querySelector('#total');
var DOMbotonVaciar = document.querySelector('#boton-vaciar');
var DOMsubtotal = document.querySelector('#subtotal');
var DOMprecio = document.querySelector('#precio');
var DOMbotonPdf = document.querySelector('#boton-pdf');

// Funciones

/**
 * Dibuja todos los productos a partir de la base de datos. No confundir con el carrito
 */
function renderizarProductos() {
    baseDeDatos.forEach((info) => {
        // Estructura
        const miNodo = document.createElement('div');
        miNodo.classList.add('card', 'col-sm-4');
        miNodo.setAttribute('margin', 'auto');
        // Body
        const miNodoCardBody = document.createElement('div');
        miNodoCardBody.classList.add('card-body');
        // Titulo
        const miNodoTitle = document.createElement('h5');
        miNodoTitle.classList.add('card-title');
        miNodoTitle.textContent = info.NOMBRE_TRATAMIENTO;
        // Precio
        const miNodoPrecio = document.createElement('p');
        miNodoPrecio.classList.add('card-text');
        miNodoPrecio.textContent = `${divisa}${info.PRECIO_BASE}`;
        // Boton 
        const miNodoBoton = document.createElement('button');
        miNodoBoton.classList.add('btn', 'btn-primary');
        miNodoBoton.textContent = '+';
        miNodoBoton.setAttribute('marcador', info.ID_TRATAMIENTO);
        miNodoBoton.addEventListener('click', anyadirProductoAlCarrito);
        miNodoBoton.setAttribute('id', 'add');

        const informacionCard = document.createElement('div');
        informacionCard.style.display = "none";
        informacionCard.classList.add("info", "hidden");
        const nombreInfo = document.createElement('h3');
        nombreInfo.textContent = info.NOMBRE_TRATAMIENTO;

        const descripInfo = document.createElement('p');
        descripInfo.textContent = info.DESCRIPCION_SERVICIO;

        const duracionInfo = document.createElement('p');
        duracionInfo.textContent = "Duración en horas:  " + info.DURACION_HORAS;

        informacionCard.appendChild(nombreInfo);
        informacionCard.appendChild(descripInfo);
        informacionCard.appendChild(duracionInfo);

        // Insertamos
        //miNodoCardBody.appendChild(miNodoImagen);
        miNodoCardBody.appendChild(miNodoTitle);
        miNodoCardBody.appendChild(miNodoPrecio);
        miNodoCardBody.appendChild(miNodoBoton);
        miNodo.appendChild(miNodoCardBody);
        miNodo.appendChild(informacionCard);
        DOMitems.appendChild(miNodo);
    });
}

/**
 * Evento para añadir un producto al carrito de la compra
 */
function anyadirProductoAlCarrito(evento) {
    // Anyadimos el Nodo a nuestro carrito
    carrito.push(evento.target.getAttribute('marcador'));
    // Actualizamos el carrito 
    renderizarCarrito();

}

/**
 * Dibuja todos los productos guardados en el carrito
 */
function renderizarCarrito() {
    // Vaciamos todo el html
    DOMcarrito.textContent = '';
    // Quitamos los duplicados
    const carritoSinDuplicados = [...new Set(carrito)];
    // Generamos los Nodos a partir de carrito
    carritoSinDuplicados.forEach((item) => {
        // Obtenemos el item que necesitamos de la variable base de datos
        const miItem = baseDeDatos.filter((itemBaseDatos) => {
            // ¿Coincide las id? Solo puede existir un caso
            return itemBaseDatos.ID_TRATAMIENTO === parseInt(item);
        });
        // Cuenta el número de veces que se repite el producto
        const numeroUnidadesItem = carrito.reduce((total, itemId) => {
            // ¿Coincide las id? Incremento el contador, en caso contrario no mantengo
            return itemId === item ? total += 1 : total;
        }, 0);
        // Creamos el nodo del item del carrito
        const miNodo = document.createElement('li');
        miNodo.classList.add('list-group-item', 'text-right', 'mx-2');
        miNodo.textContent = `${numeroUnidadesItem} x ${miItem[0].NOMBRE_TRATAMIENTO} - ${divisa}${miItem[0].PRECIO_BASE}`;
        // Boton de borrar
        const miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger', 'mx-5');
        miBoton.textContent = 'X';
        miBoton.style.marginLeft = '1rem';
        miBoton.dataset.item = item;
        miBoton.addEventListener('click', borrarItemCarrito);
        miBoton.setAttribute("id", "eliminar");
        // Mezclamos nodos
        miNodo.appendChild(miBoton);
        DOMcarrito.appendChild(miNodo);
    });
    // Renderizamos el precio total en el HTML
    DOMprecio.textContent = calcularTotal();
    DOMimpuesto.textContent = (DOMprecio.textContent * 0.1).toFixed(2);
    DOMsubtotal.textContent = (parseFloat(DOMprecio.textContent) + parseFloat(DOMimpuesto.textContent)).toFixed(2);
    DOMdescuento.textContent = calcularDescuento();
    DOMtotal.textContent = (parseFloat(DOMsubtotal.textContent) - parseFloat(DOMdescuento.textContent)).toFixed(2);

}

/**
 * Evento para borrar un elemento del carrito
 */
function borrarItemCarrito(evento) {
    // Obtenemos el producto ID que hay en el boton pulsado
    const id = evento.target.dataset.item;
    // Borramos todos los productos
    carrito = carrito.filter((carritoId) => {
        return carritoId !== id;
    });
    // volvemos a renderizar
    renderizarCarrito();
}

/**
 * Calcula el precio total teniendo en cuenta los productos repetidos
 */
function calcularTotal() {
    // Recorremos el array del carrito 
    return carrito.reduce((total, item) => {
        // De cada elemento obtenemos su precio
        const miItem = baseDeDatos.filter((itemBaseDatos) => {
            return itemBaseDatos.ID_TRATAMIENTO === parseInt(item);
        });
        // Los sumamos al total
        return total + miItem[0].PRECIO_BASE;
    }, 0).toFixed(2);
}

function calcularDescuento() {
    descuentototal = 0;
    // Recorremos el array del carrito 
    return carrito.reduce((descuentototal, item) => {
        // De cada elemento obtenemos su precio
        const miItem = baseDeDatos.filter((itemBaseDatos) => {
            return itemBaseDatos.ID_TRATAMIENTO === parseInt(item);
        });
        // Los sumamos al total
        return descuentototal + miItem[0].DESCUENTO;
    }, 0).toFixed(2);
}

/**
 * Varia el carrito y vuelve a dibujarlo
 */
function vaciarCarrito() {
    // Limpiamos los productos guardados
    carrito = [];
    descuentototal = 0;
    // Renderizamos los cambios
    renderizarCarrito();
}

function syncDelay(milliseconds) {
    var start = new Date().getTime();
    var end = 0;

    while ((end - start) < milliseconds) {
        end = new Date().getTime();
    }
}

function descargarPdf() {
    var theIds = JSON.stringify(carrito);
    var montosarray = [DOMprecio.textContent, DOMimpuesto.textContent, DOMsubtotal.textContent, DOMdescuento.textContent, DOMtotal.textContent]
    var montos = JSON.stringify(montosarray)
    $.ajax({
        type: "GET",
        url: "/Cotizaciones/Download",
        data: {
            'carrito': theIds,
            'montos': montos
        },
    })
    syncDelay(8000);

    window.open('/assets/test.pdf');
};

// Eventos
DOMbotonVaciar.addEventListener('click', vaciarCarrito);


DOMbotonPdf.addEventListener('click', descargarPdf);

// Inicio
$.when(obtenerServicios()).done(function (a1) {
    renderizarProductos();
    renderizarCarrito()
});

