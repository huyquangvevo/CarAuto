using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossRoads : MonoBehaviour {

	public int direct;
	public GameObject[] listRoad;

	// Use this for initialization
	void Start () {
		if(listRoad[this.direct] != null)
			listRoad [this.direct].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDirect(int d){
		listRoad [d].SetActive (true);
	}
}
