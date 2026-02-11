using System.Text.Json;

namespace GestorBibliotecaExpress;

public class AccesoADatosLibros
{
    private string rutaArchivoLibros = "Data/libros.json";

    public List<Libros> CargarLibros()
    {
        var libros = new List<Libros>();
        if (File.Exists(rutaArchivoLibros))
        {
            string txtJson = File.ReadAllText(rutaArchivoLibros);
            libros = JsonSerializer.Deserialize<List<Libros>>(txtJson);
        }
        return libros;
    }
    public void GuardarNuevosLibros(List<Libros> listaDeLibrosActualizada)
    {
        using(FileStream archivo = new FileStream(rutaArchivoLibros, FileMode.Create))
        {
            using(StreamWriter guardarLibro = new StreamWriter(archivo))
            {
                var archivoPGuardar = JsonSerializer.Serialize<List<Libros>>(listaDeLibrosActualizada);
                guardarLibro.WriteLine(archivoPGuardar);
            }
        }
    }
    
}