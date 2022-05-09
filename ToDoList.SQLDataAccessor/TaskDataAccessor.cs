using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ToDoList.Business.DataAccessors;
using ToDoList.Business.Entities;
using Task = ToDoList.Business.Entities.Task;

namespace ToDoList.SQLDataAccessor
{
    public class TaskDataAccessor : ITaskDataAccessor
    {
        private static string sqlConnectionString = @"Data Source = localhost\SQLEXPRESS01;initial catalog=ToDoDB";

        public void CreateTask(Task task)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string insertQuery = @"INSERT INTO[dbo].[Tasks]([Name], [Deadline], [CategoryId]) VALUES(@Name, @Deadline, @CategoryId)";
                
                var result = connection.Execute(insertQuery, task);
            }
        }        
        public void DeleteTask(int id)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string deleteQuery = @"DELETE FROM [dbo].[Tasks] WHERE Id = @Id";
                
                var result = connection.Execute(deleteQuery, new { id });
            }
        }

        public void UpdateTask(int id, bool completed, DateTime completedTime = default)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string updateQuery = @"UPDATE [dbo].[Tasks] SET Completed = @Completed AND CompletedTime = @CompletedTime WHERE Id = @Id";
                
                var result = connection.Execute(updateQuery, new
                {
                    completed,
                    id,
                    completedTime
                });
            }
        }

        public Task GetTaskById(int id)
        {
            Task task = new Task();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Tasks] WHERE Id=@Id";
                task = connection.QueryFirstOrDefault(selectQuery, new { id });
            }
            return task;
        }

        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Tasks] WHERE Completed = 0 ORDER BY Deadline ASC";
                
                tasks = connection.Query<Task>(selectQuery).ToList();
            }
            return tasks;
        }
        
        public List<Task> GetCompletedTasks()
        {
            List<Task> tasks = new List<Task>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Tasks] WHERE Completed = 1 ORDER BY CompletedTime DESC";
                tasks = connection.Query<Task>(selectQuery).ToList();
            }
            return tasks;
        }

        public List<Task> GetTasksByCategory(int categoryId)
        {
            List<Task> tasks = new List<Task>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                string selectQuery = @"SELECT * FROM [dbo].[Tasks] WHERE CategoryId = @CategoryId OREDR BY Deadline ASC";
                
                tasks = connection.Query<Task>(selectQuery, new { categoryId }).ToList();
            }
            return tasks;
        }
    }
}