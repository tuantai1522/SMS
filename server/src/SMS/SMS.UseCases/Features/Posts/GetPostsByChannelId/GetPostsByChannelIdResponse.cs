namespace SMS.UseCases.Features.Posts.GetPostsByChannelId;

public sealed record GetPostsByChannelIdResponse(Guid Id, string Message, Guid? RootId, Guid? UserId, long CreatedAt, long? UpdatedAt);
