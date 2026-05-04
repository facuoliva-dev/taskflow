using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;
using TaskFlow.Utils;

namespace TaskFlow.Services;

public class TaskService
{
    private List<TaskItem> tasks;
    private FileManager fileManager;

    public TaskService()
    {
        fileManager = new FileManager();
        tasks = fileManager.Load(); // 🔥 carga desde JSON
    }

    public TaskItem CreateTask(string title, string description, string responsible)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("El título es obligatorio.");
        }

        var task = new TaskItem
        {
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Title = title,
            Description = description,
            Responsible = responsible,
            Status = TaskStatus.Pendiente,
            CreatedAt = DateTime.Now
        };

        tasks.Add(task);
        fileManager.Save(tasks); // 🔥 guarda

        return task;
    }

    public List<TaskItem> GetAllTasks()
    {
        return tasks;
    }

    public List<TaskItem> GetTasks(TaskStatus? filter = null)
    {
        if (filter.HasValue)
        {
            return tasks.Where(t => t.Status == filter.Value).ToList();
        }

        return tasks;
    }

    public bool UpdateStatus(int id, TaskStatus newStatus)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task != null)
        {
            task.Status = newStatus;
            task.UpdatedAt = DateTime.Now;

            fileManager.Save(tasks); // 🔥 guarda

            return true;
        }

        return false;
    }

    public bool UpdateResponsible(int id, string newResponsible)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task != null)
        {
            task.Responsible = newResponsible;
            task.UpdatedAt = DateTime.Now;

            fileManager.Save(tasks); // 🔥 guarda

            return true;
        }

        return false;
    }

    public bool DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task != null)
        {
            tasks.Remove(task);

            fileManager.Save(tasks); // 🔥 guarda

            return true;
        }

        return false;
    }
}