using System;
using System.Linq;
using ToDos.Data;
using ToDos.Models;

namespace ToDos.ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            ToDosDB todoEntities = new ToDosDB();

            for (int i = 0; i < 10; i++)
            {
                var cat = new Category()
                {
                    Name = "new category" + i,

                };
                todoEntities.Categories.Add(cat);

                for (int m = 0; m < 20; m++)
                {
                    var todo = new Todo()
                    {
                        Title = "new todo" + i + m,
                        Body = "bodyOfTodo" + i + m,
                        Category = cat,
                        LastChangeDate = DateTime.Now,
                    };
                    todoEntities.Todos.Add(todo);
                }
            }
            todoEntities.SaveChanges();
        }
    }
}
