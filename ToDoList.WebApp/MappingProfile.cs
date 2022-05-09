using AutoMapper;
using ToDoList.Business.Entities;
using ToDoList.WebApp.ViewModels.Tasks;
using Task = ToDoList.Business.Entities.Task;


namespace ToDoList.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewTaskViewModel, Task>();
            CreateMap<Task, NewTaskViewModel>();
        }
    }
}
