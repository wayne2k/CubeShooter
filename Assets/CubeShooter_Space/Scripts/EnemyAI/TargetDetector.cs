using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class TargetDetectorParams
	{
		public Transform target;
		public Vector2 targetGoalRange = new Vector2 (5.0f, 5.0f);
	}

	public class TargetDetector : MonoBehaviour 
	{
		public TargetDetectorParams defaultParams;
		TargetDetectorParams _overrideParams;
		public TargetDetectorParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		TargetDetectorParams settings { get { return OverrideParams ?? defaultParams; } }

		public float targetDistance = 0.0f;
		public bool targetReached;

		void Update ()
		{
			CalculateDistance ();
		}

		void CalculateDistance ()
		{
			if (settings.target != null) 
			{
				targetDistance = Vector3.Distance (settings.target.position, transform.position);
				
				if (targetDistance <= settings.targetGoalRange.RandomFromRange ())
				{
					targetReached = true;
				}
				else
				{
					targetReached = false;
				}
			}
		}
	}
}