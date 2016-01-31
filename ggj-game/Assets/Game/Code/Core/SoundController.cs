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
		Count
    }

	public enum MusicType {
		MusicBaseline
	}

	private uint[] activeSounds = new uint[(int)SfxType.Count];

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

		// Start all sfx in the background so they stay on beat
		sounds[(int)SfxType.FxCreeper1].volume = 0;
		sounds[(int)SfxType.FxCreeper2].volume = 0;
		sounds[(int)SfxType.FxTams1].volume = 0;
		sounds[(int)SfxType.FxKickSlow].volume = 0;
		sounds[(int)SfxType.FxDistortedHat].volume = 0;
		sounds[(int)SfxType.FxWeirdDrummish].volume = 0;
		sounds[(int)SfxType.FxKickBassFast].volume = 0;
		sounds[(int)SfxType.FxMetal1].volume = 0;
		sounds[(int)SfxType.FxMelodicDistorted1].volume = 0;
		sounds[(int)SfxType.FxMelodic2].volume = 0;
		sounds[(int)SfxType.FxTams2].volume = 0;
		sounds[(int)SfxType.FxMelodic1].volume = 0;
		sounds[(int)SfxType.FxWubBassSlow].volume = 0;

		sounds[(int)SfxType.FxCreeper1].Play();
		sounds[(int)SfxType.FxCreeper2].Play();
		sounds[(int)SfxType.FxTams1].Play();
		sounds[(int)SfxType.FxKickSlow].Play();
		sounds[(int)SfxType.FxDistortedHat].Play();
		sounds[(int)SfxType.FxWeirdDrummish].Play();
		sounds[(int)SfxType.FxKickBassFast].Play();
		sounds[(int)SfxType.FxMetal1].Play();
		sounds[(int)SfxType.FxMelodicDistorted1].Play();
		sounds[(int)SfxType.FxMelodic2].Play();
		sounds[(int)SfxType.FxTams2].Play();
		sounds[(int)SfxType.FxMelodic1].Play();
		sounds[(int)SfxType.FxWubBassSlow].Play();
    }

    public void PlaySfx (SfxType sfx) {
		activeSounds[(int)sfx] += 1;
		sounds[(int)sfx].volume = 1.0f;
    }

	public void StopSfx (SfxType sfx) {
		activeSounds[(int)sfx] -= 1;
		sounds[(int)sfx].volume = 0f;
	}
}
