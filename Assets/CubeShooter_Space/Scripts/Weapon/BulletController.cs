using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class BulletController : MonoBehaviour 
	{
		public int damagePower = 1;

		BulletMovement _movement;

		void Awake ()
		{
			_movement = GetComponent <BulletMovement> ();
		}

		void OnTriggerEnter (Collider col)
		{
//			Debug.Log (gameObject + " hit " + col.name);

			// Note: GetComponentInParent because Collider is on on the parent gameObject.
			HealthController _health = col.gameObject.GetComponentInParent <HealthController> ();

			if (_health != null) 
			{
				_health.TakeDamage (damagePower);		
			}

			if (_movement != null) 
			{
				_movement._lifeTimeTimer = 0.0f;
			}
		}
	}
}