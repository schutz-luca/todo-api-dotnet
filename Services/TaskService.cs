using ToDoAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Models;
using TodoApi.DTOs;

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

		public async Task<TaskModel> CreateTaskAsync(TaskCreateDto dto)
		{
			var task = new TaskModel
			{
				Title = dto.Title,
				Description = dto.Description,
				Status = dto.Status
			};

			_context.Tasks.Add(task);
			await _context.SaveChangesAsync();
			return task;
		}

		public async Task<bool> UpdateTaskAsync(int id, TaskUpdateDto dto)
		{
			var existingTask = await _context.Tasks.FindAsync(id);
			if (existingTask == null)
				return false;

			existingTask.Title = dto.Title;
			existingTask.Description = dto.Description;
			existingTask.Status = dto.Status;

			_context.Entry(existingTask).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return true;
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
