using UnityEngine;
using System.Collections;

public class PlayerComponent : MonoBehaviour
{
	private enum Behaviour
	{
		SwipeLeft,
		SwipeRight,
		Tilt,
		HoldStart,
		HoldEnd,
		Tap
	};

	private Animator animator;

	void Start ()
	{
		animator = this.GetComponent<Animator> ();
		ChangeBehaviour (Behaviour.HoldStart);
	}

	public void SwipeLeft (GameMessage msg)
	{
		ChangeBehaviour (Behaviour.SwipeLeft);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic1, msg.targetId);
	}


	public void SwipeRight (GameMessage msg)
	{
		ChangeBehaviour (Behaviour.SwipeRight);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic2, msg.targetId);
	}


	public void Tilt (GameMessage msg)
	{
		ChangeBehaviour (Behaviour.Tilt);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxDistortedHat, msg.targetId);
	}


	public void HoldStart (GameMessage msg)
	{
		ChangeBehaviour (Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2, msg.targetId);
	}


	public void HoldEnd (GameMessage msg)
	{
		// TODO(oz) Differenciate hold end from hold start
		ChangeBehaviour (Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2, msg.targetId);
	}


	public void Tap (GameMessage msg)
	{
		ChangeBehaviour (Behaviour.Tap);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxKickBassFast, msg.targetId);
	}

	private void ChangeBehaviour (Behaviour b)
	{
		Debug.Log("Changing Behaviour to id: " + (int)b);
		animator.SetInteger ("Behaviour", (int)b);
	}
}
