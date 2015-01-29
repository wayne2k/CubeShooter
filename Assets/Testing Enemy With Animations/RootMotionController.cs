using UnityEngine;
using System.Collections;

public class RootMotionController : MonoBehaviour 
{
	[Range (0, 1)]
	public float evadeBehavoiur = 0f;
	public bool evade = true;

	Animator _anim;

	void Awake ()
	{
		_anim = GetComponentInChildren <Animator> ();

		evadeBehavoiur = Random.Range (0f, 1f);
	}

	void LateUpdate ()
	{
		_anim.SetBool ("Evade", evade);
		_anim.SetFloat ("EvadeBehavoiur", evadeBehavoiur);
	}


//	void OnAnimatorMove()
//	{
//		Animator animator = GetComponent<Animator>(); 
//		
//		if (animator)
//		{
//			Vector3 newPosition = transform.position;
//
//			transform.position = newPosition;
//		}
//	}
}
