using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Animator))]
	public class UFOAC : MonoBehaviour 
	{
		public bool setAnimatorParams = true;

		Animator _anim;

		public float Speed { get; set; }
		public float HDirection { get; set; }

		void Awake ()
		{
			_anim = GetComponent <Animator> ();
		}

		void Update ()
		{
			if (_anim != null && setAnimatorParams) 
			{
				_anim.SetFloat (UFOACHash.SpeedFloat, Speed);
				_anim.SetFloat (UFOACHash.HDirectionFloat, HDirection);
			}
		}
	}

	[System.Serializable]
	public static class UFOACHash
	{
		public static string SpeedFloat = "Speed";
		public static string HDirectionFloat = "HDirection";
	}
}