namespace ToDoList.WebApp.ViewModels.Tasks
{
    public class NewTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}
