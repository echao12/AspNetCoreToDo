using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ApplicationDbContext _context;
        public ToDoItemService(ApplicationDbContext context)
        {
            _context = context;//constructor injects the passed database context to this service
        }

        public async Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var items = await _context.Items // accesses all to-do items
                //LINQ method that translates where into a query statement to filter only incomplete items
                .Where(x => x.IsDone == false) //translates into => SELECT * from Items Where IsDone = 0
                .ToArrayAsync(); //async fn that grabs all matched entities & package them into an Array.
            return items;
        }

        public async Task<bool> AddItemAsync(ToDoItem newItem)
        {
            //ASP.Net Core's model binder already set Title property from the AddItem action in the controller.
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            _context.Items.Add(newItem);//add the newItem to the Items table in the database context.

            var saveResult = await _context.SaveChangesAsync();//save the changes to the db
            
            //if save successful, should return 1.
            return saveResult == 1; //if matching with 1, successful. return true. else return false.
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
                .Where(x => x.Id == id) //looks for x where x.Id = the passed id
                .SingleOrDefaultAsync();//return item or null if not found.
            
            if (item == null) return false;

            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();//save changes to database.
            return saveResult == 1;
        }
    }
}