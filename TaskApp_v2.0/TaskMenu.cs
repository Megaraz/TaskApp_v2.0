using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp_v2._0;
internal class TaskMenu
{
    private static List<UserTask>? s_tasks;

    public TaskMenu(List<UserTask> tasks)
    {
        s_tasks = tasks;
    }

    private readonly string[] _menuOverview = { "Update task", "Delete task", "Mark as completed", "Exit" };
    private readonly string[] _menuSpecific = { "Update Title", "Update Description", "Update Due Date", "Mark as completed", "Exit" };

    public enum MenuState
    {
        None,
        Overview,
        Specific,
        Update,
        Delete,
        Exit
    }
    public MenuState CurrentMenuState { get; set; } = MenuState.Overview;


    public int overviewIndex = 0;
    public int specificIndex = 0;
    public int updateIndex = 0;


    public void DisplayAllTasks()
    {
        Console.Clear();
        Console.WriteLine("DUE DATE(MM/dd)".PadRight(20) + "TASKS");
        Console.WriteLine();

        if (s_tasks!.Count > 0)
        {
            for (int i = 0; i < s_tasks!.Count; i++)
            {
                UserTask? task = s_tasks![i];
                if (i == overviewIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{task.DueDate:MM/dd}".PadRight(20));
                    Console.WriteLine($"{task.Title!.ToUpper()}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{task.DueDate:MM/dd}".PadRight(20));
                    Console.WriteLine($"{task.Title!.ToUpper()}");
                    Console.ResetColor();
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Task List is Empty! Add new tasks in Main Menu");
            Thread.Sleep(2000);
            MainMenu.CurrentMenuState = MainMenu.MenuState.Main;
        }
    }
    public ConsoleKey GetUserInput()
    {
        
        ConsoleKey input;

        switch (CurrentMenuState)
        {
            case MenuState.Overview: 
                (input, overviewIndex) = MenuSelection.GetUserInput(overviewIndex, s_tasks!.Count, MenuSelection.NavigationDirection.Vertical); break;
            case MenuState.Specific: 
                (input, specificIndex) = MenuSelection.GetUserInput(specificIndex, _menuOverview.Length, MenuSelection.NavigationDirection.Horizontal); break;
            case MenuState.Update: 
                (input, updateIndex) = MenuSelection.GetUserInput(updateIndex, _menuSpecific.Length, MenuSelection.NavigationDirection.Horizontal); break;
            default: 
                input = ConsoleKey.None; break;
        }

        return input;

    }

    public void DisplaySpecificTask()
    {
        
        Console.Clear();
        Console.Write($"{s_tasks![overviewIndex].DueDate:MM/dd}".PadRight(20));
        Console.WriteLine($"{s_tasks[overviewIndex].Title.ToUpper()}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{s_tasks[overviewIndex].Description}");
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < _menuOverview.Length; i++)
        {
            if (i == specificIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{_menuOverview[i]}\t");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{_menuOverview[i]}\t");
                Console.ResetColor();
            }
        }
            
    }
    public void DisplaySpecificUpdateChoices()
    {
        
        Console.Clear();
        Console.Write($"{s_tasks![overviewIndex].DueDate:MM/dd}".PadRight(20));
        Console.WriteLine($"{s_tasks[overviewIndex].Title.ToUpper()}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{s_tasks[overviewIndex].Description}");
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < _menuSpecific.Length; i++)
        {
            if (i == updateIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{_menuSpecific[i]}\t");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{_menuSpecific[i]}\t");
                Console.ResetColor();
            }
        }

    }
}
