using LibraryDataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SQL_Server
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();

            SqlCRUD obj = new SqlCRUD(connectionString);

            //ReadAllContacts(obj);
            GetContactById(obj,8);
            Console.ReadLine();
        }
        private static void ReadAllContacts(SqlCRUD sql)
        {
            var rows = sql.GetAllContacts();
            foreach(var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }
        private static void GetContactById(SqlCRUD sql,int id)
        {
            var item = sql.GetContactById(id);
            
                Console.WriteLine($"{item.Id}: {item.FirstName} {item.LastName}");
            
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json");
            var config = builder.Build();
            output = config.GetConnectionString(connectionStringName);
            return output;
        }
    }
}
