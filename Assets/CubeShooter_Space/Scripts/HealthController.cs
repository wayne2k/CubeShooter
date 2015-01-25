using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class HealthControllerParams
	{
		public float immunityTime = .5f;
		public int maxHealth = 100;
	}

	[RequireComponent (typeof (HealthBarUI))]
	public class HealthController : MonoBehaviour 
	{
		public HealthControllerParams defaultParams;
		HealthControllerParams _overrideParams;
		public HealthControllerParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		public HealthControllerParams settings { get { return OverrideParams ?? defaultParams; } }

		public HealthBarUI healthBar;

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

			IsDead = false;
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
			if (Immune || IsDead) 
			{
				return;
			}

			_immunityTimer = 0.00f;

			_currentHealth -= damage;


			if (_currentHealth <= 0) 
			{
				IsDead = true;
				_currentHealth = 0;
			}

			healthBar.CurrentHealth (_currentHealth);

			SendMessage ("TookDamage", SendMessageOptions.DontRequireReceiver);
		}

		public void TakeDamage (int damage)
		{
			OnTakeDamage (damage);
		}

		public void TakeDamageFull ()
		{
			OnTakeDamage (settings.maxHealth);
		}
	}
}