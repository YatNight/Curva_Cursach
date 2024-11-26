using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace OOP.SQL
{
    class DB
    {
        SqlConnection connection = new SqlConnection("server=DESKTOP-445R5GV; Initial Catalog=DB_transportation;Integrated Security=True");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
                      if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
    } 
}
