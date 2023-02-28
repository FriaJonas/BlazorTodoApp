using BlazorTodoApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BlazorTodoApp.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoAPIController : Controller
    {
        private TodoDB dbConn;
        public TodoAPIController(TodoDB dbConn)
        {
            this.dbConn = dbConn;
        }

        [HttpGet("ListTasks")]
        public async Task<JsonResult> ListTasks()
        {
            //läs in alla lasks från databasen
            var tasks = await dbConn.ListAllTaskView();
            //Konvetera till Json
            var jsonres = Json(tasks);
            //Retunera Json
            return jsonres;

        }
    }
}
