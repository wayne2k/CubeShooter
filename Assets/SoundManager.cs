using UnityEngine;
using System.Collections;
using System;

namespace RollRoti.CubeShooter_Space
{
	public class SoundManager : MonoBehaviour
	{
		public static SoundManager Instance { get; private set; }

		public ToggleButtonState sfx;
		public ToggleButtonState music;

		void Awake ()
		{
			Instance = this;
		}

		void LateUpdate ()
		{
			if (music.IsActive && audio.isPlaying == false) {
				audio.Play ();			
			}
			else if (music.IsActive == false && audio.isPlaying) {
				audio.Stop ();			
			}
		}
	}
}