using Microsoft.Data.SqlClient;
using static System.Console;
using Store.Services;
using Store.Model;

namespace Store.Repository;

static class CarritoADO
{
    public static void Insert(DatabaseConnection dbConn, Carrito carrito)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Carritos (ID, name)
                        VALUES (@ID, @name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", carrito.ID);
        cmd.Parameters.AddWithValue("@name", carrito.name);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<ResumeProduct> GetAll(DatabaseConnection dbConn, Guid ID )
    {
        List<ResumeProduct> ResumeProducts = new();

        dbConn.Open();
        string sql = "SELECT cp.ID, Carrito_id, Product_id, Quantity, p.Price FROM CarritoProduct as cp INNER JOIN Products as p on p.ID = cp.Product_id WHERE Carrito_id = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
         cmd.Parameters.AddWithValue("@ID", ID);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ResumeProducts.Add(new ResumeProduct
            {
                ID = reader.GetGuid(0),
                Carrito_id = reader.GetGuid(1),
                Product_id = reader.GetGuid(2),
                Quantity = reader.GetInt32(3),
                Price = reader.GetFloat(4),
            });
        }

        dbConn.Close();
        return ResumeProducts;
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
                name = reader.GetString(1),
            };
        }

        dbConn.Close();
        return carrito;
    }
}