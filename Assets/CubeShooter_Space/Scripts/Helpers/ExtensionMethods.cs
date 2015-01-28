using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	public static class ExtensionMethods
	{
		public static Vector3 RandomVector3 (Vector3 min, Vector3 max)
		{
			Vector3 _vector3 = Vector3.zero;

			_vector3.x = Random.Range (min.x, max.x);
			_vector3.y = Random.Range (min.y, max.y);
			_vector3.z = Random.Range (min.z, max.z);

			return _vector3;
		}

		public static float RandomFromRange (this Vector2 value) 
		{
			return Random.Range (value.x, value.y);
		}

		public static int RandomIntFromRange (this Vector2 value) 
		{
			return Random.Range ((int) value.x, (int) value.y);
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