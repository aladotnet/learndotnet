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


    public void UpdaTodo(TodoItem todo)
    {
        var existing = _todos.FirstOrDefault(x => x.Id == todo.Id);
        if (existing != null)
        {
            _todos.Remove(existing);
        }
        _todos.Add(todo);
    }

    public IReadOnlyList<TodoItem> GetAll() => _todos.AsReadOnly();

    private int CaculateId()
    {
        if (!_todos.Any())
            return 1;

        return _todos.Select(x => x.Id).Max() + 1;
    }
    public TodoItem GetTodoById(int id)
    {

        var existing = _todos.FirstOrDefault(x => x.Id == id);
        return existing;
    }
}
