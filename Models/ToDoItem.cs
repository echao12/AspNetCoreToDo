using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models{
    //this class defines what each todo item needs to store in the db.
    public class ToDoItem {
        //id is a randomly generated globally unique identifier (Guid). ex: 43ec09f2-7f70-4f4b-9559-65011d5781bb
        //unlike incrementing ids, they are long & have extremely low chance for duplication & dont have to setup db to auto increment.
        public Guid Id {get; set;} //C#'s auto-implement property feature. Will implicitly create a private var and use get/set when var is being invoked.
        
        //false by defualt. set true when user clicks item checkbox on the view.
        public bool IsDone{get; set;}

        [Required] //tells ASP.NET core this property cannot be null or empty
        public string Title {get; set;}

        //DateTimeOffset stores date/time stamp & timezone offset from UTC.
        //the '?' marks this property as nullable/optional. not every todo item needs this field filled.
        public DateTimeOffset? DueAt {get; set;}
    }
}