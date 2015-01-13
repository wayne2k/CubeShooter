using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	[RequireComponent (typeof (UFOAC))]
	public class DebugUFOAC : MonoBehaviour 
	{
		public bool debugControls = false;
		public string hDirectionButton = "Horizontal";

		UFOAC _ufoAC;
		
		void Awake ()
		{
			_ufoAC = GetComponent <UFOAC> ();
		}
		
		void Update ()
		{
			if (_ufoAC != null && debugControls) 
			{
				_ufoAC.HDirection = Input.GetAxis (hDirectionButton);
				_ufoAC.Speed = Mathf.Abs(_ufoAC.HDirection);
			}
		}
	}
}