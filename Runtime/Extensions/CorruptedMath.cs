using UnityEngine;

namespace Corrupted
{
    public static class CorruptedMath 
    {
        /// <summary>
        /// Returns the angle (in degrees) opposite the width side of a right triangle.
        /// </summary>
        /// <param name="width">The length of the opposite side (width).</param>
        /// <param name="length">The length of the adjacent side (length).</param>
        /// <returns>The angle in degrees.</returns>
        public static float GetAngleFromLengthAndWidth(float width, float length)
        {
            if (length == 0f)
            {
                Debug.LogWarning("Length cannot be zero when calculating an angle.");
                return 0f;
            }

            float angleRadians = Mathf.Atan(width / length);
            float angleDegrees = angleRadians * Mathf.Rad2Deg;

            return angleDegrees;
        }
    }
}
