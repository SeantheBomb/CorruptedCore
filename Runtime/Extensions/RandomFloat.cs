using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Corrupted
{

    public static class RandomFloat
    {
        public static float Range(RangedFloat range)
        {
            return Range(range.minValue, range.maxValue);
        }

        public static float Range(float minValue, float maxValue)
        {
            return Random.Range(minValue, maxValue);
        }
    }

}