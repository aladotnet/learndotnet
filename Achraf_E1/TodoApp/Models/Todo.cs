using System;

namespace TodoManagerApp.Models
{
    public enum TodoStatus
    {
        Pending,
        InProgress,
        Closed,
        Cancelled
    }

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
        public string AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
    }
}
