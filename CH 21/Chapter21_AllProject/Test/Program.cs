using System;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("config.json", true, true)
    .Build();
//Console.WriteLine(config.GetSection("ConnectionStrings")["DefaultConnection"]);
using (SqlConnection connection = new SqlConnection())
{
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
    {
        DataSource = "DESKTOP-H7TV7FI",
        InitialCatalog = "AutoLot",
        TrustServerCertificate = true,
        IntegratedSecurity = true
    };
    connection.ConnectionString = config["connection"];
    string sqlCommandText = "SELECT * FROM Inventory";
    SqlCommand command = new SqlCommand(sqlCommandText, connection);
    connection.Open();
    using(SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"-> Make: {reader["MakeId"]}, PetName: {reader["PetName"]}, Color: {reader["Color"]}.");
        }
    }
    connection.Close();
}
