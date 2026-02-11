namespace GestorBibliotecaExpress;

public class Prestamo
{
    public int id {get;set;}
    public int libroId {get;set;}
    public string NombreLector {get;set;}
    public DateTime FechaPrestamo {get;set;}
    public DateTime? FechaDevolucion {get;set;}

    public Prestamo()
    {
    }
}