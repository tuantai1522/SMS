using MediatR;
using SMS.Core.Common;
using SMS.UseCases.Interfaces;

namespace SMS.UseCases.Features.Auths.GoogleSignIn.GetGoogleAuthenticationUrl;

internal sealed class GetGoogleAuthenticationQueryHandler(
    IGoogleAuthentication googleAuthentication): IRequestHandler<GetGoogleAuthenticationQuery, Result<GetGoogleAuthenticationResponse>>
{
    public Task<Result<GetGoogleAuthenticationResponse>> Handle(GetGoogleAuthenticationQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(new GetGoogleAuthenticationResponse(googleAuthentication.GetGoogleAuthUrl())));
    }
}
