using BibliotecaWebApp.Models;
using BibliotecaWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
  [ApiController]
  [Route("api/Revistas")]
  public class RevistasController : ControllerBase
  {
    private readonly PublicacionRepositorio _repositorio;

    public RevistasController(PublicacionRepositorio repositorio)
    {
      _repositorio = repositorio;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Revista revista)
    {
      var publicacion = _repositorio.Guardar(revista);

      return Created($"api/Revistas/{publicacion.Id}", publicacion);
    }
  }
}