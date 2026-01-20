using Microsoft.Data.SqlClient;
using static System.Console;
using Store.Services;
using Store.Model;

namespace Store.Repository;

static class CarritoProductADO
{

    public static void Insert(DatabaseConnection dbConn, Carrito carrito, Product product, CarritoProduct carritoProduct)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoProduct (ID, Carrito_id, Product_id, Quantity)
                        VALUES (@ID, @Carrito_id, @Product_id, @Quantity)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", carritoProduct.ID);
        cmd.Parameters.AddWithValue("@Carrito_id", carrito.ID);
        cmd.Parameters.AddWithValue("@Product_id", product.ID);
        cmd.Parameters.AddWithValue("@Quantity", carritoProduct.Quantity);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }
    
    public static List<ResumeProduct> GetAll(DatabaseConnection dbConn, Guid ID )
    {
        List<ResumeProduct> CarritoProducts = new();

        dbConn.Open();
        string sql = "SELECT ID, Carrito_id, Product_id, Quantity FROM CarritoProducts as cp INNER JOIN Products as p on p.ID = cp.Product_id WHERE Carrito_id = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
         cmd.Parameters.AddWithValue("@ID", ID);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            CarritoProducts.Add(new ResumeProduct
            {
                Carrito_id = reader.GetGuid(0),
                Product_id = reader.GetGuid(1),
                Quantity = reader.GetInt32(2),
                Price = reader.GetFloat(3),
            });
        }

        dbConn.Close();
        return CarritoProducts;
    }
}