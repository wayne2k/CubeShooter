using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class EnemyAttack : MonoBehaviour 
	{
		public Transform target;
		public Transform weapon;
		public GameObject bulletPfb;

		void Awake ()
		{
			InvokeRepeating ("Attack", 5f, 5f);
		}

		void Update ()
		{
			if (target != null)
			{
				Vector3 vectorToPlayer = target.transform.position - transform.position;
			
				weapon.rotation = Quaternion.LookRotation(vectorToPlayer);
			}
		}

		public void Attack ()
		{
			if (bulletPfb != null)
				Instantiate (bulletPfb, weapon.position, weapon.rotation);
		}
	}
}
