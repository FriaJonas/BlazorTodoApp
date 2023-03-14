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

            //vi skapar en klass för att göra ett anrop på nätet
            HttpClient httpClient = new HttpClient();

            //URL.en där vår data hämtas ifrån
            string path = "https://localhost:7212/api/todoapi/listtasks";
            
            //Vi gör ett anrop och laddar ner data i response
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                //Om det gick bra - konvertera Jsoninformationen till en lista med TaskItem
                TaskList = await response.Content.ReadFromJsonAsync<IEnumerable<TaskItem>>();

                //Sätt TaskList som en datakälla till vår GridView
                gridTasks.DataSource = TaskList;

            }
        }
    }
}
