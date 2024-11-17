namespace TaskApp_v2._0;
public class UserTask(string title, string description, DateTime dueDate)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime DueDate { get; set; } = dueDate;
    public bool IsCompleted { get; set; }

}
