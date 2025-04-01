namespace BeginnerCSharpApp.Models.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}