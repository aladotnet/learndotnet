using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoManagementCore
{

    public interface ITodoItem
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }
        DateTime? StartAt { get; }
        DateTime? EndAt { get; }
        TodoStatus Status { get; }

        void ChangeDetails(string title, string description);
        void Start();
        void Close();
        void Cancel();
        string ToString();
    }
}
