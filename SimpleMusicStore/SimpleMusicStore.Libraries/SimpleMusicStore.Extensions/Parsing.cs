using System;

namespace SimpleMusicStore.Extensions
{
    public static class Parsing
    {
        public static Uri AsUri(this string url)
        {
            return new Uri(url);
        }
    }
}
