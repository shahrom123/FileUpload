using System.Security.Principal;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class TodoImageController : ControllerBase
{
    private readonly ITodoImageService _todoImageService;
    private readonly IWebHostEnvironment _environment;

    public TodoImageController(ITodoImageService todoImageService, IWebHostEnvironment environment)
    {
        _todoImageService = todoImageService;
        _environment = environment;
    }
    [HttpGet("GetAddressFotoTodoImage")]
    public string WWWRootPath()
    {
        return _environment.WebRootPath; 
    }

    [HttpPut("UpdateTodoImage")]
    public async Task<Response<GetImageDto>> UpdateTodoImage([FromForm] AddImagesDto todo)
    {
        return await _todoImageService.UpdateImage(todo);
    }
}