using Dapper;
using System.ComponentModel;

namespace BlazorTodoApp.Data
{
    public class TodoDB
    {
        DB _DB { get; init; }
        public TodoDB(DB _DB)
        {
            this._DB = _DB;
        }

        public async Task<IEnumerable<Category>> ListAllCategories()
        {
            var sql = "SELECT * FROM TblCategory";
            using var cn = _DB.Conn;
            return await cn.QueryAsync<Category>(sql);
        }
        public async Task<IEnumerable<TodoTask>> ListAllTasks()
        {
            var sql = "SELECT * FROM TblTask";
            using var cn = _DB.Conn;
            return await cn.QueryAsync<TodoTask>(sql);
        }

        //Funktion som hämtar samtliga tasks
        public async Task<IEnumerable<TodoTaskView>> ListAllTaskView()
        {
            var sql = @"SELECT TblTask.*, TblCategory.Name as CategoryName 
                        FROM TblTask join TblCategory on TblTask.Category=TblCategory.Id ORDER BY Completed";
            using var cn = _DB.Conn;
            return await cn.QueryAsync<TodoTaskView>(sql);

        }
        public async Task<int> AddTask(TodoTask task)
        {
            var sql = @"INSERT INTO TblTask (Id,Header,Description,DateAdded,Priority,Category,Completed) VALUES 
                    (@Id,@Header,@Description,@DateAdded,@Priority,@Category,@Completed)";
            using var cn = _DB.Conn;
            return await cn.ExecuteScalarAsync<int>(sql, new { task.Id, task.Header, task.Description, DateAdded = DateTime.Now, task.Priority, task.Category, Completed = false });
        }

        public async Task<int> UpdateTask(TodoTask task)
        {
            var sql = @"UPDATE TblTask SET Header=@Header,Description=@Description,Priority=@Priority,Category=@Category,Completed=@Completed WHERE Id=@Id";
            using var cn = _DB.Conn;
            return await cn.ExecuteScalarAsync<int>(sql, new { task.Id, task.Header, task.Description, task.Priority, task.Category, task.Completed });
        }
        public async Task<int> DeleteTask(Guid Id)
        {
            var sql = "DELETE FROM TblTask WHERE Id=@Id";
            using var cn = _DB.Conn;
            return await cn.ExecuteScalarAsync<int>(sql, new { Id});
        }
    }
}
