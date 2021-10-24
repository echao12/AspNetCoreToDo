//tldr; controllers recieve requests and looks up info in database
// then creates a model with the data and attaches it to a view.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    //notes:
    //controllers handle routes by calling actions on them.
    //model types -> entities & view models.
    //  Entities: represents a todo item stored in db
    //  view models: model that will be combined with a view.
    public class ToDoController : Controller
    {
        //holds a reference to a service that implements the service inteface.
        private readonly IToDoItemService _todoItemService;

        //constructor that takes something that implements the IToDoItemService interface.
        //powerful b/c it does not take any specific class. just something that implements the interface.
        public ToDoController(IToDoItemService toDoItemService)
        {
            //set a reference to the service
            _todoItemService = toDoItemService;
        }
        //IActionResult: flexible type & can return views, JSON data, or HTTP sttaus codes like 200 ok.
        //mark it as async so it can call async code.
        //wrap return type with Task because it is a async fn that returns a value.
        public async Task<IActionResult> Index() {
            //get todo item from database
            //await waits for the result before continuing.
            var items = await _todoItemService.GetIncompleteItemsAsync();
            //put items into a model
            //using object initialization. Creates an "unnamed" instance with the coded values
            //and then assigns those values to the instance variable being created.
            //ex: model is a instance of ToDoViewModel whose values comes 
            //     from an unnamed instance of the same type with values Item = items.
            var model = new ToDoViewModel()
            {
                Items = items
            };
            //render view using the model
            return View(model);
        }
    }
}