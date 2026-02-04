

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

