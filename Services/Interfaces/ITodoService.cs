using BeginnerCSharpApp.Models.Entities;

namespace BeginnerCSharpApp.Services.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> CreateAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(int id);
    }
}