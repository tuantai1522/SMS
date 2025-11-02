using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Posts.EditPost;

public sealed record EditPostCommand(Guid PostId, string Message) : IRequest<Result<Guid>>;
