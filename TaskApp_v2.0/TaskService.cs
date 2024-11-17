using System.ComponentModel.Design;

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
    public void HandleExitMenuInput(ConsoleKey input, ref bool exitProgram)
    {
        if (input == ConsoleKey.Enter)
        {
            switch (MainMenu.ExitIndex)
            {
                case 0:
                    // Yes, exit program
                    exitProgram = true;
                    break;
                case 1:
                    // No, go back to main menu
                    MainMenu.CurrentMenuState = MainMenu.MenuState.Main;
                    break;
                default:
                    Console.WriteLine($"{Environment.NewLine}Invalid choice");
                    Thread.Sleep(500);
                    break;
            }
        }
        else if (input == ConsoleKey.Escape)
        {
            // Cancel exit and return to main menu
            MainMenu.CurrentMenuState = MainMenu.MenuState.Main;
        }
    }


    public void HandleMainMenuInput(ConsoleKey input, ref bool exitProgram)
    {
        if (input == ConsoleKey.Enter)
        {
            switch (MainMenu.MainIndex)
            {
                case 0:
                    AddTask();
                    break;
                case 1:
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Overview;
                    TaskMenuLogic();
                    break;
                case 2:
                    MainMenu.CurrentMenuState = MainMenu.MenuState.Exit;
                    break;
                default:
                    Console.WriteLine($"{Environment.NewLine}Invalid choice");
                    Thread.Sleep(500);
                    break;
            }
        }
        //else if (input == ConsoleKey.Escape)
        //{
        //    // Optionally handle Esc key in main menu
        //    MainMenu.CurrentMenuState = MenuState.Exit;
        //}
    }

    public void HandleSpecificTaskMenuInput(ConsoleKey input)
    {
        if (input == ConsoleKey.Enter)
        {
            switch (_taskMenu.specificIndex)
            {
                case 0:
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Update;
                    break;

                case 1:
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Delete;
                    break;

                case 2:
                    _tasks[_taskMenu.overviewIndex].IsCompleted = true;
                    CompleteTask();
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Overview;
                    break;

                case 3:
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Exit;
                    break;
            }
        }
        else if (input == ConsoleKey.Escape)
        {
            _taskMenu.CurrentMenuState = TaskMenu.MenuState.Overview;
        }
    }


    public void TaskMenuLogic()
    {
        ConsoleKey input;
        bool isMenu;
        

        do
        {
            switch (_taskMenu.CurrentMenuState)
            {
                case TaskMenu.MenuState.Overview: 
                    _taskMenu.DisplayAllTasks();
                    if (_tasks.Count > 0)
                    {
                        input = _taskMenu.GetUserInput();
                    if (input == ConsoleKey.Enter)
                        _taskMenu.CurrentMenuState = TaskMenu.MenuState.Specific;
                    else if (input == ConsoleKey.Escape)
                        _taskMenu.CurrentMenuState = TaskMenu.MenuState.None;
                    }
                    else
                        _taskMenu.CurrentMenuState = TaskMenu.MenuState.None;
                    break;


                case TaskMenu.MenuState.Delete:
                    DeleteTask();
                    _taskMenu.CurrentMenuState = TaskMenu.MenuState.Overview;
                    break;
                    

                case TaskMenu.MenuState.Specific:
                    _taskMenu.DisplaySpecificTask();
                    input = _taskMenu.GetUserInput();
                    HandleSpecificTaskMenuInput(input);
                    break;

                case TaskMenu.MenuState.Update:
                    _taskMenu.DisplaySpecificUpdateChoices();
                    input = _taskMenu.GetUserInput();
                    if (input == ConsoleKey.Enter)
                    {
                        UpdateTask();
                        _taskMenu.CurrentMenuState = TaskMenu.MenuState.Specific; 
                    }
                    else if (input == ConsoleKey.Escape)
                        _taskMenu.CurrentMenuState = TaskMenu.MenuState.Specific;
                    break;
            }

            isMenu = !(_taskMenu.CurrentMenuState == TaskMenu.MenuState.None || _taskMenu.CurrentMenuState == TaskMenu.MenuState.Exit);

        } while (isMenu);

    }

    public void UpdateTask()
    {
        Console.Clear();
        switch (_taskMenu.updateIndex)
        {
            case 0: 
                Console.Write("Title: "); 
                _tasks[_taskMenu.overviewIndex].Title = Console.ReadLine()!; 
                break;

            case 1:
                Console.WriteLine("Task description: "); 
                _tasks[_taskMenu.overviewIndex].Description = Console.ReadLine()!; 
                break;

            case 2: 
                Console.WriteLine("Due date(DD/MM): "); 
                _tasks[_taskMenu.overviewIndex].DueDate = DateTime.Parse(Console.ReadLine()!); 
                break;

            case 3:
                _tasks[_taskMenu.overviewIndex].IsCompleted = true;
                CompleteTask();
                break;

            case 4: 
                Console.WriteLine("Exiting.."); 
                break;

        }

        _repository.SaveAllTasks(_tasks);


    }

    private void CompleteTask()
    {
        Console.Clear();
        Console.WriteLine($"{_tasks[_taskMenu.overviewIndex].Title} Completed!");
        Thread.Sleep(1000);
        
        if (_tasks[_taskMenu.overviewIndex].IsCompleted)
        {
            _tasks.Remove(_tasks[_taskMenu.overviewIndex]);
            _repository.SaveAllTasks(_tasks);
        }
    }

    public void DeleteTask()
    {
        Console.Clear();
        Console.WriteLine($"{_tasks[_taskMenu.overviewIndex].Title} Deleted!");
        Thread.Sleep(1000);

        _tasks.Remove(_tasks[_taskMenu.overviewIndex]);
        _repository.SaveAllTasks(_tasks);
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
