using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoAPI.Interfaces;
using TodoApi.DTOs;

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

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
			var tasks = await _taskService.GetAllTasksAsync();
			return Ok(tasks);
		}

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
			var task = await _taskService.GetTaskByIdAsync(id);
			if (task == null) return NotFound();
			return Ok(task);
		}

		// POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask([FromBody] TaskCreateDto task)
        {
			var created = await _taskService.CreateTaskAsync(task);
			return CreatedAtAction(nameof(GetTaskById), new { id = created.Id }, created);
		}

		// PUT: api/tasks/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTask(int id, TaskUpdateDto updatedTask)
		{
			var updated = await _taskService.UpdateTaskAsync(id, updatedTask);
			if (!updated) return NotFound();

			return NoContent();
		}

		// DELETE: api/tasks/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var deleted = await _taskService.DeleteTaskAsync(id);
			if (!deleted) return NotFound();
			return NoContent();
		}
	}
}
