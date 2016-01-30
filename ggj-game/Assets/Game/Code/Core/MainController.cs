//#define LOG_TRACE_INFO
//#define LOG_EXTRA_INFO

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
	private static MainController mainController;

	private string currentSceneName;
	private string nextSceneName;
	private AsyncOperation resourceUnloadTask;
	private AsyncOperation sceneLoadTask;

	private enum SceneState
	{
		Reset,
		Preload,
		Load,
		Unload,
		Postload,
		Ready,
		Run,
		Count
	};

	private SceneState sceneState;
	private delegate void UpdateDelegate ();
	private UpdateDelegate[] updateDelegates;

	public static void SwitchScene (string nextSceneName)
	{
		if (mainController != null) {
			if (mainController.currentSceneName != nextSceneName) {
				mainController.nextSceneName = nextSceneName;
			}
		}
	}

	protected void Awake ()
	{
		// Let's keep this alive between scene changes
		Object.DontDestroyOnLoad (gameObject);

		// Setup the singleton instance
		mainController = this;

		// Setup the array of updateDelegates
		updateDelegates = new UpdateDelegate[(int)SceneState.Count];

		// Set each updateDelegate
		updateDelegates [(int)SceneState.Reset] = UpdateSceneReset;
		updateDelegates [(int)SceneState.Preload] = UpdateScenePreload;
		updateDelegates [(int)SceneState.Load] = UpdateSceneLoad;
		updateDelegates [(int)SceneState.Unload] = UpdateSceneUnload;
		updateDelegates [(int)SceneState.Postload] = UpdateScenePostload;
		updateDelegates [(int)SceneState.Ready] = UpdateSceneReady;
		updateDelegates [(int)SceneState.Run] = UpdateSceneRun;

		nextSceneName = "Menu Scene";
		sceneState = SceneState.Reset;
		GetComponent<Camera> ().orthographicSize = Screen.height / 2;
	}

	protected void OnDestroy ()
	{
		// Clean up all the updateDelegates
		if (updateDelegates != null) {
			for (int i = 0; i < (int)SceneState.Count; i++) {
				updateDelegates [i] = null;
			}
			updateDelegates = null;
		}

		// Clean up the singleton instance
		if (mainController != null) {
			mainController = null;
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
		if (updateDelegates [(int)sceneState] != null) {
			updateDelegates [(int)sceneState] ();
		}
	}
		
	// attach the new scene controller to start cascade of loading
	private void UpdateSceneReset ()
	{
		// run a gc pass
		System.GC.Collect ();
		sceneState = SceneState.Preload;
	}

	// handle anything that needs to happen before loading
	private void UpdateScenePreload ()
	{
		sceneLoadTask = SceneManager.LoadSceneAsync (nextSceneName);
		sceneState = SceneState.Load;
	}

	// show the loading screen until it's loaded
	private void UpdateSceneLoad ()
	{
		// done loading?
		if (sceneLoadTask.isDone == true) {
			sceneState = SceneState.Unload;
		} else {
			// update scene loading progress
		}
	}

	// clean up unused resources by unloading them
	private void UpdateSceneUnload ()
	{
		// cleaning up resources yet?
		if (resourceUnloadTask == null) {
			resourceUnloadTask = Resources.UnloadUnusedAssets ();
		} else {
			// done cleaning up?
			if (resourceUnloadTask.isDone == true) {
				resourceUnloadTask = null;
				sceneState = SceneState.Postload;
			}
		}
	}

	// handle anything that needs to happen immediately after loading
	private void UpdateScenePostload ()
	{
		currentSceneName = nextSceneName;
		sceneState = SceneState.Ready;
	}

	// handle anything that needs to happen immediately before running
	private void UpdateSceneReady ()
	{
		// run a gc pass
		// if you have assets loaded in the scene that are
		// currently unused currently but may be used later
		// DON'T do this here
		System.GC.Collect ();
		sceneState = SceneState.Run;
	}

	// wait for scene change
	private void UpdateSceneRun ()
	{
		if (currentSceneName != nextSceneName) {
			sceneState = SceneState.Reset;
		}
	}
}
