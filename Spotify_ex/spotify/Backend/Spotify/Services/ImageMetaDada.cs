using Spotify.Repository;
using Spotify.Model;
using Spotify.Services;
using TagLib;

namespace Spotify.Services;

public class ImageService
{
    private readonly string _uploadsFolder;

    public ImageService()
    {
        _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        if (!Directory.Exists(_uploadsFolder))
            Directory.CreateDirectory(_uploadsFolder);
    }

    public async Task<Media?> ProcessAndInsertUploadedImage(DatabaseConnection dbConn, Guid porfileId, IFormFile image)
    {

        String filePath = await SavePorfileImage(porfileId, image);
        if (image == null || image.Length == 0)
            return null;

        try
        {
            var tagFile = TagLib.File.Create(filePath);

            Console.WriteLine("=== Metadades del fitxer ===");
            Console.WriteLine($"Fitxer: {filePath}");
            Console.WriteLine($"Títol: {tagFile.Tag.Title ?? "<sense>"}");
            Console.WriteLine($"Any: {(tagFile.Tag.Year != 0 ? tagFile.Tag.Year.ToString() : "<sense>")}");

            Console.WriteLine("============================");

            Image image = new Image
            {
                ID = Guid.NewGuid(),
                Porfile_Id = porfileId,
                URL = filePath
            };

            return image;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processant fitxer: {ex.Message}");
            return null;
        }
    }
    private static async Task<string> SavePorfileImage(Guid id, IFormFile image)
    {
        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        string fileName = $"{id}_{Path.GetFileName(image.FileName)}";
        string filePath = Path.Combine(uploadsFolder, fileName);

        using (FileStream stream = new FileStream(filePath, FileMode.Create)) 
        {
            await image.CopyToAsync(stream);
        }

        return filePath;
    }
}
