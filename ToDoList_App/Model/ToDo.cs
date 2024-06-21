using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_App.Model
{
    // ToDo - класс, описывающий сущность дела
    public class ToDo
    {
        public int Id { get; set; }                 // id
        public string Title { get; set; }           // заголовок дела
        public DateTime DeadLine { get; set; }      // дедлайн
        public ToDoPriority Priority { get; set; }  // приоритет

        public ToDo() { }
        public ToDo(ToDo other)
        {
            Id = other.Id;
            Title = other.Title;
            DeadLine = other.DeadLine;
            Priority = other.Priority;
        }
        //
        public static List<ToDoPriority> AvailablePriorities
        {
            get
            {
                return new List<ToDoPriority>()
                {
                    ToDoPriority.Lowest,
                    ToDoPriority.Low,
                    ToDoPriority.Normal,
                    ToDoPriority.High,
                    ToDoPriority.Highest,
                };
            }
        }

        //
        public override string ToString()
        {
            return $"{Id} - {Title} - {DeadLine:dd.MM.yyyy} - {Priority}";
        }
    }
}
