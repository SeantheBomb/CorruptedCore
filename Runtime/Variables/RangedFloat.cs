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
}

[System.Serializable]
public class RangedAngle : RangedFloat
{

}