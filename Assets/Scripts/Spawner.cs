using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public string fileName;
	public GameObject Note;
	public GameObject Obstacle;
	private SpawnMap spawnMap;

	// Use this for initialization
	void Start () {
		spawnMap = new SpawnMap(fileName);
		foreach(var item in spawnMap.eventMap){ Spawn(item); }
		spawnObstacles();
	}
	
	// Update is called once per frame
	// void Update () {
	// }
	private void Spawn(SpawnEvent spawn)
	{
		Transform spawnLocation = transform;
		spawnLocation.position = new Vector2(spawn.xPos, GameManager.lanePositions[spawn.lane - 1]);
		var note = Instantiate<GameObject>(Note, spawnLocation.position, new Quaternion());
		note.GetComponent<Note>().groupId = spawn.groupId;
	}

	private void spawnObstacles(){
		System.Random rand = new System.Random();
		for(var i=6; i < 512; i++){

			var position = new Vector2(i*4, GameManager.lanePositions[rand.Next(0, 7)]);
			if (!spawnMap.eventMap.Any(e => e.vec == position)){
				var newObj = Instantiate(Obstacle, position, new Quaternion()) as GameObject;
			}
			var positionTwo = new Vector2(i*4, GameManager.lanePositions[rand.Next(0, 7)]);		
			if ((position != positionTwo) && !spawnMap.eventMap.Any(e => e.vec == positionTwo)){
				var newObj = Instantiate(Obstacle, positionTwo, new Quaternion()) as GameObject;
					
			}
		}
	}

	private class SpawnMap{
		public List<SpawnEvent> eventMap = new List<SpawnEvent>();

		// Use this for initialization
		public SpawnMap (string fileName) {
			string[] dataAsCsv = File.ReadAllLines($"Assets/Data/{fileName}");
			foreach(var line in dataAsCsv){
				string[] split = line.Split(',');
				eventMap.Add(new SpawnEvent(split[0].Trim(),split[1].Trim(),split[2].Trim()));
			}
		}
	}

	private class SpawnEvent{
		public int lane {get;set;}
		public float xPos {get;set;}
		public int groupId {get;set;}
		public Vector2 vec {get;set;}
		public SpawnEvent(string laneString, string xPosString, string groupString){
			lane = int.Parse(laneString);
			xPos = float.Parse(xPosString);
			groupId = int.Parse(groupString);
			
			vec = new Vector2(xPos, GameManager.lanePositions[lane - 1]);
		}
	}
}

