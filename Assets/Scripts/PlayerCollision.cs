using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	NoteCounter noteCounter;
	// Use this for initialization
	void Start () {
		noteCounter = GetComponent<NoteCounter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Obstacle") {
			Destroy(other.gameObject);
			//Drop a track?
			//Add weird distortion?
		}
		if (other.tag == "Note") {
			noteCounter.countNote(other.gameObject.GetComponent<Note>());
			Destroy(other.gameObject);
		}
    }
}
