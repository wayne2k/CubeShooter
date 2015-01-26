using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (HealthController))]
	public class PlayerController : MonoBehaviour 
	{
		public GameObject explosionVFX;
		public GameObject damageVFX;

		HealthController _health;
		public bool _handledDeath = false;
		
		void Awake ()
		{
			_health = GetComponent <HealthController> ();
		}
		
		void Update ()
		{
			if (_handledDeath == false && _health.IsDead) 
			{
				_handledDeath = true;
				OnNoHealth ();
			}
		}
		
		void OnNoHealth ()
		{
			DeathVFX ();
			
			Destroy (gameObject);
		}
		
		void DeathVFX ()
		{
			if (explosionVFX != null)
				Instantiate (explosionVFX, transform.position, transform.rotation);
		}
		
		void DamageVFX ()
		{
			if (damageVFX != null)
				Instantiate (damageVFX, transform.position, transform.rotation);
		}
		
		void TookDamage ()
		{
			DamageVFX ();
		}
	}
}