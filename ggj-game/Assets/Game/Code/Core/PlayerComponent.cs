using UnityEngine;
using System.Collections;

public class PlayerComponent : MonoBehaviour {

    private enum Behaviour {
        SwipeLeft,
        SwipeRight,
        Tilt,
        HoldStart,
        HoldEnd,
        Tap
    };

    private Animator animator;


    // Use this for initialization
    void Start () {

        animator = this.GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update () {
	
	}


    public void SwipeLeft() {

        ChangeBehaviour(Behaviour.SwipeLeft);
        SoundController.instance.PlaySfx(SoundController.SfxType.FxCreeper1);

    }


    public void SwipeRight() {

        ChangeBehaviour(Behaviour.SwipeRight);

    }


    public void Tilt() {

        ChangeBehaviour(Behaviour.Tilt);

    }


    public void HoldStart() {

        ChangeBehaviour(Behaviour.HoldStart);

    }


    public void HoldEnd() {

        ChangeBehaviour(Behaviour.HoldEnd);

    }


    public void Tap() {

        ChangeBehaviour(Behaviour.Tap);

    }

    private void ChangeBehaviour(Behaviour b) {

        animator.SetInteger("Behaviour", (int)b);

    }
}
