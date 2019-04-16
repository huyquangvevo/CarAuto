using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	//	driveCar ();
		Physics2D.IgnoreLayerCollision(10,5,true);
		Debug.Log ("Mo: " + Steerage.clarify (0.35f));
		Debug.Log ("Physic : " + Physics2D.DefaultRaycastLayers);
	}
	
	void Update () {
		steer();
		controlSpeed ();
	}

	void driveCar(){

		this.rb.velocity = new Vector2 (1f,0f)*speed;
	}


	float getDeviation(){
		Vector3 posRayLeft = new Vector3 (transform.position.x + 0.3f, transform.position.y + 0.2f, transform.position.z);
		Vector3 posRayRight = new Vector3 (transform.position.x + 0.3f, transform.position.y - 0.2f, transform.position.z);

		RaycastHit2D hitLeft = Physics2D.Raycast (posRayLeft, -transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRayRight, transform.right);

		if (hitLeft && hitRight) {
		//	Debug.Log ("InRoad");
		//	Debug.Log ("Hit Left: " + hitLeft.distance);
		//	Debug.Log ("Hit Right: " + hitRight.distance);
			return (hitLeft.distance) / (hitLeft.distance + hitRight.distance);
		} else {
		//	Debug.Log ("***** OutRoad *****");
			return 0f;
		}
	}

	void steer(){
		float x = getDeviation ();
		if (x == 0f) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, -90));
			return;		
		}
		float st = Steerage.clarify (x);
		//Debug.Log ("Steering: " + st);
		float direction = -(st - 0.5f) * 180f;
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, -90 + direction));
		Vector2 v;
		if (st < 0.5f)
			v = new Vector2 (1f * Mathf.Tan (Mathf.PI * st), 1f) ;
		else if (st > 0.5f)
			v = new Vector2 (-1f * Mathf.Tan (Mathf.PI * st), -1f);
		else
			v = new Vector2 (1f, 1f);
		speed = Mathf.Abs (v.y / (2*v.x));
		//Debug.Log ("Vector velocity: " + v);
		rb.velocity = v*speed;
	}

	void controlSpeed(){
		Vector3 posRayUp = new Vector3 (transform.position.x, transform.position.y + 0.2f, transform.position.z);

		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp, transform.up);

		if(hitUp)
		if (hitUp.collider.gameObject.tag == "TrafficLight") {

			TrafficLightController traffic = (TrafficLightController) hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
			
			if(hitUp.distance < 0.5f)
				hitUp.collider.enabled = false;
		}

	}
		

}
