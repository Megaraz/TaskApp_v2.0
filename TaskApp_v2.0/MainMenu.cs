using System.Security.Principal;

namespace TaskApp_v2._0;

static class MainMenu
{
    private static readonly string[] s_mainItems =
    [
        "Add new task",
        "Show tasks",
        "Save & exit"
    ];

    private static readonly string[] s_exitItems =
    [
        "Yes exit program",
        "No go back to Main Menu"
    ];

    public enum MenuState
    {
        None,
        Main,
        Exit
    }

    public static MenuState CurrentMenuState { get; set; } = MenuState.Main;


    public static int MainIndex = 0;
    public static int ExitIndex = 0;

    public static void DisplayMain()
    {
        Console.Clear();
        Console.WriteLine("TASKMANAGER");

        for (int i = 0; i < s_mainItems.Length; i++)
        {
            if (i == MainIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{i + 1}]. {s_mainItems[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"[{i + 1}]. {s_mainItems[i]}");
                Console.ResetColor();
            }
        }

    }

    public static void DisplayExit()
    {
        Console.Clear();
        Console.WriteLine("ARE YOU SURE YOU WANT TO EXIT?");
        Console.WriteLine();

        for (int i = 0; i < s_exitItems.Length; i++)
        {
            if (i == ExitIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"[{s_exitItems[i]}]".PadRight(20));
                Console.ResetColor();
            }
            else
            {
                Console.Write($"[{s_exitItems[i]}]".PadRight(20));
                Console.ResetColor();
            }
        }

    }

    public static ConsoleKey GetUserInput()
    {
        switch (CurrentMenuState)
        {
            case MenuState.Main:  
                (ConsoleKey mainInput, MainIndex) = MenuSelection.GetUserInput(MainIndex, s_mainItems.Length, MenuSelection.NavigationDirection.Vertical);
                return mainInput;

            case MenuState.Exit:
                (ConsoleKey exitInput, ExitIndex) = MenuSelection.GetUserInput(ExitIndex, s_exitItems.Length, MenuSelection.NavigationDirection.Horizontal);
                return exitInput;

            default:
                return ConsoleKey.None;
        }
    }

}
