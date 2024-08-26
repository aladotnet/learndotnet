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

    public void CancelTodo(int id)
    {
        todoManager.CancelTodo(id);

        logger.WriteLog("Todos Cancled");
    }


    public void CloseTodo(int id)
    {
        todoManager.CloseTodo(id);

        logger.WriteLog("Todos Closed");
    }

    public void StratTode(int id)
    {
        todoManager.StratTode(id);

        logger.WriteLog("Todos Started");
    }

    public IReadOnlyList<TodoItem> GetAll()
    {
        logger.WriteLog("Getting todos ...");

        var all = todoManager.GetAll();
        logger.WriteLog("Todos found");
        return all;
    }

    public void GetTodoById(int id)
    {
        todoManager.GetTodoById(id);

        logger.WriteLog("Todos found");
        
    }

    public void UpdaTodo(int id, string title, string description)
    {
        todoManager.UpdaTodo(id,title,description);
        logger.WriteLog("Todos updated");

    }
}
