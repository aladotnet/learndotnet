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

    public TodoItem GetTodoById(int id)
    {
        return _todos.FirstOrDefault(todo => todo.Id == id);
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
            _todos.Add(todo);
        }
    }

    public void CloseTodo(int id)
    {
        var todo = GetTodoById(id);
        if (todo != null)
        {
            if (todo.Status == TodoStatus.Started)
            {
                todo.Close();
                Console.WriteLine($"Tâche avec l'ID {id} fermée avec succès.");
            }
            else
            {
                Console.WriteLine($"La tâche avec l'ID {id} ne peut pas être fermée. Elle doit d'abord être démarrée.");
            }
        }
        else
        {
            Console.WriteLine($"Tâche avec l'ID {id} non trouvée.");
        }
    }

    public IReadOnlyList<TodoItem> GetAll() => _todos.AsReadOnly();

    private int CaculateId()
    {
        if (!_todos.Any())
            return 1;

        return _todos.Select(x => x.Id).Max() + 1;
    }
}
