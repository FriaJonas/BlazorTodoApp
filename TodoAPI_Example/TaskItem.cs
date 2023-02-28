using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAPI_Example
{
    public class TaskItem
    {
        public string CategoryName { get; set; }

        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int Priority { get; set; }
        public Guid Category { get; set; }
        public bool Completed { get; set; }
    }
}
