namespace TaskApp_v2._0;

static class MainMenu
{
    public static readonly string[] s_Items = new string[]
    {
        "Add new task",
        "Show tasks",
        "Save & exit"
    };

    public static int Index;

    public static void Display()
    {
        Console.Clear();
        Console.WriteLine("TASKMANAGER");

        for (int i = 0; i < s_Items.Length; i++)
        {
            if (i == Index)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{i + 1}]. {s_Items[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"[{i + 1}]. {s_Items[i]}");
                Console.ResetColor();
            }
        }

    }



    public static ConsoleKey GetUserInput()
    {
        (ConsoleKey input, Index) = MenuSelection.GetUserInputVertical(Index, s_Items.Length);
        return input;
    }
}
