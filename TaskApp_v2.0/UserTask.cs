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


    //public UserTask()
    //{
    //    Id = new Random().Next(1000);
    //}
    //public int Id { get; private set; }
    //private string? _title;
    //public string? Title
    //{
    //    get { return _title; }
    //    set
    //    {

    //        if (string.IsNullOrEmpty(value))
    //            value = $"{DateTime.Now}";
    //        else
    //            _title = value;
    //    }
    //}
    //public string? Description { get; set; }
    //public DateTime DueDate { get; set; }
    //public bool IsCompleted { get; set; }




}
