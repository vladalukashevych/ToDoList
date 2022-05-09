namespace ToDoList.WebApp.ViewModels.Tasks
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}
