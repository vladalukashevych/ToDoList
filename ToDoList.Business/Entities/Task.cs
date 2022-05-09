using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Business.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CompletedTime { get; set; }
    }
}
