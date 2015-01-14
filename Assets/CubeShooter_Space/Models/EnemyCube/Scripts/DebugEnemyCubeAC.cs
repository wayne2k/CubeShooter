using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (EnemyCubeAC))]
	public class DebugEnemyCubeAC : MonoBehaviour 
	{
		public bool debugControls = false;
		public string attackButton = "Fire2";

		EnemyCubeAC _enemyCubeAC;
		
		void Awake ()
		{
			_enemyCubeAC = GetComponent <EnemyCubeAC> ();
		}
		
		void Update ()
		{
			if (_enemyCubeAC != null && debugControls) 
			{
				_enemyCubeAC.Attack = Input.GetButton (attackButton);
			}
		}
	}
}