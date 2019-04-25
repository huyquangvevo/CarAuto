using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenCar : MonoBehaviour {


	void Start(){

		getDeviation ();
	
	}

	void Update(){
		//transform.Translate (transform.right*Time.deltaTime);
		//getEdge ();

	}

	public float getDeviation(){
	
		Vector3 posRay = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
//		Debug.Log ("Transform right: " + transform.right);
//		Debug.Log ("Transform up: " + transform.up);
		RaycastHit2D hitLeft = Physics2D.Raycast (posRay, - transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRay, transform.right);
		Debug.Log ("Forbiddend - hit left: " + hitLeft.distance);
		Debug.Log ("Forbiddend - hit right: " + hitRight.distance);
		if (hitLeft && hitRight)
			return hitRight.distance / (hitLeft.distance + hitRight.distance);
		else
			return 0;
	}


}
