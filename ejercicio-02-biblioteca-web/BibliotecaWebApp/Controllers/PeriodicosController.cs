using BibliotecaWebApp.Models;
using BibliotecaWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
  [ApiController]
  [Route("api/Periodicos")]
  public class PeriodicosController  : ControllerBase
  {
    private readonly PublicacionRepositorio _repositorio;

    public PeriodicosController (PublicacionRepositorio repositorio)
    {
      _repositorio = repositorio;
    }

    [HttpPost]
    public IActionResult Crear([FromBody] Periodico periodico)
    {
      var publicacion = _repositorio.Guardar(periodico);

      return Created($"api/Periodicos/{publicacion.Id}", publicacion);
    }
  }
}