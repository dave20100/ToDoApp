using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        ToDoContext context = new ToDoContext();

        [HttpGet]
        public ActionResult<IEnumerable<ToDoList>> GetLists() {
            return new JsonResult(context.ToDoLists.Include(todolist => todolist.ToDos));
        }

        [HttpPost]
        public void AddList([FromBody] ToDoList toDoList) {
            context.ToDoLists.Add(toDoList);
            context.SaveChanges();
        }

        [HttpGet("ToDo")]
        public ActionResult<IEnumerable<ToDo>> GetToDos([FromBody]ToDoList toDoList) {
            return new JsonResult(context.ToDoLists.FirstOrDefault(todolistiter => todolistiter == toDoList).ToDos);
        }

        [HttpPost("ToDo")]
        public void AddToDo([FromBody] ToDo toDo, int id) {
            context.ToDoLists.FirstOrDefault(list => list.Id == id).ToDos.Add(toDo);
            context.SaveChanges();
        }

        [HttpPost("ToDoAsList")]
        public void AddToDos([FromBody] List<ToDo> toDos, int id)
        {
            var toDoList = context.ToDoLists.FirstOrDefault(list => list.Id == id);
            foreach(var toDo in toDos) {
                toDoList.ToDos.Add(toDo);
            }
            context.SaveChanges();
        }
    }
}