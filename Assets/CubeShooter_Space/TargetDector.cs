using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class TargetDector : MonoBehaviour 
	{
		public Transform target;
		public float targetGoal = 5.0F;
		public float targetDistance = 0.0f;
		public bool targetReached;

		void Update ()
		{
			CalculateDistance ();
		}

		void CalculateDistance ()
		{
			if (target != null) 
			{
				targetDistance = Vector3.Distance (target.position, transform.position);
				
				if (targetDistance <= targetGoal)
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