using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class BulletMovement : MonoBehaviour 
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
		public float lifeTime = 10f;

		public Vector3 _direction = Vector3.zero;
		public Vector3 _currentVelocity;
		public float _lifeTimeTimer;

		void Awake ()
		{
			rigidbody.useGravity = false;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}

		void Start ()
		{
			Initialize ();
		}

		void Update ()
		{
			if (_lifeTimeTimer > 0.0f) 
			{
				_lifeTimeTimer -= Time.deltaTime;		
			}
			else
				gameObject.SetActive (false);
		}

		void FixedUpdate ()
		{
			_currentVelocity = rigidbody.velocity;
		}

		public void Initialize ()
		{
			rigidbody.velocity = Vector3.zero;
			_lifeTimeTimer = lifeTime;

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