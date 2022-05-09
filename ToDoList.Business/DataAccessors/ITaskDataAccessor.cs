using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = ToDoList.Business.Entities.Task;

namespace ToDoList.Business.DataAccessors
{
    public interface ITaskDataAccessor
    {
        List<Task> GetTasks();
        List<Task> GetCompletedTasks();
        List<Task> GetTasksByCategory(int categoryId);
        Task GetTaskById(int id);
        void CreateTask(Task task);
        void UpdateTask(int id, bool completed, DateTime completedTime = default);
        void DeleteTask(int id);
    }
}
