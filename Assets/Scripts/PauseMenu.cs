using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	public Transform canvas;
	void Update () {
		if(Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape)) {
			ToggleMenu();
		}
	}

	public void ToggleMenu(){
			canvas.gameObject.SetActive(!canvas.gameObject.activeInHierarchy);
			Time.timeScale = canvas.gameObject.activeInHierarchy ? 0f : 1f;
			AudioListener.pause = canvas.gameObject.activeInHierarchy;
	}
}
