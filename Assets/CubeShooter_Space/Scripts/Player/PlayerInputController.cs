using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (PlayerMovement))]
	[RequireComponent (typeof (AttackController))]
	public class PlayerInputController : MonoBehaviour 
	{
		public string horizontalBtn = "Horizontal";
		public string verticalBtn = "Vertical";
		public string Fire1Btn = "Fire1";
		public string Fire2Btn = "Fire2";

		float _h, _v;

		PlayerMovement _movement;
		AttackController _attack;

		void Awake ()
		{
			_movement = GetComponent <PlayerMovement> ();
			_attack = GetComponent <AttackController> ();
		}

		void Update ()
		{
//			_h = Input.GetAxis (horizontalBtn);
//			_v = Input.GetAxis (verticalBtn);

			_attack.Attack = Input.GetButton (Fire1Btn);
			_attack.AimAtTarget = Input.GetButton (Fire2Btn);
		}

		void FixedUpdate ()
		{
			_h = Input.GetAxis (horizontalBtn);
			_v = Input.GetAxis (verticalBtn);

			_movement.Move (_h, _v);
		}
	}
}