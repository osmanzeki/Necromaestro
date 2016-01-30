//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private static GameController gameController;

	protected void Awake ()
	{
		gameController = this;

		// Bind events
		InputEvents.Signals[(int)InputEvents.Events.SWIPE_LEFT].AddListener(OnSwipeLeft);
	}

	protected void OnDestroy ()
	{
		if (gameController != null) {
			gameController = null;
		}

		// Unbind events
		InputEvents.Signals[(int)InputEvents.Events.SWIPE_LEFT].RemoveListener(OnSwipeLeft);
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

	private void OnSwipeLeft () {
		Debug.Log ("GAME IS NOW SWIPING LEFT!!!");
	}
}
