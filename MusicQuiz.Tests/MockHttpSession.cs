using Microsoft.AspNetCore.Http;

public class MockHttpSession : ISession
{
    private readonly Dictionary<string, byte[]> _sessionStorage = [];

    public IEnumerable<string> Keys => _sessionStorage.Keys;

    public string Id => Guid.NewGuid().ToString();

    public bool IsAvailable => true;

    public void Clear() => _sessionStorage.Clear();

    public void Remove(string key) => _sessionStorage.Remove(key);

    public void Set(string key, byte[] value) => _sessionStorage[key] = value;

    public bool TryGetValue(string key, out byte[] value)
    {
        if (_sessionStorage.TryGetValue(key, out var objValue))
        {
            value = objValue;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Asynchronously loads the session data.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task LoadAsync(CancellationToken cancellationToken = default)
    {
        // Simulate loading session data (no-op for mock)
        return Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronously commits the session data.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        // Simulate committing session data (no-op for mock)
        return Task.CompletedTask;
    }
}
