using ToDoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoAPI.Services
{
	public class TaskService : ITaskService
	{
		private readonly ToDoContext _context;

		public TaskService(ToDoContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TaskModel>> GetAllTasksAsync()
		{
			return await _context.Tasks.ToListAsync();
		}

		public async Task<TaskModel?> GetTaskByIdAsync(int id)
		{
			return await _context.Tasks.FindAsync(id);
		}

		public async Task<TaskModel> CreateTaskAsync(TaskModel task)
		{
			_context.Tasks.Add(task);
			await _context.SaveChangesAsync();
			return task;
		}

		public async Task<bool> DeleteTaskAsync(int id)
		{
			var task = await _context.Tasks.FindAsync(id);
			if (task == null) return false;

			_context.Tasks.Remove(task);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
