//namespace TaskApp_v2._0;
//public class TaskMenu_old
//{
//    private static List<UserTask>? s_tasks;

//    public TaskMenu_old(List<UserTask> tasks)
//    {
//        s_tasks = tasks;
//    }

//    private static int s_selectedTaskIndex;

//    public int SelectedTaskIndex
//    {
//        get { return s_selectedTaskIndex; }
//        set
//        {
//            if (value < 0)
//            {
//                value = s_tasks!.Count() - 1;
//            }
//            else if (value >= s_tasks!.Count())
//            {
//                value = 0;
//            }
//            s_selectedTaskIndex = value;
//        }
//    }

//    private static string[] updateChoices = { "Update Title", "Update Description", "Update Due Date", "Mark as completed", "Exit" };

//    private static int s_selectedUpdateItem;

//    public static int SelectedUpdateItem
//    {
//        get { return s_selectedUpdateItem; }
//        set 
//        {
//            if (value < 0)
//            {
//                value = updateChoices.Length - 1;
//            }
//            else if (value >= updateChoices.Length)
//            {
//                value = 0;
//            }

//            s_selectedUpdateItem = value; 
//        }
//    }


//    private static int _selectedUpdateFunction;

//    public static int SelectedUpdateFunction
//    {
//        get { return _selectedUpdateFunction; }
//        set
//        {
//            if (value < 0)
//            {
//                value = updateChoices.Length - 1;
//            }
//            else if (value >= updateChoices.Length)
//            {
//                value = 0;
//            }

//            _selectedUpdateFunction = value;
//        }
//    }



//    private static string[] choices = { "Update task", "Delete task", "Mark as completed", "Exit" };

//    //private static int SelectedTaskFunction = 0;

//    private static int s_selectedTaskFunction;

//    public static int SelectedTaskFunction
//    {
//        get { return s_selectedTaskFunction; }
//        set
//        {
//            if (value < 0)
//            {
//                value = choices.Length - 1;
//            }
//            else if (value >= choices.Length)
//            {
//                value = 0;
//            }

//            s_selectedTaskFunction = value;
//        }
//    }

//    public void DisplayAllTasks()
//    {
//        ConsoleKey taskSelect;
//        do
//        {
//            Console.Clear();
//            Console.WriteLine("DUE DATE(MM/dd)".PadRight(20) + "TASKS");
//            Console.WriteLine();
//            for (int i = 0; i < s_tasks!.Count; i++)
//            {
//                UserTask? task = s_tasks![i];
//                if (i == SelectedTaskIndex)
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write($"{task.DueDate:MM/dd}".PadRight(20));
//                    Console.WriteLine($"{task.Title!.ToUpper()}");
//                    Console.ResetColor();
//                }
//                else
//                {
//                    Console.Write($"{task.DueDate:MM/dd}".PadRight(20));
//                    Console.WriteLine($"{task.Title!.ToUpper()}");
//                    Console.ResetColor();
//                }

//            }

//            //taskSelect = GetUserTaskIndex();

//            //if (taskSelect == ConsoleKey.Enter)
//            {
//                DisplaySpecificTask();

//            }
//        } while (taskSelect != ConsoleKey.Enter);


//    }

//    private void DisplaySpecificTask()
//    {
//        ConsoleKey taskFunctionSelect;
//        do
//        {

//            Console.Clear();
//            Console.Write($"{s_tasks![SelectedTaskIndex].DueDate:MM/dd}".PadRight(20));
//            Console.WriteLine($"{s_tasks[SelectedTaskIndex].Title.ToUpper()}");
//            Console.WriteLine();
//            Console.WriteLine();
//            Console.WriteLine($"{s_tasks[SelectedTaskIndex].Description}");
//            Console.WriteLine();
//            Console.WriteLine();

