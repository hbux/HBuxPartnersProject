using System.Text.Json;

namespace HBPWebUI.Extensions
{
    public static class SessionExtensions
    {
        private const string sessionKey = "HBP_Basket_Session";

        public static void Set<T>(this ISession session, T value)
        {
            session.SetString(sessionKey, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session)
        {
            var value = session.GetString(sessionKey);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
