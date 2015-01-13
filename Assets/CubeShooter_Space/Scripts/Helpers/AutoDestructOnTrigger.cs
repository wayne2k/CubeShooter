using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	public class AutoDestructOnTrigger : MonoBehaviour 
	{
		public enum DestructionTypes
		{
			DESTROY,
			HIDE
		}
		
		public DestructionTypes destructionType = DestructionTypes.DESTROY;
		public LayerMask includeLayers;


		void OnTriggerEnter (Collider col)
		{
			if(((1<<col.gameObject.layer) & includeLayers) != 0)
			{
				Destruct ();
			}
		}

		void Destruct ()
		{
			if (destructionType == DestructionTypes.DESTROY)
			{
				Destroy (gameObject);
			}
			else if (destructionType == DestructionTypes.HIDE)
			{
				gameObject.SetActive (false);
			}
		}
	}
}