﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour {

	public GameObject[] listCrossRoads;

	public int[] direct;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnMouseDown(){
		Debug.Log ("Click on Realmadrid: " + this.name);
		if (Shader.GetGlobalInt ("start") == 0) {
			Shader.SetGlobalInt ("start", 1);
		}
		setRoad ();
	}

	void setRoad(){
		for (int i = 0; i < direct.Length; i++) {
			listCrossRoads [i].GetComponent<CrossRoads> ().setDirect (direct[i]);
		}
	}
}
