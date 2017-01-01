﻿using System;

namespace WebCrawler.TrackingService
{
    /// <summary>
    /// Convert a URI into an actor-friendly name
    /// </summary>
    public static class ActorSafeNameFromUri
    {
        public static string ToActorName(this Uri uri)
        {
            return Uri.EscapeDataString(uri.ToString());
        }
    }
}
