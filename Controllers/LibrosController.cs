using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GestorBibliotecaExpress;

[ApiController]
[Route("[controller]")]
public class LibrosController : ControllerBase
{
    private readonly LibroRepository librosrepo;

    public LibrosController()
    {
        librosrepo = new LibroRepository();
    }

    [HttpGet("Libros")]
    public IActionResult GetLibros()
    {
        return Ok(librosrepo.ObtenerTodos());
    }
    [HttpGet("LibroPorId")]
    public IActionResult GetLibroId(int idLibro)
    {
        var asd = librosrepo.ObtenerLibrosId(idLibro);
        if(asd != null) return Ok(asd);
        return NoContent();
    }
    [HttpPost("AgregarLibro")]
    public IActionResult AgregarLibro(Libros nuevoLibro)
    {
        if(librosrepo.AgregarUnLibro(nuevoLibro)) return Created("libro creado", nuevoLibro);
        return BadRequest();
    }
    [HttpPut("Actualizar")]
    public IActionResult Actualizarlibro(int idLibroActualizar, Libros nuevoLibro)
    {
        var libro = librosrepo.ActualizarDatosLibro(idLibroActualizar, nuevoLibro);
        if(libro == null) return BadRequest();
        return Ok(libro);
    }
    [HttpDelete("EliminarLibro")]
    public IActionResult Eliminar(int idLibro)
    {
        if(librosrepo.EliminarLibro(idLibro)) return Ok();
        return BadRequest();
    }
}