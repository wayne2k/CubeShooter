using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	public class AutoDestructLifetime : MonoBehaviour 
	{
		public enum DestructionTypes
		{
			DESTROY,
			HIDE
		}

		public float lifeTime = 10f;
		public DestructionTypes destructionType = DestructionTypes.DESTROY;

		void Start ()
		{
			Destruct ();
		}

		void Destruct ()
		{
			if (destructionType == DestructionTypes.DESTROY)
			{
				Destroy (gameObject, lifeTime);
			}
			else if (destructionType == DestructionTypes.HIDE)
			{
				gameObject.SetActive (false);
			}
		}
	}
}
