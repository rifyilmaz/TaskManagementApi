using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services;

public class TasksDb
{

    private static List<TaskItem> _tasks = new()
        {
        new TaskItem
        {
        Id = 1,
        Title = "Complete ASP.NET Core tutorial",
        Description = "Learn routing, configuration, and environments",
        IsCompleted = false,
        DueDate = DateTime.Now.AddDays(7),
        Priority = Priority.High,
        CreatedAt = DateTime.Now.AddDays(-3)
        },
        new TaskItem
        {
        Id = 2,
        Title = "Build sample API",
        Description = "Create a task management API",
        IsCompleted = true,
        DueDate = DateTime.Now.AddDays(-2),
        Priority = Priority.Medium,
        CreatedAt = DateTime.Now.AddDays(-5)
        },
        new TaskItem
        {
        Id = 3,
        Title = "Write unit tests",
        Description = "Add tests for the task service",
        IsCompleted = false,
        DueDate = DateTime.Now.AddDays(3),
        Priority = Priority.Low,
        CreatedAt = DateTime.Now.AddDays(-1)
        }
    };    

    /*** Get all tasks ***/
    public static List<TaskItem> GetTasks()
    {
        return _tasks;
    }

    
    public static TaskItem? CreateTask(TaskItem task)
    {        
        if (task.Id==0)
        {
            return null;
        }
        else {
            TasksDb.AddTask(task);
            task.CreatedAt = DateTime.Now;
        }
        
        return task;
    }    
    public static TaskItem? UpdateTask(int id, TaskItem task)
    {
        TaskItem? existingTask = GetTaskById(id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.DueDate = task.DueDate;
            existingTask.Priority = task.Priority;
            return existingTask;
        }
        return existingTask;
    } 

    public static TaskItem? DeleteTask(int id)
    {
        TaskItem? task = TasksDb.GetTaskById(id);
        if (task != null)
        {
            TasksDb.RemoveTask(task);
        }
        return task;
    }    
    

    /*** Get task by id ***/
    public static TaskItem? GetTaskById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    /*** Get tasks by priority ***/
    public static List<TaskItem> GetTasksByPriority(Priority priority)
    {
        return _tasks.Where(t => t.Priority == priority).ToList();
    }

    public static List<TaskItem> SearchTasks(string? keyword, bool? isCompleted)
    {
        IEnumerable<TaskItem> query = _tasks;

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                     (t.Description != null && t.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)));
        }

        if (isCompleted.HasValue)
        {
            query = query.Where(t => t.IsCompleted == isCompleted.Value);
        }

        return query.ToList();
    }    
    private static int FindItemIndex(int id)
    {
        int say = -1;
        foreach (var task in _tasks)
        {
            say++;
            if (task.Id==id)
            {
                return say;
            }
        }
        return -1;
    }


    private static TaskItem? AddTask(TaskItem task)
    {
        _tasks.Add(task);
        return task;
    }

    private static TaskItem? RemoveTask(TaskItem task)
    {
        _tasks.Remove(task);
        return task;
    }

}
