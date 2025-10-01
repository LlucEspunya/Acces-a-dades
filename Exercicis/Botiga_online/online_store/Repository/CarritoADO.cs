using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;

namespace dbdemo.Repository;

class CarritoADO
{
    public Guid ID { get; set; }
    public string nom { get; set; } = "";


    public void Insert(DatabaseConnection dbConn)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Carritos (ID, nom)
                        VALUES (@ID, @nom)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);
        cmd.Parameters.AddWithValue("@nom", nom);


        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<CarritoADO> GetAll(DatabaseConnection dbConn)
    {
        List<CarritoADO> carritos = new();

        dbConn.Open();
        string sql = "SELECT ID, nom FROM Carrito";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            carritoss.Add(new ProductADO
            {
                ID = reader.GetGuid(0),
                nom = reader.GetString(1),
            });
        }

        dbConn.Close();
        return carritos;
    }

    public static CarritoADO? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT ID, nom FROM Carrito WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        using SqlDataReader reader = cmd.ExecuteReader();
        CarritoADO? carrito = null;

        if (reader.Read())
        {
            carrito = new CarritoADO
            {
                ID = reader.GetGuid(0),
                nom = reader.GetString(1),
            };
        }

        dbConn.Close();
        return carrito;
    }
}