//            for (int i = 0; i < choices.Length; i++)
//            {
//                if (i == SelectedTaskFunction)
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write($"{choices[i]}\t");
//                    Console.ResetColor();
//                }
//                else
//                {
//                    Console.Write($"{choices[i]}\t");
//                    Console.ResetColor();
//                }
//            }
//            taskFunctionSelect = GetUserTaskFunction();

//            if (taskFunctionSelect == ConsoleKey.Enter)
//            {

//            }

//        } while (!(taskFunctionSelect == ConsoleKey.Escape || taskFunctionSelect == ConsoleKey.Enter));
//    }

//    private void DisplaySpecificUpdateChoices()
//    {
//        ConsoleKey updateSelection;

//        do
//        {

//            Console.Clear();
//            Console.Write($"{s_tasks![SelectedTaskIndex].DueDate:MM/dd}".PadRight(20));
//            Console.WriteLine($"{s_tasks[SelectedTaskIndex].Title.ToUpper()}");
//            Console.WriteLine();
//            Console.WriteLine();
//            Console.WriteLine($"{s_tasks[SelectedTaskIndex].Description}");
//            Console.WriteLine();
//            Console.WriteLine();

//            for (int i = 0; i < updateChoices.Length; i++)
//            {
//                if (i == SelectedUpdateFunction)
//                {
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    Console.Write($"{updateChoices[i]}\t");
//                    Console.ResetColor();
//                }
//                else
//                {
//                    Console.Write($"{updateChoices[i]}\t");
//                    Console.ResetColor();
//                }
//            }
//            updateSelection = GetSpecificUserUpdateSelection();

//            if (updateSelection == ConsoleKey.Enter)
//            {

//            }

//        } while (!(updateSelection == ConsoleKey.Escape || updateSelection == ConsoleKey.Enter));

//    }

//    //private static ConsoleKey GetSpecificUserUpdateSelection()
//    //{
//    //    var input = Console.ReadKey(true).Key;

//    //    switch (input)
//    //    {
//    //        case ConsoleKey.LeftArrow: SelectedUpdateItem--; break;
//    //        case ConsoleKey.RightArrow: SelectedUpdateItem++; break;
//    //        case ConsoleKey.Enter: break;
//    //        case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Exiting task menu.."); Thread.Sleep(1250); break;
//    //    }

//    //    return input;
//    //}

//    //public static ConsoleKey GetUserUpdateSelection()
//    //{
//    //    var input = Console.ReadKey(true).Key;

//    //    switch (input)
//    //    {
//    //        case ConsoleKey.LeftArrow: SelectedUpdateFunction--; break;
//    //        case ConsoleKey.RightArrow: SelectedUpdateFunction++; break;
//    //        case ConsoleKey.Enter: break;
//    //        case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Exiting task menu.."); Thread.Sleep(1250); break;
//    //    }

//    //    return input;
//    //}

//    //public ConsoleKey GetUserTaskIndex()
//    //{
//    //    var input = Console.ReadKey(true).Key;

//    //    switch (input)
//    //    {
//    //        case ConsoleKey.UpArrow: SelectedTaskIndex--; break;
//    //        case ConsoleKey.DownArrow: SelectedTaskIndex++; break;
//    //        case ConsoleKey.Enter: break;
//    //        case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Exiting task menu.."); Thread.Sleep(1250); break;
//    //    }

//    //    return input;
//    //}
//    //public static ConsoleKey GetUserTaskFunction()
//    //{
//    //    var input = Console.ReadKey(true).Key;

//    //    switch (input)
//    //    {
//    //        case ConsoleKey.LeftArrow: SelectedTaskFunction--; break;
//    //        case ConsoleKey.RightArrow: SelectedTaskFunction++; break;
//    //        case ConsoleKey.Enter: break;
//    //        case ConsoleKey.Escape: Console.Clear(); Console.WriteLine("Exiting task menu.."); Thread.Sleep(1250); break;
//    //    }

//    //    return input;
//    //}
//}
