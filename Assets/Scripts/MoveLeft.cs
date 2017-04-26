using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveLeft : MonoBehaviour {
	private float tempo;
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position -= new Vector3(0.156666666f, 0.0f, 0.0f);
		if (tag == "Note" && transform.position.x < GameObject.Find("Player").transform.position.x - 4){
				GameObject.Find("Player").GetComponent<NoteCounter>().missNote(gameObject.GetComponent<Note>());
			}
		if (transform.position.x < -15 ){
			Destroy(gameObject);
		}
	}
}
