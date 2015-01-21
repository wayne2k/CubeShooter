using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RollRoti.CubeShooter_Space
{
	public class AttackController : MonoBehaviour 
	{
		public WeaponController weapon;
		public Transform target;

		public bool Attack;
		public bool AimAtTarget;

		void Update ()
		{
			if (weapon == null)
				return;

			FireWeapon ();
			RotateWeapon ();
		}

		void RotateWeapon ()
		{
			if (weapon == null)
				return;

			if (AimAtTarget && target != null) 
			{
				Vector3 targetVector= target.position - transform.position;

				if (targetVector != Vector3.zero)
					weapon.transform.rotation = Quaternion.LookRotation(targetVector);
			}
			else
			{
				weapon.transform.rotation = Quaternion.identity;
			}
		}

		public void FireWeapon ()
		{
			if (Attack && weapon != null)
				weapon.FireWeapon ();
		}
	}
}