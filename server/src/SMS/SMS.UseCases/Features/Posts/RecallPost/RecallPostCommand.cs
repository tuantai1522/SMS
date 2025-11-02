using MediatR;
using SMS.Core.Common;

namespace SMS.UseCases.Features.Posts.RecallPost;

public sealed record RecallPostCommand(Guid PostId) : IRequest<Result<Guid>>;
