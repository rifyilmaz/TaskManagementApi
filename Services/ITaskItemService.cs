
using TaskManagementApi.Models;

namespace TaskManagementApi.Services;

public interface ITaskItemService
{
 List<TaskItem> GetAllTasks();
 TaskItem? GetTaskById(int id);
 List<TaskItem> GetTasksByPriority(Priority priority);
 List<TaskItem> SearchTasks(string? keyword, bool? isCompleted);
 TaskItem? CreateTask(TaskItem task);
 TaskItem? UpdateTask(int id, TaskItem task);
 bool DeleteTask(int id);
 int GetTaskCount();
}
