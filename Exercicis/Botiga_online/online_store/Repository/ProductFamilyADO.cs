using Microsoft.Data.SqlClient;
using static System.Console;
using Store.Services;
using Store.Model;
using System.ComponentModel;

namespace Store.Repository;

static class ProductFamilyADO
{
    public static void Insert(DatabaseConnection dbConn, ProductFamily productFamily)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Familias (ID, family, description)
                        VALUES (@ID, @family, @description)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", productFamily.ID);
        cmd.Parameters.AddWithValue("@family", productFamily.family);
        cmd.Parameters.AddWithValue("@description", productFamily.description);
        cmd.ExecuteNonQuery();
        dbConn.Close();
    }

    public static List<ProductFamily> GetAll(DatabaseConnection dbConn)
    {
        List<ProductFamily> PorductsFamilias = new();

        dbConn.Open();
        string sql = "SELECT ID, family, description FROM Familias";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            PorductsFamilias.Add(new ProductFamily
            {
                ID = reader.GetGuid(0),
                family = reader.GetString(1),
                description = reader.GetString(2)
            });
        }

        dbConn.Close();
        return PorductsFamilias;
    }

    public static ProductFamily? GetById(DatabaseConnection dbConn, Guid ID)
    {
        dbConn.Open();
        string sql = "SELECT ID, family, description FROM Familias WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        using SqlDataReader reader = cmd.ExecuteReader();
        ProductFamily? productFamily = null;

        if (reader.Read())
        {
            productFamily = new ProductFamily
            {
                ID = reader.GetGuid(0),
                family = reader.GetString(1),
                description = reader.GetString(2)
            };
        }

        dbConn.Close();
        return productFamily;
    }
}