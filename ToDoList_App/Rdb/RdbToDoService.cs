using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_App.Model;

namespace ToDoList_App.Rdb
{
    internal class RdbToDoService : IToDoService
    {
        private readonly string _connectionString;

        public RdbToDoService()
        {
            _connectionString = @"Data Source=HOME-PC\SQLEXPRESS;Initial Catalog=ToDoListDB;Integrated Security=SSPI; Timeout=5;";

        }
        public void Add(ToDo toDo)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO ToDos (Title, DeadLine, Priority) VALUES (@Title, @DeadLine, @Priority)", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Title", toDo.Title));
                    command.Parameters.Add(new SqlParameter("@DeadLine", toDo.DeadLine));
                    command.Parameters.Add(new SqlParameter("@Priority", (int)toDo.Priority));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM ToDos WHERE Id = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ToDo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDo> GetAll()
        {
            List<ToDo> toDos = new List<ToDo>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM ToDos", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ToDo toDo = new ToDo
                            {
                                Id = (int)reader["Id"],
                                Title = (string)reader["Title"],
                                DeadLine = (DateTime)reader["DeadLine"],
                                Priority = (ToDoPriority)reader["Priority"]
                            };
                            toDos.Add(toDo);
                        }
                    }
                }
            }
            return toDos;
        }


        public void Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
