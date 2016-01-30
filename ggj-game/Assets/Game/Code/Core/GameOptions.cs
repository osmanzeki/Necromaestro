using UnityEngine;
using System.Collections;

public class GameOptions
{
	public static int targetFramerate;

	static GameOptions ()
	{
		SetDefaults ();
	}

	static void SetDefaults ()
	{
		targetFramerate = 60;
	}
}