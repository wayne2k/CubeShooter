using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	public static class ExtensionMethods
	{
		public static float RandomFromRange (this Vector2 value) 
		{
			return Random.Range (value.x, value.y);
		}

		public static bool ToBool (this int value)
		{
			return (value == 1) ? true : false;
		}

		public static int ToInt (this bool value)
		{
			return (value) ? 1 : 0;
		}
	}
}