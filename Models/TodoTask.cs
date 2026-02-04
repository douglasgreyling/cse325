// using System.ComponentModel.DataAnnotations;

// namespace CSE325App.Models
// { 

//     public enum TaskStatus
//     {
//         Open = 0, // Default status when a task is created
//         InProgress = 1, // Status when work on the task has started
//          Completed = 2 // Status when the task has been finished
//      }

//     public class TodoTask
//     {
//         // Each task has a unique identifier that serves as the primary key.
//         public int Id { get; set; }

//        // The name of the task with validation attributes.
//        [Required(ErrorMessage = "Task name is required")] 
//        [StringLength(200, ErrorMessage = "Task name cannot exceed 200 characters")] 
//        public string TaskName { get; set; } =  string.Empty;

//         // A detailed description of the task with validation attributes.
//        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
//        public string Description { get; set; } = string.Empty;

//        // The due date for the task with a required validation attribute.
//        [Required(ErrorMessage = "Due date is required")]
//        public DateTime DueDate { get; set; }

       
//        // this holds the status of the task in the enum below
//        public TaskStatus Status { get; set; } 

//        // The date and time when the task was created, defaulting to the current date and time.
//        public DateTime CreatedAt { get; set; } = DateTime.Now;
//         public bool IsCompleted { get; internal set; }

//     }



// }


using System.ComponentModel.DataAnnotations;

namespace CSE325App.Models
{
    public enum TaskStatus
    {
        Open = 0,
        InProgress = 1,
        Completed = 2
    }

    public class TodoTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        [StringLength(200, ErrorMessage = "Task name cannot exceed 200 characters")]
        public string TaskName { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Open;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

