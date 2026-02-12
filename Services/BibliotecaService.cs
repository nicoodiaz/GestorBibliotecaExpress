namespace GestorBibliotecaExpress;

public class BibliotecaService
{
    private PrestamoRepository prestamoRepoReglas;
    private LibroRepository libroRepoReglas;

    public BibliotecaService(PrestamoRepository prestamo, LibroRepository lbro)
    {
        this.prestamoRepoReglas = prestamo;
        this.libroRepoReglas = lbro;
    }

    public bool CrearPrestamo(int idLibro, Prestamo prestamo)
    {
        var existeLibro = libroRepoReglas.ObtenerLibrosId(idLibro);
        if(existeLibro == null) return false;
        if(!existeLibro.disponible) return false;
        prestamoRepoReglas.AgregarUnPrestamo(prestamo);
        bool actualizo = libroRepoReglas.AsignarPrestamo(idLibro);
        if(!actualizo) return false;
        return true;
    }
    public bool DevolverPrestamo(int idPrestamo)
    {
        var prestamoDevolver = prestamoRepoReglas.ObtenerPrestamoId(idPrestamo);
        if(prestamoDevolver == null) return false;
        if(prestamoDevolver.FechaDevolucion != null) return false;
        prestamoRepoReglas.ActualizarDatosPrestamo(prestamoDevolver.id, prestamoDevolver);
        libroRepoReglas.DevolverLibro(prestamoDevolver.libroId);
        return true;
    }
}