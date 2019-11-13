using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.CollectionsExtensions
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Randomized<T>(this List<T> list, Func<int> rng)
        {
            return list.OrderBy(x => rng()).ToArray();
        }
    }
}