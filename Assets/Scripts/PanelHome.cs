using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHome : Panel {
	public AppValues appValues;
	public AnimationCurve lerpCurve;
	public float animationTime = 0.5f;

	[Header("Points")]
	public Image pointsImage;
	public Text pointsText;
	public string pointsTextFormat = "{0} pts";
	public Text pointsHighscoreText;
	public string pointsHighscoreTextFormat = "Highscore: {0} pts";

	[Header("Mins")]
	public Image minsImage;
	public Text minsText;
	public string minsTextFormat = "{0}/{1} mins";
	public Text minsWeeklyText;
	public string minsWeeklyTextFormat = "Weekly: {0}/{1} mins";

	[Header("Settings")]
	public RectTransform activityPopup;
	public RectTransform workoutPopup;
	public RectTransform teamPopup;


	void OnEnable() {
		ShowActivityPopup(false);
		ShowWorkoutPopup(false);
		ShowTeamPopup(false);

		pointsHighscoreText.text = string.Format(pointsHighscoreTextFormat, appValues.pointsWeeklyHighscore);
		minsWeeklyText.text = string.Format(minsWeeklyTextFormat, appValues.minutesWeeklyDone, appValues.minutesWeekly);

		StopAllCoroutines();

		StartCoroutine(UIUtils.FillEffect(lerpCurve, pointsImage, appValues.pointsWeeklyPercentage, animationTime));
		StartCoroutine(UIUtils.CountEffect(lerpCurve, pointsText, pointsTextFormat, appValues.pointsWeekly, animationTime));

		string minutesFormat = string.Format(minsTextFormat, "{0}", appValues.minutesDaily);

		StartCoroutine(UIUtils.FillEffect(lerpCurve, minsImage, appValues.minutesDailyPercentage, animationTime));
		StartCoroutine(UIUtils.CountEffect(lerpCurve, minsText, minutesFormat, appValues.minutesDailyDone, animationTime));
	}

	public void ShowActivityPopup(bool show) {
		activityPopup.gameObject.SetActive(show);
	}

	public void ShowWorkoutPopup(bool show) {
		workoutPopup.gameObject.SetActive(show);
	}

	public void ShowTeamPopup(bool show) {
		teamPopup.gameObject.SetActive(show);
	}
}