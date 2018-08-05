using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : SingletonScriptableObject<GameSettings>
{

	[System.Serializable]
	public class BulletData
	{
		public int WeaponId;
		public SpaceshipBullet Prefab;
	}
	
	public List<BulletData> BulletPrefabs;

	public float HorizontalLimit;
	public float TopPositionLimit;

	public float PixelsToWorld;
}
