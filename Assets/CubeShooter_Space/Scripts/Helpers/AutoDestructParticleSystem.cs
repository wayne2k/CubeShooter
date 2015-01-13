using UnityEngine;
using System.Collections;

namespace RollRoti.HelperLib
{
	[RequireComponent (typeof(ParticleSystem))]
	public class AutoDestructParticleSystem : MonoBehaviour 
	{
		public enum DestructionTypes
		{
			DESTROY,
			HIDE
		}
		
		public DestructionTypes destructionType = DestructionTypes.DESTROY;

		ParticleSystem _particleSystem;

		void Awake ()
		{
			_particleSystem = GetComponent <ParticleSystem> ();
		}

		void Update ()
		{
			if (_particleSystem != null && _particleSystem.isPlaying == false) 
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