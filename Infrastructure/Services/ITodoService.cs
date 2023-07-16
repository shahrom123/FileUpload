using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface ITodoService
{
    Task<Response<List<TodoDto>>> GetTodos();
    Task<Response<TodoDto>> GetTodoById(int id);
    Task<Response<TodoDto>> AddTodo(AddTodoDto todo);
    Task<Response<TodoDto>> UpdateTodo(AddTodoDto todo);
    Task<Response<string>> DeleteTodo(int id);

}