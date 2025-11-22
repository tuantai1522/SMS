using Microsoft.EntityFrameworkCore;
using SMS.Core.Features.Projects;
using SMS.Core.Features.Tasks;
using SMS.UseCases.Abstractions.Data;
using Task = SMS.Core.Features.Tasks.Task;

namespace SMS.Infrastructure.Repositories;

public sealed class TaskRepository(IApplicationDbContext context) : ITaskRepository
{
    public async Task<Task> AddTaskAsync(Task task, CancellationToken cancellationToken)
    {
        var result = await context.Set<Task>().AddAsync(task, cancellationToken);
        
        return result.Entity;
    }

    public IQueryable<Task> GetTasksOrderByTitleAsync(
        Guid workspaceId,
        Guid? projectId,
        IReadOnlyList<Guid>? statusIds,
        IReadOnlyList<Guid>? priorityIds,
        IReadOnlyList<Guid>? assignedToIds,
        string? keyWord,
        long? dueDate,
        bool isAscending,
        CancellationToken cancellationToken)
    {
        var query = GetTasksAsync(workspaceId, projectId, statusIds, priorityIds, assignedToIds, keyWord, dueDate);
        
        query = isAscending
            ? query.OrderBy(t => t.Name)
            : query.OrderByDescending(t => t.Name);

        return query;
    }

    public IQueryable<Task> GetTasksOrderByProjectNameAsync(
        Guid workspaceId,
        Guid? projectId,
        IReadOnlyList<Guid>? statusIds,
        IReadOnlyList<Guid>? priorityIds,
        IReadOnlyList<Guid>? assignedToIds,
        string? keyWord,
        long? dueDate,
        bool isAscending,
        CancellationToken cancellationToken)
    {
        var taskQuery = GetTasksAsync(
            workspaceId, projectId, statusIds, priorityIds,
            assignedToIds, keyWord, dueDate);

        var query =
            from t in taskQuery
            join p in context.Set<Project>() on t.ProjectId equals p.Id
            select new { Task = t, Project = p };

        query = isAscending
            ? query.OrderBy(x => x.Project.Name)
            : query.OrderByDescending(x => x.Project.Name);

        return query
            .Select(t => t.Task);
    }


    private IQueryable<Task> GetTasksAsync(
        Guid workspaceId,
        Guid? projectId,
        IReadOnlyList<Guid>? statusIds,
        IReadOnlyList<Guid>? priorityIds,
        IReadOnlyList<Guid>? assignedToIds,
        string? keyWord,
        long? dueDate)
    {
        var query = 
            from t in context.Set<Task>()
            join p in context.Set<Project>() on t.ProjectId equals p.Id
            where p.WorkspaceId == workspaceId
            select t;

        // Filter project
        if (projectId.HasValue)
        {
            query = query.Where(t => t.ProjectId == projectId);
        }

        // Filter status
        if (statusIds is { Count: > 0 })
        {
            query = query.Where(t => statusIds.Contains(t.StatusId));
        }

        // Filter priority
        if (priorityIds is { Count: > 0 })
        {
            query = query.Where(t => priorityIds.Contains(t.PriorityId));
        }

        // Filter assigned to
        if (assignedToIds is { Count: > 0 })
        {
            query = query.Where(t => t.AssignedToId.HasValue && assignedToIds.Contains(t.AssignedToId.Value));
        }

        // Keyword search (nếu có các field Name, Description)
        if (!string.IsNullOrWhiteSpace(keyWord))
        {
            var words = keyWord
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            query = words.Aggregate(query, (current, w) =>
                current.Where(t =>
                    t.Name.ToLower().Contains(w) ||
                    (t.Description != null && t.Description.ToLower().Contains(w)) ||
                    (t.Code.ToLower().Contains(w))
                )
            );
        }

        // Due date
        if (dueDate != null)
        {
            query = query.Where(t => t.DueDate == dueDate);
        }

        return query
            .Include(t => t.TaskPriority)
            .Include(t => t.TaskStatus)
            .Include(t => t.Project)
            .Include(t => t.AssignedTo);
    }

}