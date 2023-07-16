using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Services;

public class TodoImageService :ITodoImageService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _todoImageService;

    public TodoImageService(DataContext context, IMapper mapper, IFileService todoImageService)
    {
        _context = context;
        _mapper = mapper;
        _todoImageService = todoImageService;
    }


    public async Task<Response<GetImageDto>> UpdateImage(AddImagesDto model)
    {
        var existing = await _context.TodoImages.FindAsync(model.Id);
        if (existing == null)
        {
            return new Response<GetImageDto>(HttpStatusCode.BadRequest,
            new System.Collections.Generic.List<string>() { "Todo Image not Found" });
        }

        var existingTodo = await _context.Todos.FindAsync(model.Id);
        if (existingTodo == null)
        {
            return new Response<GetImageDto>(HttpStatusCode.BadRequest,
             new System.Collections.Generic.List<string>() { "Todo not Found" });

        }
         existing.TodoId = model.Id;
        if(model.File != null)
        {
            if(existing.FileName!=null)
            {
                await _todoImageService.DeleteFileAsync(existing.FileName, "images" );
                existing.FileName = await _todoImageService.AddFileAsync
                    (model.File.FileName, "images", model.File);
            }
            else
            {
                existing.FileName = await _todoImageService.AddFileAsync
                  (model.File.FileName, "images", model.File);

            }
        }
        await _context.SaveChangesAsync();

        return new Response<GetImageDto>(_mapper.Map<GetImageDto>(existing)); 
    }

}