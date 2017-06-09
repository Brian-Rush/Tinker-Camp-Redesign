using System.Collections.Generic;
using System.Data.SqlClient;
using Salon.Objects;

namespace Salon
{
  public class DB
  {
    public static SqlConnection Connection()
    {
      SqlConnection conn = new SqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
