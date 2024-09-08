// See https://aka.ms/new-console-template for more information


using TodoManagementCore;

public static class TodoDemo
{
    public static void CreateAndDisplayTodos(TodoManager1 service)
    {
        service.AddTodo("Title1");
        service.AddTodo("Title2");

        if (service.TryGetTodo(3, out TodoItem todo))
        {
            Console.WriteLine(todo);
        }
        else
        {
            Console.WriteLine("No Todo found with the given Id : {0}", 3);
        }


        //var todo = result.Value;


        //Console.WriteLine(todo);
    }

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

    public static void StartTodo(int id, ITodoManager service)
    {
        var todos = service.GetAll();

        var found = todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        found.Start();
        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }

    }
}
