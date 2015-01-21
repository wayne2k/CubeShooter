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

		Quaternion _initRotation;

		void Awake ()
		{
			_initRotation = transform.rotation;
		}

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
				weapon.transform.rotation = _initRotation;
			}
		}

		public void FireWeapon ()
		{
			if (Attack && weapon != null)
				weapon.FireWeapon ();
		}
	}
}