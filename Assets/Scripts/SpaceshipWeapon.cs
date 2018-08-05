using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipWeapon : MonoBehaviour
{

	#region Enums

	public enum SpaceshipWeaponType
	{
		Physical,
		Plasma,
		Laser,
		DarkMatter,
		RadiationParticles
	}

	#endregion

	#region Fields

	public SpaceshipWeaponType Type;
	public float Damage;
	public float Armor;
	public float RechargeTime;
	public int Level;
	public float Exp;
	public int Stars;
	public int WeaponId = -1;

	private float timeToShoot;

	#endregion

	#region Mono

	private void Awake()
	{
		timeToShoot = RechargeTime;
	}

	private void Update()
	{
		if (!GameController.I.IsPlaying)
			return;

		timeToShoot -= Time.deltaTime;

		if (timeToShoot <= 0f)
		{
			timeToShoot = RechargeTime;
			
			var bulletPrefab = GameSettings.I.BulletPrefabs.Find(b => b.WeaponId == WeaponId).Prefab;
			var bullet = Instantiate(bulletPrefab, GameController.I.BulletHolder);
			bullet.transform.position = transform.position;
			bullet.Initialize(Damage);
		}
	}

	#endregion

}
