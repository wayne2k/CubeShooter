using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	public class HealthPowerUpSpawner : MonoBehaviour 
	{
		public int playerHealthLevel = 2;
		public List<GameObject> objPfbs;
		public Transform minSpawnLocation;
		public Transform maxSpawnLocation;
		
		public Vector2 startTime = new Vector2 (10f, 10f);
		public Vector2 delayTime = new Vector2 (1f, 5f);
		public Vector2 waveRange = new Vector2 (1f, 5f);
		
		public GameObject RandomObjectPfb { 
			get { return (objPfbs.Count <= 0) ? null : objPfbs [Random.Range (0, objPfbs.Count)]; } 
		}
		
		public Vector3 RandomPosition {
			get {
				if (minSpawnLocation != null && maxSpawnLocation != null)
					return ExtensionMethods.RandomVector3 (minSpawnLocation.position, maxSpawnLocation.position);			
				
				return transform.position;
			}
		}

		HealthController _playerHealth;

		void Awake ()
		{
			if (minSpawnLocation == null)
				minSpawnLocation = transform.FindChild ("LocationMin");
			
			if (maxSpawnLocation == null)
				maxSpawnLocation = transform.FindChild ("LocationMax");
			
			if (minSpawnLocation == null || maxSpawnLocation == null)
				Debug.LogWarning ("Spawn Locations not set, defaulting to " + gameObject.name + " position.");
		}

		void Update ()
		{
			if (_playerHealth == null)
			{
//				Debug.Log (GameManager.Instance.Player_T.gameObject.name);
				if (GameManager.Instance != null && GameManager.Instance.Player_T != null) 
				{
					_playerHealth = GameManager.Instance.Player_T.gameObject.GetComponent<HealthController> ();
				}
			}
			else
			{
				if (_playerHealth.CurrentHealth <= playerHealthLevel) 
				{
					if (IsInvoking ("SpawnObject") == false) 
					{
						Invoke ("SpawnObject", startTime.RandomFromRange ());
					}
				}
				else if (_playerHealth.CurrentHealth > playerHealthLevel && IsInvoking ("SpawnObject"))
				{
					CancelInvoke ("SpawnObject");
				}
			}
		}

		void SpawnObject ()
		{
			if (objPfbs.Count <= 0) 
			{
				Debug.LogWarning ("No Objects to spawn. Spawner Stopping.");
				return;
			}
			
			int waveSize = waveRange.RandomIntFromRange ();
			
			for (int i=0; i < waveSize; i++) 
			{
				GameObject go = RandomObjectPfb;
				
				if (go != null) 
				{
					GameObject obj = Instantiate (go, RandomPosition, transform.rotation) as GameObject;
					obj.transform.parent = (GameManager.Instance != null) ? GameManager.Instance.EnemyHolder_T : null;
				}
			}
			
			Invoke ("SpawnObject", delayTime.RandomFromRange ());
		}
		
		void OnEnable() 
		{
//			if (_playerHealth != null && IsInvoking ("SpawnObject") == false)
//				Invoke ("SpawnObject", startTime.RandomFromRange ());
		}
		
		void OnDisable() 
		{
			CancelInvoke ("SpawnObject");
		}
	}
}