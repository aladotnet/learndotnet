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

    public static void DisplayTodos(ITodoManager service)
    {
        var todos = service.GetAll();

        Console.WriteLine("Todos found :");
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

    }

    public static void DisplayOneTodoById(int id, ITodoManager service)
    {
        var todo = service.GetTodoById(id);

        if (todo is null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        Console.WriteLine(todo.ToString());

    }

    public static void UpdateTodo(int id, ITodoManager service)
    {
        service.UpdaTodo(service.GetTodoById(id));
    }

    public static void UpdateDetails(int id, String title, String desc, ITodoManager service)
    {
        var todo = service.GetTodoById(id);
        if (todo is null)
            return;
        todo.ChangeDetails(title, desc);
        Console.WriteLine("todo changed");
    }


}
