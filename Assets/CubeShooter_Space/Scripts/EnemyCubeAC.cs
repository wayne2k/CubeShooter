using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter
{
	public class EnemyCubeAC: MonoBehaviour 
	{
		public bool debugOn = false;
		public KeyCode debugAttackKey = KeyCode.L;

		Animator _anim;

		public bool Attack { get; set; }

		void Start () 
		{
			_anim = GetComponent <Animator> ();
		}

		void Update ()
		{
			if (debugOn) 
			{
				if (Input.GetKey (debugAttackKey)) 
						Attack = true;
				else
						Attack = false;
			}

			if (_anim != null) 
			{
				_anim.SetBool (EnemyCubeHash.AttackBool, Attack);	
			}
		}
	}

	[SerializeField]
	public static class EnemyCubeHash
	{
		public static string AttackBool = "Attack";
	}
}

/*
	public Vector3 rotateDirection = Vector3.right;
		public float rotateSpeed = 50f;

		void Update () 
		{
			transform.Rotate (rotateDirection, rotateSpeed * Time.deltaTime);
		}

*/