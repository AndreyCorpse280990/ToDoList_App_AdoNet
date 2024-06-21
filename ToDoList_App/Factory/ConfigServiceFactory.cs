using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Mock;
using ToDoList_App.Model;
using ToDoList_App.Rdb;

namespace ToDoList_App.Factory
{
    // ConfigServiceFactory - фабрика, создающая сервисы на основе файла конфигурации App.config
    internal static class ConfigServiceFactory
    {
        public static IToDoService CreateToDoService()
        {
            string useToDoService = ConfigurationManager.AppSettings["useToDoService"];
            switch (useToDoService)
            {
                case "ToDoServiceStub":
                    return new ToDoServiceStub();
                case "RdbToDoService":
                    return new RdbToDoService();
                case null:
                    throw new InvalidOperationException("no 'useToDoService' in App.config");
                default:
                    throw new InvalidOperationException($"unknown toDoService name '{useToDoService}'");
            }
        }
    }
}
