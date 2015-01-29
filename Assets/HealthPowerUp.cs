using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class HealthPowerUp : MonoBehaviour 
	{
		public int healthBoost = 1;

		void OnTriggerEnter (Collider other)
		{
			HealthController player = other.GetComponentInParent <HealthController> ();

			if (player != null)
				player.IncreaseHealth (healthBoost);

			Destroy (gameObject);
		}
	}
}