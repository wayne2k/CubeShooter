using UnityEngine;
using System.Collections;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	public class KeepInBoundry : MonoBehaviour 
	{
		public enum ComponentTypes
		{
			TRANSFORM,
			RIGIDBODY
		}

		public enum UpdateTypes
		{
			NONE,
			UPDATE,
			FIXEDUPDATE,
			LATEUPDATE
		}

		public UpdateTypes updateType = UpdateTypes.LATEUPDATE;
		public ComponentTypes componentType = ComponentTypes.RIGIDBODY;
		public Boundry boundry;

		Rigidbody _rb;
		Transform _t;

		void Awake ()
		{
			_rb = GetComponent <Rigidbody> ();
			_t = GetComponent <Transform> ();

			if (_rb == null)
				componentType = ComponentTypes.TRANSFORM;
		}

		void Update ()
		{
			if (updateType == UpdateTypes.UPDATE)
			{
				ConstrainToBoundry ();
			}
		}

		void FixedUpdate ()
		{
			if (updateType == UpdateTypes.FIXEDUPDATE)
			{
				ConstrainToBoundry ();
			}
		}

		void LateUpdate ()
		{
			if (updateType == UpdateTypes.LATEUPDATE)
			{
				ConstrainToBoundry ();
			}
		}

		void ConstrainToBoundry ()
		{
			if (_rb != null) 
			{
				_rb.position = boundry.ClampOnAxis (_rb.position);			
			}
			else if (_t != null)
			{
				_t.position = boundry.ClampOnAxis (_t.position);
			}
		}
	}
}