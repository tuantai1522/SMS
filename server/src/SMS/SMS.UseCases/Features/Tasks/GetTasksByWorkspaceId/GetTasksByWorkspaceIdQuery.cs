using SMS.UseCases.Pagination.OffsetPagination;

namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

public sealed class GetTasksByWorkspaceIdQuery(
    Guid workspaceId,
    Guid? projectId,
    IReadOnlyList<Guid>? statusIds,
    IReadOnlyList<Guid>? priorityIds,
    IReadOnlyList<Guid>? assignedToIds,
    string? keyWord,
    long? dueDate,
    bool isAscending) : OffsetPaginationRequest<GetTasksByWorkspaceIdResponse>
{
    public Guid WorkspaceId { get; } = workspaceId;
    public Guid? ProjectId { get; } = projectId;
    public IReadOnlyList<Guid>? StatusIds { get; } = statusIds;
    public IReadOnlyList<Guid>? PriorityIds { get; } = priorityIds;
    public IReadOnlyList<Guid>? AssignedToIds { get; } = assignedToIds;
    public string? KeyWord { get; } = keyWord;
    public long? DueDate { get; } = dueDate;
    
    public bool IsAscending { get; } = isAscending;
}

