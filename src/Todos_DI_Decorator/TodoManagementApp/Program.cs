// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using TodoManagementCore;

var services = new ServiceCollection();
services.AddScoped<ILogger, MyLogger>();
services.AddScoped<ITodoManager, LoggingTodoManager>(sp => new LoggingTodoManager(new TodoManager(), sp.GetRequiredService<ILogger>()));

var serviceProvider = services.BuildServiceProvider();
var todoManager = serviceProvider.GetRequiredService<ITodoManager>();

bool continueRunning = true;

while (continueRunning)
{
    Console.WriteLine("Todo Management Menu:");
    Console.WriteLine("1. Create and display todos");
    Console.WriteLine("2. Start a todo");
    Console.WriteLine("3. Close a todo");
    Console.WriteLine("4. Cancel a todo");
    Console.WriteLine("5. Display one todo by ID");
    Console.WriteLine("6. Update a todo");
    Console.WriteLine("7. Update details of a todo");
    Console.WriteLine("8. Display all todos");
    Console.WriteLine("9. Exit");
    Console.Write("Choose an option (1-9): ");

    
    try
    {
        string input = Console.ReadLine();
        int choice = Convert.ToInt32(input);
        switch (choice)
        {
            case 1:
                TodoDemo.CreateAndDisplayTodos(todoManager);
                break;
            case 2:
                Console.Write("Enter Todo ID to start: ");
                if (int.TryParse(Console.ReadLine(), out int startId))
                {
                    TodoDemo.StartTodo(startId, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 3:
                Console.Write("Enter Todo ID to close: ");
                if (int.TryParse(Console.ReadLine(), out int closeId))
                {
                    TodoDemo.CloseTodo(closeId, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 4:
                Console.Write("Enter Todo ID to cancel: ");
                if (int.TryParse(Console.ReadLine(), out int cancelId))
                {
                    TodoDemo.CancelTodo(cancelId, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 5:
                Console.Write("Enter Todo ID to display: ");
                if (int.TryParse(Console.ReadLine(), out int displayId))
                {
                    TodoDemo.DisplayOneTodoById(displayId, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 6:
                Console.Write("Enter Todo ID to update: ");
                if (int.TryParse(Console.ReadLine(), out int updateId))
                {
                    TodoDemo.UpdateTodo(updateId, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 7:
                Console.Write("Enter Todo ID to update details: ");
                if (int.TryParse(Console.ReadLine(), out int updateDetailsId))
                {
                    Console.Write("Enter new title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter new description: ");
                    string description = Console.ReadLine();
                    TodoDemo.UpdateDetails(updateDetailsId, title, description, todoManager);
                }
                else
                {
                    Console.WriteLine("Invalid ID.");
                }
                break;
            case 8:
                TodoDemo.DisplayTodos(todoManager);
                break;
            case 9:
                continueRunning = false;
                Console.WriteLine("Exiting the application...");
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 9.");
                break;
        }
        Console.WriteLine();
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}
