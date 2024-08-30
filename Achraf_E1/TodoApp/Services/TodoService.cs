using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TodoManagerApp.Interfaces;
using TodoManagerApp.Models;

namespace TodoManagerApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly string _filePath = "todos.json";
        private List<Todo> _todos;

        public TodoService()
        {
            _todos = LoadTodosFromFile();
        }

        public void AddTodo(Todo todo)
        {
            todo.Id = _todos.Count > 0 ? _todos[^1].Id + 1 : 1; // Auto-increment ID
            todo.CreatedAt = DateTime.Now;
            _todos.Add(todo);
            SaveTodosToFile();
        }

        public void ChangeTodoDetails(int id, string title, string description)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo != null)
            {
                todo.Title = title;
                todo.Description = description;
                SaveTodosToFile();
            }
        }

        public void Start(int id)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo != null && todo.Status == TodoStatus.Pending)
            {
                todo.Status = TodoStatus.InProgress;
                todo.StartedAt = DateTime.Now;
                SaveTodosToFile();
            }
        }

        public void Close(int id)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo != null && todo.Status == TodoStatus.InProgress)
            {
                todo.Status = TodoStatus.Closed;
                todo.ClosedAt = DateTime.Now;
                SaveTodosToFile();
            }
        }

        public void Cancel(int id)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo != null && todo.Status != TodoStatus.Closed)
            {
                todo.Status = TodoStatus.Cancelled;
                SaveTodosToFile();
            }
        }

        public void AssignToExecuter(int id, string executer)
        {
            var todo = _todos.Find(t => t.Id == id);
            if (todo != null)
            {
                todo.AssignedTo = executer;
                SaveTodosToFile();
            }
        }

        public List<Todo> GetTodoList()
        {
            return _todos;
        }

        public Todo GetTodoById(int id)
        {
            return _todos.Find(t => t.Id == id);
        }

        private void SaveTodosToFile()
        {
            var json = JsonSerializer.Serialize(_todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private List<Todo> LoadTodosFromFile()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Todo>>(json) ?? new List<Todo>();
            }
            return new List<Todo>();
        }
    }
}
