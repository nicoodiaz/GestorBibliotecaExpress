using Microsoft.AspNetCore.Routing.Tree;

namespace GestorBibliotecaExpress;

public class LibroRepository : ILibroRepository
{
    private List<Libros> _libros;
    private AccesoADatosLibros ADLibros;
    public LibroRepository()
    {
        ADLibros = new AccesoADatosLibros();
        _libros = ADLibros.CargarLibros();
    }
    public List<Libros> ObtenerTodos()
    {
        return _libros;
    }
    public Libros ObtenerLibrosId(int idLibro)
    {
        var libro = _libros.FirstOrDefault(l => l.id == idLibro);
        if (libro == null) return null;
        return libro;
    }
    public bool AgregarUnLibro(Libros nuevoLibro)
    {
        var existe = _libros.FirstOrDefault(l => l.id == nuevoLibro.id);
        if(existe != null) return false;
        _libros.Add(nuevoLibro);
        ADLibros.GuardarNuevosLibros(_libros);
        return true;
    }
    public Libros ActualizarDatosLibro(int idLibroActualizar, Libros nuevoLibro)
    {
        var libroPActualizar = ObtenerLibrosId(idLibroActualizar);
        if(libroPActualizar == null) return null;
        libroPActualizar.titulo = nuevoLibro.titulo;
        libroPActualizar.autor = nuevoLibro.autor;
        libroPActualizar.anioPublicacion = nuevoLibro.anioPublicacion;
        libroPActualizar.genero = nuevoLibro.genero;
        libroPActualizar.disponible = nuevoLibro.disponible;
        ADLibros.GuardarNuevosLibros(_libros);
        return libroPActualizar;
    }
    public bool EliminarLibro(int idLibro)
    {
        var libroPEliminar = _libros.FirstOrDefault(l => l.id == idLibro);
        if(libroPEliminar == null) return false;
        _libros.Remove(libroPEliminar);
        ADLibros.GuardarNuevosLibros(_libros);
        return true;
    }
}