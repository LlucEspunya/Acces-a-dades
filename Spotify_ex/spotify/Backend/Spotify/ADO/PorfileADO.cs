using Microsoft.Data.SqlClient;
using Spotify.Model;
using Spotify.Services;

namespace Spotify.Repository;

class PorfileADO
{
    public static void Insert(DatabaseConnection dbConn, Porfile porfile)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Porfiles (ID, Name, Description, Status)
                        VALUES (@ID, @Name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", porfile.ID);
        cmd.Parameters.AddWithValue("@Name", porfile.Name);
        cmd.Parameters.AddWithValue("@Description", porfile.Description);
        cmd.Parameters.AddWithValue("@Status", porfile.Status);


        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
}