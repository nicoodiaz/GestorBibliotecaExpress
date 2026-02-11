using System.Reflection.Metadata;
using System.Text.Json;

namespace GestorBibliotecaExpress;

public class AccesoADatosPrestamos
{
    private string rutaArchivoPrestamos = "Data/prestamos.json";

    public List<Prestamo> CargarPrestamos()
    {
        var prestamos = new List<Prestamo>();
        if(File.Exists(rutaArchivoPrestamos))
        {
            string txtJson = File.ReadAllText(rutaArchivoPrestamos);
            prestamos = JsonSerializer.Deserialize<List<Prestamo>>(txtJson);
        }
        return prestamos;
    }

    public void GuardarPrestamos (List<Prestamo> pretamosActualizados)
    {
        using (FileStream archivo = new FileStream(rutaArchivoPrestamos, FileMode.Create))
        {
            using(StreamWriter guardarPrestamo = new StreamWriter(archivo))
            {
                var archivoPGuardar = JsonSerializer.Serialize<List<Prestamo>>(pretamosActualizados);
                guardarPrestamo.WriteLine(archivoPGuardar);
            }
        }
    }
}