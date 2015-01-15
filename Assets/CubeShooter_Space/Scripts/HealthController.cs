using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class HealthController : MonoBehaviour 
	{
		public float immunityTime = .5f;
		public int maxHealth = 100;
		public bool isDead = false;
		public bool destroyOnDeath = false;
		public GameObject deathVfx;
		public AudioClip deathAudioClip;

		[SerializeField] int _currentHealth;
		float _immunityTimer;

		public bool Immune {
			get {
				return _immunityTimer < immunityTime;		
			}
		}

		void Awake ()
		{
			_currentHealth = maxHealth;
			_immunityTimer = immunityTime;
		}

		void Update ()
		{
			if (_immunityTimer < immunityTime) 
			{
				_immunityTimer += Time.deltaTime;		
			}
			else
			{
				_immunityTimer = immunityTime;
			}
		}

		void OnTakeDamage (int damage)
		{
			if (Immune) 
			{
				return;
				Debug.Log ("immune: " + Immune);
			}

			_immunityTimer = 0.00f;

			_currentHealth -= damage;

			if (_currentHealth <= 0) 
			{
				isDead = true;
				_currentHealth = 0;

				PlayDeathEffects ();

				if (destroyOnDeath)
					Destroy (gameObject);
			}
		}

		void PlayDeathEffects ()
		{
			if (deathVfx != null) {
				Instantiate (deathVfx, transform.position, Quaternion.identity);		
			}

			if (deathAudioClip != null)
			{
				AudioSource.PlayClipAtPoint (deathAudioClip, transform.position, 0.2f);
			}
		}

		public void TakeDamage (int damage)
		{
			OnTakeDamage (damage);
		}

		public void TakeDamage (int damage, Collider col)
		{
			OnTakeDamage (damage);
		}
	}
}