﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	public GameObject car;
	public GameObject forCar;

	public GameObject[] listCrossRoads;

	public GameObject camVM;

	// Use this for initialization
	void Awake(){
		Shader.SetGlobalInt ("start", 0);
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Shader.GetGlobalInt ("start") == 1) {
			if (!camVM.activeInHierarchy) {
				camVM.SetActive (true);
			};
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("Pressed primary button");
				createForbidden ();
			} else if (Input.GetMouseButtonDown (1)) {
				Debug.Log ("Pressed secornd button");
			} else if (Input.GetMouseButtonDown (2)) {
				Debug.Log ("Pressed middle click");
			}
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			SceneManager.LoadScene (0);
		}
	}

	void createForbidden(){
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		//Debug.Log ("Mouse Possition" + mousePos);

		float zAngle = Vector2.SignedAngle (car.GetComponent<DriveCar> ().directRoad, Vector2.up);

		Instantiate (forCar, mousePos, Quaternion.Euler(new Vector3(0,0,zAngle)));
	}
}
