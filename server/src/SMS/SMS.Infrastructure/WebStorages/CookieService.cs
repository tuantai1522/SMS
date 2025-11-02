using Microsoft.AspNetCore.Http;
using SMS.UseCases.Abstractions.WebStorages;

namespace SMS.Infrastructure.WebStorages;

public sealed class CookieService(IHttpContextAccessor http) : ICookieService
{
    public void Set(string key, string value, DateTimeOffset expiresAt)
    {
        http.HttpContext?.Response.Cookies.Append(key, value, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,                
            SameSite = SameSiteMode.None,
            Expires = expiresAt,
            Path = "/"
        });
    }

    public string? Get(string key)
    {
        return http.HttpContext?.Request.Cookies[key];
    }

    public void Delete(string key)
    {
        http.HttpContext?.Response.Cookies.Delete(key, new CookieOptions
        {
            Path = "/",
            Secure = true,
            SameSite = SameSiteMode.None,
            HttpOnly = true
        });
    }
}