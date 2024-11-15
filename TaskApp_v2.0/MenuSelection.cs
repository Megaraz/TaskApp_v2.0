using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp_v2._0;
public static class MenuSelection
{


    public static (ConsoleKey input, int index) GetUserInputVertical(int index, int length)
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        switch (input)
        {
            case ConsoleKey.UpArrow: index--; break;
            case ConsoleKey.DownArrow: index++; break;
            case ConsoleKey.Enter: break;
            case ConsoleKey.Escape: Console.Clear(); Console.WriteLine($"Exiting.."); Thread.Sleep(1000); break;
            default: Console.WriteLine($"{Environment.NewLine}Invalid choice"); Thread.Sleep(500); Console.Clear(); break;
        }

        if (index < 0)
        {
            index = length - 1;
        }
        else if (index >= length)
        {
            index = 0;
        }

        return (input, index);
    }

    public static (ConsoleKey input, int index)GetUserInputHorizontal(int index, int length)
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        switch (input)
        {
            case ConsoleKey.LeftArrow: index--; break;
            case ConsoleKey.RightArrow: index++; break;
            case ConsoleKey.Enter: break;
            case ConsoleKey.Escape: Console.Clear(); Console.WriteLine($"Exiting.."); Thread.Sleep(1000); break;
            default: Console.WriteLine($"{Environment.NewLine}Invalid choice"); Thread.Sleep(500); Console.Clear(); break;
        }

        if (index < 0)
        {
            index = length - 1;
        }
        else if (index >= length)
        {
            index = 0;
        }
        

        return (input, index);
    }
}
