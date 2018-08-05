using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainEventTrigger : EventTrigger
{

	private float lastDragPos;
	
	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);

		lastDragPos = Input.mousePosition.x;
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);

		var diffPos = Input.mousePosition.x - lastDragPos;
		
		Debug.LogError(diffPos);
		GameController.I.MoveSpaceship(diffPos * GameSettings.I.PixelsToWorld);

		lastDragPos = Input.mousePosition.x;
	}
}
