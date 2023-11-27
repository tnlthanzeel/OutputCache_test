﻿using OutputCache_test.SharedKernal.Models;
using TimeZoneConverter;

namespace OutputCache_test.SharedKernal.Extensions;

public static class TimeZoneExtension
{
    private static readonly IReadOnlyList<TimeZoneModel> _timeZones = TimeZoneInfo.GetSystemTimeZones()
                                                                                  .Select(tz => new TimeZoneModel(tz.DisplayName, tz.Id))
                                                                                  .ToList();
    public static DateTimeOffset GetLocalTime(this DateTimeOffset dateTimeOffset, string timeZoneId)
    {
        TimeZoneInfo timeZone = TZConvert.GetTimeZoneInfo(timeZoneId);

        var clientdatetime = dateTimeOffset.ToOffset(timeZone.BaseUtcOffset);
        return clientdatetime;
    }
}
