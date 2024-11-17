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
    public static void HandleExitMenuInput(ConsoleKey input, ref bool exitProgram)
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
        else if (input == ConsoleKey.Escape)
        {
            // Optionally handle Esc key in main menu
            MainMenu.CurrentMenuState = MainMenu.MenuState.Exit;
        }
    }

    private void HandleSpecificTaskMenuInput(ConsoleKey input)
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


    private void TaskMenuLogic()
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

    private void UpdateTask()
    {
        Console.Clear();
        switch (_taskMenu.updateIndex)
        {
            case 0:
                Console.Write("Title: ");
                string title = Console.ReadLine()!;
                //_tasks[_taskMenu.overviewIndex].Title = Console.ReadLine()!; 
                break;

            case 1:
                Console.WriteLine("Task description: ");
                string description = Console.ReadLine()!;
                //_tasks[_taskMenu.overviewIndex].Description = Console.ReadLine()!; 
                break;

            case 2:
                Console.WriteLine("Due date(DD/MM): ");
                DateTime duedate = DateTime.Parse(Console.ReadLine()!);
                //_tasks[_taskMenu.overviewIndex].DueDate = DateTime.Parse(Console.ReadLine()!); 
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

    private void DeleteTask()
    {
        Console.Clear();
        Console.WriteLine($"{_tasks[_taskMenu.overviewIndex].Title} Deleted!");
        Thread.Sleep(1000);

        _tasks.Remove(_tasks[_taskMenu.overviewIndex]);
        _repository.SaveAllTasks(_tasks);
    }

    private static string? ReadInputWithEscape(string prompt)
    {
        Console.Write(prompt);
        string input = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Escape)
            {
                return null; // Indicate cancellation
            }
            else if (key == ConsoleKey.Backspace)
            {
                if (input.Length > 0)
                {
                    input = input[0..^1];
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                input += keyInfo.KeyChar;
                Console.Write(keyInfo.KeyChar);
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }

    private void AddTask()
    {
        //UserTask task = new UserTask();

        Console.Clear();
        Console.WriteLine("=== Add New Task ===");
        

        // Prompt for Title
        string? title = ReadInputWithEscape("Title: ");
        if (title == null)
        {
            CancelOperation();
            return;
        }
        else if (title.Length == 0)
        {
            Console.WriteLine();
            Console.WriteLine("Task needs a title!");
            Thread.Sleep(1250);
            return;
        }
        //task.Title = title;

        // Prompt for Description
        string? description = ReadInputWithEscape("Task Description: ");
        if (description == null)
        {
            CancelOperation();
            return;
        }
        //task.Description = description;

        // Prompt for Due Date
        string? dueDateInput = ReadInputWithEscape("Due Date (MM/dd): ");
        if (dueDateInput == null)
        {
            CancelOperation();
            return;
        }


        DateTime dueDate;
        // Parse Due Date
        try
        {
            dueDate = DateTime.ParseExact(dueDateInput, "MM/dd", null);
        }
        catch
        {
            Console.WriteLine("Invalid date format. Setting Due Date to MaxValue.");
            dueDate = DateTime.MaxValue;
        }

        UserTask task = new UserTask(title, description, dueDate);


        // Add Task to List and Save
        _tasks.Add(task);
        _repository.SaveAllTasks(_tasks);
        Console.WriteLine($"\nTask '{task.Title}' added successfully!");
        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }

    private void CancelOperation()
    {
        Console.WriteLine("\nOperation canceled. Returning to the main menu...");
        Thread.Sleep(1000);
        MainMenu.CurrentMenuState = MainMenu.MenuState.Main;
    }



    //public void AddTask()
    //{

    //    UserTask task = new UserTask();

    //    Console.Clear();

    //    Console.Write("Title: ");
    //    task.Title = Console.ReadLine()!;

    //    Console.WriteLine("Task description: ");
    //    task.Description = Console.ReadLine()!;


    //    Console.WriteLine("Due date(DD/MM): ");
    //    string dueDate = Console.ReadLine()!;
    //    try
    //    {
    //        task.DueDate = DateTime.Parse(dueDate);

    //    }
    //    catch
    //    {
    //        Console.WriteLine("Not valid date, setting default");
    //        task.DueDate = Convert.ToDateTime(DateTime.MaxValue);
    //    }


    //    _tasks.Add(task);
    //    _repository.SaveAllTasks(_tasks);
    //    Console.WriteLine($"{task.Title} added.");

    //}
}
