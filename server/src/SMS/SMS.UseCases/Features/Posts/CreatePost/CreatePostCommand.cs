using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Posts.CreatePost;

public sealed record CreatePostCommand(Guid ChannelId, Guid? RootId, string Message) : IRequest<Result<Guid>>;
