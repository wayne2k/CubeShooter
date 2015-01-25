using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class HealthControllerParams
	{
		public float immunityTime = .5f;
		public int maxHealth = 100;
		public int scoreToGive = 1;
		public bool destroyOnDeath = false;
	}

	public class HealthController : MonoBehaviour 
	{
		public HealthControllerParams defaultParams;
		HealthControllerParams _overrideParams;
		public HealthControllerParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		HealthControllerParams settings { get { return OverrideParams ?? defaultParams; } }

		public GameObject explosionEffect;

		[SerializeField] int _currentHealth;
		float _immunityTimer;

		public bool Immune {
			get {
				return _immunityTimer < settings.immunityTime;		
			}
		}

		public bool IsDead { get; private set; }

		void Awake ()
		{
			_currentHealth = settings.maxHealth;
			_immunityTimer = settings.immunityTime;
		}

		void Update ()
		{
			if (_immunityTimer < settings.immunityTime) 
			{
				_immunityTimer += Time.deltaTime;		
			}
			else
			{
				_immunityTimer = settings.immunityTime;
			}
		}

		void OnTakeDamage (int damage)
		{
			if (Immune) 
			{
				return;
			}

			_immunityTimer = 0.00f;

			_currentHealth -= damage;

			if (_currentHealth <= 0) 
			{
				IsDead = true;
				_currentHealth = 0;

				if (ScoreManager.Instance != null)
					ScoreManager.Instance.score += settings.scoreToGive;

				if (explosionEffect != null)
					Instantiate (explosionEffect, transform.position, transform.rotation);

				if (settings.destroyOnDeath)
					Destroy (gameObject);
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