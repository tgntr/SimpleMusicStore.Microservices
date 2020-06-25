using SimpleMusicStore.Constants;
using System;
using System.Linq;
using System.Net;

namespace SimpleMusicStore.Extensions
{
    public static class DiscogsExtensions
    {
        public static string FindDiscogsId(this Uri uri)
        {
            var id = uri.AbsolutePath.Split(DiscogsConstants.PARAMETER_SPLITTER).Last();

            return id;
        }

        public static void AddHeaders(this WebClient client)
        {
            client.Headers.Add("user-agent", "SimpleMusicStore2");
        }
    }
}
