using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCounter : MonoBehaviour {

	Dictionary<int,float> missedTimer = new Dictionary<int,float>();
	Dictionary<string,string> volumeControl = new Dictionary<string,string>();
	

	// Use this for initialization
	void Start () {
		//this isnt that great, but oh well
		volumeControl.Add("Audio Source Bass","none");
		volumeControl.Add("Audio Source Drums","none");
		volumeControl.Add("Audio Source Hihat","none");
		volumeControl.Add("Audio Source Synth","none");
		volumeControl.Add("Audio Source Pad","none");
		volumeControl.Add("Audio Source Chorus","none");
		volumeControl.Add("Audio Source Chip","none");
		
	}
	
	// Update is called once per frame
	void Update () {
		List<int> keys = new List<int>(missedTimer.Keys);
		foreach ( var key in keys){
			missedTimer[key] = missedTimer[key] - Time.deltaTime;
			if (missedTimer[key] <= 0 ){
				missedTimer.Remove(key);
			}
		}
		List<string> newKeys = new List<string>(volumeControl.Keys);
		foreach ( var key in newKeys){
			switch (volumeControl[key]){
				case "up":
					GameObject.Find(key).GetComponent<AudioSource>().volume = GameObject.Find(key).GetComponent<AudioSource>().volume + Time.deltaTime;	
					if(GameObject.Find(key).GetComponent<AudioSource>().volume >= 1){
						GameObject.Find(key).GetComponent<AudioSource>().volume = 1;
						volumeControl[key] = "none";
					}
					break;
				case "down":
					GameObject.Find(key).GetComponent<AudioSource>().volume = GameObject.Find(key).GetComponent<AudioSource>().volume - Time.deltaTime;
					if(GameObject.Find(key).GetComponent<AudioSource>().volume <= 0){
						GameObject.Find(key).GetComponent<AudioSource>().volume = 0;
						volumeControl[key] = "none";
					}
					break;
				case "none":
					// :)
					break;
			}
		}

	}

	public void countNote(Note note){
		if(!missedTimer.ContainsKey(note.groupId)){
			volumeControl[note.audioTrack] = "up";	
		}
	}
	public void missNote(Note note){
		volumeControl[note.audioTrack] = "down";	
		if (missedTimer.ContainsKey(note.groupId)){
			missedTimer[note.groupId] = 5;
		}else{
			missedTimer.Add(note.groupId,5);
		}
	}
}
