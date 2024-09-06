using TodoManagementCore;

public static class TodoDemo
{
    public static void CreateAndDisplayTodos(ITodoManager service)
    {
        service.AddTodo("Title1");
        service.AddTodo("Title2");
        service.AddTodo("Title3");

        var todos = service.GetAll();

        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }
    }

    public static void AddTodo(string title, ITodoManager service)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Le titre de la tâche ne peut pas être vide.");
            return;
        }

        var todo = service.AddTodo(title);
        Console.WriteLine($"Todo ajouté avec succès : {todo}");
    }

    public static void CancelTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();
        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] non trouvé");
            return;
        }

        try
        {
            found.Cancel();
            Console.WriteLine($"Todo avec Id: [{id}] a été annulé.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Impossible d'annuler le Todo avec Id: [{id}]. Raison: {ex.Message}");
        }

        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }
    }

    public static void StartTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();
        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] non trouvé");
            return;
        }

        try
        {
            found.Start();
            Console.WriteLine($"Todo avec Id: [{id}] a été démarré.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Impossible de démarrer le Todo avec Id: [{id}]. Raison: {ex.Message}");
        }

        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }
    }

    public static void DisplayTodoById(int id, ITodoManager service)
    {
        var todo = service.GetTodoById(id);
        if (todo == null)
        {
            Console.WriteLine($"Todo avec Id {id} non trouvé.");
        }
        else
        {
            Console.WriteLine($"Détails du Todo avec Id {id}:");
            Console.WriteLine(todo);
        }
    }

    public static void CloseTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();
        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] non trouvé");
            return;
        }

        try
        {
            found.Close();
            Console.WriteLine($"Todo avec Id: [{id}] a été fermé.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Impossible de fermer le Todo avec Id: [{id}]. Raison: {ex.Message}");
        }

        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }
    }
}
