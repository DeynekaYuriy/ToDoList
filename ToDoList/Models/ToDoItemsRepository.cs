using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace ToDoList.Models
{
    public class ToDoItemsRepository : IToDoItemsRepository
    {
        private static readonly string connectionString = "Data Source=SLAP\\SQLEXPRESS;Initial Catalog=TODO;Integrated Security=True";
        public List<ToDoItem> GetItems(Category category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ToDoItem> items = connection.Query<ToDoItem>(@"SELECT * FROM WHERE CategoryId = @CategoryId Item",
                    new
                    {
                        @CategoryId = category.Id
                    }).ToList();
                return items;
            }
        }
        public void AddItem(NewToDoItem item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(@"INSERT INTO Item (Text, CategoryId, Deadline) VALUES (@Text,@CategoryId, @Deadline)",
                    new
                    {
                        Text = item.Text,
                        CategoryId = item.CategoryId,
                        Deadline = item.Deadline
                    });
            }
        }

        public List<ToDoItem> GetActive()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ToDoItem> items = connection.Query<ToDoItem>("SELECT * FROM Item WHERE IsDone = 0").ToList();
                return items;
            }

        }
        public List<ToDoItem> GetActive(Category category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ToDoItem> items = connection.Query<ToDoItem>("SELECT * FROM Item WHERE IsDone = 0 and CategoryId = @CategoryId",
                    new
                    {
                        CategoryId = category.Id,
                    }).ToList();
                return items;
            }
        }
        public List<ToDoItem> GetCompleted()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ToDoItem> items = connection.Query<ToDoItem>("SELECT * FROM Item WHERE IsDone = 1").ToList();
                return items;
            }
        }
        public List<ToDoItem> GetCompleted(Category category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<ToDoItem> items = connection.Query<ToDoItem>("SELECT * FROM Item WHERE IsDone = 1 and CategoryId = @CategoryId",
                    new
                    {
                        CategoryId = category.Id
                    }).ToList();
                return items;
            }

        }

        public void DeleteItem(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(@"DELETE FROM Item WHERE Id = @Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public int GetItemsCountWithCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<int>("SELECT COUNT (CategoryId) FROM Item WHERE CategoryId=@CategoryId",
                    new
                    {
                        CategoryId = categoryId
                    }).FirstOrDefault();
            }
        }

        public int GetItemsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<int>("SELECT COUNT (CategoryId) FROM Item ").FirstOrDefault();
            }
        }
    }
}
