using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class EnemyMovement : MonoBehaviour 
	{

	}


}

/*
[System.Serializable]
	public class SineWave
	{
		public bool useSineWave = false;
		public float frequency = 10.0f; // Speed of sine movement
		public float magnitude = 0.5f; // Size of sine movement
		public Vector3 sineAxis = Vector3.right;

		public Vector3 Direction { 
			get { 
				if (useSineWave == false)
					return Vector3.zero;

				return sineAxis * Mathf.Sin (Time.time * frequency) * magnitude; 
			} 
		}
	}
	*/

/*
[RequireComponent (typeof (Rigidbody))]
	public class EnemyMovement : MonoBehaviour 
	{
		public bool canMove = true;
		public float speed = 2f;
		public Vector3 moveDirection;
		public SineWave sineWave;


		bool _stoppedMoving = false;
		[SerializeField] Vector3 _currentVelocity;

		void Awake ()
		{
			rigidbody.useGravity = false;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

			moveDirection = transform.forward;
			sineWave.sineAxis = transform.right;
		}
		
		void FixedUpdate ()
		{
			if (Input.GetAxisRaw ("Vertical") > 0f)
			    Move ();
			else if (Input.GetAxisRaw ("Vertical") < 0f)
				Stop ();

			if (canMove)
				rigidbody.velocity += sineWave.Direction;

			_currentVelocity = rigidbody.velocity;
		}

		public void Move ()
		{
			if (canMove) 
			{
				rigidbody.velocity = (moveDirection + sineWave.Direction) * speed;	
			}
		}

		public void Stop ()
		{
			rigidbody.velocity = Vector3.zero;
		}
	}

	[System.Serializable]
	public class SineWave
	{
		public bool useSineWave = false;
		public float frequency = 10.0f; // Speed of sine movement
		public float magnitude = 0.5f; // Size of sine movement
		public Vector3 sineAxis = Vector3.right;

		public Vector3 Direction { 
			get { 
				if (useSineWave == false)
					return Vector3.zero;

				return sineAxis * Mathf.Sin (Time.time * frequency) * magnitude; 
			} 
		}
	}
	*/