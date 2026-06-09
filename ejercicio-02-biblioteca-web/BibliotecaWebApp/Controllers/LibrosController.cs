using BibliotecaWebApp.Models;
using BibliotecaWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
  [ApiController]
  [Route("api/Libros")]
  public class LibrosController : ControllerBase
  {
    private readonly PublicacionRepositorio _repositorio;

    public LibrosController(PublicacionRepositorio repositorio)
    {
      _repositorio = repositorio;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Libro libro)
    {
      var publicacion = _repositorio.Guardar(libro);

      return Created($"api/Libros/{publicacion.Id}", publicacion);
    }
  }
}