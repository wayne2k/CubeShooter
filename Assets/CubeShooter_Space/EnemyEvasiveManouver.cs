using UnityEngine;
using System.Collections;
using RollRoti.HelperLib;

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
		public EvasiveManouverParams overrideParams { get; set; }
		EvasiveManouverParams settings { get { return  overrideParams ?? defaultParams; } }

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

			if (boundary.axisToClamp != Vector3.zero)
			{
				rigidbody.position = boundary.ClampOnAxis (rigidbody.position);
			}

//			Quaternion q = rigidbody.rotation;
//			q.z = rigidbody.velocity.x * -settings.tilt;
//			rigidbody.rotation = q;

//			rigidbody.rotation = Quaternion.Euler (transform.rotation.x, transform.rotation.y, rigidbody.velocity.x * -settings.tilt);
			rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -settings.tilt);
		}
	}
}