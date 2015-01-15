using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RollRoti.CubeShooter_Space
{
	public class SpawnerGeneric : MonoBehaviour 
	{
		public Transform spawnObjHolder;
		public float spawnRadius = 3f;
		public float delayTimeMin = 1f;
		public float delayTimeMax = 5f;
		public List<GameObject> objPfbs;
		public int spawnWaveMin = 1;
		public int spawnWaveMax = 5;

		public float RandomDelayTime {
			get {
				return Random.Range (delayTimeMin, delayTimeMax);		
			}
		}

		public Vector3 RandomPointInSphere {
			get {
				return transform.position + Random.insideUnitSphere * spawnRadius;	
			}
		}

		public int RandomSpawnWave {
			get {
				return Random.Range (spawnWaveMin, spawnWaveMax);			
			}
		}

		public GameObject RandomObjectPfb {
			get {
				if (objPfbs.Count <= 0)
					return null;

				return objPfbs [Random.Range (0, objPfbs.Count)];
			}
		}

		void Start ()
		{
			Invoke ("SpawnObject", RandomDelayTime);
		}

		void SpawnObject ()
		{
			if (objPfbs.Count <= 0) 
			{
				Debug.LogWarning ("No Objects to spawn. Spawner Stopping.");
				return;
			}

			int waveSize = RandomSpawnWave;

			for (int i=0; i < waveSize; i++) 
			{
				GameObject go = RandomObjectPfb;
				
				if (go != null) 
				{
					GameObject obj = Instantiate (go, RandomPointInSphere, transform.rotation) as GameObject;
					obj.transform.parent = spawnObjHolder;
				}
			}

			Invoke ("SpawnObject", RandomDelayTime);
		}
	}
}