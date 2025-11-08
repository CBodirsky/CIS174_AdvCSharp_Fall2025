using System.Text.Json;

public static class FavoriteManager
{
    private const string SessionKey = "Favorites";

    public static List<string> GetFavorites(ISession session)
    {
        var data = session.GetString(SessionKey);
        return string.IsNullOrEmpty(data) ? new List<string>() : JsonSerializer.Deserialize<List<string>>(data);
    }

    public static void AddFavorite(ISession session, string key)
    {
        var favorites = GetFavorites(session);
        if (!favorites.Contains(key))
        {
            favorites.Add(key);
            session.SetString(SessionKey, JsonSerializer.Serialize(favorites));
        }
    }

    public static void ClearFavorites(ISession session)
    {
        session.Remove(SessionKey);
    }
}
