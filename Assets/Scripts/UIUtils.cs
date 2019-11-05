using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UIUtils {
	public static IEnumerator FillEffect(AnimationCurve lerp, Image image, float max, float time) {
		WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();
		float currentTime = 0;

		while (currentTime < time) {
			currentTime += Time.deltaTime;

			float percentage = currentTime / time;
			float fillPercentage = lerp.Evaluate(percentage);
			float fill = max * fillPercentage;

			image.fillAmount = fill;

			yield return waitFrame;
		}

		image.fillAmount = max;
	}

	public static IEnumerator CountEffect(AnimationCurve lerp, Text text, string textFormat, int max, float time) {
		WaitForEndOfFrame waitFrame = new WaitForEndOfFrame();
		float currentTime = 0;

		while (currentTime < time) {
			currentTime += Time.deltaTime;

			float percentage = currentTime / time;
			float fillPercentage = lerp.Evaluate(percentage);
			float fill = (float)max * fillPercentage;

			text.text = string.Format(textFormat, Mathf.RoundToInt(fill));

			yield return waitFrame;
		}

		text.text = string.Format(textFormat, max);
	}
}