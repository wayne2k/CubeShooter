using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class EnemyAIParams
	{
		[Range (0.0f, 1.0f)]
		public float chanceOfStopping = 1f;
		[Range (0.0f, 1.0f)]
		public float chanceOfEvading = 1f;
		[Range (0.0f, 1.0f)]
		public float chanceOfAttacking = 1f;
	}

	[RequireComponent (typeof (EnemyMovement))]
	[RequireComponent (typeof (EnemyEvasiveManouver))]
	[RequireComponent (typeof (TargetDector))]
	[RequireComponent (typeof (WeaponController))]
	public class EnemyAI : MonoBehaviour 
	{
		public Vector2 waitTime = Vector2.one;
		public Vector2 attackTime = Vector2.one;
		public Vector2 evadeTime = Vector2.one;

		[Range (0.0f, 1.0f)]
		public float chanceOfStopping = 1f;
		[Range (0.0f, 1.0f)]
		public float chanceOfEvading = 1f;
		[Range (0.0f, 1.0f)]
		public float chanceOfAttacking = 1f;


		public Transform target;

		bool _targetDetected;

		EnemyMovement _movement;
		EnemyEvasiveManouver _evade;
		TargetDector _targetDetector;
		WeaponController _weapon;

		public bool IsMoving { get; private set; }
		public bool IsEvading { get; private set; }
		public bool IsAttacking { get; private set; }

		float RandomFromRange (Vector2 value) {
			return Random.Range (value.x, value.y);
		}

		void Awake ()
		{
			_movement = GetComponent <EnemyMovement> ();
			_evade = GetComponent <EnemyEvasiveManouver> ();
			_weapon = GetComponent <WeaponController> ();

			_targetDetector = GetComponent <TargetDector> ();
			target = GameObject.FindWithTag ("Player").transform;
			_targetDetector.target = target;
		}

		void Start ()
		{
			Move ();

			if (Random.value <= chanceOfEvading) {
				Evade ();	
				Invoke ("StopEvading", RandomFromRange (evadeTime));
			}

			if (Random.value <= chanceOfAttacking) {
				Attack ();
				Invoke ("StopAttacking", RandomFromRange (attackTime));
			}
		}

		void Update ()
		{
			EnemyActions ();
		}

		void Move ()
		{
			IsMoving = true;

			_movement.Move ();
		}

		void StopMoving ()
		{
			IsMoving = false;

			_movement.Stop ();
		}

		void Evade ()
		{
			IsEvading = true;

			_evade.Evade ();
		}

		void StopEvading ()
		{
			IsEvading = false;

			_evade.Stop ();
		}

		void Attack ()
		{
			IsAttacking = true;

			_weapon.Attack = true;
		}

		void StopAttacking ()
		{
			IsAttacking = false;

			_weapon.Attack = false;
		}

		void EnemyActions ()
		{
			if (Random.value > chanceOfStopping) {
				return;
			}

			if (_targetDetected == false && _targetDetector.targetReached) 
			{
				_targetDetected = true;

				StopMoving ();
				Invoke ("Move", RandomFromRange (waitTime));
				Attack ();
				Invoke ("StopAttacking", RandomFromRange (attackTime));
				Evade ();
				Invoke ("StopEvading", RandomFromRange (evadeTime));
			}
		}
	}
}

/*
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
 */