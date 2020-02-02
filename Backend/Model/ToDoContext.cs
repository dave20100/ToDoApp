using Microsoft.EntityFrameworkCore;

namespace Backend.Model
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
            
        }
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
        { }
        public virtual DbSet<ToDo> ToDos {get; set;}
        public virtual DbSet<ToDoList> ToDoLists {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ToDoDb;Integrated Security=True"); 
        }
    }
}