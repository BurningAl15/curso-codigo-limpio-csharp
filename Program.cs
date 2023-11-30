using System;
using System.Collections.Generic;

namespace ToDo
{
    public enum Menu{
        Initialize,
        Add,
        Remove,
        List,
        Quit
    }

    internal class Program
    {
        public static List<string> ToDoList { get; set; }

        static void Main(string[] args)
        {
            ToDoList = new List<string>();
            // int menuSelected = 0;
            Menu menuSelected = Menu.Initialize;
            do
            {
                menuSelected = ShowMainMenu();
                if (menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if (menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if (menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while (menuSelected != Menu.Quit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static Menu ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return (Menu)Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ToDoList[i]);
                }
                Console.WriteLine("----------------------------------------");

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (ToDoList.Count > 0)
                    {
                        string task = ToDoList[indexToRemove];
                        ToDoList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                ToDoList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (ToDoList == null || ToDoList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < ToDoList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + ToDoList[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
