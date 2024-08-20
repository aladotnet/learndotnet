namespace TodoManagementCore;

public class MyLogger : ILogger
{
    public void WriteLog(string message)
    {
        Console.WriteLine(message);
    }
}
