namespace TaskApp_v2._0;
public class UserTask
{
    public UserTask(string title, string description, DateTime dueDate)
    {
        Id = Guid.NewGuid(); 
        Title = title;
        Description = description;
        DueDate = dueDate;
    }

    public Guid Id { get; private set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}
