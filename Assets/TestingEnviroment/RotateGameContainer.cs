using UnityEngine;
using System.Collections;

public class RotateGameContainer : MonoBehaviour
{
	public float speed = 2f;

	public Vector3 axis = Vector3.up;

	void Update ()
	{
		transform.Rotate (axis * speed * Time.deltaTime);
	}
}
