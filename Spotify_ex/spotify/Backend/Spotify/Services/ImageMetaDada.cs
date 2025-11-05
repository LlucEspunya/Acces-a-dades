// using Spotify.Repository;
// using Spotify.Model;
// using Spotify.Services;
// using TagLib;

// namespace Spotify.Services;

// public class ImageService
// {
//     public async Task<Image?> PassarImages(IFormFileCollection images)
//     {
//         List<Task> process = new List<Task>();

//         for (int i = 0; i < images.Count; i++)
//         {
//             process.Add(Task.Run(() => ExtreureMetadades(images)));
//         }
//         Task.WhenAll(process.ToArray());

//         return images;
//     }
    
//     public async Task<Image> ExtreureMetadades(IFormFileCollection images)
//     {
//         Console.WriteLine("Processant Metadades");

//         return images;
//     }
// }
