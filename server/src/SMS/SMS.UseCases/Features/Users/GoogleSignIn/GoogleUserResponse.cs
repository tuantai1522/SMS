using Newtonsoft.Json;

namespace SMS.UseCases.Features.Users.GoogleSignIn
{
    /// <summary>
    /// Response from Google return after logging in successfully
    /// Need to map to snake_case naming convention which is returned from Google
    /// </summary>
    public class GoogleUserResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;
        
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("given_name")]
        public string GivenName { get; set; } = null!;

        [JsonProperty("family_name")]
        public string FamilyName { get; set; } = null!;
    }
}

