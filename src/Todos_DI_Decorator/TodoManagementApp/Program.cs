// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using TodoManagementCore;

var services = new ServiceCollection();

services.AddScoped<ILogger, MyLogger>();

services.AddScoped<ITodoManager, LoggingTodoManager>(sp=> new LoggingTodoManager(new TodoManager(),sp.GetRequiredService<ILogger>()));

var serviceProvider = services.BuildServiceProvider();

TodoDemo.StartApplication(serviceProvider.GetRequiredService<ITodoManager>());

