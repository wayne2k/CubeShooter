using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
	public static float RandomFromRange (this Vector2 value) 
	{
		return Random.Range (value.x, value.y);
	}
}
