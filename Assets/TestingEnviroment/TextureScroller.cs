using UnityEngine;

namespace RollRoti.CubeShooter_Space
{
	public class TextureScroller : MonoBehaviour
	{
		public Vector2 scrollAxis = Vector3.up;
		public float speed = 0.1f;

		Vector2 offset = Vector2.zero;
		Vector2 _initOffset;

		void Awake ()
		{
			_initOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
		}

		void Update ()
		{
			float y = Mathf.Repeat (Time.time * speed, 1);

			if (scrollAxis.x != 0)
				offset.x = y;

			if (scrollAxis.y != 0)
				offset.y = y;

			renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		}

		void OnDisable () 
		{
			renderer.sharedMaterial.SetTextureOffset ("_MainTex", _initOffset);
		}
	}
}