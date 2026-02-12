using Microsoft.AspNetCore.Mvc;

namespace GestorBibliotecaExpress;

[ApiController]
[Route("[controller]")]
public class PrestamoController : ControllerBase
{
    private readonly PrestamoRepository prestamorepo;
    private readonly LibroRepository libroRepo;
    private readonly BibliotecaService reglasPrestamos;
    public PrestamoController()
    {
        prestamorepo = new PrestamoRepository();
        libroRepo = new LibroRepository();
        reglasPrestamos = new BibliotecaService(prestamorepo, libroRepo);
    }
    [HttpGet("Prestamos")]
    public IActionResult GetPrestamos()
    {
        return Ok(prestamorepo.ObtenerTodos());
    }
    [HttpGet("PrestamoPorId")]
    public IActionResult GetPrestamoId(int idPrestamo)
    {
        var asd = prestamorepo.ObtenerPrestamoId(idPrestamo);
        if(asd != null) return Ok(asd);
        return NoContent();
    }
    [HttpPost("AgregarPrestamo")]
    public IActionResult AgregarPrestamo([FromBody]Prestamo nuevoPrestamo, int idLibro)
    {
        if(reglasPrestamos.CrearPrestamo(idLibro, nuevoPrestamo)) return Created("libro creado", nuevoPrestamo);
        return BadRequest();
    }
    [HttpPut("Actualizar")]
    public IActionResult ActualizarPrestamo(int idPrestamoActualizar, Prestamo nuevoPrestamo)
    {
        var prestamo = prestamorepo.ActualizarDatosPrestamo(idPrestamoActualizar, nuevoPrestamo);
        if(prestamo == null) return BadRequest();
        return Ok(prestamo);
    }
    [HttpDelete("EliminarPrestamo")]
    public IActionResult Eliminar(int idPrestamo)
    {
        if(prestamorepo.EliminarPrestamo(idPrestamo)) return Ok();
        return BadRequest();
    }
}