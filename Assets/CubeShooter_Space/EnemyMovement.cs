using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class EnemyMovementParams
	{
		public float speed = 3f;
		public Transform target;
		public float distanceToStop = 5.0F;
		public float distanceFromTarget = 0.0f;
		public bool atTarget;
		public Vector2 waitTime;
	}

	[RequireComponent (typeof (Rigidbody))]
	public class EnemyMovement : MonoBehaviour
	{
		public EnemyMovementParams defaultParams;
		public EnemyMovementParams overrideParams { get; set; }
		EnemyMovementParams settings { get { return  overrideParams ?? defaultParams; } }

		bool _stoppedOnce;
		Rigidbody _rb;

		public Vector3 CurrentVelocity {
			get {
				return _rb.velocity;		
			}
		}

		void Awake ()
		{
			_rb = GetComponent <Rigidbody> ();
		}

		void Start ()
		{
			Forward ();
		}

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

		public void Forward ()
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