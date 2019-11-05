using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivity : Panel {
	public Image progressImage;
	public Text timeText;
	public string timeTextFormat = @"mm\:ss";

	public int complimentIndex = 0;
	public List<string> compliments = new List<string>();

	public Text popupText;

	private int lastMinute = 9;
	private float maxTime = 600;
	private float time = 600;

	void OnEnable() {
		complimentIndex = UnityEngine.Random.Range(0, compliments.Count);
		lastMinute = 9;
		maxTime = 600;
		time = 600;
	}

	void Update() {
		if (time > 0) {
			time -= Time.deltaTime;
		}

		TimeSpan timeSpan = TimeSpan.FromSeconds(Mathf.Max(0, time));

		if (timeSpan.Minutes != lastMinute) {
			lastMinute = timeSpan.Minutes;
			popupText.text = compliments[complimentIndex++ % compliments.Count];
			popupText.gameObject.SetActive(false);
			popupText.gameObject.SetActive(true);
		}

		timeText.text = timeSpan.ToString(timeTextFormat);
		progressImage.fillAmount = 1f - (time / maxTime);
	}

	public void AddMinute(bool add) {
		if (add) {
			time += 60;

			if (time > maxTime) {
				maxTime = time;
			}
		}
		else {
			time = Mathf.Max(0, time - 60);
		}
	}
}