using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WindowsFormsApp1
{


    internal class DB
    {
        private static string connection_string = "server=	localhost;port=3306;username=root;password=root;database=students_bkt";

        MySqlConnection connection = new MySqlConnection(connection_string);

        public void open_connection() 
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void close_connection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection get_connection() 
        {
            return connection;
        }





    }
}
