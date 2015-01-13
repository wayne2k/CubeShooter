using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RollRoti.CubeShooter_Space
{
	public class Weapon : MonoBehaviour 
	{
		public Transform bulletHolder;
		public List<Transform> shotPostions;
		public GameObject bulletPfb;
		public float fireRate = 0.5f;
		public string fireButton = "Fire1";
		public int bulletCache = 10;
		
		float _timer;
		List<GameObject> _bullets;
		
		void Awake ()
		{
			if (bulletHolder == null)
				Debug.LogError ("No GameObject to hold bullets.");

			if (shotPostions.Count <= 0)
				Debug.LogError ("No Shot Positions set.");
			
			if (bulletPfb == null)
				Debug.LogError ("No Bullet Prefab set.");
			else 
			{
				_bullets = new List<GameObject> (bulletCache);
				for (int i=0; i < bulletCache; i++) 
				{
					GameObject _b = Instantiate (bulletPfb) as GameObject;
					_b.gameObject.SetActive (false);
					_b.transform.parent = bulletHolder;
					_bullets.Add (_b);
				}
			}
			
		}
		
		void Update ()
		{
			if (_timer >= 0f)
				_timer -= Time.deltaTime;
			
			if (Input.GetButton (fireButton)) 
			{
				FireWeapon ();
			}
		}
		
		GameObject GetBullet ()
		{
			for (int i=0; i < bulletCache; i++) 
			{
				if (_bullets[i].activeInHierarchy == false)
					return _bullets[i];
			}
			
			GameObject _b = Instantiate (bulletPfb) as GameObject;
			_b.gameObject.SetActive (false);
			_b.transform.parent = bulletHolder;
			_bullets.Add (_b);
			bulletCache = _bullets.Count;
			return _b;
		}
		
		public void FireWeapon ()
		{
			if (_timer <= 0f)
			{
				_timer = fireRate;
				
				foreach (Transform shotPos in shotPostions)
				{
					//				Instantiate (bulletPfb, shotPos.position, shotPos.rotation);
					GameObject _b = GetBullet ();
					if (_b != null)
					{
						_b.transform.position = shotPos.position;
						_b.transform.rotation = shotPos.rotation;
						_b.gameObject.SetActive (true);
						_b.GetComponent<BulletMovement> ().Initialize ();
					}
				}
			}
		}
	}
}