using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Model
{
    // ToDoService - интерфейс, описывающий операции с делом
    internal interface IToDoService : IDisposable
    {
        // Add - добавить новое дело
        void Add(ToDo toDo);

        // GetAll - получить список дел
        List<ToDo> GetAll();

        // Get - получить дело по id
        ToDo Get(int id);

        // Delete - удалить дело по id
        void Delete(int id);

        // Update - обновить данные дела
        void Update(ToDo toDo);
    }
}
