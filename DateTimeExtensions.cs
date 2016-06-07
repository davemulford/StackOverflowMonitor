using System;

namespace StackOverflowMonitor.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToReadableString(this DateTime dt)
        {
            TimeSpan ts = DateTime.UtcNow.Subtract(dt);

            if (ts.TotalSeconds <= 1)
            {
                return "just now";
            }
            else if (ts.TotalMinutes <= 1)
            {
                return $@"{ts.TotalSeconds} ago";
            }
            else if (ts.TotalHours <= 1)
            {
                return $@"{ts.TotalMinutes} ago";
            }
            else if (ts.TotalDays <= 1)
            {
                return $@"{ts.TotalHours} ago";
            }
            else
            {
                if (DateTime.UtcNow.Year == dt.Year)
                {
                    return $@"{dt:MMM dd}";
                }
                else
                {
                    return $@"{dt:MMM dd, yyyy}";
                }
            }
        }
    }
}
