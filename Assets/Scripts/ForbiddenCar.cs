using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenCar : MonoBehaviour {

	public float speed = 0.5f;

	int layerCar;

	void Start(){

		getDeviation ();
		layerCar = LayerMask.GetMask ("Car");
	
	}

	void Update(){
		//getEdge ();
		move();
	}

	void move(){
		RaycastHit2D hitUpFor = Physics2D.Raycast (transform.position, transform.up, 2f, layerCar);
		if (hitUpFor) {
			this.speed = 0;
		} else {
			this.speed = 1f;
		}

		transform.Translate (-transform.up*this.speed*Time.deltaTime);
	}

	public float getDeviation(){
	
		Vector3 posRay = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
//		Debug.Log ("Transform right: " + transform.right);
//		Debug.Log ("Transform up: " + transform.up);
		RaycastHit2D hitLeft = Physics2D.Raycast (posRay, - transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRay, transform.right);
//		Debug.Log ("Forbiddend - hit left: " + hitLeft.distance);
//		Debug.Log ("Forbiddend - hit right: " + hitRight.distance);
		if (hitLeft && hitRight)
			return hitRight.distance / (hitLeft.distance + hitRight.distance);
		else
			return 0;
	}


}
