using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class IndexViewModel
    {
        public List<ToDoItem> Completed { get; set; }
        public List<ToDoItem> Active { get; set; }
        public List<Category> Categories { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IToDoItemsRepository ItemsRepository{ get; set; }
        public Category SelectedCategory { get; set; }
    }
}
