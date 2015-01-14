using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	public class SineWaveMovement : MonoBehaviour 
	{
		public float MoveSpeed = 5.0f;
		public float frequency = 20.0f; // Speed of sine movement
		public float magnitude = 0.5f; // Size of sine movement

		[SerializeField] private Vector3 moveDirection = Vector3.up;
		[SerializeField] private Vector3 axis = Vector3.right;
		private Vector3 pos;
		
		void Start () 
		{
			pos = transform.position;
			//		DestroyObject(gameObject, 1.0f);
			//axis = transform.right; // May or may not be the axis you want
		}
		
		void Update () 
		{
			pos += moveDirection * Time.deltaTime * MoveSpeed;
			transform.position = pos + axis * Mathf.Sin (Time.time * frequency) * magnitude;

		}
	}
}