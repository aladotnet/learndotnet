namespace TodoManagementCore;

public class LoggingTodoManager : ITodoManager
{
    private readonly ITodoManager todoManager;
    private readonly ILogger logger;

    public LoggingTodoManager(ITodoManager todoManager,ILogger logger)
    {
        this.todoManager = todoManager;
        this.logger = logger;
    }
    public TodoItem AddTodo(string title)
    {
        logger.WriteLog("Adding todo ...");
        var todo = todoManager.AddTodo(title);
        logger.WriteLog("Todo added");
        return todo;
    }

    public IReadOnlyList<TodoItem> GetAll()
    {
        logger.WriteLog("Getting todos ...");

        var all = todoManager.GetAll();
        logger.WriteLog("Todos found");
        return all;
    }

    public void UpdaTodo(TodoItem todo)
    {
        todoManager.UpdaTodo(todo);
    }
}
