using System.Drawing;

namespace TodoManagementCore;


public class Result<TValue>
{
    public Result(bool isSuccess, TValue value)
    {
        IsSuccess = isSuccess;
        Value = value;
    }

    public bool IsSuccess { get; }
    public TValue Value { get; }

}




public class Result
{
    public static Result<TValue> Failure<TValue>(TValue value)
    {
        return new Result<TValue>(false, value);
    }

    public static Result<TValue> Success<TValue>(TValue value)
    {
        return new Result<TValue>(true, value);
    }


}

public class TodoManager1 //: ITodoManager
{
    private readonly List<TodoItem> _todos;
    private int _currentId = 0;
    private readonly Dictionary<int, TodoItem> _todoMap;
    public TodoManager1()
    {
        _todoMap = new();
        _todos = new();
    }


    public bool TryGetTodo(int id, out TodoItem todo)
    {
        var keyFound = _todoMap.Keys.Any(k => k == id);

        if (!keyFound)
        {
            todo = null;
            return false;
        }

        todo = _todoMap[id];

        return true;
    }

    public TodoItem GetById(int id)
    {
        //var todo = _todoMap[_currentId];

       if(!_todoMap.TryGetValue(id, out TodoItem todo))
       {
          return null;
       }

        return todo;
    }

    public Result<TodoItem> AddTodo(string title)
    {
        _currentId = CaculateId();
        var todo = TodoItem.New(_currentId, title);

//        _todoMap[_currentId] = todo;

        _todoMap.Add(_currentId, todo);

        _todos.Add(todo);
        //return TodoResult.Success<TodoItem>(todo);

        return new Result<TodoItem>(true, todo);
    }


    public void UpdaTodo(TodoItem todo)
    {
        var existing = _todos.FirstOrDefault(x => x.Id == todo.Id);
        _todos.Remove(existing);
        _todos.Add(todo);


    }

    public IReadOnlyList<TodoItem> GetAll() => _todos.AsReadOnly();

    public TodoItem[] GetAll1() => _todos.ToArray();

    private int CaculateId()
    {
        if (!_todos.Any())
            return 1;

        return _todos.Select(x => x.Id).Max() + 1;
    }
}


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


    public void UpdaTodo(TodoItem todo)
    {
        var existing = _todos.FirstOrDefault(x => x.Id == todo.Id);
        _todos.Remove(existing);
        _todos.Add(todo);
    }

    public IReadOnlyList<TodoItem> GetAll() => _todos.AsReadOnly();

    private int CaculateId()
    {
        if (!_todos.Any())
            return 1;

        return _todos.Select(x => x.Id).Max() + 1;
    }
}
