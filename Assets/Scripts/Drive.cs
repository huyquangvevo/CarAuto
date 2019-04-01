using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		driveCar ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void driveCar(){

		this.rb.velocity = new Vector2 (1.0f, 0f);
		
	}
}
