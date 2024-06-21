using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Model;

namespace ToDoList_App.Mock
{
    internal class ToDoServiceStub : IToDoService
    {
        private List<ToDo> toDos;
        private int nextId = 4;

        public ToDoServiceStub()
        {
            toDos = new List<ToDo>()
            {
                new ToDo() {Id = 1, Title = "Помыть посуду", DeadLine = new DateTime(2024, 5, 10), Priority = ToDoPriority.Normal },
                new ToDo() {Id = 2, Title = "Пропылесосить", DeadLine = new DateTime(2024, 5, 15), Priority = ToDoPriority.Low },
                new ToDo() {Id = 3, Title = "Купить молоко", DeadLine = new DateTime(2024, 5, 6), Priority = ToDoPriority.High },
            };
        }

        public List<ToDo> GetAll()
        {
            return toDos.Select(toDo => new ToDo(toDo)).ToList();
        }

        public void Add(ToDo toDo)
        {
            toDo.Id = nextId++;
            toDos.Add(new ToDo(toDo));
        }

        public void Delete(int id)
        {
            ToDo deleted = toDos.First(toDo => toDo.Id == id);
            toDos.Remove(deleted);
        }

        public ToDo Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        //
        public void Dispose()
        {
            
        }
    }
}
