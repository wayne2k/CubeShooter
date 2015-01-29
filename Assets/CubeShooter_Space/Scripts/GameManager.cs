using UnityEngine;
using System.Collections;

namespace RollRoti.CubeShooter_Space
{
	public class GameManager : MonoBehaviour 
	{
		public static GameManager Instance { get; private set; }

		public string playerTag = "Player";
		public string bulletholderTag = "$BulletHolder";
		public string enemyholderTag = "$EnemyHolder";
		public string explosionsTag = "$Explosions";

		private GameObject _player;
		private GameObject _bulletHolder;
		private GameObject _enemyHolder;
		private GameObject _explosionsHolder;

		public Vector3 PlayerPosition {
			get {
				return _player == null ? Vector3.zero : _player.transform.position;
			}
		}

		public Transform Player_T {
			get {
				return _player == null ? null : _player.transform;
			}
		}

		public Transform BulletHolder_T {
			get {
				return _bulletHolder == null ? null : _bulletHolder.transform;
			}
		}

		public Transform EnemyHolder_T {
			get {
				return _enemyHolder == null ? null : _enemyHolder.transform;
			}
		}

		public Transform ExplosionsHolder_T {
			get {
				return _explosionsHolder == null ? null : _explosionsHolder.transform;
			}
		}

		void Awake ()
		{
			Instance = this;
		}

		void Update ()
		{
			if (_player == null)
				_player = GameObject.FindWithTag (playerTag);
			if (_bulletHolder == null)
				_bulletHolder = GameObject.FindWithTag (bulletholderTag);
			if (_enemyHolder == null)
				_enemyHolder = GameObject.FindWithTag (enemyholderTag);
			if (_explosionsHolder == null)
				_explosionsHolder = GameObject.FindWithTag (explosionsTag);
		}

		public void LevelLost ()
		{
		}

		public void LevelWon ()
		{
		}
	}
}