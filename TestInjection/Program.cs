using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TestInjection
{
    class Program
    {
        public const string sqlconnectStr = "Data Source=SLLPKLLS\\SQLEXPRESS;Initial Catalog=test;User ID=sa;Password=hoangthaifc01";

        public static void Menu()
        {
            Console.WriteLine("--Menu--");
            Console.WriteLine("1,Add account");
            Console.WriteLine("2,Sign account");
        }
        public static void AddAcc()
        {
            try
            {
                using var connection = new SqlConnection(sqlconnectStr);
                using var command = new SqlCommand();
                command.Connection = connection;
                Console.WriteLine("Enter ID: ");
                string ID = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string PASSWORD = Console.ReadLine();
                command.CommandText = $"INSERT INTO account VALUES ('{ID}','{PASSWORD}')";
                connection.Open();
                Console.WriteLine(connection.State);
                var reader = command.ExecuteNonQuery();
                Console.WriteLine("Added "+reader+" lines!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cant Add! Error!");
            }


        }
        public static void SignIn()
        {
            using var connection = new SqlConnection(sqlconnectStr);
            using var command = new SqlCommand();
            command.Connection = connection;
            Console.WriteLine("Enter ID: ");
            string ID = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string PASSWORD = Console.ReadLine();
            command.CommandText = $"select * from account where ID = '{ID}' and PASSWORDA = '{PASSWORD}'";
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows) Console.WriteLine("Sign in success");
                else Console.WriteLine("This account does not exist!");
            }
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Menu();
                    Console.WriteLine("Enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Clear();
                                AddAcc();
                                break;
                            }
                            case 2:
                            {
                                Console.Clear();
                                SignIn();
                                break;
                            }
                    }
                }
                catch ( Exception ex)
                {
                    Console.WriteLine("Error!");
                }
            }


        }
    }
}