let idEditando = null;

function cargarPublicaciones() {
  fetch("http://localhost:5247/api/publicaciones")
    .then((response) => response.json())
    .then((data) => {
      document.getElementById("tablaPublicaciones").innerHTML = "";
      data.forEach((publicacion) => {
        const fila = document.createElement("tr");
        fila.innerHTML = `
        <td>${publicacion.id}</td>
        <td>${publicacion.titulo}</td>
        <td>${publicacion.tipo}</td>
        <td>${publicacion.anio}</td>
        <td>${publicacion.isbn}</td>
        <td>${publicacion.costo}</td>
        <td>${publicacion.autor || publicacion.paginas || publicacion.heroe || publicacion.noticia || ""}</td>
        <td><button onclick="eliminarPublicacion(${publicacion.id})">Eliminar</button></td>
        <td><button onclick="editarPublicacion(${publicacion.id})">Editar</button></td>
        `;
        document.getElementById("tablaPublicaciones").appendChild(fila);
      });
    });
}

function mostrarCampoEspecifico() {
  const tipo = document.getElementById("tipo").value;

  document.getElementById("autor").style.display = "none";
  document.getElementById("paginas").style.display = "none";
  document.getElementById("heroe").style.display = "none";
  document.getElementById("noticia").style.display = "none";

  if (tipo == "libro") {
    document.getElementById("autor").style.display = "inline";
  } else if (tipo == "revista") {
    document.getElementById("paginas").style.display = "inline";
  } else if (tipo == "comic") {
    document.getElementById("heroe").style.display = "inline";
  } else if (tipo == "periodico") {
    document.getElementById("noticia").style.display = "inline";
  }
}

function crearPublicacion() {
  const titulo = document.getElementById("titulo").value;
  const anio = parseInt(document.getElementById("anio").value);
  const isbn = document.getElementById("isbn").value;
  const costo = parseFloat(document.getElementById("costo").value);
  const tipo = document.getElementById("tipo").value;

  let publicacion = { titulo, anio, isbn, costo, tipo };
  let url = "";

  if (tipo == "libro") {
    publicacion.autor = document.getElementById("autor").value;
    url = "http://localhost:5247/api/Libros";
  } else if (tipo == "revista") {
    publicacion.paginas = parseInt(document.getElementById("paginas").value);
    url = "http://localhost:5247/api/Revistas";
  } else if (tipo == "comic") {
    publicacion.heroe = document.getElementById("heroe").value;
    url = "http://localhost:5247/api/Comics";
  } else if (tipo == "periodico") {
    publicacion.noticia = document.getElementById("noticia").value;
    url = "http://localhost:5247/api/Periodicos";
  }

  fetch(url, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(publicacion),
  }).then((response) => {
    if (response.ok) {
      cargarPublicaciones();
    }
  });
}

function editarPublicacion(id) {
  idEditando = id;

  fetch(`http://localhost:5247/api/Publicaciones/${id}`)
    .then((response) => response.json())
    .then((publicacion) => {
      document.getElementById("titulo").value = publicacion.titulo;
      document.getElementById("anio").value = publicacion.anio;
      document.getElementById("isbn").value = publicacion.isbn;
      document.getElementById("costo").value = publicacion.costo;
      document.getElementById("tipo").value = publicacion.tipo;

      if (publicacion.tipo === "revista") {
        document.getElementById("paginas").value = publicacion.paginas;
      } else if (publicacion.tipo === "libro") {
        document.getElementById("autor").value = publicacion.autor;
      } else if (publicacion.tipo === "comic") {
        document.getElementById("heroe").value = publicacion.heroe;
      } else if (publicacion.tipo === "periodico") {
        document.getElementById("noticia").value = publicacion.noticia;
      }

      mostrarCampoEspecifico();

      document.getElementById("crear").style.display = "none";
      document.getElementById("editar").style.display = "inline";
    });
}

function actualizarPublicacion() {
  const titulo = document.getElementById("titulo").value;
  const anio = parseInt(document.getElementById("anio").value);
  const isbn = document.getElementById("isbn").value;
  const costo = parseFloat(document.getElementById("costo").value);
  const tipo = document.getElementById("tipo").value;

  let url = `http://localhost:5247/api/Libros/${idEditando}`;
  let publicacion = { titulo, anio, isbn, costo, tipo };

  if (idEditando == null) {
    document.getElementById("crear").style.display = "inline";
  } else {
    document.getElementById("editar").style.display = "inline";
  }

  if (tipo == "libro") {
    publicacion.autor = document.getElementById("autor").value;
    url = `http://localhost:5247/api/Libros/${idEditando}`;
  } else if (tipo == "revista") {
    publicacion.paginas = parseInt(document.getElementById("paginas").value);
    url = `http://localhost:5247/api/Revistas/${idEditando}`;
  } else if (tipo == "comic") {
    publicacion.heroe = document.getElementById("heroe").value;
    url = `http://localhost:5247/api/Comics/${idEditando}`;
  } else if (tipo == "periodico") {
    publicacion.noticia = document.getElementById("noticia").value;
    url = `http://localhost:5247/api/Periodicos/${idEditando}`;
  }

  fetch(url, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(publicacion),
  }).then((response) => {
    if (response.ok) {
      idEditando = null;
      document.getElementById("crear").style.display = "inline";
      document.getElementById("editar").style.display = "none";
      cargarPublicaciones();
    }
  });
}

function eliminarPublicacion(id) {
  const url = `http://localhost:5247/api/Publicaciones/${id}`;

  let confirmacion = confirm("Deseas eliminar la publicacion?");

  if (confirmacion) {
    fetch(url, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
    }).then((response) => {
      cargarPublicaciones();
    });
  } else {
    console.log("Se cancelo");
  }
}

cargarPublicaciones();
