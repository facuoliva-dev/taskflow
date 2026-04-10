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
}