namespace ToDoList.WebApp.ViewModels.Tasks
{
    public class CompletedTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedTime { get; set; }
        public int? CategoryId { get; set; }
    }
}
