using EfTest.Data;
using EfTest.DTOs;
using EfTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetTodos()
        {
            using var db = _context;

            var items = await db.TodoItems.ToListAsync();

            return Ok(new
            {
                success = true,
                todoListItems = items
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTodo( int id )
        {
            using var db = _context;

            var items = await db.TodoItems.Where(item => item.Id == id).ToListAsync();

            return Ok(new
            {
                success = true,
                todoListItems = items
            });
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateTodo(CreateTodoRequest request)
        {
            using var db = _context;
            await db.TodoItems.AddAsync(new TodoModel{
                Title = request.Title,
                Done = false
            });

            await db.SaveChangesAsync();

            return Ok(new
            {
                success = true
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTodo( int id,  UpdateTodoRequest request)
        {
            using var db = _context;

            var model = await db.TodoItems.FirstOrDefaultAsync(item => item.Id == id);

            if (model == null)
                return NotFound(new { success = false });

            if (request.Title != null)
                model.Title = request.Title;
            
            if (request.Done != null)
                model.Done = (bool)request.Done;

            await db.SaveChangesAsync();

            return Ok(new
            {
                success = true
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo( int id)
        {
            using var db = _context;

            var model = await db.TodoItems.FirstOrDefaultAsync(item => item.Id == id);

            if (model == null)
                return NotFound(new { success = false });

            db.Remove(model);

            await db.SaveChangesAsync();

            return Ok(new
            {
                success = true
            });
        }
    }
}
