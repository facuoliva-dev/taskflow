using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskFlow.Models;

namespace TaskFlow.Utils
{
    public class FileManager
    {
        private string path = "data/tasks.json";

        public List<TaskItem> Load()
        {
            try
            {
                if (!Directory.Exists("data"))
                {
                    Directory.CreateDirectory("data");
                }

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "[]");
                }

                string json = File.ReadAllText(path);

                return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
            catch (Exception)
            {
                return new List<TaskItem>();
            }
        }

        public void Save(List<TaskItem> data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
            }
            catch (Exception)
            {
                Console.WriteLine("Error al guardar el archivo.");
            }
        }
    }
}
