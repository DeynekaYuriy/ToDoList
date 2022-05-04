using System;

namespace ToDoList.Models
{
    public class NewToDoItem
    {
        public string Text { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
