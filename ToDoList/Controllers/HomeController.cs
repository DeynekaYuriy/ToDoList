using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        IToDoItemsRepository ItemsRepository;
        ICategoryRepository CategoryRepository;
        IndexViewModel IndexModel;
        public HomeController(IToDoItemsRepository itemsRepository, ICategoryRepository categoryRepository)
        {
            ItemsRepository = itemsRepository;
            CategoryRepository = categoryRepository;
            IndexModel = new IndexViewModel();

        }
        public IActionResult Index()
        {
            IndexModel.Active = ItemsRepository.GetActive();
            IndexModel.Completed = ItemsRepository.GetCompleted();

            IndexModel.Categories = CategoryRepository.GetCategories();
            IndexModel.CategoryRepository = this.CategoryRepository;
            IndexModel.ItemsRepository = this.ItemsRepository;
            return View(IndexModel);
        }

        [HttpPost]
        public IActionResult DeleteTask(int itemId)
        {
            ItemsRepository.DeleteItem(itemId);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddTask(string text, int? categoryId, DateTime? deadline)
        {
            NewToDoItem item = new NewToDoItem { Text = text, CategoryId = categoryId, Deadline = deadline };
            ItemsRepository.AddItem(item);
            return RedirectToAction("Index");
        }
        public IActionResult Category(int categoryId)
        {
            IndexModel.SelectedCategory = CategoryRepository.GetCategoryById(categoryId);
            IndexModel.Active = ItemsRepository.GetActive(IndexModel.SelectedCategory);
            IndexModel.Completed = ItemsRepository.GetCompleted(IndexModel.SelectedCategory);
            IndexModel.Categories = CategoryRepository.GetCategories();
            IndexModel.CategoryRepository = this.CategoryRepository;
            IndexModel.ItemsRepository = this.ItemsRepository;
            return View("Index", IndexModel);
        }

    }
}
