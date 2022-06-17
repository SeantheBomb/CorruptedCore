using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Corrupted
{

    public static class SeanHelperMath
    {

        public static Vector3 PercentageAlongAxis(this Vector3 vector, Vector3 axis)
        {
            return axis * (Vector3.Dot(axis.normalized, vector.normalized) * vector.magnitude);
        }

    }
}