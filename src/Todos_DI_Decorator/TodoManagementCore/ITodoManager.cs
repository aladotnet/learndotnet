
namespace TodoManagementCore
{
    public interface ITodoManager
    {
        TodoItem AddTodo(string title);
        IReadOnlyList<TodoItem> GetAll();
        void UpdaTodo(int id ,string title,string description);
        void GetTodoById(int id);
        void CancelTodo(int id);
        void CloseTodo(int id);
        void StratTode(int id);

    }
}
