using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class PlayerShipMovement : MonoBehaviour 
	{
		public float speed = 5f;
		//	public float moveForce = 10f;
		//	public ForceMode forceMode = ForceMode.VelocityChange;
		public bool invertControlsX = false;
		public bool invertControlsY = false;
		
		float _h, _v;
		Vector3 _initialPostiion;

		UFOAC _animatorAC;
		Rigidbody _rb;

		int InvertedControlsX {
			get
			{
				return invertControlsX ? -1 : 1;	
			}
		}
		
		int InvertedControlsY {
			get
			{
				return invertControlsY ? -1 : 1;	
			}
		}

		void Awake ()
		{
			_initialPostiion = transform.position;

			_animatorAC = GetComponentInChildren <UFOAC> ();

			_rb = GetComponent <Rigidbody> ();
			_rb.useGravity = false;
			_rb.isKinematic = true;
			_rb.constraints = RigidbodyConstraints.FreezeRotation;
		}

		void FixedUpdate ()
		{
			_h = Input.GetAxis ("Horizontal");
			_v = Input.GetAxis ("Vertical");
			
			Move (_h, _v);
		}
		
		public void Move (float h, float v)
		{
			//		if (Mathf.Abs (h) > 0.0f) 
			//		{
			//			rigidbody.AddForce (Vector3.right * h * InvertedControls * moveForce, forceMode);
			//		}
			//
			//		if (Mathf.Abs (v) > 0.0f) 
			//		{
			//			rigidbody.AddForce (Vector3.up * h * InvertedControls * moveForce, forceMode);
			//		}
			//		Vector3 finalDirection = new Vector3(h, v, 1.0f);
			//		transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(finalDirection),Mathf.Deg2Rad*angleChangeSpeed);
			
			Vector3 newPosition = new Vector3 (h * InvertedControlsX, v * InvertedControlsY, _initialPostiion.z).normalized;
			
			_rb.MovePosition (rigidbody.position + newPosition * speed * Time.fixedDeltaTime);

			Animate ();
		}

		void Animate ()
		{
//			_animatorAC.HorizontalSpeed = _h;
			_animatorAC.HDirection = _h;
			_animatorAC.Speed = Mathf.Abs (_h);
		}
	}
}