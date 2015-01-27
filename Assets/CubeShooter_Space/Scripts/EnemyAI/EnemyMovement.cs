using UnityEngine;
using System.Collections;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class EnemyMovementParams
	{
		public Vector2 speedRange = new Vector2 (3f, 3f);
		public bool moveOnStart = true;
	}

	[RequireComponent (typeof (Rigidbody))]
	public class EnemyMovement : MonoBehaviour
	{
		public EnemyMovementParams defaultParams;
		EnemyMovementParams _overrideParams;
		public EnemyMovementParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		EnemyMovementParams settings { get { return OverrideParams ?? defaultParams; } }

		Rigidbody _rb;
		Vector3 initDirection = Vector3.zero;

		public bool Moving { get { return CurrentVelocity.z <= -0.1f && CurrentVelocity.z >= 0.1f; } }
		public Vector3 CurrentVelocity { get { return _rb.velocity;	} }
		public float Speed { get { return settings.speedRange.RandomFromRange (); } }

		void Awake ()
		{
			_rb = GetComponent <Rigidbody> ();
			_rb.useGravity = false;
			_rb.constraints = RigidbodyConstraints.FreezeRotation;

			initDirection = transform.forward;
		}

		void Start ()
		{
			if (settings.moveOnStart) {
				Move ();		
			}
		}

		void Update ()
		{
			initDirection = transform.forward;
		}

		public void Move ()
		{
			initDirection.x = 0f;
			_rb.velocity = initDirection * Speed;
		}

		public void Stop ()
		{
			_rb.velocity = Vector3.zero;
		}
	}
}