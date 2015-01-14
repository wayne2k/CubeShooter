using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class EnemyCubeAttack : MonoBehaviour 
	{
		public Transform other;
		public float closeDistance = 5.0F;

		public float distance = 0.0f;

		void Update() 
		{
			if (other) 
			{
//				Vector3 offset = other.position - transform.position;
//				float sqrLen = offset.sqrMagnitude;
//				if (sqrLen < closeDistance * closeDistance)
//					print("The other transform is close to me!");

				distance = Vector3.Distance (other.position, transform.position);

				if (distance <= closeDistance)
					print("The other transform is close to me!");				
			}
		}
	}
}