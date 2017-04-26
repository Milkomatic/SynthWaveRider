using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject Obstacle;

	// Use this for initialization
	void Start () {
		System.Random rand = new System.Random();
		for(var i=0; i < 512; i++){
			var position = new Vector2(i*4, GameManager.lanePositions[rand.Next(0, 7)]);
			GameObject newObj = Instantiate(Obstacle, position, new Quaternion()) as GameObject;
			var secondPosition = new Vector2(i*4, GameManager.lanePositions[rand.Next(0, 7)]);
			if (secondPosition != position){
				newObj = Instantiate(Obstacle, secondPosition, new Quaternion()) as GameObject;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
