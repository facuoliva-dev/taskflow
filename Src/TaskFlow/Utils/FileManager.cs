using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskFlow.Models;

namespace TaskFlow.Utils
{
    public class FileManager
    {
        private string path;

        public FileManager()
        {
            // Ruta base del ejecutable
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Subimos hasta la raíz del proyecto
            var projectPath = Path.GetFullPath(
                Path.Combine(basePath, "..", "..", "..")
            );

            // Apuntamos a la carpeta Utils
            path = Path.Combine(projectPath, "Utils", "tasks.json");
        }

        public List<TaskItem> Load()
        {
            try
            {
                var directory = Path.GetDirectoryName(path);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "[]");
                }

                string json = File.ReadAllText(path);

                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return new List<TaskItem>();
            }
        }

        public void Save(List<TaskItem> data)
        {
            try
            {
                var directory = Path.GetDirectoryName(path);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
            }
        }
    }
}