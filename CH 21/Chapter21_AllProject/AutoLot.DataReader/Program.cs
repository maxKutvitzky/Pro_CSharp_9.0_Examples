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
    INNER JOIN Makes m on m.Id = i.MakeId;";
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
    using(SqlDataReader myDataReader = myCommand.ExecuteReader())
    {
        // Loop whith int idx
        while (myDataReader.Read())
        {
            for (int i = 0; i < myDataReader.FieldCount; i++)
            {
                Console.Write(i != myDataReader.FieldCount - 1
                ? $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}, "
                : $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)} ");
            }
            Console.WriteLine();
        }
    }
    sql += "Select * from Customers;";
    myCommand.CommandText = sql;
    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
    {
        do
        {
            Console.WriteLine("Multiple queries");
            while (myDataReader.Read())
            {
                for (int i = 0; i < myDataReader.FieldCount; i++)
                {
                    Console.Write(i != myDataReader.FieldCount - 1
                    ? $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)}, "
                    : $"{myDataReader.GetName(i)} = {myDataReader.GetValue(i)} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } while (myDataReader.NextResult());
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