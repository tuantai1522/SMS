namespace SMS.UseCases.Features.Tasks.GetTasksByWorkspaceId;

public sealed record GetTasksByWorkspaceIdResponse(
    Guid Id, 
    string Code, 
    string Title, 
    string ProjectName,
    string? GivenName,
    long? DueDate, 
    string StatusName,
    string PriorityName);
