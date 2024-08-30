using System.Collections.Generic;
using TodoManagerApp.Models;

namespace TodoManagerApp.Interfaces
{
    public interface ITodoService
    {
        void AddTodo(Todo todo);
        void ChangeTodoDetails(int id, string title, string description);
        void Start(int id);
        void Close(int id);
        void Cancel(int id);
        void AssignToExecuter(int id, string executer);
        List<Todo> GetTodoList();
        Todo GetTodoById(int id);
    }
}
