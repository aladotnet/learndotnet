using System;
using TodoManagerApp.Interfaces;
using TodoManagerApp.Models;

namespace TodoManagerApp.App
{
    public class TodoApp
    {
        private readonly ITodoService _todoService;

        public TodoApp(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public void Run()
        {
            while (true)
            {
                DisplayMenu();
                var choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        ChangeTodoDetails();
                        break;
                    case "3":
                        StartTodo();
                        break;
                    case "4":
                        CloseTodo();
                        break;
                    case "5":
                        CancelTodo();
                        break;
                    case "6":
                        AssignToExecuter();
                        break;
                    case "7":
                        DisplayTodoList();
                        break;
                    case "8":
                        DisplayTodoDetailsById();
                        break;
                    case "9":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                ReturnToMenu();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("===== TODO MANAGER =====");
            Console.WriteLine("1. Add Todo");
            Console.WriteLine("2. Change Todo Details");
            Console.WriteLine("3. Start Todo");
            Console.WriteLine("4. Close Todo");
            Console.WriteLine("5. Cancel Todo");
            Console.WriteLine("6. Assign Todo to Executer");
            Console.WriteLine("7. Display Todo List");
            Console.WriteLine("8. Display Todo Details by Id");
            Console.WriteLine("9. Exit");
            Console.WriteLine("========================");
            Console.Write("Choose an option: ");
        }

        private void ReturnToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }

        private void AddTodo()
        {
            Console.WriteLine("===== ADD TODO =====");
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter description: ");
            var description = Console.ReadLine();

            var todo = new Todo { Title = title, Description = description };
            _todoService.AddTodo(todo);
            Console.WriteLine("Todo added successfully.");
        }

        private void ChangeTodoDetails()
        {
            Console.WriteLine("===== CHANGE TODO DETAILS =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Enter new title: ");
            var title = Console.ReadLine();
            Console.Write("Enter new description: ");
            var description = Console.ReadLine();

            _todoService.ChangeTodoDetails(id, title, description);
            Console.WriteLine("Todo details updated successfully.");
        }

        private void StartTodo()
        {
            Console.WriteLine("===== START TODO =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            _todoService.Start(id);
            Console.WriteLine("Todo started.");
        }

        private void CloseTodo()
        {
            Console.WriteLine("===== CLOSE TODO =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            _todoService.Close(id);
            Console.WriteLine("Todo closed.");
        }

        private void CancelTodo()
        {
            Console.WriteLine("===== CANCEL TODO =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            _todoService.Cancel(id);
            Console.WriteLine("Todo cancelled.");
        }

        private void AssignToExecuter()
        {
            Console.WriteLine("===== ASSIGN TODO TO EXECUTER =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            Console.Write("Enter executer name: ");
            var executer = Console.ReadLine();
            _todoService.AssignToExecuter(id, executer);
            Console.WriteLine("Todo assigned to executer.");
        }

        private void DisplayTodoList()
        {
            Console.WriteLine("===== TODO LIST =====");
            var todos = _todoService.GetTodoList();
            foreach (var todo in todos)
            {
                Console.WriteLine($"{todo.Id}: {todo.Title} [{todo.Status}]");
            }
        }

        private void DisplayTodoDetailsById()
        {
            Console.WriteLine("===== TODO DETAILS =====");
            Console.Write("Enter Todo Id: ");
            var id = int.Parse(Console.ReadLine());
            var todo = _todoService.GetTodoById(id);
            if (todo != null)
            {
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Title: {todo.Title}");
                Console.WriteLine($"Description: {todo.Description}");
                Console.WriteLine($"Status: {todo.Status}");
                Console.WriteLine($"Assigned To: {todo.AssignedTo}");
                Console.WriteLine($"Created At: {todo.CreatedAt}");
                Console.WriteLine($"Started At: {todo.StartedAt}");
                Console.WriteLine($"Closed At: {todo.ClosedAt}");
            }
            else
            {
                Console.WriteLine("Todo not found.");
            }
        }
    }
}
