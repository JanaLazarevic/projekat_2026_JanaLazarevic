using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace projekat_2026_JanaLazarevic
{
    internal class Konekcija
    {
        static public SqlConnection Connect()
        {
            string CS;
            CS = ConfigurationManager.ConnectionStrings["skola"].ConnectionString;
            return new SqlConnection(CS);
           
        }
    }
}
