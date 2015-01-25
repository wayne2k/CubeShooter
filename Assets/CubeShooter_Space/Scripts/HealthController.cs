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
	[RequireComponent (typeof (HealthBarUI))]
	public class HealthController : MonoBehaviour 
	{
		public HealthControllerParams defaultParams;
		HealthControllerParams _overrideParams;
		public HealthControllerParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		public HealthControllerParams settings { get { return OverrideParams ?? defaultParams; } }

		public HealthBarUI healthBar;
		public GameObject explosionVFX;
		public GameObject damageVFX;


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
			healthBar = GetComponent <HealthBarUI> ();
			_currentHealth = settings.maxHealth;
			_immunityTimer = settings.immunityTime;
		}

		void Start ()
		{
			healthBar.InitHealthBar (settings.maxHealth, _currentHealth);
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

				DeathVFX ();

				if (settings.destroyOnDeath)
					Destroy (gameObject);
			}
			else
			{
				DamageVFX ();
			}


			healthBar.CurrentHealth (_currentHealth);
		}

		public void TakeDamage (int damage)
		{
			OnTakeDamage (damage);
		}

		public void TakeDamage (int damage, Collider col)
		{
			OnTakeDamage (damage);
		}

		public void DeathVFX ()
		{
			if (explosionVFX != null)
				Instantiate (explosionVFX, transform.position, transform.rotation);
		}

		public void DamageVFX ()
		{
			if (damageVFX != null)
				Instantiate (damageVFX, transform.position, transform.rotation);
		}
	}
}