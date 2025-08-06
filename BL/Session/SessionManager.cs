using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace GitHubRepoSearchApi.BL.Session
{
    public static class SessionManager
    {
        public static void SetObject<T>(ISession session, string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        public static T? GetObject<T>(ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
    }
}
