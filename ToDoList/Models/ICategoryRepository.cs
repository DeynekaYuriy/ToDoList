using System.Collections.Generic;

namespace ToDoList.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int? id);
        void AddCategory(NewCategory category);
        void DeleteCategory(int id);
    }
}
