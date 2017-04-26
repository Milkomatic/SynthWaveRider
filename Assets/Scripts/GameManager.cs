using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager GM;
	public static float tempo = 128f;
	public static float lane1 = -4.1f;
	public static float lane2 = -2.7f;
	public static float lane3 = -1.3f;
	public static float lane4 = 0.1f;
	public static float lane5 = 1.5f;
	public static float lane6 = 2.9f;
	public static float lane7 = 4.3f;
	public static float[] lanePositions = new float[]{lane1, lane2, lane3, lane4, lane5, lane6, lane7};
	void Awake(){
		if (GM != null) GameObject.Destroy(GM);
		else GM = this;
		DontDestroyOnLoad(this);
	}
}
