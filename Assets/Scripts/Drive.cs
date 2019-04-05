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
	//	Vector2 sp = new Vector2 (-5, 0);
	//	Vector2 ep = new Vector2 (5, 1);
		this.rb.velocity = new Vector2 (0.2f,0);
	//	this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 135));
	}

	void OnCollisionStay2D(Collision2D col){
		Debug.Log ("Contact: " + col.contactCount);
		Debug.Log ("Va Cham " + col.contacts.Length);
		for (int i = 0; i < col.contacts.Length; i++) {
			Debug.Log ("Diem va cham " + i + " " + col.GetContact(i).point);
		}
		//Debug.Log ("Diem va cham: " + col.GetContact(0).point);
		//if(col.contacts.Length>1)
		//	Debug.Log ("Diem va cham 2: " + col.GetContact(1).point);
	}

	void OnTriggerEnter2D(Collider2D coli){
		Debug.Log ("Cham Trigger");
	}
}
