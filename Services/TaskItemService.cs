
using TaskManagementApi.Models;

namespace TaskManagementApi.Services;

public class TaskItemService : ITaskItemService
{

    public TaskItemService()
    {
    }

    public  List<TaskItem> GetAllTasks()
    {
        return TasksDb.GetTasks();
    }    

    public TaskItem? GetTaskById(int id)
    {
        return TasksDb.GetTaskById(id);
    }

    public List<TaskItem> GetTasksByPriority(Priority priority)
    {
        return TasksDb.GetTasksByPriority(priority);   
     }

    public List<TaskItem> SearchTasks(string? keyword, bool? isCompleted) {
        return TasksDb.SearchTasks(keyword, isCompleted);
    }

    public TaskItem? CreateTask(TaskItem task)
    {        
        return TasksDb.CreateTask(task);
    }

    public TaskItem? UpdateTask(int id, TaskItem task)
    {
        return TasksDb.UpdateTask(id, task);
    }
    

    public bool DeleteTask(int id)
    {
        return TasksDb.DeleteTask(id) != null;
    }    

    public int GetTaskCount()
    {
        return TasksDb.GetTasks().Count;
    }

}