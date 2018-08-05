using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	#region Static

	private static GameController instance;

	public static GameController I
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<GameController>();
			}
			return instance;
		}
	}

	#endregion

	#region Enums

	public enum GameState
	{
		Intro,
		Playing,
		Paused,
		End
	}

	#endregion

	#region Events

	public Action<Spaceship> OnSpaceshipMoved;

	#endregion

	#region Fields

	[SerializeField]
	private float horizontalMargin = 20f;

	private Spaceship spaceship;
	private Vector2 spaceshipTargetPos;

	#endregion

	#region Properties

	public GameState State { get; private set; }
	public bool IsPlaying { get { return Application.isPlaying && State == GameState.Playing; } }
	
	public Transform BulletHolder { get; private set; }

	#endregion

	#region Mono

	private void Awake()
	{
		Application.targetFrameRate = 60;
		
		spaceship = FindObjectOfType<Spaceship>();
		spaceshipTargetPos = spaceship.transform.position;

		BulletHolder = GameObject.Find("BulletHolder").transform;
	}

	private void Start()
	{
		// TODO: debug
		NewGame();
	}

	private void Update()
	{
		if (!IsPlaying)
			return;
		
		spaceship.MoveTo(spaceshipTargetPos);
		if (OnSpaceshipMoved != null)
		{
			OnSpaceshipMoved(spaceship);
		}
	}

	#endregion

	#region Public

	public void NewGame()
	{
		State = GameState.Playing;
	}

	public void MoveSpaceship(float diff)
	{
		var horizontalLimit = GameSettings.I.HorizontalLimit;
		spaceshipTargetPos.x = Mathf.Clamp(spaceshipTargetPos.x + diff, -horizontalLimit, horizontalLimit);
	}

	#endregion
}
