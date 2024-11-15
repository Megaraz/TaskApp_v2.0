namespace TaskApp_v2._0;
internal class TaskService
{

    private readonly TaskRepository _repository;
    public List<UserTask> _tasks;
    public TaskMenu _taskMenu;

    public TaskService(TaskRepository repository)
    {
        _repository = repository;
        _tasks = OrderListByDueDate(_repository.GetAllTasks());
        _taskMenu = new TaskMenu(_tasks);

    }

    private static List<UserTask> OrderListByDueDate(List<UserTask> tasks)
    {
        var orderedTasks = tasks.OrderBy(x => x.DueDate).ToList();
        return orderedTasks;
    }

    public void TaskMenuLogic()
    {
        ConsoleKey input;

        do
        {
            _taskMenu.DisplayAllTasks();
            _taskMenu.GetUserInput();

            


        } while (true);





        if (_taskMenu.isOverviewMenu)
        {
            do
            {
                _taskMenu.DisplayAllTasks();
                input = _taskMenu.GetUserInput();

                _taskMenu.isOverviewMenu = !(input == ConsoleKey.Enter || input == ConsoleKey.Escape);

                if (!_taskMenu.isOverviewMenu)
                    _taskMenu.isSpecificMenu = true;


            } while (_taskMenu.isOverviewMenu);
        }
        if (_taskMenu.isSpecificMenu)
        {
            do
            {
                _taskMenu.DisplaySpecificTask();
                input = _taskMenu.GetUserInput();

                _taskMenu.isSpecificMenu = !(input == ConsoleKey.Enter || input == ConsoleKey.Escape);

                if (!_taskMenu.isSpecificMenu)
                    _taskMenu.isUpdateMenu = true;

            } while (_taskMenu.isSpecificMenu);
        }
        if (_taskMenu.isUpdateMenu)
        {
            do
            {
                _taskMenu.DisplaySpecificUpdateChoices();
                input = _taskMenu.GetUserInput();

                _taskMenu.isUpdateMenu = !(input == ConsoleKey.Enter || input == ConsoleKey.Escape);

                if (input == ConsoleKey.Enter && _taskMenu.updateIndex < 3)
                {
                    UpdateTask();
                }

                if (!_taskMenu.isUpdateMenu)
                    _taskMenu.isSpecificMenu = true;

            } while (_taskMenu.isUpdateMenu);
        }


    }

    public void UpdateTask()
    {
        //var taskToUpdate = _tasks[_taskMenu.overviewIndex];

        switch (_taskMenu.updateIndex)
        {
            case 0: Console.Write("Title: "); _tasks[_taskMenu.overviewIndex].Title = Console.ReadLine()!; break;
            case 1: Console.WriteLine("Task description: "); _tasks[_taskMenu.overviewIndex].Description = Console.ReadLine()!; break;
            case 2: Console.WriteLine("Due date(DD/MM): "); _tasks[_taskMenu.overviewIndex].DueDate = DateTime.Parse(Console.ReadLine()!); break;
            case 3: Console.WriteLine("Task completed!"); _tasks[_taskMenu.overviewIndex].IsCompleted = true; break;
            case 4: Console.WriteLine("Exiting.."); break;

        }


    }

    public void AddTask()
    {
        UserTask task = new UserTask();

        Console.Clear();

        Console.Write("Title: ");
        task.Title = Console.ReadLine()!;

        Console.WriteLine("Task description: ");
        task.Description = Console.ReadLine()!;


        Console.WriteLine("Due date(DD/MM): ");
        string dueDate = Console.ReadLine()!;
        try
        {
            task.DueDate = DateTime.Parse(dueDate);

        }
        catch
        {
            Console.WriteLine("Not valid date, setting default");
            task.DueDate = Convert.ToDateTime(DateTime.MaxValue);
        }


        _tasks.Add(task);
        _repository.SaveAllTasks(_tasks);
        Console.WriteLine($"{task.Title} added.");

    }
}
