using System.Data.SqlClient;

namespace BlazorTodoApp.Data
{
    public class DB
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "ToDoApp";
        public DB(IConfiguration config)
        {
            _config = config;
        }



        public SqlConnection Conn => new SqlConnection(_config.GetConnectionString(ConnectionStringName));

        public string ConnString()
        {
            return _config.GetConnectionString(ConnectionStringName);

        }
    }
}
