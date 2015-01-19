using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{	
	[System.Serializable]
	public class EvasiveManouverParams
	{
		public float tilt;
		public float dodge;
		public float smoothing;
		public Vector2 startWait;
		public Vector2 maneuverTime;
		public Vector2 maneuverWait;
	}

	[RequireComponent (typeof (Rigidbody))]
	public class EnemyEvasiveManouver : MonoBehaviour 
	{
		public EvasiveManouverParams defaultParams;
		EvasiveManouverParams _overrideParams;
		public EvasiveManouverParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		EvasiveManouverParams settings { get { return OverrideParams ?? defaultParams; } }

		[SerializeField] private Vector3 currentVelocity;
		[SerializeField] private float targetManeuver;

		public bool Evading { get; private set; }

		void Start ()
		{
			currentVelocity = rigidbody.velocity;
		}

		public void Evade ()
		{
			if (Evading == false)
				StartCoroutine (EvadeCo ());
		}

		public void Stop ()
		{
			if (Evading) {
				StopCoroutine (EvadeCo ());
				Evading = false;
			}
		}

		IEnumerator EvadeCo ()
		{
			Evading = true;

			yield return new WaitForSeconds (Random.Range (settings.startWait.x, settings.startWait.y));
			while (true)
			{
				targetManeuver = Random.Range (1, settings.dodge) * -Mathf.Sign (transform.position.x);
				yield return new WaitForSeconds (Random.Range (settings.maneuverTime.x, settings.maneuverTime.y));
				targetManeuver = 0;
				yield return new WaitForSeconds (Random.Range (settings.maneuverWait.x, settings.maneuverWait.y));
			}

			Evading = false;
		}

		void FixedUpdate ()
		{
			currentVelocity = rigidbody.velocity;

			float newManeuver = Mathf.MoveTowards (rigidbody.velocity.x, targetManeuver, settings.smoothing * Time.deltaTime);

			rigidbody.velocity = new Vector3 (newManeuver, currentVelocity.y, currentVelocity.z);

//			Quaternion q = rigidbody.rotation;
//			q.z = rigidbody.velocity.x * -settings.tilt;
//			rigidbody.rotation = q;

//			rigidbody.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, rigidbody.velocity.x * -settings.tilt);
			rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -settings.tilt);
		}
	}
}