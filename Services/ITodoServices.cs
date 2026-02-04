using CSE325App.Models;
using System.Collections.Generic;

namespace CSE325App.Services;
public interface ITodoServices
{

    // Define asynchronous method to get all tasks from the database
    Task<List<TodoTask>> GetAllTasks();

   // Define asynchronous method to get a task by its ID, it has optional return type   {?}
    Task<TodoTask?> GetTaskByIdAsync(int id);

    // Define asynchronous method to search tasks by a search term
    Task<List<TodoTask>> SearchTaskAsync(string searchTerm);

    Task<TodoTask> CreateTaskAsync(TodoTask task);
    Task<TodoTask> UpdateTaskAsync(TodoTask task);
    Task<bool> DeleteTaskAsync(int id);


    //interfaces for the dashboard to fetch specific task lists

    Task<List<TodoTask>> GetTasksForTodayAsync();
    Task<List<TodoTask>> GetOverdueTasksAsync();
    Task<List<TodoTask>> GetCompletedTasksAsync();
    Task<List<TodoTask>> GetOpenTasksAsync();

}
