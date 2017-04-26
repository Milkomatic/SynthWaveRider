using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

	public int groupId;
	public string audioTrack;

	// Use this for initialization
	void Start () {
		switch(groupId){
			case 1:
				audioTrack = "Audio Source Bass";
				break;
			case 2:
				audioTrack = "Audio Source Drums";
				break;
			case 3:
				audioTrack = "Audio Source Hihat";
				break;
			case 4:
				audioTrack = "Audio Source Pad";
				break;
			case 5:
				audioTrack = "Audio Source Chorus";
				break;
			case 6:
				audioTrack = "Audio Source Synth";
				break;
			case 7:
				audioTrack = "Audio Source Chip";
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
