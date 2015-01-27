using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class HealthBarUI : MonoBehaviour 
	{
		public Slider healthbar;
		public bool isPlayer = false;

		bool HasHealthBar { get { return (healthbar != null); } }

		void Awake ()
		{
			if (isPlayer) 
			{
				GameObject playerHealthBar = GameObject.Find ("PlayerHealthBarUI");
				if (playerHealthBar != null && HasHealthBar == false)
				{
					healthbar = playerHealthBar.GetComponent <Slider> ();
				}
			}
		}

		public void InitHealthBar (int maxHealth, int currentHealth)
		{
			if (HasHealthBar) 
			{
				healthbar.wholeNumbers = true;
				healthbar.maxValue = maxHealth;
				healthbar.value = currentHealth;
			}
		}

		public void CurrentHealth (int currentHealth)
		{
			if (HasHealthBar) 
			{
				healthbar.value = currentHealth;
			}
		}
	}
}