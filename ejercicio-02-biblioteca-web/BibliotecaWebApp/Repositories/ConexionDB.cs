using Microsoft.Data.SqlClient;

namespace BibliotecaWebApp.Repositories
{
  public class ConexionDB
  {
    private readonly string _connectionString;

    public ConexionDB(string connectioString)
    {
      _connectionString = connectioString;
    }

    public SqlConnection ObtenerConexion()
    {
      return new SqlConnection(_connectionString);
    }
  }
}