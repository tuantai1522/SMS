using SMS.UseCases.Features.Auths.GoogleSignIn;

namespace SMS.UseCases.Interfaces;

public interface IGoogleAuthentication
{
    /// <summary>
    /// Get link navigate to link to log in by Google
    /// </summary>
    /// <returns></returns>
    public string GetGoogleAuthUrl();

    /// <summary>
    /// From access token and idToken, I can get email, name, or avatar, ... of Contact
    /// </summary>
    public Task<GoogleUserResponse?> GetGoogleUserAsync(string code);

}