using System;
using System.Collections.Generic;

namespace Core.CollectionsExtensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            TValue value;
            return dict.TryGetValue(key, out value)
                ? value
                : default(TValue);
        }

        public static TMapValue MapValueOrDefault<TMapValue, TKey, TValue>(this IDictionary<TKey, TValue> dict,
            TKey key,
            Func<TValue, TMapValue> valueFunc,
            TMapValue defaultConstFunc)
        {
            TValue value;
            return dict.TryGetValue(key, out value)
                ? valueFunc.Invoke(value)
                : defaultConstFunc;
        }

        public static RType ForValueOrDefault<TKey, TValue, RType>(this IDictionary<TKey, TValue> dict, TKey key,
            Func<TValue, RType> valueAction,
            Func<RType> defaultAction)
        {
            TValue value;
            if (dict.TryGetValue(key, out value))
            {
               return valueAction.Invoke(value);
            }
            else
            {
               return defaultAction.Invoke();
            }
        }

        public static void ForValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key,
            Action<TValue> valueAction)
        {
            TValue value;
            if (dict.TryGetValue(key, out value))
            {
                valueAction.Invoke(value);
            }
        }
    }
}