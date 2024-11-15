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

    private static string[] menuOverview = { "Update task", "Delete task", "Mark as completed", "Exit" };
    private static string[] menuSpecific = { "Update Title", "Update Description", "Update Due Date", "Mark as completed", "Exit" };


    public int overviewIndex = 0;
    public int specificIndex = 0;
    public int updateIndex = 0;

    public bool isOverviewMenu = false;
    public bool isSpecificMenu = false;
    public bool isUpdateMenu = false;

    public void DisplayAllTasks()
    {
        Console.Clear();
        Console.WriteLine("DUE DATE(MM/dd)".PadRight(20) + "TASKS");
        Console.WriteLine();
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
    public ConsoleKey GetUserInput()
    {
        ConsoleKey menuOverviewInput;
        ConsoleKey menuSpecificInput;
        ConsoleKey menuUpdateInput;


        if (isOverviewMenu)
        {
            (menuOverviewInput, overviewIndex) = MenuSelection.GetUserInputVertical(overviewIndex, s_tasks!.Count);
            return menuOverviewInput;
        }
        else if (isSpecificMenu)
        {
            (menuSpecificInput, specificIndex) = MenuSelection.GetUserInputHorizontal(specificIndex, menuOverview.Length);
            return menuSpecificInput;
        }
        else if (isUpdateMenu)
        {
            (menuUpdateInput, updateIndex) = MenuSelection.GetUserInputHorizontal(updateIndex, menuSpecific.Length);
            return menuUpdateInput;
        }

        return ConsoleKey.None;

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

        for (int i = 0; i < menuOverview.Length; i++)
        {
            if (i == specificIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{menuOverview[i]}\t");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{menuOverview[i]}\t");
                Console.ResetColor();
            }
        }
            
    }
    public void DisplaySpecificUpdateChoices()
    {
        ConsoleKey updateSelection;

        
        Console.Clear();
        Console.Write($"{s_tasks![overviewIndex].DueDate:MM/dd}".PadRight(20));
        Console.WriteLine($"{s_tasks[overviewIndex].Title.ToUpper()}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"{s_tasks[overviewIndex].Description}");
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < menuSpecific.Length; i++)
        {
            if (i == updateIndex)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{menuSpecific[i]}\t");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{menuSpecific[i]}\t");
                Console.ResetColor();
            }
        }

    }
}
