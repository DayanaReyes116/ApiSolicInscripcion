using System;

namespace ApiSolicInscripcion.Infrastructure.Helpers
{
    public class DateUtils
    {
        public static DateTime GetCurrentDate()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
        }
    }
}


