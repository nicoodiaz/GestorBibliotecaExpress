namespace GestorBibliotecaExpress;

public interface ILibroRepository
{
    public List<Libros> ObtenerTodos();
    public Libros ObtenerLibrosId(int idLibro);
    public bool AgregarUnLibro(Libros nuevoLibro);
    public Libros ActualizarDatosLibro(int idLibroActualizar, Libros nuevoLibro);
    public bool EliminarLibro(int idLibro);
}