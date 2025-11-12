using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.DTOs;
using ToDoApi.Models;

namespace ToDoAPI.Interfaces
{
	public interface ITaskService
	{
		Task<IEnumerable<TaskModel>> GetAllTasksAsync();
		Task<TaskModel?> GetTaskByIdAsync(int id);
		Task<TaskModel> CreateTaskAsync(TaskCreateDto task);
		Task<bool> UpdateTaskAsync(int id, TaskUpdateDto updatedTask);
		Task<bool> DeleteTaskAsync(int id);
	}
}
