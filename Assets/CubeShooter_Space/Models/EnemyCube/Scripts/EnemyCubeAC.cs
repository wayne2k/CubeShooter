using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Animator))]
	public class EnemyCubeAC : MonoBehaviour 
	{
		public bool setAnimatorParams = true;
		
		Animator _anim;
		
		public bool Attack { get; set; }
		
		void Awake ()
		{
			_anim = GetComponent <Animator> ();
		}
		
		void Update ()
		{
			if (_anim != null && setAnimatorParams) 
			{
				_anim.SetBool (EnemyCubeACHash.AttackBool, Attack);
			}
		}
	}
	
	[System.Serializable]
	public static class EnemyCubeACHash
	{
		public static string AttackBool = "Attack";
	}
}