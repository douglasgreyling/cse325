using CSE325App.Models;
using CSE325App.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
    

namespace CSE325App.Services;

public class TodoService : ITodoServices
{
    private readonly ApplicationDbContext _context;

    public TodoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoTask>> GetAllTasks()
    {
        return await _context.Tasks
            .OrderBy(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<TodoTask?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<TodoTask>> SearchTaskAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllTasks();

        var lowerSearchTerm = searchTerm.ToLower();

        return await _context.Tasks
            .Where(t => t.TaskName.ToLower().Contains(lowerSearchTerm) ||
                        t.Description.ToLower().Contains(lowerSearchTerm))
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<TodoTask> CreateTaskAsync(TodoTask task)
    {
        task.CreatedAt = DateTime.Now;
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TodoTask> UpdateTaskAsync(TodoTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<TodoTask>> GetTasksForTodayAsync()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        return await _context.Tasks
            .Where(t => t.DueDate >= today &&
                        t.DueDate < tomorrow &&
                        t.Status != CSE325App.Models.TaskStatus.Completed)
            .OrderBy(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoTask>> GetCompletedTasksAsync()
    {
        return await _context.Tasks
            .Where(t => t.Status == CSE325App.Models.TaskStatus.Completed)
            .OrderByDescending(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoTask>> GetOpenTasksAsync()
    {
        return await _context.Tasks
            .Where(t => t.Status == CSE325App.Models.TaskStatus.Open ||
                        t.Status == CSE325App.Models.TaskStatus.InProgress)
            .OrderByDescending(t => t.DueDate)
            .ToListAsync();
    }

    public async Task<List<TodoTask>> GetOverdueTasksAsync()
    {
        var today = DateTime.Today;

        return await _context.Tasks
            .Where(t => t.DueDate < today &&
                        t.Status != CSE325App.Models.TaskStatus.Completed)
            .OrderByDescending(t => t.DueDate)
            .ToListAsync();
    }

   
}

