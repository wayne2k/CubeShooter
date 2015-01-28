using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	[System.Serializable]
	public class Boundry
	{
		public Vector3 axisToClamp = Vector3.zero;
		public float xMin, xMax, yMin, yMax, zMin, zMax;
		
		public float ClampX (float value) {
			return Mathf.Clamp (value, xMin, xMax);
		}
		
		public float ClampY (float value) {
			return Mathf.Clamp (value, yMin, yMax);
		}
		
		public float ClampZ (float value) {
			return Mathf.Clamp (value, zMin, zMax);
		}
		
		public Vector3 ClampAll (Vector3 value)
		{
			return new Vector3 
				(
					Mathf.Clamp(value.x, xMin, xMax), 
					Mathf.Clamp(value.y, yMin, yMax), 
					Mathf.Clamp(value.z, zMin, zMax)
					);
		}
		
		public Vector3 ClampOnAxis (Vector3 value)
		{
			Vector3 clamped = value;
			
			if (axisToClamp.x != 0)
				clamped.x =	Mathf.Clamp (clamped.x, xMin, xMax);
			if (axisToClamp.y != 0)
				clamped.y =	Mathf.Clamp (clamped.y, yMin, yMax);
			if (axisToClamp.z != 0)
				clamped.z =	Mathf.Clamp (clamped.z, zMin, zMax);
			
			return clamped;
		}
	}
}