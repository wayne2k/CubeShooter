using UnityEngine;
using System.Collections;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class EnemyEvasiveManouverY : MonoBehaviour 
	{
		public EvasiveManouverParams settings;
		public Boundry boundary;

		[SerializeField] private Vector3 currentVelocity;
		[SerializeField] private float targetManeuver;

		public bool Evading { get; private set; }

		void Start ()
		{
			currentVelocity = rigidbody.velocity;

			StartCoroutine (EvadeCo ());
		}
		
		IEnumerator EvadeCo ()
		{
			Evading = true;

			yield return new WaitForSeconds (Random.Range (settings.startWait.x, settings.startWait.y));
			while (true)
			{
				targetManeuver = Random.Range (1, settings.dodge) * -Mathf.Sign (transform.position.y);
				yield return new WaitForSeconds (Random.Range (settings.maneuverTime.x, settings.maneuverTime.y));
				targetManeuver = 0;
				yield return new WaitForSeconds (Random.Range (settings.maneuverWait.x, settings.maneuverWait.y));
			}

			Evading = false;
		}

		void FixedUpdate ()
		{
			currentVelocity = rigidbody.velocity;

			float newManeuver = Mathf.MoveTowards (rigidbody.velocity.y, targetManeuver, settings.smoothing * Time.deltaTime);

			rigidbody.velocity = new Vector3 (currentVelocity.x, newManeuver, currentVelocity.z);

			if (boundary.axisToClamp != Vector3.zero)
			{
				rigidbody.position = boundary.ClampOnAxis (rigidbody.position);
			}

			Quaternion q = rigidbody.rotation;
			q.x = rigidbody.velocity.y * -settings.tilt;
			rigidbody.rotation = q;

	//		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.y * -settings.tilt, transform.rotation.y, transform.rotation.z);
		}
	}
}