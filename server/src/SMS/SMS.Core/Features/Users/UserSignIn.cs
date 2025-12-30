using SMS.Core.Common;

namespace SMS.Core.Features.Users;

public sealed class UserSignIn : BaseEntity
{
    public Guid UserId { get; private set; }
    
    public ProviderType ProviderType { get; private set; } = ProviderType.Facebook;
    public string ProviderKey { get; private set; } = string.Empty;
    public string? ProviderEmail { get; private set; }
    
    
    private UserSignIn() { }

    internal static UserSignIn CreateUserSignIn(Guid userId, ProviderType providerType, string providerKey, string? providerEmail)
    {
        return new UserSignIn
        {
            UserId = userId,
            ProviderType = providerType,
            ProviderKey = providerKey,
            ProviderEmail = providerEmail
        };
    }
}