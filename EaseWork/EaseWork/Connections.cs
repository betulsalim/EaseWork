using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace EaseWork
{
    internal class Connections
    {
        public SqlConnection connect ()
        {
            SqlConnection connections = new SqlConnection ("Data Source=DESKTOP-1O31I5R\\SQLEXPRESS;Initial Catalog=EaseWork;Integrated Security=True");
            connections.Open();
            return connections;
        }

    }
}
