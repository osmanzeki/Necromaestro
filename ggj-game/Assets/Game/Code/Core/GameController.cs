//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private static GameController gameController;

	public static Signal<GameMessage> MessageReceivedSignal = new Signal<GameMessage>();

	// Players
	public GameObject[] players;

	protected void Awake ()
	{
		gameController = this;

		// Bind events
		MessageReceivedSignal.AddListener(OnServerMessage);
	}

	protected void OnDestroy ()
	{
		if (gameController != null) {
			gameController = null;
		}

		// Unbind events
		MessageReceivedSignal.RemoveListener(OnServerMessage);
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
		
	}

	private void OnServerMessage (GameMessage msg)
	{
		Debug.Log(msg.e);
	}
}
