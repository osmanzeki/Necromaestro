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
        Debug.Log("SwipeLeft");
		ChangeBehaviour (Behaviour.SwipeLeft);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic1, msg.targetId);
	}


	public void SwipeRight (GameMessage msg)
	{
        Debug.Log("SwipeRight");
        ChangeBehaviour(Behaviour.SwipeRight);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic2, msg.targetId);
	}


	public void Tilt (GameMessage msg)
	{
        Debug.Log("Tilt");
        ChangeBehaviour(Behaviour.Tilt);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxDistortedHat, msg.targetId);
	}


	public void HoldStart (GameMessage msg)
	{
        Debug.Log("HoldStart");
        ChangeBehaviour(Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2, msg.targetId);
	}


	public void HoldEnd (GameMessage msg)
	{
        Debug.Log("HoldEnd");
        // TODO(oz) Differenciate hold end from hold start
        ChangeBehaviour(Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2, msg.targetId);
	}


	public void Tap (GameMessage msg)
	{
        Debug.Log("Tap");
        ChangeBehaviour(Behaviour.Tap);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxKickBassFast, msg.targetId);
	}

	private void ChangeBehaviour (Behaviour b)
	{
        Debug.Log("ChangeBehaviour");
        Debug.Log("Changing Behaviour to id: " + (int)b);
		animator.SetInteger ("Behaviour", (int)b);
	}
}
