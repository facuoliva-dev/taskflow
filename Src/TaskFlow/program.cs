using TaskFlow.Services;
using TaskFlow.Models;

var service = new TaskService();

var task = service.CreateTask("Test", "Probando", "Facu");

Console.WriteLine(task.Title);