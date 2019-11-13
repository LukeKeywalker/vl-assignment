using UnityEngine;
namespace Core.UnityEngineExtensions 
{
    public static class Vector3Extensions
    {
        public static Vector3 xzProjection(this Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z);
        }

        public static Vector3 xzProjection(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }
    }
}