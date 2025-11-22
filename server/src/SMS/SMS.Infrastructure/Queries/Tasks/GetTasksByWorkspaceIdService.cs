using SMS.UseCases.Abstractions.Data;
using SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;
using SMS.UseCases.Pagination.OffsetPagination;
using SMS.UseCases.Queries.Tasks;
using Task = SMS.Core.Features.Tasks.Task;

namespace SMS.Infrastructure.Queries.Tasks;

public sealed class GetTasksByWorkspaceIdService(IApplicationDbContext context) : IGetTasksByWorkspaceIdService
{
    public Task<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>> Handle(GetTasksByWorkspaceIdQuery query, CancellationToken cancellationToken)
    {
        var baseQuery = context.Set<Task>()
            .Where(t => t.Project.WorkspaceId == query.WorkspaceId);
        
        baseQuery = HandleTasksFilter(baseQuery, query);
        baseQuery = HandleTasksOrder(baseQuery, query);
        
        var result = HandleTasksPagination(query, baseQuery, cancellationToken);
        
        return result;
    }

    private static IQueryable<Task> HandleTasksFilter(IQueryable<Task> baseQuery, GetTasksByWorkspaceIdQuery query)
    {
        // Filter project
        if (query.ProjectId.HasValue)
        {
            baseQuery = baseQuery.Where(t => t.ProjectId == query.ProjectId);
        }

        // Filter status
        if (query.StatusIds is { Count: > 0 })
        {
            baseQuery = baseQuery.Where(t => query.StatusIds.Contains(t.StatusId));
        }

        // Filter priority
        if (query.PriorityIds is { Count: > 0 })
        {
            baseQuery = baseQuery.Where(t => query.PriorityIds.Contains(t.PriorityId));
        }

        // Filter assigned to
        if (query.AssignedToIds is { Count: > 0 })
        {
            baseQuery = baseQuery.Where(t => t.AssignedToId.HasValue && query.AssignedToIds.Contains(t.AssignedToId.Value));
        }

        // Keyword search (nếu có các field Name, Description)
        if (!string.IsNullOrWhiteSpace(query.KeyWord))
        {
            var words = query.KeyWord
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            baseQuery = words.Aggregate(baseQuery, (current, w) =>
                current.Where(t =>
                    t.Name.ToLower().Contains(w) ||
                    (t.Description != null && t.Description.ToLower().Contains(w)) ||
                    (t.Code.ToLower().Contains(w))
                )
            );
        }

        // Due date
        if (query.DueDate != null)
        {
            baseQuery = baseQuery.Where(t => t.DueDate == query.DueDate);
        }

        return baseQuery;
    }

    private static IQueryable<Task> HandleTasksOrder(IQueryable<Task> baseQuery, GetTasksByWorkspaceIdQuery query)
    {
        baseQuery = query.Order switch
        {
            GetTasksOrder.ProjectName => query.IsAscending
                ? baseQuery.OrderBy(t => t.Project.Name)
                : baseQuery.OrderByDescending(t => t.Project.Name),
            GetTasksOrder.AssignedTo => query.IsAscending
                ? baseQuery.OrderBy(t => t.AssignedTo!.FirstName)
                : baseQuery.OrderByDescending(t => t.AssignedTo!.FirstName),
            GetTasksOrder.DueDate => query.IsAscending
                ? baseQuery.OrderBy(t => t.DueDate)
                : baseQuery.OrderByDescending(t => t.DueDate),
            GetTasksOrder.TaskStatus => query.IsAscending
                ? baseQuery.OrderBy(t => t.TaskStatus.Name)
                : baseQuery.OrderByDescending(t => t.TaskStatus.Name),
            GetTasksOrder.TaskPriority => query.IsAscending
                ? baseQuery.OrderBy(t => t.TaskPriority.Name)
                : baseQuery.OrderByDescending(t => t.TaskPriority.Name),
            
            _ => query.IsAscending 
                ? baseQuery.OrderBy(t => t.Name) 
                : baseQuery.OrderByDescending(t => t.Name)
        };

        return baseQuery;
    }

    private static async Task<OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>> HandleTasksPagination(
        GetTasksByWorkspaceIdQuery query, IQueryable<Task> baseQuery, CancellationToken cancellationToken)
    {
        return await OffsetPaginationResponse<GetTasksByWorkspaceIdResponse>.CreateAsync(
            baseQuery.Select(task => new GetTasksByWorkspaceIdResponse(
                task.Id,
                task.Code,
                task.Name,
                task.Project.Name,
                task.AssignedTo != null ? task.AssignedTo.FirstName : null,
                task.AssignedTo != null ? task.AssignedTo.MiddleName : null,
                task.AssignedTo != null ? task.AssignedTo.LastName : null,
                task.DueDate,
                task.TaskStatus.Name,
                task.TaskPriority.Name
            )),
            query.Page,
            query.PageSize,
            cancellationToken
        );
    }
    
}