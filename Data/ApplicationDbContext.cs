using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Data
{
    //a context class provides an entry point to the database.
    //defines how the software will interact with the database.
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //DbSet is a table in the database
        //creating items to hold a table(DbSet) of ToDoItems.
        public DbSet<ToDoItem> Items{ get; set; }
        //this db context now has an Items table, but the actual db does not.
        //need to create a migration to update the database.
        //migrations track changes to db structure over time & make it possible
        //to roll back changes or clone the database.
        //create migration: dotnet ef migrations add AddItems
        //update database with the Items table: dotnet ef database update
    }
}
