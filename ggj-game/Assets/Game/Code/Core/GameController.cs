//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour
{
	private static GameController gameController;
	private int currentFakeTargetId = 0;

	public static Signal<GameMessage> MessageReceivedSignal = new Signal<GameMessage> ();

	private enum GameState
	{
		Lobby,
		Started,
		End}

	;

	private GameState gameState;

	// Players
	public PlayerComponent[] players;

	protected void Awake ()
	{
		gameController = this;

		// Bind events
		MessageReceivedSignal.AddListener (OnServerMessage);
	}

	protected void OnDestroy ()
	{
		if (gameController != null) {
			gameController = null;
		}

		// Unbind events
		MessageReceivedSignal.RemoveListener (OnServerMessage);
	}

	protected void OnDisable ()
	{
		
	}


	protected void OnEnable ()
	{
		
	}


	protected void Start ()
	{
		
	}

	protected void Update ()
	{
		if (Input.GetKeyDown ("space"))
			FakeMsg ("gameEvent", "GAME_STARTING", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.Keypad1))
			currentFakeTargetId = 0;

		if (Input.GetKeyDown (KeyCode.Keypad2))
			currentFakeTargetId = 1;

		if (Input.GetKeyDown (KeyCode.Keypad3))
			currentFakeTargetId = 2;

		if (Input.GetKeyDown (KeyCode.Keypad4))
			currentFakeTargetId = 3;

		if (Input.GetKeyDown (KeyCode.Q))
			FakeMsg ("inputEvent", "SWIPE_LEFT", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.W))
			FakeMsg ("inputEvent", "SWIPE_RIGHT", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.E))
			FakeMsg ("inputEvent", "TILT", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.R))
			FakeMsg ("inputEvent", "HOLD_START", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.T))
			FakeMsg ("inputEvent", "HOLD_END", currentFakeTargetId);

		if (Input.GetKeyDown (KeyCode.Y))
			FakeMsg ("inputEvent", "TAP", currentFakeTargetId);

	}

	private void FakeMsg (string type, string ev, int targetId)
	{
		GameMessage msg = new GameMessage ();
		msg.e = ev;
		msg.type = type;
		msg.targetId = targetId;
		OnServerMessage (msg);
	}

	private void OnServerMessage (GameMessage msg)
	{
		if (msg.type == "gameEvent")
			OnGameEvent (msg);
		else if (msg.type == "inputEvent")
			OnInputEvent (msg);
	}
		
	/*
     * Message types
     */
	private void OnGameEvent (GameMessage msg)
	{
		Debug.Log (msg.e);
		if (msg.e == "GAME_STARTING")
			OnGameStart (msg);
		else if (msg.e == "GAME_LOADED")
			OnGameLoaded (msg);
		else if (msg.e == "GAME_END")
			OnGameEnd (msg);
	}

	private void OnInputEvent (GameMessage msg)
	{
		if (gameState != GameState.Started)
			return;

		// SWIPE_LEFT, SWIPE_RIGHT, TILT, HOLD_START, HOLD_END, TAP
		Debug.Log (msg.e);
		if (msg.e == "SWIPE_LEFT")
			OnPlayerSwipeLeft (msg);
		else if (msg.e == "SWIPE_RIGHT")
			OnPlayerSwipeRight (msg);
		else if (msg.e == "TILT")
			OnPlayerTilt (msg);
		else if (msg.e == "HOLD_START")
			OnPlayerHoldStart (msg);
		else if (msg.e == "HOLD_END")
			OnPlayerHoldEnd (msg);
		else if (msg.e == "TAP")
			OnPlayerTap (msg);
	}
		
	/*
     * Event types
     */
	private void OnGameLoaded (GameMessage msg)
	{
		Debug.Log ("* Game Loaded");
		gameState = GameState.Lobby;
	}

	private void OnGameStart (GameMessage msg)
	{
		Debug.Log ("* Game Start");
		gameState = GameState.Started;
	}

	private void OnGameEnd (GameMessage msg)
	{
		Debug.Log ("* Game End");
		gameState = GameState.End;
	}

	private void OnPlayerSwipeLeft (GameMessage msg)
	{
		players [msg.targetId].SwipeLeft ();
	}

	private void OnPlayerSwipeRight (GameMessage msg)
	{
		players [msg.targetId].SwipeRight ();
	}

	private void OnPlayerTilt (GameMessage msg)
	{
		players [msg.targetId].Tilt ();
	}

	private void OnPlayerHoldStart (GameMessage msg)
	{
		players [msg.targetId].HoldStart ();
	}

	private void OnPlayerHoldEnd (GameMessage msg)
	{
		players [msg.targetId].HoldEnd ();
	}

	private void OnPlayerTap (GameMessage msg)
	{
		players [msg.targetId].Tap ();
	}
}
