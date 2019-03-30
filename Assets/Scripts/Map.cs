using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map : MonoBehaviour{
	public List<Segment> listSegment = new List<Segment>();

	public void initSegements(){
	
		this.listSegment.Add (new Segment (new Vector2 (-5, 0), new Vector2 (5, 0)));

	}

	void Start() {

		initSegements ();
		JsonUtility.ToJson (this.listSegment);

	}
}
