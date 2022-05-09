using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Business.DataAccessors;
using ToDoList.SQLDataAccessor;
using ToDoList.WebApp.ViewModels;
using AutoMapper;
using Task = ToDoList.Business.Entities.Task;

namespace ToDoList.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskDataAccessor taskDataAccessor;
        private readonly ICategoryDataAccessor categoryDataAccessor;
        private readonly IMapper mapper;

        public TaskController(ITaskDataAccessor taskDataAccessor, ICategoryDataAccessor categoryDataAccessor, IMapper mapper)
        {
            this.taskDataAccessor = taskDataAccessor;
            this.categoryDataAccessor = categoryDataAccessor;   
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Tasks = mapper.Map<List<ViewModels.Tasks.TaskViewModel>>(taskDataAccessor.GetTasks());
            model.CompletedTasks = mapper.Map<List<ViewModels.Tasks.CompletedTaskViewModel>>(taskDataAccessor.GetCompletedTasks());
            model.Categories = mapper.Map<List<CategoryViewModel>>(categoryDataAccessor.GetCategories());
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomePageViewModel task)
        {
            var newTask = mapper.Map<Task>(task);
            taskDataAccessor.CreateTask(newTask);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            taskDataAccessor.DeleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var task = taskDataAccessor.GetTaskById(id);
            var completed = task.Completed ? false : true;
            if (completed == true)
            {
                var completedTime = DateTime.Now;
                taskDataAccessor.UpdateTask(id, completed, completedTime);
                return RedirectToAction("Index");
            }

            taskDataAccessor.UpdateTask(id, completed);
            return RedirectToAction("Index");
        }
    }
}
