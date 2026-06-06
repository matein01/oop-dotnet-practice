using Microsoft.Data.SqlClient;

namespace BibliotecaApp
{
  public class ConexionDB
  {
    //Variable con la ruta y los datos necesarios para conectarse a la BD
    const string connection = @"Server=localhost\SQLEXPRESS;Database=BibliotecaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    //Método para obtener una conexión a la base de datos
    public static SqlConnection ObtenerConexion()
    {
      return new SqlConnection(connection);
    }
  }
}