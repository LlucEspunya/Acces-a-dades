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

        app.MapGet("/Porfiles", () =>
        {
            List<Porfile> porfiles = PorfileADO.GetAll(dbConn);
            return Results.Ok(porfiles);
        });

        app.MapGet("/Porfiles/{Id}", (Guid ID) =>
        {
            Porfile porfile = PorfileADO.GetById(dbConn, ID);

            return porfile is not null
            ? Results.Ok(porfile)
            : Results.NotFound(new { message = $"Porfile with Id {ID} not found" });
        });
        app.MapPut("/Porfiles/{ID}", (Guid ID, PorfileRequest req) =>
        {
            var existing = PorfileADO.GetById(dbConn, ID);
            if (existing == null)
                return Results.NotFound();

            existing.Name = req.Name;
            existing.Description = req.Description;
            existing.Status = req.Status;

            PorfileADO.Update(dbConn, existing);
            return Results.Ok(existing);
        });

        app.MapDelete("/Porfiles/{ID}", (Guid ID) => PorfileADO.Delete(dbConn, ID) ? Results.NoContent() : Results.NotFound());

        app.MapPost("/Porfile/{ID}/upload", async (Guid id, IFormFileCollection images) =>
        {
            if (images == null || images.Count == 0)
            return Results.BadRequest(new { message = "No s'ha rebut cap imatge." });
            Song? song = SongADO.GetById(dbConn, id);
            if (song is null)
            return Results.NotFound(new { message = $"media amb Id {id} no trobat." });
                
            ImageService imageService = new();

            for (int i = 0; i < images.Count; i++)
            {
                Image? image = await imageService.ProcessAndInsertUploadedImage(dbConn, ID, images[i]);

                ImageADO.Insert(dbConn, image);
            }

            return Results.Ok(new { message = "Imatge pujada correctament."});
        }).DisableAntiforgery();
    }
}

public record PorfileRequest(Guid ID, string Name, string Description, string Status);