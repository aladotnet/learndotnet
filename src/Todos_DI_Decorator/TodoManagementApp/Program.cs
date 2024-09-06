using Microsoft.Extensions.DependencyInjection;
using TodoManagementCore;

var services = new ServiceCollection();

services.AddScoped<ILogger, MyLogger>();
services.AddScoped<ITodoManager, LoggingTodoManager>(sp => new LoggingTodoManager(new TodoManager(), sp.GetRequiredService<ILogger>()));

var serviceProvider = services.BuildServiceProvider();
var todoManager = serviceProvider.GetRequiredService<ITodoManager>();

bool exit = false;

Console.WriteLine("Création et affichage des tâches par défaut:");
TodoDemo.CreateAndDisplayTodos(todoManager);

while (!exit)
{
    Console.WriteLine(new string('-', 50));

    Console.WriteLine("Veuillez choisir une action :");
    Console.WriteLine("1. Afficher les détails d'une tâche par Id");
    Console.WriteLine("2. Annuler une tâche par Id");
    Console.WriteLine("3. Démarrer une tâche par Id");
    Console.WriteLine("4. Fermer une tâche par Id");
    Console.WriteLine("5. Ajouter une nouvelle tâche");
    Console.WriteLine("0. Quitter");

    Console.Write("Votre choix: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Entrez l'ID de la tâche à afficher : ");
            var inputDisplay = Console.ReadLine();
            if (int.TryParse(inputDisplay, out int idDisplay))
            {
                Console.WriteLine($"\nAffichage des détails de la tâche avec l'ID: {idDisplay}");
                TodoDemo.DisplayTodoById(idDisplay, todoManager);
            }
            else
            {
                Console.WriteLine("ID de tâche invalide.");
            }
            break;

        case "2":
            Console.Write("Entrez l'ID de la tâche à annuler : ");
            var inputCancel = Console.ReadLine();
            if (int.TryParse(inputCancel, out int idCancel))
            {
                Console.WriteLine($"\nAnnulation de la tâche avec l'ID: {idCancel}");
                TodoDemo.CancelTodo(idCancel, todoManager);
            }
            else
            {
                Console.WriteLine("ID de tâche invalide.");
            }
            break;

        case "3":
            Console.Write("Entrez l'ID de la tâche à démarrer : ");
            var inputStart = Console.ReadLine();
            if (int.TryParse(inputStart, out int idStart))
            {
                Console.WriteLine($"\nDémarrage de la tâche avec l'ID: {idStart}");
                TodoDemo.StartTodo(idStart, todoManager);
            }
            else
            {
                Console.WriteLine("ID de tâche invalide.");
            }
            break;

        case "4":
            Console.Write("Entrez l'ID de la tâche à fermer : ");
            var inputClose = Console.ReadLine();
            if (int.TryParse(inputClose, out int idClose))
            {
                Console.WriteLine($"\nFermeture de la tâche avec l'ID: {idClose}");
                TodoDemo.CloseTodo(idClose, todoManager);
            }
            else
            {
                Console.WriteLine("ID de tâche invalide.");
            }
            break;

        case "5":
            Console.Write("Entrez le titre de la nouvelle tâche : ");
            var title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title))
            {
                Console.WriteLine($"\nAjout de la nouvelle tâche avec le titre: {title}");
                TodoDemo.AddTodo(title, todoManager);
            }
            else
            {
                Console.WriteLine("Le titre de la tâche ne peut pas être vide.");
            }
            break;

        case "0":
            exit = true;
            Console.WriteLine("Fermeture du programme...");
            break;

        default:
            Console.WriteLine("Option non valide.");
            break;
    }
}

Console.WriteLine("\nAppuyez sur Entrée pour quitter...");
Console.ReadLine();
