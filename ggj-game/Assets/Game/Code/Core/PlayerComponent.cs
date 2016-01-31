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

	public void SwipeLeft ()
	{
		ChangeBehaviour (Behaviour.SwipeLeft);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic1);
	}


	public void SwipeRight ()
	{
		ChangeBehaviour (Behaviour.SwipeRight);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxMelodic2);
	}


	public void Tilt ()
	{
		ChangeBehaviour (Behaviour.Tilt);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxDistortedHat);
	}


	public void HoldStart ()
	{
		ChangeBehaviour (Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2);
	}


	public void HoldEnd ()
	{
		// TODO(oz) Differenciate hold end from hold start
		ChangeBehaviour (Behaviour.HoldStart);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxTams2);
	}


	public void Tap ()
	{
		ChangeBehaviour (Behaviour.Tap);
		SoundController.instance.PlaySfx (SoundController.SfxType.FxKickBassFast);
	}

	private void ChangeBehaviour (Behaviour b)
	{
		Debug.Log("Changing Behaviour to id: " + (int)b);
		animator.SetInteger ("Behaviour", (int)b);
	}
}
