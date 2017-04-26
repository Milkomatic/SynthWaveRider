using UnityEngine;

public class ChangeLane : MonoBehaviour {
	private float? newLane;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		if(Input.GetButton("Lane1")) newLane = GameManager.lane1;
		if(Input.GetButton("Lane2")) newLane = GameManager.lane2;
		if(Input.GetButton("Lane3")) newLane = GameManager.lane3;
		if(Input.GetButton("Lane4")) newLane = GameManager.lane4;
		if(Input.GetButton("Lane5")) newLane = GameManager.lane5;
		if(Input.GetButton("Lane6")) newLane = GameManager.lane6;
		if(Input.GetButton("Lane7")) newLane = GameManager.lane7;
		if (newLane.HasValue) transform.position = new Vector3(transform.position.x, newLane.Value);
	}
}
