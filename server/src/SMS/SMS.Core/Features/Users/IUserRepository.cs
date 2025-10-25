namespace SMS.Core.Features.Users;

public interface IUserRepository
{
    Task<User?> FindUserByEmailAsync(string email, CancellationToken cancellationToken);

    Task<bool> VerifyExistedEmailAsync(string email, CancellationToken cancellationToken);
    Task<bool> VerifyExistedNickNameAsync(string nickName, CancellationToken cancellationToken);
    
    /// <summary>
    /// Verify list userIds must be in database
    /// </summary>
    Task<bool> VerifyExistedUserIdsAsync(IReadOnlyList<Guid> userIds, CancellationToken cancellationToken);
    
    Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
}