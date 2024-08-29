// See https://aka.ms/new-console-template for more information


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
     public static void CancelTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();

        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        try
        {
            found.Cancel();
            Console.WriteLine($"Todo with Id: [{id}] has been cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not cancel the Todo with Id: [{id}]. Reason: {ex.Message}");
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
     public static void DisplayTodoById(int id, ITodoManager service)
    {
        var todo = service.GetTodoById(id);
        if (todo == null)
        {
            Console.WriteLine($"Todo with Id {id} not found.");
        }
        else
        {
            Console.WriteLine($"Details of Todo with Id {id}:");
            Console.WriteLine(todo);
        }
    }
}