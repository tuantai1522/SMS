using Newtonsoft.Json;

namespace SMS.UseCases.Features.Users.GoogleSignIn;

public class GoogleTokenResponse
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; } = null!;

    [JsonProperty("id_token")]
    public string IdToken { get; set; } = null!;
}