namespace GestorBibliotecaExpress;

public class PrestamoRepository : IPrestamoRepository
{
    private List<Prestamo> _prestamos;
    private AccesoADatosPrestamos ADPrestamos;

    public PrestamoRepository()
    {
        ADPrestamos = new AccesoADatosPrestamos();
        _prestamos = ADPrestamos.CargarPrestamos();
    }

    public List<Prestamo> ObtenerTodos()
    {
        return _prestamos;
    }
    public Prestamo ObtenerPrestamoId(int idPrestamo)
    {
        var prestamo = _prestamos.FirstOrDefault(l => l.id == idPrestamo);
        if (prestamo == null) return null;
        return prestamo;
    }
    public bool AgregarUnPrestamo(Prestamo nuevoPrestamo)
    {
        var existe = _prestamos.FirstOrDefault(l => l.id == nuevoPrestamo.id);
        if(existe != null) return false;
        _prestamos.Add(nuevoPrestamo);
        ADPrestamos.GuardarPrestamos(_prestamos);
        return true;
    }
    public Prestamo ActualizarDatosPrestamo(int idPrestamoActualizar, Prestamo nuevoPrestamo)
    {
        var prestamoPActualizar = ObtenerPrestamoId(idPrestamoActualizar);
        if(prestamoPActualizar == null) return null;
        prestamoPActualizar.libroId = nuevoPrestamo.libroId;
        prestamoPActualizar.NombreLector = nuevoPrestamo.NombreLector;
        prestamoPActualizar.FechaPrestamo = nuevoPrestamo.FechaPrestamo;
        prestamoPActualizar.FechaDevolucion = nuevoPrestamo.FechaDevolucion;
        ADPrestamos.GuardarPrestamos(_prestamos);
        return prestamoPActualizar;
    }
        public bool EliminarPrestamo(int idPrestamo)
    {
        var prestamoTerminado = _prestamos.FirstOrDefault(l => l.id == idPrestamo);
        if(prestamoTerminado == null) return false;
        _prestamos.Remove(prestamoTerminado);
        ADPrestamos.GuardarPrestamos(_prestamos);
        return true;
    }
}