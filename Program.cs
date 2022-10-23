// See https://aka.ms/new-console-template for more information
using HotelSystem;
using System.Data.SqlClient;


static void SQLConnect()
{
    try
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "GASPIPI\\SQLEXPRESS";
        builder.UserID = "sa";
        builder.Password = "pass1234";
        builder.InitialCatalog = "prueba";

        using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
        {
            Console.WriteLine("\nQuery data example:");
            Console.WriteLine("=========================================\n");

            connection.Open();

            String sql = "SELECT name, collation_name FROM sys.databases";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                    }
                }
            }
        }
    }
    catch (SqlException e)
    {
        Console.WriteLine(e.ToString());
    }
    Console.WriteLine("\nDone. Press enter.");
    Console.ReadLine();
}
SQLConnect();
Hotel NewHotel = new();
NewHotel.Inicio();
NewHotel.Menu();
