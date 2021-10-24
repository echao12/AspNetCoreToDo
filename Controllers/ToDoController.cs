//tldr; controllers recieve requests and looks up info in database
// then creates a model with the data and attaches it to a view.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTodo.Controllers
{
    //notes:
    //controllers handle routes by calling actions on them.
    //model types -> entities & view models.
    //  Entities: represents a todo item stored in db
    //  view models: model that will be combined with a view.
    public class ToDoController : Controller
    {
        //IActionResult: flexible type & can return views, JSON data, or HTTP sttaus codes like 200 ok.
        public IActionResult Index() {
            //get todo item from database
            //put items into a model
            //render view using the model
            return null;
        }
    }
}