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
  }
}
