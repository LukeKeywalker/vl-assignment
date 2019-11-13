using System;

namespace Core.SystemExtensions
{
    public static class ArrayExtensions 
    {
        public static bool Contains<T> (this T[] array, T element)
        {
            return !Array.Find(array, x => x.Equals(element)).Equals(null);
        }

        public static T Find<T>(this T[] array, Predicate<T> predicate)
        {
            return Array.Find(array, predicate);
        }

        public static T Find<T>(this T[,] array, Predicate<T> predicate)
        {
            T result = default(T);
            var rowLowerLimit = array.GetLowerBound(0);
            var rowUpperLimit = array.GetUpperBound(0);

            var colLowerLimit = array.GetLowerBound(1);
            var colUpperLimit = array.GetUpperBound(1);

            bool breakFlag = false;
            for (int row = rowLowerLimit; row <= rowUpperLimit && breakFlag == false; row++)
            {
                for (int col = colLowerLimit; col <= colUpperLimit && breakFlag == false; col++)
                {
                    T x = array[row, col];
                    if (predicate(x))
                    {
                        result = x;
                        breakFlag = true;
                    }
                }
            }

            return result;
        }

        public static bool Exists<T>(this T[,] array, Predicate<T> predicate) where T: class
        {
            return array.Find(predicate) != default(T);
        }

        public static void ForEach<T>(this T[, ] array, Action<T> action)
        {
            foreach (T e in array)
            {
                action(e);
            }
        }
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            foreach (T e in array)
            {
                action(e);
            }
        }
    }
}