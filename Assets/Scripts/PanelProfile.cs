using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelProfile : Panel {
	public AppValues appValues;

	public AnimationCurve lerpCurve;
	public float animationTime = 1.2f;

	public Image minsWeekImage;
	public Image minsTodayImage;

	public Image ptsImage;
	public Image ptsHighscoreImage;

	void OnEnable() {
		StopAllCoroutines();

		StartCoroutine(UIUtils.FillEffect(lerpCurve, minsWeekImage, appValues.minutesWeeklyPercentage, animationTime));
		StartCoroutine(UIUtils.FillEffect(lerpCurve, minsTodayImage, appValues.minutesDailyPercentage, animationTime));

		StartCoroutine(UIUtils.FillEffect(lerpCurve, ptsImage, appValues.pointsWeeklyPercentage, animationTime));
		StartCoroutine(UIUtils.FillEffect(lerpCurve, ptsHighscoreImage, 1f, animationTime));
	}
}
