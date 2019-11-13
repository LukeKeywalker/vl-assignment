using System;

namespace Core.SystemExtensions
{
    public static class IntExtensions
    {
        public static void InRange(this Int64 n, Action<int> a)
        {
            for (int i = 0; i < n; ++i) a(i);
        }

        public static void InRange(this Int32 n, Action<int> a)
        {
            for (int i = 0; i < n; ++i) a(i);
        }
    }
}