using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		driveCar ();
		Debug.Log (transform.right);
	}
	
	// Update is called once per frame
	void Update () {
		getEdge ();
	}

	void driveCar(){
	//	Vector2 sp = new Vector2 (-5, 0);
	//	Vector2 ep = new Vector2 (5, 1);
		this.rb.velocity = new Vector2 (0.2f,0);
	//	this.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 135));
	}

	void OnCollisionStay2(Collision2D col){
		Debug.Log ("Contact: " + col.contactCount);
		Debug.Log ("Va Cham " + col.contacts.Length);
	//	for (int i = 0; i < col.contacts.Length; i++) {
	//		Debug.Log ("Diem va cham " + i + " " + col.GetContact(i).point);
	//	}

		foreach (ContactPoint2D c in col.contacts) {
			Debug.Log ("Diem va cham " + c.point);
		}

		//Debug.Log ("Diem va cham: " + col.GetContact(0).point);
		//if(col.contacts.Length>1)
		//	Debug.Log ("Diem va cham 2: " + col.GetContact(1).point);
	}

	void OnTriggerEnter2(Collider2D coli){
		Debug.Log ("Cham Trigger");
	}

	void getEdge(){
		Vector3 posRayLeft = new Vector3 (transform.position.x + 0.3f, transform.position.y + 0.2f, transform.position.z);
		Vector3 posRayRight = new Vector3 (transform.position.x + 0.3f, transform.position.y - 0.2f, transform.position.z);

		RaycastHit2D hitLeft = Physics2D.Raycast (posRayLeft, -transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRayRight, transform.right);

		if (hitLeft != null || hitRight != null) {
			Debug.Log ("InRoad");
			Debug.Log ("Hit Left: " + hitLeft.distance);
			Debug.Log ("Hit Right: " + hitRight.distance);
		} else {
			Debug.Log ("***** OutRoad *****"); 
		}

	}
}
