using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DrawRoad : MonoBehaviour {

	public GameObject road;
	public Vector2 startPoint;
	public Vector2 endPoint;
	public List<Segment> listSegment;

	void Awake(){

		listSegment = new List<Segment> ();

	}
	// Use this for initialization
	void Start () {
		

		initMap ();
		Debug.Log (Application.dataPath+"/Data");
		for (int i = 0; i < listSegment.Count; i++) {
			Debug.Log ("Point: " + i + " : " + listSegment [i].startPoint + " - " + listSegment [i].endPoint);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initMap(){

		StreamReader sr = new StreamReader(Application.dataPath+"/Data/map.txt");
	
		string lineSeg;
		while ((lineSeg = sr.ReadLine ()) != null) {
			string[] pos = lineSeg.Split(' ');
			Vector2 startPoint = new Vector2 (float.Parse (pos [0]), float.Parse (pos [1]));
			Vector2 endPoint = new Vector2 (float.Parse (pos [2]), float.Parse (pos [3]));
			listSegment.Add (new Segment (startPoint, endPoint));
		}

		for (int j = 0; j < listSegment.Count; j++) {

			Segment seg = listSegment [j];

			if (seg.startPoint.x == seg.endPoint.x) {
				for(float i=seg.startPoint.y;i<seg.endPoint.y;i=i+0.5f){
					Instantiate (road, new Vector2 (seg.startPoint.x,i), Quaternion.Euler(new Vector3(0,0,90)));
				}
			} else {
				for(float i=seg.startPoint.x;i<seg.endPoint.x;i=i+0.5f){
					Instantiate (road, new Vector2 (i,seg.startPoint.y), Quaternion.Euler(new Vector3(0,0,0)));
				}
			}
				

		}
	}
}
