using System.Collections.Generic;

namespace ToDoList.Models
{
    public interface IToDoItemsRepository
    {

        List<ToDoItem> GetCompleted(Category category);
        List<ToDoItem> GetCompleted();
        List<ToDoItem> GetActive(Category category);
        List<ToDoItem> GetActive();
        void AddItem(NewToDoItem item);
        void DeleteItem(int id);
        int GetItemsCount();

        int GetItemsCountWithCategory(int categoryId);

    }
}
