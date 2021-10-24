//interfaces are prefixed with "I"
//Interfaces (similar to traits in rust) are a collection of method signitures for the classes to implement.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models; //to reference the Models namespace in this file

namespace AspNetCoreTodo.Services
{
    public interface IToDoItemService
    {
        //Task type is similar to a future/promise. Its for noting Asynchronous code.
        Task<ToDoItem[]> GetIncompleteItemsAsync();
    }
}