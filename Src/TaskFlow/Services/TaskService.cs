using System;
using System.Collections.Generic;
using System.Linq;
using TaskFlow.Models;
public class TaskService
{
    private List<TaskItem> tasks = new List<TaskItem>();

    public TaskItem CreateTask(string title, string description, string responsible)
    {
        [cite_start]
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("El título es obligatorio.");
        }

        var task = new TaskItem
        {
            [cite_start]
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Title = title,
            Description = description,
            Responsible = responsible,
            [cite_start]Status = TaskStatus.Pendiente,
            [cite_start]CreatedAt = DateTime.Now
        };

        tasks.Add(task);

        [cite_start]

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
        var json = System.Text.Json.JsonSerializer.Serialize(tasks);
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