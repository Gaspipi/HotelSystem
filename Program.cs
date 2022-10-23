// See https://aka.ms/new-console-template for more information
using HotelSystem;
using System.Data;
using System.Data.SqlClient;


static void SQLConnect()
{
    string connectionString;
    string id = "sa";
    string pass = "pass1234";
    SqlConnection cnn;
    connectionString = @$"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID={id};Password={pass}";
    cnn = new SqlConnection(connectionString);
    cnn.Open();
    Console.WriteLine("Connection Open!");
    cnn.Close();
}
SQLConnect();
Hotel NewHotel = new();
NewHotel.Inicio();
NewHotel.Menu();
