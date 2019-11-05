using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Panel : MonoBehaviour {
	public int index = 0;
	public Animator animator;

	public void SetActive() {
		gameObject.SetActive(true);
	}

	public void SetInactive() {
		gameObject.SetActive(false);
	}

}