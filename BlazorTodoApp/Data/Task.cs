namespace BlazorTodoApp.Data
{
    public class TodoTask
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int Priority { get; set; }
        //public Category Category { get; set; }
        public Guid Category { get; set; }
        public bool Completed { get; set; }
    }
    public class TodoTaskView:TodoTask
    {
        public string CategoryName { get; set; }
    }
}
