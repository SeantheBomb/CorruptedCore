//using System;
using UnityEngine;

[System.Serializable]
public class RangedFloat
{
	public float minValue;
	public float maxValue;

	public float GetRandom()
    {
		return Random.Range(minValue, maxValue);
    }

    public static implicit operator float(RangedFloat value)
    {
        return value != null ? value.GetRandom() : 0;
    }

    public static implicit operator RangedFloat(float value)
    {
        return new RangedFloat() { minValue = value, maxValue = value };
    }
}

[System.Serializable]
public class RangedAngle : RangedFloat
{

}