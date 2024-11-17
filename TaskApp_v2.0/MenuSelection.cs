using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp_v2._0;
public static class MenuSelection
{

    public enum NavigationDirection
    {
        Vertical,
        Horizontal
    }

    public static (ConsoleKey input, int index) GetUserInput(int currentIndex, int length, NavigationDirection direction)
    {
        ConsoleKey input = Console.ReadKey(true).Key;
        switch (input)
        {
            case ConsoleKey.UpArrow when direction == NavigationDirection.Vertical: 
                currentIndex--; break;
            case ConsoleKey.DownArrow when direction == NavigationDirection.Vertical: 
                currentIndex++; break;
            case ConsoleKey.LeftArrow when direction == NavigationDirection.Horizontal: 
                currentIndex--; break;
            case ConsoleKey.RightArrow when direction == NavigationDirection.Horizontal: 
                currentIndex++; break;
            case ConsoleKey.Enter: break;
            case ConsoleKey.Escape: break;
            
            default: Console.WriteLine($"{Environment.NewLine}Invalid choice"); Thread.Sleep(500); Console.Clear(); break;
        }

        if (currentIndex < 0)
        {
            currentIndex = length - 1;
        }
        else if (currentIndex >= length)
        {
            currentIndex = 0;
        }

        return (input, currentIndex);
    }


}
