using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AntiSQLInjection
{
    class SQL
    {
        string con = "Data Source=SLLPKLLS\\SQLEXPRESS;Initial Catalog=test;User ID=sa;Password=hoangthaifc01";//biến con sqlconection để kêt nối đến CSDL
        
        public Boolean execute(string ID, string PASS) //hàm thực thi dữ liệu có tham số cmd
        {
            using var connection = new SqlConnection(con);
            using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT * FROM Account WHERE ID = '{ID}' AND PASSWORDA = '{PASS}'";
            connection.Open();
            using(var reader = command.ExecuteReader())
            {
                if (reader.HasRows) return true;
                
            }
            return false;
            connection.Close();

        }
        

    }
}
