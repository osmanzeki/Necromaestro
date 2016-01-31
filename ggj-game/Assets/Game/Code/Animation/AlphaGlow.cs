using UnityEngine;
using System.Collections;
using DG.Tweening;

public class AlphaGlow : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Transform myTransform;

	void Start ()
	{
		// Caches
		spriteRenderer = GetComponent<SpriteRenderer>();
		myTransform = GetComponent<Transform>();

		// Set initial alpha
		Color color = spriteRenderer.material.color;
		spriteRenderer.material.color = new Color(color.r, color.g, color.b, 0.4f);

		float duration = Random.Range(0.8f, 1.6f);

		// Tween alpha
		spriteRenderer.material
			.DOFade(0.1f, duration)
			.SetEase(Ease.InOutSine)
			.SetLoops(-1, LoopType.Yoyo);

		// Tween scale
		myTransform.DOScale(new Vector3(0.75f, 0.5f, 1f), duration)
			.SetEase(Ease.InOutSine)
			.SetLoops(-1, LoopType.Yoyo);
	}
}