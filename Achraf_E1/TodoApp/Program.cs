using Microsoft.Extensions.DependencyInjection;
using System;
using TodoManagerApp.App;
using TodoManagerApp.Interfaces;
using TodoManagerApp.Services;

namespace TodoManagerApp
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            var app = _serviceProvider.GetService<TodoApp>();
            app.Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<ITodoService, TodoService>();
            collection.AddTransient<TodoApp>();
            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
