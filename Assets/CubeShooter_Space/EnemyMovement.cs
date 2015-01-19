using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class EnemyMovementParams
	{
		public float speed = 3f;
	}

	[RequireComponent (typeof (Rigidbody))]
	public class EnemyMovement : MonoBehaviour
	{
		public EnemyMovementParams defaultParams;
		EnemyMovementParams _overrideParams;
		public EnemyMovementParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		EnemyMovementParams settings { get { return OverrideParams ?? defaultParams; } }

		Rigidbody _rb;

		public bool Moving {
			get { return CurrentVelocity.z <= -0.1f && CurrentVelocity.z >= 0.1f; }
		}

		public Vector3 CurrentVelocity {
			get {
				return _rb.velocity;		
			}
		}

		void Awake ()
		{
			_rb = GetComponent <Rigidbody> ();
		}

		public void Move ()
		{
			_rb.velocity = transform.forward * settings.speed;
		}

		public void Stop ()
		{
			_rb.velocity = Vector3.zero;
		}
	}
}

/*
 * How to Calculating distance:
 * 
	Vector3 offset = other.position - transform.position;
	float sqrLen = offset.sqrMagnitude;
	if (sqrLen < closeDistance * closeDistance)
		print("The other transform is close to me!");

 */

/*
 * 
 * public Transform target;
		public float distanceToStop = 5.0F;
		public float distanceFromTarget = 0.0f;
		public bool atTarget;
		public Vector2 waitTime;
 * 
		void Update ()
		{
			CalculateDistance ();

			if (settings.atTarget && _stoppedOnce == false) 
			{
				_stoppedOnce = true;
				Stop ();
				Invoke ("Forward", Random.Range (settings.waitTime.x, settings.waitTime.y));
			}
		}

		void CalculateDistance ()
		{
			if (settings.target) 
			{
				settings.distanceFromTarget = Vector3.Distance (settings.target.position, transform.position);
				
				if (settings.distanceFromTarget <= settings.distanceToStop)
				{
					settings.atTarget = true;
				}
				else
				{
					settings.atTarget = false;
				}
			}
		}

 */