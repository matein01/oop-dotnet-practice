using BibliotecaWebApp.Models;
using BibliotecaWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PublicacionesController : ControllerBase
  {
    private readonly PublicacionRepositorio _repositorio;

    public PublicacionesController(PublicacionRepositorio repositorio)
    {
      _repositorio = repositorio;
    }

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
      var publicaciones = _repositorio.ObtenerTodas();

      return Ok(publicaciones);
    }

    [HttpGet("{id}")]
    public IActionResult BucarPorId(int id)
    {
      var publicacion = _repositorio.BuscarPorId(id);

      if (publicacion == null)
      {
        return NotFound($"No existe una publicación con id {id}");
      }

      return Ok(publicacion);
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Publicacion p)
    {
      var publicacion = _repositorio.Guardar(p);

      return Created($"api/Publicaciones/{publicacion.Id}", publicacion);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
      var encontrada = _repositorio.BuscarPorId(id);

      if (encontrada == null)
      {
        return NotFound($"No existe una publicación con id {id}");
      }

      _repositorio.Eliminar(id);

      return NoContent();
    }
  }
}
