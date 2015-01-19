using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (WeaponController))]
	public class DebugWeaponController : MonoBehaviour 
	{
		public string FireButton = "Fire1";

		WeaponController _weapon;

		void Awake ()
		{
			_weapon = GetComponent <WeaponController> ();
		}

		void Update () 
		{
			if (Input.GetButton (FireButton)) 
			{
				_weapon.FireWeapon ();
			}
		}
	}
}