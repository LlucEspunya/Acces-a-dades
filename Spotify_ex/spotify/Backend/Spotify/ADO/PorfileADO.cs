using System.ComponentModel;
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
                        VALUES (@ID, @Name, @Description, @Status)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", porfile.ID);
        cmd.Parameters.AddWithValue("@Name", porfile.Name);
        cmd.Parameters.AddWithValue("@Description", porfile.Description);
        cmd.Parameters.AddWithValue("@Status", porfile.Status);


        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
    public static List<Porfile> GetAll(DatabaseConnection dbConn)
    {
        List<Porfile> porfiles = new();

        dbConn.Open();
        string sql = "SELECT ID, Name, Description, Status FROM Porfiles";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            porfiles.Add(new Porfile
            {
                ID = reader.GetGuid(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Status = reader.GetString(3)
            });
        }
        dbConn.Close();
        return porfiles;
    }
    public static Porfile? GetById(DatabaseConnection dbConn, Guid ID)
    {
        dbConn.Open();
        string sql = "SELECT ID, Name, Description, Status FROM Porfiles WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        using SqlDataReader reader = cmd.ExecuteReader();
        Porfile? porfile = null;

        if (reader.Read())
        {
            porfile = new Porfile
            {
                ID = reader.GetGuid(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Status = reader.GetString(3)
            };
        }

        dbConn.Close();
        return porfile;
    }
    public static void Update(DatabaseConnection dbConn, Porfile porfile)
    {
        dbConn.Open();

        string sql = @"UPDATE Porfiles 
                        SET Id = @ID,
                        Name = @Name,
                        Description = @Description,
                        Status = @Status
                        WHERE ID = @ID";
        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", porfile.ID);
        cmd.Parameters.AddWithValue("@Name", porfile.Name);
        cmd.Parameters.AddWithValue("@Description", porfile.Description);
        cmd.Parameters.AddWithValue("@Status", porfile.Status);

        int rows = cmd.ExecuteNonQuery();

        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
    public static bool Delete(DatabaseConnection dbConn, Guid ID)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Porfiles WHERE ID = @ID";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", ID);

        int rows = cmd.ExecuteNonQuery();
        dbConn.Close();

        return rows > 0;
    }
}