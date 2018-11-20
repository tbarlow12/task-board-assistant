using System;
using System.Collections.Generic;
using System.Linq;
using TaskBoardAssistant.Core.Models.Resources;
using Newtonsoft.Json;

namespace TaskBoardAssistant.Core.Services
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

        public static TValue GetKeyOrThrow<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string message)
        {
            try
            {
                return dictionary[key];
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException(message);
            }
        }

        public static bool NotNullAndEquals<T>(this T t1, T t2)
        {
            return t1 != null && t1.Equals(t2);
        }

        public static bool IsNullOrEquals<T>(this T t1, T t2)
        {
            return t1 == null || t1.Equals(t2);
        }

        public static bool IsNullOrEqualsIgnoreCase(this string t1, string t2)
        {
            return t1 == null || (t2 != null && t1.ToLower().Equals(t2.ToLower()));
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

        public static DateTime? ToDateTimeOrRelative(this string s)
        {
            if (s == null)
                return null;
            var dt = s.ToDateTime();
            if (dt == null)
                dt = s.ToRelativeDateTime();
            return dt;
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

        public static int Count<T>(this IEnumerable<T> source)
        {
            ICollection<T> c = source as ICollection<T>;
            if (c != null)
                return c.Count;

            int result = 0;
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    result++;
            }
            return result;
        }

        public static IEnumerable<ITaskList> ListsInBoards(this IEnumerable<ITaskBoard> boards)
        {
            var result = new List<ITaskList>();
            foreach(var board in boards)
            {
                result.AddRange(board.Lists);
            }
            return result;
        }

        public static IEnumerable<ITaskCard> CardsInLists(this IEnumerable<ITaskList> lists)
        {
            var result = new List<ITaskCard>();
            foreach (var list in lists)
            {
                result.AddRange(list.Cards);
            }
            return result;
        }

        public static IEnumerable<ITaskLabel> LabelsInCards(this IEnumerable<ITaskCard> cards)
        {
            var result = new List<ITaskLabel>();
            foreach (var card in cards)
            {
                result.AddRange(card.Labels);
            }
            return result;
        }

        public static IEnumerable<ITaskResource> GetByName(this IEnumerable<ITaskResource> resources, string name, bool case_sensitive=false)
        {
            var result = new List<ITaskResource>();
            string targetName = (case_sensitive) ? name : name.ToLower();
            foreach(var resource in resources)
            {
                if(targetName.Equals((case_sensitive) ? resource.Name : resource.Name.ToLower()))
                {
                    yield return resource;
                }
            }
        }

        public static ITaskResource GetFirstByName(this IEnumerable<ITaskResource> resources, string name, bool case_sensitive = false)
        {
            foreach(var resource in resources.GetByName(name, case_sensitive))
            {
                return resource;
            }
            throw new InvalidOperationException("No resource by the name: " + name);
        }

        public static TChild CastToChild<TParent, TChild>(this TParent parent)
        {
            var serializedParent = JsonConvert.SerializeObject(parent);
            return JsonConvert.DeserializeObject<TChild>(serializedParent);
        }

        public static IEnumerable<TChild> CastIEnumerableToChild<TParent, TChild>(this IEnumerable<TParent> parents)
        {
            foreach(var parent in parents)
            {
                yield return parent.CastToChild<TParent, TChild>();
            }
        }
    }
}
