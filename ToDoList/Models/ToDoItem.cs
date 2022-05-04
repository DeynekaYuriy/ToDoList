using System;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsDone { get; set; }
        public DateTime? DoneTime { get; set; }
    }
}
