using ToDoList.Business.Entities;
using Task = ToDoList.Business.Entities.Task;
using ToDoList.WebApp.ViewModels.Tasks;

namespace ToDoList.WebApp.ViewModels
{
    public class HomePageViewModel
    {
        public NewTaskViewModel? NewTask { get; set; }
        public CategoryViewModel? Category { get; set; }
        public List<CategoryViewModel>? Categories { get; set; }
        public List<TaskViewModel>? Tasks { get; set; }
        public List<CompletedTaskViewModel>? CompletedTasks { get; set; }
    }
}
