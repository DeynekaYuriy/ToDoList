using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace ToDoList.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly string connectionString = "Data Source=SLAP\\SQLEXPRESS;Initial Catalog=TODO;Integrated Security=True";

        public void AddCategory(NewCategory category)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query("INSERT INTO Category (Name) VALUES (@Name)", new
                {
                    Name = category.Name
                });
            }
        }

        public void DeleteCategory(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Query(@"DELETE FROM Category WHERE Id = @Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public List<Category> GetCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Category> categories = connection.Query<Category>("SELECT * FROM Category").ToList();
                return categories;
            }
        }

        public Category GetCategoryById(int? id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Category>("SELECT * FROM Category WHERE Id = @Id",
                    new
                    {
                        Id = id
                    }).FirstOrDefault();
            }
        }
    }
}
