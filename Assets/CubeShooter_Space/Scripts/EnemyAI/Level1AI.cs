﻿using UnityEngine;
using System.Collections;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class Level1AIParams 
	{
		public EnemyMovementParams moveParams;
		public TargetDetectorParams detectorParams;
		
		[Range (0.0f, 1.0f)]
		public float chanceOfStopping = 0.5f;
		[Range (0.0f, 1.0f)]
		public float chanceOfAttacking = 0.5f;
		[Range (0.0f, 1.0f)]
		public float chanceOfStartAttack = 0.5f;
		[Range (0.0f, 1.0f)]
		public float chanceOfAiming = 0.5f;

		public Vector2 waitTime = Vector2.one;
		public Vector2 attackTime = Vector2.one;
		public Vector2 startAttackTime = Vector2.one;
	}


	[RequireComponent (typeof (EnemyMovement))]
	[RequireComponent (typeof (TargetDetector))]
	[RequireComponent (typeof (AttackController))]
	public class Level1AI : MonoBehaviour 
	{
		public Level1AIParams defaultParams;
		Level1AIParams _overrideParams;
		public Level1AIParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		public Level1AIParams settings { get { return OverrideParams ?? defaultParams; } }

		EnemyMovement _movement;
		TargetDetector _targetDetector;
		AttackController _attack;
		EnemyCubeAC _anim;
		bool _reachedTargetOnce;

		void Awake ()
		{
			_movement = GetComponent <EnemyMovement> ();
			_movement.OverrideParams = settings.moveParams;

			_targetDetector = GetComponent <TargetDetector> ();
			settings.detectorParams.target = (GameManager.Instance != null) ? GameManager.Instance.Player_T : null;
			_targetDetector.OverrideParams = settings.detectorParams;

			_attack = GetComponent <AttackController> ();
			_attack.target = (GameManager.Instance != null) ? GameManager.Instance.Player_T : null;
			if (ChanceOfOperation (settings.chanceOfAiming))
				_attack.AimAtTarget = true;

			_anim = GetComponent <EnemyCubeAC> ();
		}

		void Start ()
		{
			if (ChanceOfOperation (settings.chanceOfStartAttack)) 
			{
				StartAttacking ();
				Invoke ("StopAttacking", settings.startAttackTime.RandomFromRange ());
			}
		}

		void Update ()
		{
			if (_reachedTargetOnce == false && _targetDetector.targetReached) 
			{
				_reachedTargetOnce = true;
				TargetReached ();
			}
		}

		void TargetReached ()
		{
			//STOP > ATTACK > GO.

			if (ChanceOfOperation (settings.chanceOfStopping))
			{	
				Stop ();
				Invoke ("Move", settings.waitTime.RandomFromRange ());
			}

			if (ChanceOfOperation (settings.chanceOfAttacking))
			{
				StartAttacking ();
				Invoke ("StopAttacking", settings.attackTime.RandomFromRange ());
			}
		}
	
		bool ChanceOfOperation (float chance)
		{
			float chanceValue = Random.value;
			return (chanceValue <= chance);
		}

		void Move ()
		{
			_movement.Move ();
		}
		void Stop ()
		{
			_movement.Stop ();
		}

		void StartAttacking ()
		{
			_attack.Attack = true;
			_anim.Attack = true;
		}

		void StopAttacking ()
		{
			_attack.Attack = false;
			_anim.Attack = false;
		}
	}
}