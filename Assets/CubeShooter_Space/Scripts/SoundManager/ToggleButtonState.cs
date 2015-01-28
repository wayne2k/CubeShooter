using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RollRoti.HelperLib;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (Toggle))]
	public class ToggleButtonState : MonoBehaviour 
	{
		public string saveKey = "sfx";

		public bool IsActive { 
			get { return (_toggle == null) ? false :_toggle.isOn; }
			set { if (_toggle != null) _toggle.isOn = value; }
		}

		Toggle _toggle;

		void Awake ()
		{
			_toggle = GetComponent <Toggle> ();

			LoadStateFromDisk ();
		}
	
		void LoadStateFromDisk ()
		{
			IsActive = PlayerPrefs.GetInt (saveKey, 0).ToBool ();
		}
		
		void SaveStateToDisk ()
		{
			PlayerPrefs.SetInt (saveKey, IsActive.ToInt ());
		}

		public void ToggleStateChange ()
		{
			SaveStateToDisk ();
		}
	}
}