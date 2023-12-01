using System;
using System.Collections.Generic;

namespace ToDo
{
    public enum Menu
    {
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
                ShowTodoList();

                string taskNumberToDelete = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

                if (indexToRemove > ToDoList.Count - 1 || indexToRemove < 0)
                    Console.WriteLine("Numero de tarea seleccionado no es valido");
                else
                {
                    if (indexToRemove > -1 && ToDoList.Count > 0)
                    {
                        string task = ToDoList[indexToRemove];
                        ToDoList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
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

                ShowTodoList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al añadir la tarea");
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
                ShowTodoList();
            }
        }

        private static void ShowTodoList()
        {
            Console.WriteLine("----------------------------------------");
            // for (int i = 0; i < ToDoList.Count; i++)
            // {
            //     Console.WriteLine((i + 1) + ". " + ToDoList[i]);
            // }
            int indexTask = 1;
            ToDoList.ForEach((p) => Console.WriteLine((indexTask++) + ". " + p));
            Console.WriteLine("----------------------------------------");
        }
    }
}
