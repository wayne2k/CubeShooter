using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class BulletControllerParams
	{
		public int damagePower = 1;
		public float lifeTime = 10f;
//		public bool destroyOnImpact = true;
	}

	public class BulletController : MonoBehaviour 
	{
		public BulletControllerParams defaultParams;
		BulletControllerParams _overrideParams;
		public BulletControllerParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		BulletControllerParams settings { get { return OverrideParams ?? defaultParams; } }

		void Start ()
		{
			Destroy (gameObject, settings.lifeTime);
		}

		void OnTriggerEnter (Collider other)
		{
			// Note: GetComponentInParent because Collider is on on the parent gameObject.
			HealthController _health = other.gameObject.GetComponentInParent <HealthController> ();

			if (_health != null) 
			{
				_health.TakeDamage (settings.damagePower);		
			}

//			if (settings.destroyOnImpact)
				Destroy (gameObject);
		}
	}
}