namespace SMS.Core.Features.Users;

public interface IUserRepository
{
    Task<bool> VerifyExistedEmailAsync(string email, CancellationToken cancellationToken);
    Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
}