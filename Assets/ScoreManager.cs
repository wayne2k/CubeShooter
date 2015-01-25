using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{

	public class ScoreManager : MonoBehaviour 
	{
		public int score = 0;

		public static ScoreManager Instance { get; private set; }

		void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(this.gameObject);
				return;
			}
			else
			{
				Instance = this;
			}
			DontDestroyOnLoad(this.gameObject);
			gameObject.name = "$ScoreManager";
		}

		void OnGUI()
		{
			GUILayout.Label("Score: " + score);
		}
	}
}