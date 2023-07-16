using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost("Upload")]
        public async Task<bool> Upload([FromForm] FileDto model )
        {
            try
            {
                var path = Path.Combine(_environment.WebRootPath, "files");
                if(Path.Exists(path) == false )
                    Directory.CreateDirectory(path); 

                path = Path.Combine(_environment.WebRootPath, "files", model.Photo.FileName);
                await model.Photo.CopyToAsync(System.IO.File.Create(path));
                return true;  

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
