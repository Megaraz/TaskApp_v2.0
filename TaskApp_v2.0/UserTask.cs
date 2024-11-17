namespace TaskApp_v2._0;
public class UserTask
{
    //public UserTask(int id, string title, string description, DateTime dueDate, bool isCompleted)
    //{
    //    Id = id;
    //    Title = title;
    //    Description = description;
    //    DueDate = dueDate;
    //    IsCompleted = false;
    //}

    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}
