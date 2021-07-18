using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Constants
{
    public static class CommonConstants
    {
        public const string
            BUCKET_NAME = "simplemusicstore",
            MP3 = "audio/mpeg",
            STORAGE_URL = @"https://storage.googleapis.com/simplemusicstore/";//TODO maybe this is env variable for appsettings
        public const int PAGE_SIZE = 24;
    }
}
