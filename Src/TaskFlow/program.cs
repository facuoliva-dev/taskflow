using System;
using TaskFlow.Services;
using TaskFlow.Models;

class Program
{
    static void Main()
    {
        var service = new TaskService();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("===== TASKFLOW =====");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Actualizar estado");
            Console.WriteLine("4. Cambiar responsable");
            Console.WriteLine("5. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.Write("Elegí una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Título: ");
                    var titulo = Console.ReadLine();

                    Console.Write("Descripción: ");
                    var descripcion = Console.ReadLine();

                    Console.Write("Responsable: ");
                    var responsable = Console.ReadLine();

                    var tarea = service.CreateTask(titulo, descripcion, responsable);
                    Console.WriteLine($"✔ Tarea creada: {tarea.Title}");
                    break;

                case "2":
                    var tareas = service.GetAllTasks();
                    foreach (var t in tareas)
                    {
                        Console.WriteLine($"ID: {t.Id} | {t.Title} | {t.Responsible} | {t.Status}");
                    }
                    break;

                case "3":
                    Console.Write("ID de la tarea: ");
                    int idEstado = int.Parse(Console.ReadLine());

                    Console.WriteLine("1. Pendiente\n2. En progreso\n3. Completada");
                    int estado = int.Parse(Console.ReadLine());

                    string nuevoEstado = estado == 1 ? "Pending" :
                                         estado == 2 ? "InProgress" :
                                         "Completed";

                    service.UpdateStatus(idEstado, nuevoEstado);
                    Console.WriteLine("✔ Estado actualizado");
                    break;

                case "4":
                    Console.Write("ID de la tarea: ");
                    int idResp = int.Parse(Console.ReadLine());

                    Console.Write("Nuevo responsable: ");
                    var nuevoResp = Console.ReadLine();

                    service.UpdateResponsible(idResp, nuevoResp);
                    Console.WriteLine("✔ Responsable actualizado");
                    break;

                case "5":
                    Console.Write("ID de la tarea: ");
                    int idDel = int.Parse(Console.ReadLine());

                    service.DeleteTask(idDel);
                    Console.WriteLine("✔ Tarea eliminada");
                    break;

                case "0":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine();
        }
    }
}
