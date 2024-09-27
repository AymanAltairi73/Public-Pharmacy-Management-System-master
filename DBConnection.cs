using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sinhala_POS_VERSION
{
    class DBConnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string con;


        public string MyConnection()
        {
            con = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=pharmacy_db;Integrated Security=True";
            return con;
        }

    }

}

