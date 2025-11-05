using Microsoft.Data.SqlClient;
using Spotify.Model;
using Spotify.Services;

namespace Spotify.Repository;

public class ImageADO
{
    public static void Insert(DatabaseConnection dbConn, Image image)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Media (ID, Porfile_ID, URL)
                        VALUES (@Id, @Porfile_Id, @URL)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", image.ID);
        cmd.Parameters.AddWithValue("@Porfile_Id", image.Porfile_Id);
        cmd.Parameters.AddWithValue("@URL", image.URL);

        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
}