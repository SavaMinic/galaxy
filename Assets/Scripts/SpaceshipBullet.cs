using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBullet : MonoBehaviour
{

	#region Fields

	[SerializeField]
	private float speed;

	[SerializeField]
	private SpaceshipWeapon.SpaceshipWeaponType type;

	private float baseDamage;

	#endregion

	#region Properties

	public SpaceshipWeapon.SpaceshipWeaponType Type { get { return type; } }
	public bool IsExploding { get; private set; }

	#endregion

	#region Mono

	private void Update()
	{
		if (!GameController.I.IsPlaying || IsExploding)
			return;

		transform.position = Vector2.Lerp(transform.position, transform.position + Vector3.up * speed, Time.deltaTime);

		if (transform.position.y >= GameSettings.I.TopPositionLimit)
		{
			StartCoroutine(Explode());
		}
	}

	#endregion

	#region Public

	public void Initialize(float damage)
	{
		baseDamage = damage;
	}

	#endregion

	#region Private

	private IEnumerator Explode()
	{
		IsExploding = true;
		yield return new WaitForSeconds(0.4f);
		
		Destroy(gameObject);
	}

	#endregion

}
