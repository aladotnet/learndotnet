using System.Drawing;

namespace TodoManagementCore;

public class TodoManager : ITodoManager
{
    private readonly List<TodoItem> _todos;

    private int _currentId = 0;

    public TodoManager()
    {
        _todos = new();
    }


    public TodoItem AddTodo(string title)
    {
        _currentId = CaculateId();
        var todo = TodoItem.New(_currentId, title);

        _todos.Add(todo);

        return todo;
    }


    public void UpdaTodo(int id, string NewTitle,string NewDescription)
    {
        var serched = Search(id);
        if (serched == null) { 
            Console.WriteLine("task not found");
        return; }
        serched.ChangeDetails(NewTitle, NewDescription);
    }

    public IReadOnlyList<TodoItem> GetAll() => _todos.AsReadOnly();


    public void GetTodoById(int id)
    {
        var todo = Search(id);
        if (todo is null) { 
        Console.WriteLine("task not found");
        return; }

        Console.WriteLine(todo);

    }

    public void CancelTodo(int id)
    {
        var serched = Search(id);
        if (serched == null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }

        serched.Cancel();

    }
    public void CloseTodo(int id) {
        var serched = Search(id);
        if (serched == null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }
        serched.Close(); 
    }

    public void StratTode(int id)
    {
        var serched = Search(id);
        if (serched == null)
        {
            Console.WriteLine($"Id: [{id}] not found");
            return;
        }
        serched.Start();
    }
    private TodoItem Search(int id)
    {
        var found = _todos.FirstOrDefault(x => x.Id == id);

        if (found is null)
            return null;
        return found;

    }
    private int CaculateId()
    {
        if (!_todos.Any())
            return 1;

        return _todos.Select(x => x.Id).Max() + 1;
    }

    }
