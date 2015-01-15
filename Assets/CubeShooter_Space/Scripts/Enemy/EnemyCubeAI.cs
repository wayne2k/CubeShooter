using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (EnemyCubeMovement))]
	public class EnemyCubeAI : MonoBehaviour 
	{
		public float chanceOfStopping = 0.1f;
		public bool stopAtTarget;
		public Transform target;
		public float stopDIstance = 5.0F;

		[SerializeField] float _distanceTo;

		EnemyCubeMovement _movement;
		[SerializeField] DebugEnemyCubeAI _debugAI;

		void Awake () 
		{
			_movement = GetComponent <EnemyCubeMovement> ();
			_movement.moveDirection = transform.forward;

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if (player != null)
				target = player.transform;
		}

		void Start ()
		{
			float randomValue = Random.value;
			stopAtTarget = (randomValue <= chanceOfStopping);

			Debug.Log (randomValue, gameObject);
		}

		void Update () 
		{
			if (_debugAI.move) 
			{
				_movement.Move ();		
				_debugAI.move = false;
			}
			else if (_debugAI.stop)
			{
				_movement.Stop ();
				_debugAI.stop = false;
			}

			if (stopAtTarget && AtTargetDistance ()) 
			{
				_movement.Stop ();		
			}
		}

		bool AtTargetDistance ()
		{
			if (target != null) 
			{
				_distanceTo = Vector3.Distance (target.position, transform.position);
				
				if (_distanceTo <= stopDIstance)
					return true;
			}

			return false;
		}
	}

	[System.Serializable]
	public class DebugEnemyCubeAI
	{
		public bool move;
		public bool stop;
	}
}