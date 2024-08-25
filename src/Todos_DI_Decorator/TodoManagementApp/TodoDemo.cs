// See https://aka.ms/new-console-template for more information


using System.Runtime.CompilerServices;
using TodoManagementCore;

public static class TodoDemo
{
    public static void StartApplication(ITodoManager service)
    {
        int x = 0;
        while (true)
        {
            Console.WriteLine("1. Add Todo");
            Console.WriteLine("2. Display all Todo");
            Console.WriteLine("3. Start Todo");
            Console.WriteLine("4. Change Details");
            Console.WriteLine("5. Close Todo");
            Console.WriteLine("6. Cancel Todo");
            Console.WriteLine("7. Display Todo by ID");
            Console.WriteLine("0. Exit");
            Console.Write("Choisissez une option : ");
            String input = Console.ReadLine();
            int.TryParse(input,out x);
           
                switch (x)
                {
                    case 1:
                    Console.WriteLine("give a title for your Todo");
                    String Title= Console.ReadLine();
                    if (Title is null)
                        Console.WriteLine("Create a valide Title");
                    service.AddTodo(Title);
                    break;

                case 2:
                    foreach (var todo in service.GetAll())
                    {
                        Console.WriteLine(todo);
                    }
                    break;

                case 3:
                    Console.WriteLine("which task would you like started");
                        int taskId = 0;
                        int.TryParse(Console.ReadLine(),out taskId);
                        StartTodo(taskId, service);
                    break;
//over testing
                case 4:
                    Console.WriteLine("which task would you like updated");
                    int updatedtask = 0;
                    int.TryParse(Console.ReadLine(), out updatedtask);
                    TodoItem todoupdate = service.GetAll()[updatedtask];
                    service.UpdaTodo(todoupdate);
                    break;

                case 5:
                    Console.WriteLine("which task would you like Closed");
                    int closedtask = 0;
                    int.TryParse(Console.ReadLine(), out closedtask);
                    CloseTodo(closedtask, service);

                    break;
                case 6:
                    Console.WriteLine("which task would you like Caceled");
                    int canceledtask = 0;
                    int.TryParse(Console.ReadLine(), out canceledtask);
                    CancelTodo(canceledtask, service);
                    break;

                case 7:
                    Console.WriteLine("which task would you like show");
                    int selectedtask = 0;
                    int.TryParse(Console.ReadLine(), out selectedtask);
                    service.GetTodoById(selectedtask);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("You should eneter a number in liste");
                    break;

            }

        }
    }









   

    public static void StartTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();

        var found = todos.FirstOrDefault(x => x.Id == id);

        if(found is null)
        {
            Console.WriteLine($"Id: [{id}] not found" );
            return;
        }

        found.Start();
        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }

    }
    public static void CloseTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();

        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        found.Close();
        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }

    }

    public static void CancelTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();

        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        found.Cancel();
        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }

    }
}
