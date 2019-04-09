using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive2 : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = 20.0f;

	private Vector3 moveDriection = Vector3.zero;
	private CharacterController controller;

	void Start(){
		controller = GetComponent<CharacterController> ();
	}

	void Update(){
		if (controller.isGrounded) {
			moveDriection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"),0f);
			moveDriection = transform.TransformDirection (moveDriection);
			moveDriection = speed * moveDriection;
		}

		moveDriection.y = moveDriection.y - (gravity * Time.deltaTime);
		controller.Move (moveDriection * Time.deltaTime);
	}

	void OnCollisionStay2D(Collision2D col){
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

	void OnCollisionEnter2D(Collision2D c){
		Debug.Log ("cham");
	}
}
