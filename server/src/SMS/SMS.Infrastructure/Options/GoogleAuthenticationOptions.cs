namespace SMS.Infrastructure.Options;

public sealed class GoogleAuthenticationOptions
{
    /// <summary>
    /// ClientId of Google
    /// </summary>
    public string ClientId { get; init; } = null!;
        
    /// <summary>
    /// ClientSecret of Google
    /// </summary>
    public string ClientSecret { get; init; } = null!;
        
    /// <summary>
    /// Link of backend defined on Google web to log in by google
    /// </summary>
    public string RedirectUri { get; init; } = null!;

    /// <summary>
    /// Scoped which website can access in Google Contact
    /// </summary>
    public string Scope { get; init; } = null!;
        
    /// <summary>
    /// Link to navigate to website to choose account from Google
    /// </summary>
    public string GoogleUrl { get; init; } = null!;
        
    /// <summary>
    /// Endpoint to get access token and id token
    /// </summary>
    public string GoogleAuthTokenEndpoint { get; init; } = null!;
        
    /// <summary>
    /// Endpoint to get information of user by access token and id token
    /// </summary>
    public string GoogleContactInfoEndpoint { get; init; } = null!;
}