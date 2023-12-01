using System.Collections.Generic;

List<string> ToDoList = new List<string>();

Menu menuSelected = Menu.Initialize;
do
{
    menuSelected = ShowMainMenu();
    if (menuSelected == Menu.Add)
        ShowMenuAdd();
    else if (menuSelected == Menu.Remove)
        ShowMenuRemove();
    else if (menuSelected == Menu.List)
        ShowMenuTaskList();
} while (menuSelected != Menu.Quit);

/// <summary>
/// Show the main menu 
/// </summary>
/// <returns>Returns option indicated by user</returns>
Menu ShowMainMenu()
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

void ShowMenuRemove()
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
                Console.WriteLine($"Tarea {task} eliminada");
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();
        ToDoList.Add(task);
        Console.WriteLine("Tarea registrada");

        ShowTodoList();
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al añadir la tarea");
    }
}

void ShowMenuTaskList()
{
    if (ToDoList?.Count > 0)
        ShowTodoList();
    else
        Console.WriteLine("No hay tareas por realizar");
}

void ShowTodoList()
{
    Console.WriteLine("----------------------------------------");
    int indexTask = 1;
    ToDoList.ForEach((task) => Console.WriteLine($"{indexTask++}. {task}"));
    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Initialize,
    Add,
    Remove,
    List,
    Quit
}

