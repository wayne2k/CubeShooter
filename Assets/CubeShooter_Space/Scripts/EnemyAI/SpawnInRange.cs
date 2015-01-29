using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	public class SpawnInRange : MonoBehaviour 
	{
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

		void Awake ()
		{
			if (minSpawnLocation == null)
				minSpawnLocation = transform.FindChild ("LocationMin");

			if (maxSpawnLocation == null)
				maxSpawnLocation = transform.FindChild ("LocationMax");

			if (minSpawnLocation == null || maxSpawnLocation == null)
				Debug.LogWarning ("Spawn Locations not set, defaulting to " + gameObject.name + " position.");
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
			if (IsInvoking ("SpawnObject") == false)
				Invoke ("SpawnObject", startTime.RandomFromRange ());
		}
		
		void OnDisable() 
		{
			CancelInvoke ("SpawnObject");
		}
	}
}