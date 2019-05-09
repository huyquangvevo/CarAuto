using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	public GameObject car;
	public GameObject forCar;

	public GameObject[] listCrossRoads;

	Queue map;

	// Use this for initialization
	void Start () {
		map = new Queue ();
		map.Enqueue (1);
		map.Enqueue (2);
		Debug.Log ("Map Road : ");
		Debug.Log ("Cross 1: " + map.Peek());
		map.Dequeue ();
		Debug.Log ("Cross 2: " + map.Peek ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("Pressed primary button");
			createForbidden ();
		} else if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("Pressed secornd button");
		} else if (Input.GetMouseButtonDown(2)){
			Debug.Log ("Pressed middle click");
		}
	}

	void createForbidden(){
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Debug.Log ("Mouse Possition" + mousePos);

		float zAngle = Vector2.SignedAngle (-car.GetComponent<DriveCar> ().directRoad, Vector2.up);

		Instantiate (forCar, mousePos, Quaternion.Euler(new Vector3(0,0,zAngle)));
	}
}
