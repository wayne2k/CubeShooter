using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class EnemyCubeMovement : MonoBehaviour 
	{
		public float speed = 2f;
		public bool initForwardDirection = false;
		public Vector3 moveDirection;

		[SerializeField] Vector3 _currentVelocity;

		void Awake ()
		{
			if (initForwardDirection)
				moveDirection = transform.forward;		
		}

		void FixedUpdate ()
		{
			_currentVelocity = rigidbody.velocity;		
		}

		public void Move ()
		{
			rigidbody.velocity = moveDirection * speed;
		}

		public void Move (Vector3 direction)
		{
			moveDirection = direction;
			rigidbody.velocity = moveDirection * speed;
		}

		public void Stop ()
		{
			rigidbody.velocity = Vector3.zero;
		}
	}
}