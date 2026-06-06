using BibliotecaApp.Models;

namespace BibliotecaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Se crea un objeto BibliotecaMenu para usar los métodos de menú
      BibliotecaMenu menu = new BibliotecaMenu();
      //Se llama el método Iniciar
      menu.Iniciar();
    }
  }
}