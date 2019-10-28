using Dapper;
using Dapper.Contrib.Extensions;
using DbUp;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DbUpTraining
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=A-305-11;Database=BookStore;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            EnsureDatabase.For.SqlDatabase(CONNECTION_STRING);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(CONNECTION_STRING)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            upgrader.PerformUpgrade();
             
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var book = new Book
                {
                    Name = "Abay",
                    Price = 5000
                };
                //connection.Insert(book);
                connection.Execute("Insert into Books values (@Id, @Name, @Price);", book);
            }
        }
    }
}
