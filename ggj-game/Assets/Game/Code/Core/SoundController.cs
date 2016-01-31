using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    public static SoundController instance;

    public AudioSource[] sounds;

    public enum SfxType {
        FxCreeper1,
        FxCreeper2,
        FxTams1,
        FxKickSlow,
        FxDistortedHat,
        FxWeirdDrummish,
        FxKickBassFast,
        FxMetal1,
        FxMelodicDistorted1,
        FxMelodic2,
        FxTams2,
        FxMelodic1,
        FxWubBassSlow
    }

    protected void Awake()
    {
        instance = this;
    }


    public void PlaySfx (SfxType Sfx) {

        sounds[(int)Sfx].Play();
    }
}
