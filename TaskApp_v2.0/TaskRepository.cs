using System.Text.Json;

namespace TaskApp_v2._0;
public class TaskRepository(string filePath)
{
    public List<UserTask> GetAllTasks()
    {
        string json;
        try
        {
            json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<UserTask>>(json)!;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error reading tasks file. Starting with an empty list.");
            return new List<UserTask>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Error reading tasks file. Starting with an empty list.");
            return new List<UserTask>();
        }
    }

    public void SaveAllTasks(List<UserTask> tasks)
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(filePath, json);

    }
}
