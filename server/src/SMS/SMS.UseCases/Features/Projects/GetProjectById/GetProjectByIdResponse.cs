namespace SMS.UseCases.Features.Projects.GetProjectById;

public sealed record GetProjectByIdResponse(Guid Id, string Name, string Code, string? Emoji, string? Description);
