using System;

namespace Core.SystemExtensions
{
    public static class ObjectExtensions
    {
        public static T GetOrCreate<T>(this object o, T value, Func<T> create)
        {
            return value == null? create() : value;
        }
    }
}