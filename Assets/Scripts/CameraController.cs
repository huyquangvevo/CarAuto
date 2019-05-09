using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization

	Camera cam;

	float l;

	float horizontal;
	float vertical;

	void Start () {
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		l = Input.GetAxis ("Mouse ScrollWheel");
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		cam.orthographicSize += l*10;
		transform.position = transform.position + new Vector3 (horizontal*5, vertical*5,0);
	}
}
