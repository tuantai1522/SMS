using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Features.Channels.GetChannelById;

namespace SMS.Web.Endpoints.Channels;

internal sealed class GetChannelById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("channels/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetChannelByIdQuery(id);

            var result = await mediator.Send(query, cancellationToken);

            return Results.Ok(BaseResult<GetChannelByIdResponse>.FromResult(result));
        })
        .WithTags(Tags.Channels)
        .RequireAuthorization();
    }
}
