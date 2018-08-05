using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

	#region Fields

	[SerializeField]
	private float speed;

	private RectTransform rectTransform;

	#endregion

	#region Properites

	#endregion

	private void Awake()
	{
	}

	public void MoveTo(Vector3 targetPos)
	{
		transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
	}
}
