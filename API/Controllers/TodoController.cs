using BeginnerCSharpApp.Models.Entities;
using BeginnerCSharpApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeginnerCSharpApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            return await _todoService.GetAllAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _todoService.GetByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            var createdItem = await _todoService.CreateAsync(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await _todoService.UpdateAsync(todoItem);
            }
            catch
            {
                if (await _todoService.GetByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            await _todoService.DeleteAsync(id);
            return NoContent();
        }
    }
}