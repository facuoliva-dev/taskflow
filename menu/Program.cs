using System;
using System.Collections.Generic;

class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Responsable { get; set; }
    public string Estado { get; set; }
}

class Program
{
    static List<Tarea> tareas = new List<Tarea>();
    static int contadorId = 1;

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("===== TASKFLOW =====");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Actualizar estado");
            Console.WriteLine("4. Cambiar responsable");
            Console.WriteLine("5. Eliminar tarea");
            Console.WriteLine("6. Salir");
            Console.Write("Elegí una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CrearTarea();
                    break;
                case 2:
                    ListarTareas();
                    break;
                case 3:
                    ActualizarEstado();
                    break;
                case 4:
                    CambiarResponsable();
                    break;
                case 5:
                    EliminarTarea();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 6);
    }

    static void CrearTarea()
    {
        Console.Write("Título: ");
        string titulo = Console.ReadLine();

        Console.Write("Responsable: ");
        string responsable = Console.ReadLine();

        tareas.Add(new Tarea
        {
            Id = contadorId++,
            Titulo = titulo,
            Responsable = responsable,
            Estado = "Pendiente"
        });

        Console.WriteLine("✔ Tarea creada");
    }

    static void ListarTareas()
    {
        foreach (var t in tareas)
        {
            Console.WriteLine($"ID: {t.Id} | {t.Titulo} | {t.Responsable} | {t.Estado}");
        }
    }

    static void ActualizarEstado()
    {
        Console.Write("ID de la tarea: ");
        int id = int.Parse(Console.ReadLine());

        var tarea = tareas.Find(t => t.Id == id);

        if (tarea != null)
        {
            Console.WriteLine("1. Pendiente\n2. En progreso\n3. Completada");
            int op = int.Parse(Console.ReadLine());

            tarea.Estado = op == 1 ? "Pendiente" :
                           op == 2 ? "En progreso" :
                           "Completada";

            Console.WriteLine("✔ Estado actualizado");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada");
        }
    }

    static void CambiarResponsable()
    {
        Console.Write("ID de la tarea: ");
        int id = int.Parse(Console.ReadLine());

        var tarea = tareas.Find(t => t.Id == id);

        if (tarea != null)
        {
            Console.Write("Nuevo responsable: ");
            tarea.Responsable = Console.ReadLine();

            Console.WriteLine("✔ Responsable actualizado");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada");
        }
    }

    static void EliminarTarea()
    {
        Console.Write("ID de la tarea: ");
        int id = int.Parse(Console.ReadLine());

        var tarea = tareas.Find(t => t.Id == id);

        if (tarea != null)
        {
            tareas.Remove(tarea);
            Console.WriteLine("✔ Tarea eliminada");
        }
        else
        {
            Console.WriteLine("Tarea no encontrada");
        }
    }
}
