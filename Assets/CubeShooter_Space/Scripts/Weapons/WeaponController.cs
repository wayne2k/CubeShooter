using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class WeaponControllerParams
	{
		public float fireRate = 0.5f;
		public bool overrideBulletMover;
		public BulletMoverParams bulletMoverParams;
		public bool overrideBulletController;
		public BulletControllerParams bulletControllerParams;
	}

	public class WeaponController : MonoBehaviour 
	{
		public WeaponControllerParams defaultParams;
		WeaponControllerParams _overrideParams = null;
		public WeaponControllerParams OverrideParams { get { return _overrideParams; } set { _overrideParams = value; } }
		WeaponControllerParams settings { get { return OverrideParams ?? defaultParams; } }

		public List<Transform> shotPostions;
		public GameObject bulletPfb;
		public AudioClip weaponFireClip;

		float _timer;

		public bool Attack { get; set; }

		void Awake ()
		{
			if (shotPostions.Count <= 0)
				Debug.LogError ("No Shot Positions set.");
			
			if (bulletPfb == null) 
			{
				Debug.LogError ("No Bullet Prefab set.");
				gameObject.SetActive (false);
			}
		}

		void Update ()
		{
			if (_timer >= 0f)
				_timer -= Time.deltaTime;


			if (Attack)
				FireWeapon ();
		}

		void InstantiateBullet (Transform shotPosition)
		{
			GameObject _bullet = Instantiate (bulletPfb, shotPosition.position, shotPosition.rotation) as GameObject;
			_bullet.transform.parent = (GameManager.Instance != null) ? GameManager.Instance.BulletHolder_T : null;

			if (settings.overrideBulletMover) 
			{
				BulletMover _bMover = _bullet.GetComponent<BulletMover> ();		
				_bMover.OverrideParams = settings.bulletMoverParams;
			}

			if (settings.overrideBulletController) 
			{
				BulletController _bControllerParams = _bullet.GetComponent<BulletController> ();
				_bControllerParams.OverrideParams = settings.bulletControllerParams;
			}
		}
		
		public void FireWeapon ()
		{
			if (shotPostions.Count <= 0 || bulletPfb == null)
				return;
			
			if (_timer <= 0f)
			{
				_timer = settings.fireRate;
				
				foreach (Transform shotPos in shotPostions)
				{
					InstantiateBullet (shotPos);
					if (SoundManager.Instance != null && SoundManager.Instance.SfxActive && weaponFireClip != null && audio != null)
					{
						audio.Stop ();
						audio.clip = weaponFireClip;
						audio.Play ();
					}
				}
			}
		}
	}
}