//this service will always return the same array of 2 ToDoItems.
//it is for testing purposes only!
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
namespace AspNetCoreTodo.Services
{
    //fakeToDoItemService implements the IToDoItemService interface.
    public class FakeToDoItemService : IToDoItemService
    {
        public Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var item1 = new ToDoItem
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

            var item2 = new ToDoItem
            {
                Title = "Build awsome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult(new[] { item1, item2});
        }
    }
}