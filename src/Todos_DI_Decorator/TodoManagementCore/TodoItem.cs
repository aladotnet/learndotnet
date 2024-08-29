namespace TodoManagementCore;

public enum TodoStatus
{
    None = 0,
    Created,
    Started,
    Closed,
    Cancelled
}

public class TodoItem
{
    public int Id { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime? StartAt { get; private set; }
    public DateTime? EndAt { get; private set; }
    public TodoStatus Status { get; private set; }
    private TodoItem(int id, string title, string description, DateTime? startAt, DateTime? endAt, TodoStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        StartAt = startAt;
        EndAt = endAt;
        Status = status;
    }

    public void Cancel()
    {
        if (Status == TodoStatus.Closed )
            throw new InvalidOperationException("You cannot cancel a closed task.");

        Status = TodoStatus.Cancelled;
        EndAt = DateTime.Now;
    }

    public static TodoItem New(int id, string title)
    {
        return new TodoItem(id, title, string.Empty, null, null, TodoStatus.Created);
    }


    public void ChangeDetails(string title, string description)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException("title");

        Title = title;
        Description = description;
    }

    public void Start()
    {
        if (EndAt is not null || Status == TodoStatus.Closed)
            throw new InvalidOperationException("You can not start a closed Task.");

        StartAt = DateTime.Now;
        Status = TodoStatus.Started;
    }
    

    public void Close()
    {
        if (EndAt is not null && Status != TodoStatus.Started)
            throw new InvalidOperationException("You can not close a Task with stat != Started.");

        EndAt = DateTime.Now;
        Status = TodoStatus.Closed;
    }

    public override string ToString()
    {
        return $"{nameof(Id)} : {Id} - {nameof(Title)} : {Title} - {nameof(StartAt)} : {StartAt?.ToShortDateString()} - {nameof(Status)} : {Status}";
    }


}
