using Microsoft.Data.SqlClient;
using static System.Console;
using Store.Services;
using Store.Model;

namespace Store.Repository;

static class CarritoADO
{
    // public Guid ID { get; set; }
    // public string name { get; set; } = "";

    public static void Insert(DatabaseConnection dbConn, Carrito carrito)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Carritos (ID, name)
                        VALUES (@ID, @name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", carrito.ID);
        cmd.Parameters.AddWithValue("@name", carrito.ID);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<Carrito> GetAll(DatabaseConnection dbConn)
    {
        List<Carrito> Carritos = new();

        dbConn.Open();
        string sql = "SELECT ID, name FROM Carritos";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Carritos.Add(new Carrito
            {
                ID = reader.GetGuid(0),
                name = reader.GetString(2),
            });
        }

        dbConn.Close();
        return Carritos;
    }

    public static Carrito? GetById(DatabaseConnection dbConn, Guid ID)
    {
        dbConn.Open();
        string sql = "SELECT ID, name FROM Carritos WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        using SqlDataReader reader = cmd.ExecuteReader();
        Carrito? carrito = null;

        if (reader.Read())
        {
            carrito = new Carrito
            {
                ID = reader.GetGuid(0),
                name = reader.GetString(2),
            };
        }

        dbConn.Close();
        return carrito;
    }
}