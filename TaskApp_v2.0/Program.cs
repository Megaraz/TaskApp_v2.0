namespace TaskApp_v2._0;

internal class Program
{
    
    static void Main(string[] args)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "UserTasks.json");
        TaskRepository repository = new TaskRepository(filePath);
        TaskService taskService = new TaskService(repository);



        bool exitProgram = false;
        ConsoleKey mainMenuChoice;
        ConsoleKey exitMenuChoice;

        do
        {
            switch (MainMenu.CurrentMenuState)
            {
                case MainMenu.MenuState.Main: 
                    MainMenu.DisplayMain(); 
                    mainMenuChoice = MainMenu.GetUserInput();
                    taskService.HandleMainMenuInput(mainMenuChoice, ref exitProgram);
                    break;

                case MainMenu.MenuState.Exit:
                    MainMenu.DisplayExit();
                    exitMenuChoice = MainMenu.GetUserInput();
                    taskService.HandleExitMenuInput(exitMenuChoice, ref exitProgram);
                    break;

                default:
                    exitProgram = true;
                    break;
            }

            if (exitProgram)
            {
                Console.Clear();
                Console.WriteLine("Program has exited. Goodbye!");


            }

        } while (!exitProgram);

    }

}
