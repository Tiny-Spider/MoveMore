using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppValues : MonoBehaviour {
	public int minutesWeekly = 150;
	public int minutesWeeklyDone = 59;
	public int minutesDaily = 22;
	public int minutesDailyDone = 15;
	public int pointsWeekly = 1504;
	public int pointsWeeklyHighscore = 2540;

	public float minutesDailyPercentage { get { return (float)minutesDailyDone / (float)minutesDaily; } }
	public float minutesWeeklyPercentage { get { return (float)minutesWeeklyDone / (float)minutesWeekly; } }
	public float pointsWeeklyPercentage { get { return (float)pointsWeekly / (float)pointsWeeklyHighscore; } }

	public void Randomize() {
		minutesWeekly = Random.Range(100, 200);
		minutesWeeklyDone = Random.Range(20, minutesWeekly);

		minutesDaily = Mathf.RoundToInt((float)minutesWeekly / 7f);
		minutesDailyDone = Random.Range(5, minutesDaily);

		pointsWeeklyHighscore = Random.Range(2000, 4000);
		pointsWeekly = Random.Range(1000, pointsWeeklyHighscore);
	}
}