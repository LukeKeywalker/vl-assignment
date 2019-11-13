using System;

namespace Core.SystemExtensions
{
    public static class DisposableExtension
    {
        public static void SafeDispose (this IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose ();
            }
        }
    }
}