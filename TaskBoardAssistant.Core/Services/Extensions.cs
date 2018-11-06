using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoardAssistant.Common.Services
{
    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
             TKey key,
             TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            return dictionary.GetValueOrDefault(key, default(TValue));
        }

        public static DateTime? ToRelativeDateTime(this string s)
        {
            var split = s.Split('@');
            if (split.Length != 2)
                throw new Exception("Not a valid relative datetime");
            var date = split[0];
            var time = split[1];

            DateTime dateOnly = date.ToDate();
            TimeSpan timeOnly = time.ToTime();

            return dateOnly.Date.Add(timeOnly);
        }

        private static DateTime GetDay(string s)
        {
            var now = DateTime.Now.Date;
            switch (s.ToLower())
            {
                case "today":
                    return now;
                case "tomorrow":
                    return now.AddDays(1);
                case "sunday":
                    return now.NextDayOfWeek(DayOfWeek.Sunday);
                case "monday":
                    return now.NextDayOfWeek(DayOfWeek.Monday);
                case "tuesday":
                    return now.NextDayOfWeek(DayOfWeek.Tuesday);
                case "wednesday":
                    return now.NextDayOfWeek(DayOfWeek.Wednesday);
                case "thursday":
                    return now.NextDayOfWeek(DayOfWeek.Thursday);
                case "friday":
                    return now.NextDayOfWeek(DayOfWeek.Friday);
                case "saturday":
                    return now.NextDayOfWeek(DayOfWeek.Saturday);
                default:
                    throw new Exception("Invalid relative date");
            }
        }

        public static DateTime ToDate(this string s)
        {
            if (s.Contains('+'))
            {
                var split = s.Split('+');
                var day = GetDay(split[0]);
                var plus = int.Parse(split[1]);
                return day.AddDays(plus);
            }
            return GetDay(s);
        }

        public static TimeSpan ToTime(this string s)
        {
            if (TimeSpan.TryParse(s, out TimeSpan result))
                return result;
            return default(TimeSpan);
        }

        public static DateTime NextDayOfWeek(this DateTime d, DayOfWeek day)
        {
            return d.AddDays(d.DayOfWeek.DaysToAdd(day));
        }

        public static int DaysToAdd(this DayOfWeek current, DayOfWeek target)
        {
            if(current > target)
            {
                return 7 - (current - target);
            }
            if(current < target)
            {
                return target - current;
            }
            return 0;
        }

        public static DateTime? ToDateTime(this string s)
        {
            if (DateTime.TryParse(s, out DateTime result))
                return result;
            return null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> data)
        {
            return data == null || !data.Any();
        }
    }
}
