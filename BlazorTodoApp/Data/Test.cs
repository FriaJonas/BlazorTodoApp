namespace BlazorTodoApp.Data
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public List<FoodPrice> Prices { get; set; }
    }

    public class FoodPrice
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int Price { get; set; }
        public string Info { get; set; }
    }
}
