using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[System.Serializable]
	public class BulletMoverParams
	{
		public float speed = 20f;
		public ForceMode forcemode = ForceMode.VelocityChange;
		public bool moveOnStart = true;
	}


	[RequireComponent (typeof (Rigidbody))]
	public class BulletMover : MonoBehaviour 
	{
		public BulletMoverParams defaultParams;
		BulletMoverParams _overrideParams;
		public BulletMoverParams OverrideParams { get { return _overrideParams ; } set { _overrideParams = value;} }
		BulletMoverParams settings { get { return OverrideParams ?? defaultParams; } }

		Rigidbody _rb;

		void Awake ()
		{
			_rb = GetComponent <Rigidbody> ();

			_rb.useGravity = false;
			_rb.constraints = RigidbodyConstraints.FreezeRotation;
		}

		void Start () 
		{
			if (settings.moveOnStart)
				Move ();
		}

		public void Move ()
		{
			_rb.AddForce (transform.forward * settings.speed, settings.forcemode);
		}
	}
}