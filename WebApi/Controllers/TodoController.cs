using System.Security.Principal;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IWebHostEnvironment _environment;

    public TodoController(ITodoService todoService, IWebHostEnvironment environment)
    {
        _todoService = todoService;
        _environment = environment;
    }
    [HttpGet("GetAddressFotoTodo")]
    public string WWWRootPath()
    {
        return _environment.WebRootPath;
    }
    [HttpGet("GetListTodos")]
    public async Task<Response<List<TodoDto>>> GetTodo()
    {
        return await _todoService.GetTodos();
    }
    [HttpGet("GetTodosById")]
    public async Task<Response<TodoDto>> GetTodosById(int id)
    {
        return await _todoService.GetTodoById(id);
    }

    [HttpPost("AddTodo")]
    public async Task<Response<TodoDto>> AddTodo([FromForm] AddTodoDto todo)
    {
        return await _todoService.AddTodo(todo);
    }

    [HttpPut("UpdateTodo")]
    public async Task<Response<TodoDto>> UpdateTodo([FromBody] AddTodoDto todo)
    {
        return await _todoService.UpdateTodo(todo);
    }
 
    [HttpDelete("DeleteTodo")]
    public async Task<Response<string>> DeleteTedo(int id)
    {
        return await _todoService.DeleteTodo(id);
    }


}









