using System;
using Microsoft.Data.SqlClient;
Console.WriteLine("***** Fun with Data Readers *****\n");
// Create and open a connection.
using (SqlConnection connection = new SqlConnection())
{
    var connectionStringBuilder = new SqlConnectionStringBuilder
    {
        InitialCatalog = "AutoLot",
        DataSource = "DESKTOP-H7TV7FI",
        TrustServerCertificate = true,
        IntegratedSecurity = true,
        ConnectTimeout = 30
    };
    connection.ConnectionString =connectionStringBuilder.ConnectionString;
    //connection.ConnectionString =@"Server=DESKTOP-H7TV7FI;DataBase=AutoLot;TrustServerCertificate=True;Trusted_Connection=true";
    connection.Open();
    // Create a SQL command object.
    string sql =
    @"Select i.id, m.Name as Make, i.Color, i.Petname
    FROM Inventory i
    INNER JOIN Makes m on m.Id = i.MakeId";
    SqlCommand myCommand = new SqlCommand(sql, connection);
    // Obtain a data reader a la ExecuteReader().
    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
    {
        // Loop over the results.
        while (myDataReader.Read())
        {
            Console.WriteLine($"-> Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]}, Color: {myDataReader["Color"]}.");
        }
    }
    ShowConnectionStatus(connection);
}
Console.ReadLine();

static void ShowConnectionStatus(SqlConnection connection)
{
    // Show various stats about current connection object.
    Console.WriteLine("***** Info about your connection *****");
    Console.WriteLine($@"Database location: {connection.DataSource}");
    Console.WriteLine($"Database name: {connection.Database}");
    Console.WriteLine($@"Timeout: {connection.ConnectionTimeout}");
    Console.WriteLine($"Connection state: { connection.State}\n");
}