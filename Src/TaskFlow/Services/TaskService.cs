using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;

public class TaskService
{
    private List<TaskItem> tasks = new List<TaskItem>();

    public TaskItem CreateTask(string title, string description, string responsible)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("El t�tulo es obligatorio.");
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
        return task;
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
            return true;
        }

        return false;
    }

    public void SaveToFile(string path)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(tasks, new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        });

        System.IO.File.WriteAllText(path, json);
    }

    public void LoadFromFile(string path)
    {
        if (System.IO.File.Exists(path))
        {
            var json = System.IO.File.ReadAllText(path);
            tasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}