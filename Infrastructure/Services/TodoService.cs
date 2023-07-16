using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TodoService:ITodoService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public TodoService(DataContext context, IMapper mapper, IFileService fileService)
    {
        _context = context;
        _mapper = mapper;
        _fileService = fileService;
    }
    
    public async Task<Response<List<TodoDto>>> GetTodos()
    {
        var response = await _context.Todos.Select(x => new TodoDto()
        {
            Description = x.Description,
            Id = x.Id,
            Title = x.Title,
            Images = x.TodoImages.Select(x => x.FileName).ToList()
        }).ToListAsync();
        var mapped = _mapper.Map<List<TodoDto>>(response);
        return new Response<List<TodoDto>>(mapped);
    }

    public async Task<Response<TodoDto>> GetTodoById(int id)
    {
        var response = await _context.Todos.FindAsync(id);
        var mapped = _mapper.Map<TodoDto>(response);
        return new Response<TodoDto>(mapped);
    }

    public async Task<Response<TodoDto>> AddTodo(AddTodoDto todo)
    {   
         var mapped = _mapper.Map<Todo>(todo);
        await _context.Todos.AddAsync(mapped);
        await _context.SaveChangesAsync();
        foreach (var file in todo.Files)
        {
            var filename =  await _fileService.AddFileAsync(file.FileName, "images", file);
            var image = new TodoImage(filename, mapped.Id);
            await _context.TodoImages.AddAsync(image);
            await _context.SaveChangesAsync();
        }
        return new Response<TodoDto>(_mapper.Map<TodoDto>(mapped)); 
    }


    public async Task<Response<TodoDto>> UpdateTodo(AddTodoDto todo)
    {
        var existing = await _context.Todos.FindAsync(todo.Id);
        if(existing == null)
        {
            return new Response<TodoDto>(HttpStatusCode.NotFound, new List<string>() { $"Todo  Not found" });
        }
        existing.Id = todo.Id;
        existing.Title = todo.Title;
        existing.Description = todo.Description;   
        await _context.SaveChangesAsync();
        return new Response<TodoDto>(todo); 

    }

    public async Task<Response<string>> DeleteTodo(int id)
    {
        var existing = await _context.Todos.FindAsync(id);
        if (existing == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string>() { $"Todo Id Not found" }); 
        }
        _context.Todos.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>($"Deleted");
    }
}