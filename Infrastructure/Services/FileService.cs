
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Infrastructure.Services;

public class FileService:IFileService
{
    private readonly IWebHostEnvironment _environment;

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
    public async Task<string> AddFileAsync(string filename, string folder, IFormFile file)
    {
        try
        {
            // var path = $"{_environment.WebRootPath}/{folder}/{filename}";
            var path = Path.Combine(_environment.WebRootPath, folder, filename);
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            path = Path.Combine(_environment.WebRootPath, folder, filename);

            using (var stream = File.Create(path))
            { 
                await file.CopyToAsync(stream); 
            }
            return filename;  
        }
        catch (Exception ex)
        {
            return null;    
        }
    }

    public async Task<bool> DeleteFileAsync(string filename, string folder)
    {
       var path = Path.Combine(_environment.WebRootPath, folder, filename);
        if(File.Exists(path)==true)
        {
            await Task.Run(() => File.Delete(path));
            return true;

        }
        return false; 
    }

   
}