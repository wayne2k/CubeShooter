using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class EnemyAIParams
	{
		[Range (0.0f, 1.0f)]
		public float chanceOfEvade = 0.0f;
	}

	[RequireComponent (typeof (EnemyMovement))]
	[RequireComponent (typeof (EnemyEvasiveManouver))]
	public class EnemyAI : MonoBehaviour 
	{
		public EnemyAIParams defaultParams;
		public EnemyAIParams overrideParams { get; set; }
		EnemyAIParams settings { get { return  overrideParams ?? defaultParams; } }

		EnemyMovement _movement;
		EnemyEvasiveManouver _manouver;

		void Awake ()
		{
			_movement = GetComponent <EnemyMovement> ();
			_manouver = GetComponent <EnemyEvasiveManouver> ();

			_movement.enabled = false;
			_manouver.enabled = false;
		}

		void Start ()
		{

		}
	}
}