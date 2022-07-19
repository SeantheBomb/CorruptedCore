using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public static class CorruptedExtensions
    {

        public static Vector3 PercentageAlongAxis(this Vector3 vector, Vector3 axis)
        {
            return axis * (Vector3.Dot(axis.normalized, vector.normalized) * vector.magnitude);
        }

        public static bool IsGenericList(this object o)
        {
            var oType = o.GetType();
            return oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        public static Vector3 Multiply(this Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

    }
}