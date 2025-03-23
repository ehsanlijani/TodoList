using AutoMapper;
using TodoList.Application.DTOs.Response;
using TodoList.Application.DTOs.Task.Requests;

namespace TodoList.Application.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskRequest, Domain.Entities.Task.Task>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));

        CreateMap<Domain.Entities.Task.Task, GetTaskByIdDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
            .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

        CreateMap<Domain.Entities.Task.Task, GetAllTaskDto>()
           .ConstructUsing(src => new GetAllTaskDto(
             src.Title,
             src.Description,
             src.IsCompleted,
             src.DueDate,
             src.ModifiedAt,
             src.CreatedAt,
             src.IsDelete));

        CreateMap<UpdateTaskRequest, Domain.Entities.Task.Task>()
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
           .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted))
           .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(_ => DateTime.Now))
           .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
    }
}
