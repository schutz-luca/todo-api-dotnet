using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoAPI.Interfaces;
using ToDoAPI.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
		private readonly ITaskService _taskService;

		public TasksController(ITaskService taskService)
        {
			_taskService = taskService;
		}

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
			var tasks = await _taskService.GetAllTasksAsync();
			return Ok(tasks);
		}

        // GET: api/Tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
			var task = await _taskService.GetTaskByIdAsync(id);
			if (task == null) return NotFound();
			return Ok(task);
		}

		// POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel task)
        {
			var created = await _taskService.CreateTaskAsync(task);
			return CreatedAtAction(nameof(GetTaskById), new { id = created.Id }, created);
		}

		// DELETE: api/Tasks/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var deleted = await _taskService.DeleteTaskAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
