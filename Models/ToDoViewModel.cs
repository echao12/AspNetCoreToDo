namespace AspNetCoreTodo.Models {
    //since the todoitem entity is not the same as the view model, create the view model in a separate class.
    //the todo view model might need to represent tens to hundreds of todo items, where the entity is an entry for 1.
    public class ToDoViewModel {
        public ToDoItem[] Items {get; set;}

    }
}