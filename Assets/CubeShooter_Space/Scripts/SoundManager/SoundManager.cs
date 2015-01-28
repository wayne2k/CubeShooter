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

		public bool SfxActive { get { return (sfx == null) ? false : sfx.IsActive; } }
		public bool MusicActive { get { return (music == null) ? false : music.IsActive; } }

		void Awake ()
		{
			Instance = this;
		}

		void LateUpdate ()
		{
			if (MusicActive && audio.isPlaying == false) {
				audio.Play ();			
			}
			else if (MusicActive == false && audio.isPlaying) {
				audio.Stop ();			
			}
		}
	}
}