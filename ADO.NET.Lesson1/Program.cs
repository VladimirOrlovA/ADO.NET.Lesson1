using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;


// https://www.connectionstrings.com/

namespace ADO.NET.Lesson1
{
    class Program
    {
        private static string ConnectionString = "";

        static void Main(string[] args)
        {

            //AccessOleDbConnection();
            //AccessOdbcConnection();
            MySqlConnection();

            Console.ReadKey();
        }

        // Provider
        private static void AccessOleDbConnection()
        {
            // получаем строку подключения к БД из файла конфигурации в приложении App.config - XML Configuration File
            ConnectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"].ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            { // connection.Open() - равносильно

                //connection.ConnectionString = ConnectionString;

                // используем т.к. в 36 строке вызывает ошибку 'Invalid operation. The connection is closed.'
                connection.Open();

                Console.WriteLine("Подключение открыто");

                //Получение информации о подключении
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);

            } // connection.Close() - равносильно
        }

        // Driver
        private static void AccessOdbcConnection()
        {
            // получаем строку подключения к БД из файла конфигурации в приложении App.config - XML Configuration File
            ConnectionString = ConfigurationManager.ConnectionStrings["OdbcConnection"].ConnectionString;

            using (OdbcConnection connection = new OdbcConnection(ConnectionString))
            { // connection.Open() - равносильно

                //connection.ConnectionString = ConnectionString;

                // используем т.к. в 80 строке вызывает ошибку 'Invalid operation. The connection is closed.'
                connection.Open();

                Console.WriteLine("Подключение открыто");

                //Получение информации о подключении
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", connection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", connection.Database);
                Console.WriteLine("\tСервер: {0}", connection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", connection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", connection.State);

            } // connection.Close() - равносильно
        }

        // SQL Provider
        private static void MySqlConnection() 
        {
            // получаем строку подключения к БД из файла конфигурации в приложении App.config - XML Configuration File
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                // используем т.к. в 80 строке вызывает ошибку 'Invalid operation. The connection is closed.'
                sqlConnection.Open();
                Console.WriteLine("Подключение открыто");

                //Получение информации о подключении
                // Вывод информации о подключении
                Console.WriteLine("Свойства подключения:");
                Console.WriteLine("\tСтрока подключения: {0}", sqlConnection.ConnectionString);
                Console.WriteLine("\tБаза данных: {0}", sqlConnection.Database);
                Console.WriteLine("\tСервер: {0}", sqlConnection.DataSource);
                Console.WriteLine("\tВерсия сервера: {0}", sqlConnection.ServerVersion);
                Console.WriteLine("\tСостояние: {0}", sqlConnection.State);
                Console.WriteLine("\tWorkstationId: {0}", sqlConnection.WorkstationId);
            }
        }
    }
}
