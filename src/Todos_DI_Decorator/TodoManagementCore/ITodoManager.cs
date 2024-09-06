
namespace TodoManagementCore
{
    public interface ITodoManager
    {
        TodoItem AddTodo(string title);
        IReadOnlyList<TodoItem> GetAll();
        void UpdaTodo(TodoItem todo);
        TodoItem GetTodoById(int id);
    }
}
