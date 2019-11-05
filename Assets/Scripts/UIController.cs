using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public const string TriggerEnterLeft = "enter_left";
	public const string TriggerEnterRight = "enter_right";
	public const string TriggerExitLeft = "exit_left";
	public const string TriggerExitRight = "exit_right";

	public Color normalColor;
	public Color selectedColor;

	public PanelHome panelHome;
	public PanelStats panelStats;
	public PanelWorkouts panelWorkouts;
	public PanelProfile panelProfile;
	public PanelActivity panelActivity;

	public Button buttonHome;
	public Button buttonStats;
	public Button buttonWorkouts;
	public Button buttonProfile;

	public Panel activePanel;

	void Start() {
		panelHome.SetInactive();
		panelStats.SetInactive();
		panelWorkouts.SetInactive();
		panelProfile.SetInactive();
		panelActivity.SetInactive();

		ShowPanel(panelHome);
	}

	public void ShowPanel(Panel panel) {
		if (activePanel == panel)
			return;

		int activePanelIndex = activePanel ? activePanel.index : -1;

		if (activePanel)
			activePanel.animator.SetTrigger(activePanelIndex < panel.index ? TriggerExitLeft : TriggerExitRight);

		panel.gameObject.SetActive(true);
		panel.animator.SetTrigger(activePanelIndex < panel.index ? TriggerEnterRight : TriggerEnterLeft);

		activePanel = panel;

		UpdateColors();
	}

	public void UpdateColors() {
		UpdateButton(buttonHome, activePanel is PanelHome);
		UpdateButton(buttonStats, activePanel is PanelStats);
		UpdateButton(buttonWorkouts, activePanel is PanelWorkouts);
		UpdateButton(buttonProfile, activePanel is PanelProfile);
	}

	public void UpdateButton(Button button, bool active) {
		button.GetComponentInChildren<Image>().color = active ? selectedColor : normalColor;
		button.GetComponentInChildren<Text>().color = active ? selectedColor : normalColor;
	}
}