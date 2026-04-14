using System;

namespace TaskFlow.Models
{
    // Definimos los estados que pide el manual
    public enum TaskStatus
    {
        Pendiente,
        EnProgreso,
        Completada
    }

    public class Taskitem
    {
        // Estos son los campos obligatorios:
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } // El ? es porque al principio es nulo

        public Taskitem()
        {
            // El manual dice que el estado inicial es Pendiente
            Status = TaskStatus.Pendiente;
            // La fecha de creación debe ser automática
            CreatedAt = DateTime.Now;
        }
    }
}
