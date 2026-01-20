using Microsoft.Data.SqlClient;
using static System.Console;
using Store.Services;
using Store.Model;

namespace Store.Repository;

static class ProductADO
{
    public static void Insert(DatabaseConnection dbConn, Product product)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Products (ID, Name, Price, Family_id)
                        VALUES (@ID, @Name, @Price, @Family_id)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", product.ID);
        cmd.Parameters.AddWithValue("@Name", product.Name);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@Family_id", product.Family_id);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<Product> GetAll(DatabaseConnection dbConn)
    {
        List<Product> Products = new();

        dbConn.Open();
        string sql = "SELECT ID, Name, Price, Family_id FROM Products";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Products.Add(new Product
            {
                ID = reader.GetGuid(0),
                Name = reader.GetString(1),
                Price = reader.GetFloat(2),
                Family_id = reader.GetGuid(3)
            });
        }

        dbConn.Close();
        return Products;
    }

    public static Product? GetById(DatabaseConnection dbConn, Guid ID)
    {
        dbConn.Open();
        string sql = "SELECT ID, Name, Price, Family_id FROM Products WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product? product = null;

        if (reader.Read())
        {
            product = new Product
            {
                ID = reader.GetGuid(0),
                Name = reader.GetString(1),
                Price = reader.GetFloat(2),
                Family_id = reader.GetGuid(3)
            };
        }

        dbConn.Close();
        return product;
    }
}