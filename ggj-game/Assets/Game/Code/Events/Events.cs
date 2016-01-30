using UnityEngine;
using System.Collections;

public static class GameEvents
{
	// ENUMS
	
	public enum GameEventType {
		INSTRUCTION
	}

	public enum GameEventAction {
		SWIPE_LEFT,
		SWIPE_RIGHT,
		TILT,
		HOLD,
		TAP
	}

	// EVENT TYPE & DETAILS

	public class GameEventDetails {
		public GameEventAction action;
		public int playerCount;
	}

	// EVENT

	public static Signal<GameEventType, GameEventDetails> Instruction = new Signal<GameEventType, GameEventDetails> ();
}

public static class InputEvents
{
	public class InputEventDetails {}

	public static Signal<InputEventDetails> SwipeLeftSignal = new Signal<InputEventDetails> ();
	public static Signal<InputEventDetails> SwipeRightSignal = new Signal<InputEventDetails> ();
	public static Signal<InputEventDetails> TiltSignal = new Signal<InputEventDetails> ();
	public static Signal<InputEventDetails> HoldStartSignal = new Signal<InputEventDetails> ();
	public static Signal<InputEventDetails> HoldEndSignal = new Signal<InputEventDetails> ();
	public static Signal<InputEventDetails> TapSignal = new Signal<InputEventDetails> ();
}
