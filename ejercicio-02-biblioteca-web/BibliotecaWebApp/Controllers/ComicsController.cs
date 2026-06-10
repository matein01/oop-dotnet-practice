using BibliotecaWebApp.Models;
using BibliotecaWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
  [ApiController]
  [Route("api/Comics")]
  public class ComicsController  : ControllerBase
  {
    private readonly PublicacionRepositorio _repositorio;

    public ComicsController (PublicacionRepositorio repositorio)
    {
      _repositorio = repositorio;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Comic comic)
    {
      var publicacion = _repositorio.Guardar(comic);

      return Created($"api/Comics/{publicacion.Id}", publicacion);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] Comic comic)
    {
      comic.Id = id;
      _repositorio.Actualizar(comic);
      return Ok(comic);
    }
  }
}