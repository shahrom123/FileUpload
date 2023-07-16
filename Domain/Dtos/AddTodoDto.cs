


using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;

public class AddTodoDto:TodoDto
{
    public List<IFormFile> Files { get; set; }  
}

