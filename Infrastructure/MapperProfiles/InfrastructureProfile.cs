using AutoMapper;
using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Todo,TodoDto>().ReverseMap();
        CreateMap<Todo,AddTodoDto>().ReverseMap();
        CreateMap<TodoImage, GetImageDto>().ReverseMap();
    }
}