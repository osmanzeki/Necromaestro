using UnityEngine;
using System.Collections;
using DG.Tweening;

public class SoundController : MonoBehaviour {

    public static SoundController instance;

    public AudioSource[] sounds;
	public AudioSource[] music;

	private AudioSource baselineMusic;

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
        FxWubBassSlow,
    }

	public enum MusicType {
		MusicBaseline
	}

    protected void Awake() {
        instance = this;

		// Play baseline music
		baselineMusic = this.music[(int)MusicType.MusicBaseline];
		baselineMusic.volume = 0f;
		baselineMusic.Play();

		// Tween volume
		baselineMusic
			.DOFade(1.0f, 3f)
			.SetEase(Ease.InSine);

    }

	public void PlayMusic (MusicType music) {
		this.music[(int)music].Play();
	}

    public void PlaySfx (SfxType Sfx) {
        this.sounds[(int)Sfx].Play();
    }
}
