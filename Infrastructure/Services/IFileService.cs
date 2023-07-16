using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public interface IFileService
{
    Task<string> AddFileAsync(string filename, string folder, IFormFile file);
    Task<bool> DeleteFileAsync(string filename, string folder);
}