using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class StopGoAIParams 
	{
		public EnemyMovementParams moveParams;
		public TargetDetectorParams detectorParams;
		
		[Range (0.0f, 1.0f)]
		public float chanceOfStopping = 0.5f;
		public Vector2 waitTime = Vector2.one;
	}


	[RequireComponent (typeof (EnemyMovement))]
	[RequireComponent (typeof (TargetDetector))]
	public class StopGoAI : MonoBehaviour 
	{
		public StopGoAIParams defaultParams;
		StopGoAIParams _overrideParams;
		public StopGoAIParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		StopGoAIParams settings { get { return OverrideParams ?? defaultParams; } }

		EnemyMovement _movement;
		TargetDetector _targetDetector;
		bool _reachedTargetOnce;

		void Awake ()
		{
			_movement = GetComponent <EnemyMovement> ();
			_movement.OverrideParams = settings.moveParams;

			_targetDetector = GetComponent <TargetDetector> ();
			GameObject playerGO = GameObject.FindWithTag ("Player");
			if (playerGO != null)
				settings.detectorParams.target = playerGO.transform;
			_targetDetector.OverrideParams = settings.detectorParams;
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
	}
}