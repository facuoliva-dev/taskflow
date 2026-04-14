using System.Text.Json;

namespace taskflow.Utils
{
    public class FileManager
    {
        private string path = "data/tasks.json";

        public List<string> Load()
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

                return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public void Save(List<string> data)
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


//cambiar despues de List<string> a List<TaskItem> 

