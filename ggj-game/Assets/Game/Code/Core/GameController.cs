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
	}

	protected void OnDestroy ()
	{
		if (gameController != null) {
			gameController = null;
		}
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
		if (Input.GetMouseButtonDown (0) == true) {
			MainController.SwitchScene ("Menu Scene");
		}
	}
}
