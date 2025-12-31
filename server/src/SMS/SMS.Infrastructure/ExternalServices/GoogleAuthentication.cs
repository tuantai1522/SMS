using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SMS.Infrastructure.Options;
using SMS.UseCases.Features.Auths.GoogleSignIn;
using SMS.UseCases.Interfaces;

namespace SMS.Infrastructure.ExternalServices;

public sealed class GoogleAuthentication(
    HttpClient client,
    ILogger<GoogleAuthentication> logger,
    IOptionsMonitor<GoogleAuthenticationOptions> googleAuthenticationOptions) : IGoogleAuthentication
{
    public string GetGoogleAuthUrl()
    {
        var clientId = googleAuthenticationOptions.CurrentValue.ClientId;
        var redirectUri = googleAuthenticationOptions.CurrentValue.RedirectUri;
        var scope = googleAuthenticationOptions.CurrentValue.Scope;

        var url = googleAuthenticationOptions.CurrentValue.GoogleUrl
            .Replace("{clientId}", clientId)
            .Replace("{redirectUri}", Uri.EscapeDataString(redirectUri))
            .Replace("{scope}", Uri.EscapeDataString(scope));

        return url;
    }

    public async Task<GoogleUserResponse?> GetGoogleUserAsync(string code)
    {
        // 1. Prepare form data
        var formData = new Dictionary<string, string>
        {
            { "client_id", googleAuthenticationOptions.CurrentValue.ClientId }, // The application's client ID
            { "client_secret", googleAuthenticationOptions.CurrentValue.ClientSecret }, // The application's client secret
            { "code", code }, // Code to log in from Google
            { "redirect_uri", googleAuthenticationOptions.CurrentValue.RedirectUri }, // Link of back end defined on Google Api
            { "grant_type", "authorization_code" }
        };

        var encodedContent = new FormUrlEncodedContent(formData);

        // 2. Call token endpoint
        var googleTokenResponse =
            await client.PostAsync(googleAuthenticationOptions.CurrentValue.GoogleAuthTokenEndpoint, encodedContent);

        // Ensure the request was successful
        if (!googleTokenResponse.IsSuccessStatusCode)
        {
            var errorBody = await googleTokenResponse.Content.ReadAsStringAsync();

            logger.LogError("Google Token API failed. StatusCode: {StatusCode}, Response: {Response}", googleTokenResponse.StatusCode, errorBody);

            return null;
        }

        // Read the response content as a string.
        var googleTokenJson = await googleTokenResponse.Content.ReadAsStringAsync();

        var googleTokenResult = JsonConvert.DeserializeObject<GoogleTokenResponse>(googleTokenJson);

        if (googleTokenResult == null)
        {
            logger.LogError("Failed to deserialize GoogleTokenResponse. Raw: {Raw}", googleTokenJson);
            return null;
        }

        // 3. Call user info endpoint
        var userInfoRequest = new HttpRequestMessage(HttpMethod.Get,
            googleAuthenticationOptions.CurrentValue.GoogleContactInfoEndpoint + googleTokenResult.AccessToken);
        userInfoRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", googleTokenResult.IdToken);

        var userInfoResponse = await client.SendAsync(userInfoRequest);

        if (!userInfoResponse.IsSuccessStatusCode)
        {
            var errorBody = await userInfoResponse.Content.ReadAsStringAsync();

            logger.LogError("Google UserInfo API failed. StatusCode: {StatusCode}, Response: {Response}", userInfoResponse.StatusCode, errorBody);

            return null;
        }

        var userJson = await userInfoResponse.Content.ReadAsStringAsync();

        var googleUserResponse = JsonConvert.DeserializeObject<GoogleUserResponse>(userJson);

        if (googleUserResponse == null)
        {
            logger.LogError("Failed to deserialize GoogleUserResponse. Raw: {Raw}", userJson);
            return null;
        }

        return googleUserResponse;
    }
}