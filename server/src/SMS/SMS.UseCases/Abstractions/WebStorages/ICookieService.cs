namespace SMS.UseCases.Abstractions.WebStorages;

public interface ICookieService
{
    void Set(string key, string value, long expiresAt);

    string? Get(string key);

    void Delete(string key);
}