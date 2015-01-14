using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter
{
	[RequireComponent (typeof (Rigidbody))]
	public class EnemyCubeMovement : MonoBehaviour 
	{
		public enum DirectionTypes
		{
			TRANSFORM,
			VECTOR3
		}
		public enum MovementTypes
		{
			VELOCITY,
			FORCE
		}
		
		public DirectionTypes fwdDirectionType = DirectionTypes.TRANSFORM;
		public MovementTypes movementType = MovementTypes.VELOCITY;
		
		public float speed = 20f;
		public ForceMode forceMode = ForceMode.Impulse;

		public Vector3 _direction = Vector3.zero;
		public Vector3 _currentVelocity;

		void Awake ()
		{
			rigidbody.useGravity = false;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}
		
		void Start ()
		{
			Initialize ();
		}

		void FixedUpdate ()
		{
			_currentVelocity = rigidbody.velocity;
		}
		
		public void Initialize ()
		{
			rigidbody.velocity = Vector3.zero;

			if (fwdDirectionType == DirectionTypes.TRANSFORM)
				_direction = transform.forward;
			else if (fwdDirectionType == DirectionTypes.VECTOR3)
				_direction = Vector3.forward;
			
			if (movementType == MovementTypes.FORCE) 
			{
				rigidbody.AddForce (_direction * speed, forceMode);			
			}
			else if (movementType == MovementTypes.VELOCITY) 
			{
				rigidbody.velocity = _direction * speed;
			}
		}
	}
}