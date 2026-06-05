using BibliotecaApp.Models;

namespace BibliotecaApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Se crea un objeto BibliotecaMenu para usar los metodos de menu
      BibliotecaMenu menu = new BibliotecaMenu();
      //Se llama el metodo iniciar
      menu.Iniciar();
    }
  }
}