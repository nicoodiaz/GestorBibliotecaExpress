using Microsoft.AspNetCore.Routing.Tree;

namespace GestorBibliotecaExpress;

public class Libros
{
    public int id {get;set;}
    public string titulo {get;set;}
    public string autor {get;set;}
    public int anioPublicacion {get;set;}
    public string genero {get;set;}
    public bool disponible {get;set;} = true;

    public Libros()
    {
    }
    
}