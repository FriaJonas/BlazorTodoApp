using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoAPI_Example
{
    public partial class Tasks : Form
    {
        public IEnumerable<TaskItem> TaskList { get; set; }
        public Tasks()
        {
            InitializeComponent();
        }

        private async void btnLoadTask_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string path = "https://localhost:7212/api/todoapi/listtasks";
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                TaskList = await response.Content.ReadFromJsonAsync<IEnumerable<TaskItem>>();
                gridTasks.DataSource = TaskList;

            }
        }
    }
}
