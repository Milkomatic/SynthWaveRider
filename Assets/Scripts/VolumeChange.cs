using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChange : MonoBehaviour {
	public Slider slider;
	void Update(){
		AudioListener.volume = slider.value;
	}
}
