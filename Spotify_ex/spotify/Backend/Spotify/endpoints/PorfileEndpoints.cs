using Spotify.Repository;
using Spotify.Model;
using Spotify.Services;
using System.ComponentModel;
using System.Net;

namespace Spotify.Endpoints;

public static class PorfileEndpoints
{
    public static void MapPorfileEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        app.MapPost("/Porfiles", (PorfileRequest req) =>
        {
            Porfile porfile = new Porfile
            {
                ID = Guid.NewGuid(),
                Name = req.Name,
                Description = req.Description,
                Status = req.Status
            };

            PorfileADO.Insert(dbConn, porfile);

            return Results.Created($"/Porfiles/{porfile.ID}", porfile);
        });
    }
}

public record PorfileRequest(Guid ID, string Name, string Description, string Status);