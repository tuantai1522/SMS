using SMS.UseCases.Features.Users.GetMe;

namespace SMS.UseCases.Queries.Users;

public interface IGetMeService
{
    Task<GetMeResponse?> Handle(Guid userId, CancellationToken cancellationToken);
}