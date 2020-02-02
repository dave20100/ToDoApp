using System.Collections.Generic;

namespace Backend.Model
{
    public class ToDoList
    {
        public ToDoList()
        {
            ToDos = new HashSet<ToDo>();
        }
        public int Id {get; set;}
        public string Name {get; set;}
        public virtual ICollection<ToDo> ToDos {get; set;}
    }
}