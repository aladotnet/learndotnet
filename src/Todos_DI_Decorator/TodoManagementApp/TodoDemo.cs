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
                        service.StratTode(taskId);
                    break;
//over testing
                case 4:
                    Console.WriteLine("which task would you like updated");
                    int updatedtask = 0;
                    int.TryParse(Console.ReadLine(), out taskId);
                    Console.WriteLine("write the new title");
                    string title = Console.ReadLine();
                    Console.WriteLine("write the new description");
                    string description = Console.ReadLine();

                    service.UpdaTodo(updatedtask,title,description);
                    break;

                case 5:
                    Console.WriteLine("which task would you like Closed");
                    int closedtask = 0;
                    int.TryParse(Console.ReadLine(), out closedtask);
                    service.CloseTodo(closedtask);

                    break;
                case 6:
                    Console.WriteLine("which task would you like Caceled");
                    int canceledtask = 0;
                    int.TryParse(Console.ReadLine(), out canceledtask);
                    service.CancelTodo(canceledtask);
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

  
}
