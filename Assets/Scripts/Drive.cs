using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 0.3f;
	public float direction = -0.5f;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	//	driveCar ();
	}

	void OnTriggerEnter2D(Collider2D col){
	//	Physics2D.IgnoreCollision (GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
		if (col.gameObject.name == "ForbiddenCar")
			col.enabled = false;
		if (col.gameObject.name == "TrafficLight") {
			col.enabled = false;
		}
		Debug.Log (col.gameObject.name);
	}
	
	void Update () {
	//	steer(getDeviation());
		controlSpeed ();
	}

	void driveCar(){

		this.rb.velocity = new Vector2 (1f,0f)*speed;
	}


	float getDeviation(){
		Vector3 posRayLeft = new Vector3 (transform.position.x + 0.3f, transform.position.y/* + 0.2f*/, transform.position.z);
		Vector3 posRayRight = new Vector3 (transform.position.x + 0.3f, transform.position.y/* - 0.2f*/, transform.position.z);

		RaycastHit2D hitLeft = Physics2D.Raycast (posRayLeft, -transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRayRight, transform.right);

		if (hitLeft && hitRight) {
			if (hitLeft.collider.gameObject.tag == "TrafficLight" || hitRight.collider.gameObject.tag == "TrafficLight") {
				return 1;
			}
		//	Debug.Log ("InRoad");
		//	Debug.Log ("Hit Left: " + hitLeft.distance);
		//	Debug.Log ("Hit Right: " + hitRight.distance);
			float mid = (hitLeft.distance + hitRight.distance)/2f;
		//	return (hitLeft.distance) / (hitLeft.distance + hitRight.distance);
			return (hitLeft.distance-mid) / (mid);
		} else {
		//	Debug.Log ("***** OutRoad *****");
			return 0f;
		}
	}

	void steer(float x){
		if (x == 0f) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, direction*180));
			return;		
		}
		float st = Steerage.clarify (x);
	//		Debug.Log ("Steerage: " + st);
		float d = -(st - 0.5f) * 180f;
	//	Debug.Log ("Degree: " + d);
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, direction*180+d));
		//Debug.Log ("Rotation: "+ transform.rotation);
		Vector2 v = getDirectVelocity(st);
	
		rb.velocity = v*this.speed*1.5f;
	//	Debug.Log ("Velocity: "+rb.velocity);
	}

	void controlSpeed(){
		Vector3 posRayUp = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp, transform.up);
		float dev = getDeviation ();
		if (dev == 1)
			return;
		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));

		if (hitUp) {
			if (hitUp.collider.gameObject.tag == "TrafficLight") {

				TrafficLightController traffic = (TrafficLightController)hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
				float dis = hitUp.distance;
			//	Debug.Log ("Distance: "+dis);
				this.speed = Mathf.Abs (Speed.clarify (traffic.getIdL (), traffic.getRatioTime (), dis, dev));
				//Debug.Log ("Distance: " + dis + " Time: " + traffic.getRatioTime() + " Deviation: " + dev);
			//	Debug.Log ("Speed Controll: " + this.speed);
			} else if(hitUp.collider.gameObject.tag == "ForbiddenCar"){
				float df = hitUp.collider.gameObject.GetComponent<ForbiddenCar> ().getDeviation ();
				this.speed = Mathf.Abs (Forbidden.clarify (hitUp.distance, df, 0));
				Debug.Log ("ForbiddenCar Distance: " + hitUp.distance);
				Debug.Log ("ForbiddenCar Deviation: " + df);
			}
		};
	//	if(this.speed > 1f)
	//	Debug.Log ("Speed Controll: " + this.speed);

		steer (dev);
	}

	Vector2 getDirectVelocity(float steer){
		Vector2 v_;
		if (this.direction == -0.5f) {
			if (steer < 0.5f)
				v_ = new Vector2 (1f * Mathf.Tan (Mathf.PI * steer), 1f);
			else if (steer > 0.5f)
				v_ = new Vector2 (-1f * Mathf.Tan (Mathf.PI * steer), -1f);
			else
				v_ = new Vector2 (0f, 0.1f);
			//if(steer!=0.5f)
			v_ = v_*Mathf.Abs (v_.y / (2f*v_.x));
			return v_;
		} else if (direction == 0f) {
			if (steer < 0.5f) {
				v_ = new Vector2 (-1f, 1f * Mathf.Tan (Mathf.PI * steer));
			} else if (steer > 0.5f) {
				v_ = new Vector2 (1f,-1f * Mathf.Tan (Mathf.PI * steer));
			} else
				v_ = new Vector2 (1f, 1f);
			v_ = v_*Mathf.Abs (v_.x / (2*v_.y));
			return v_;
		} else if (direction == 0.5f) {
			if (steer < 0.5f) {
				v_ = new Vector2 (-1f * Mathf.Tan (Mathf.PI * steer), -1f);
			} else if (steer > 0.5f) {
				v_ = new Vector2 (1f * Mathf.Tan (Mathf.PI * steer), 1f);
			} else
				v_ = new Vector2 (1f, 1f);
			v_ = v_ * Mathf.Abs (v_.y / (2*v_.x));
			return v_;
		} else {
			if (steer < 0.5f) {
				v_ = new Vector2 (1f, -1f * Mathf.Tan (Mathf.PI * steer));
			} else if (steer > 0.5f) {
				v_ = new Vector2 (-1f, 1f * Mathf.Tan (Mathf.PI * steer));
			} else
				v_ = new Vector2 (1f, 1f);
		//	Debug.Log ("Velocity prev: "+v_);
			v_ = v_*Mathf.Abs (v_.x / (2*v_.y));
			return v_;
		}
	}
}
