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
    }
}