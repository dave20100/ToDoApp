using Newtonsoft.Json;

namespace Backend.Model
{
    public class ToDo
    {
        
        public int Id {get; set;}
        
        [JsonIgnore]
        public virtual ToDoList ToDoList {get; set;}
        public bool IsDone {get; set;}
        public string Description {get; set;}
    }
} 