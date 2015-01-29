using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Rigidbody))]
	public class PlayerMovement : MonoBehaviour 
	{
		public float speed = 5f;
		public bool invertControlsX = false;
		public bool invertControlsY = false;
		
//		float _h, _v;
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

//		void FixedUpdate ()
//		{
//			_h = Input.GetAxis ("Horizontal");
//			_v = Input.GetAxis ("Vertical");
//			
//			Move (_h, _v);
//		}
		
		public void Move (float h, float v)
		{
			_initialPostiion = transform.position;


			Vector3 newPosition = new Vector3 (h * InvertedControlsX, v * InvertedControlsY, _initialPostiion.z).normalized;
			
			_rb.MovePosition (rigidbody.position + newPosition * speed * Time.fixedDeltaTime);

			Animate (h, v);
		}

		void Animate (float h, float v)
		{
			_animatorAC.HDirection = h;
			_animatorAC.Speed = Mathf.Abs (h);
		}
	}
}