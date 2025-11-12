using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApi.Models;

namespace ToDoAPI.Interfaces
{
	public interface ITaskService
	{
		Task<IEnumerable<TaskModel>> GetAllTasksAsync();
		Task<TaskModel?> GetTaskByIdAsync(int id);
		Task<TaskModel> CreateTaskAsync(TaskModel task);
		Task<bool> DeleteTaskAsync(int id);
	}
}
