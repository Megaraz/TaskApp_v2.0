namespace TaskApp_v2._0;

internal class Program
{
    //const string _jsonFile = "UserTasks.json";
    //static readonly string s_filePath = AppDomain.CurrentDomain.BaseDirectory + _jsonFile;
    static void Main(string[] args)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "UserTasks.json");
        TaskRepository repository = new TaskRepository(filePath);
        TaskService taskService = new TaskService(repository);



        bool continueProgram;
        ConsoleKey mainMenuChoice;


        do
        {
            MainMenu.Display();

            mainMenuChoice = MainMenu.GetUserInput();

            continueProgram = !(mainMenuChoice == ConsoleKey.Enter || mainMenuChoice == ConsoleKey.Escape);

            if (mainMenuChoice == ConsoleKey.Enter)
            {
                switch (MainMenu.Index)
                {
                    case 0: taskService.AddTask(); break;
                    case 1: taskService._taskMenu.isOverviewMenu = true; taskService.TaskMenuLogic(); break;
                    case 2: Console.Clear(); Console.WriteLine($"Exiting program.."); Thread.Sleep(1000); break;
                    default: Console.WriteLine($"{Environment.NewLine}Invalid choice"); Thread.Sleep(500); Console.Clear(); break;
                }
            }

        } while (continueProgram);

    }

}
