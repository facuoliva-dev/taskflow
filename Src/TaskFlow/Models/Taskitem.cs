using System;

namespace TaskFlow.Models
{
    public enum TaskStatus
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Taskitem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Taskitem()
        {
            Status = TaskStatus.Pendiente;
            CreatedAt = DateTime.Now;
        }
    }
}
