using Microsoft.Extensions.DependencyInjection;
using TodoManagementCore;

var services = new ServiceCollection();


services.AddScoped<ILogger, MyLogger>();
services.AddScoped<ITodoManager, LoggingTodoManager>(sp => new LoggingTodoManager(new TodoManager(), sp.GetRequiredService<ILogger>()));

var serviceProvider = services.BuildServiceProvider();
var todoManager = serviceProvider.GetRequiredService<ITodoManager>();


Console.WriteLine("Création et affichage des tâches par défaut:");
TodoDemo.CreateAndDisplayTodos(todoManager);

Console.WriteLine("\nDémarrage d'une tâche par ID (ID = 2) :");
TodoDemo.StartTodo(2, todoManager);

Console.WriteLine(new string('-', 50));

Console.WriteLine("Veuillez choisir une action :");
Console.WriteLine("1. Afficher les détails d'une tâche par Id");
Console.WriteLine("2. Annuler une tâche par Id");

Console.Write("Votre choix: ");
var choice = Console.ReadLine();

Console.Write("Entrez l'ID de la tâche : ");
var input = Console.ReadLine();

if (int.TryParse(input, out int id))
{
    switch (choice)
    {
        case "1":
            Console.WriteLine($"\nAffichage des détails de la tâche avec l'ID: {id}");
            TodoDemo.DisplayTodoById(id, todoManager);
            break;
        case "2":
            Console.WriteLine($"\nAnnulation de la tâche avec l'ID: {id}");
            TodoDemo.CancelTodo(id, todoManager);
            break;
       
        default:
            Console.WriteLine("Option non valide.");
            break;
    }
}
else
{
    Console.WriteLine("L'ID de la tâche est invalide.");
}


Console.WriteLine("\nAppuyez sur Entrée pour quitter...");
Console.ReadLine();
