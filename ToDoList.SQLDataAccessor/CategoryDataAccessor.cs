using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ToDoList.Business.DataAccessors;
using ToDoList.Business.Entities;
using Task = ToDoList.Business.Entities.Task;

namespace ToDoList.SQLDataAccessor
{
    public class CategoryDataAccessor : ICategoryDataAccessor
    {
        private static string sqlConnectionString = @"Data Source = localhost\SQLEXPRESS01;initial catalog=ToDoDB";

        public void CreateCategory(Category category)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string insertQuery = @"INSERT INTO[dbo].[Categories]([Name]) VALUES(@Name)";

                var result = connection.Execute(insertQuery, category);
            }
        }

        public void DeleteCategory(int id)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string deleteQuery = @"DELETE FROM [dbo].[Categories] WHERE Id = @Id";

                var result = connection.Execute(deleteQuery, new { id });
            }
        }

        public void EditCategory(Category category)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string updateQuery = @"UPDATE [dbo].[Categories] SET Name = @Name WHERE Id = @Id";

                var result = connection.Execute(updateQuery, category);
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Categories]";

                categories = connection.Query<Category>(selectQuery).ToList();
            }
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category category = new Category();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Categories] WHERE Id=@Id";
                category = connection.QueryFirstOrDefault(selectQuery, new { id });
            }
            return category;
        }
    }
}
