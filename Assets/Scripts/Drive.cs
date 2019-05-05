using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 0.3f;
	public float direction = -0.5f;

//	Vector2 posRayLeft;
//	Vector2 posRayRight;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		//	driveCar ();
	}

	void OnTriggerEnter2D(Collider2D col){
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
		Vector2 posRayLeft = transform.position;
		Vector2 posRayRight = transform.position;
//		Debug.Log ("Transform up : " + transform.up);
	/*	if (direction == -0.5) {
			posRayLeft = new Vector2 (transform.position.x + 0.3f, transform.position.y + 0.3f);
			posRayRight = new Vector2 (transform.position.x + 0.3f, transform.position.y - 0.3f);

		} else {
			posRayLeft = new Vector2 (transform.position.x - 0.3f, transform.position.y + 0.3f);
			posRayRight = new Vector2 (transform.position.x + 0.3f, transform.position.y + 0.3f);
		}
	*/
		RaycastHit2D hitLeft = Physics2D.Raycast (posRayLeft,/*Vector2.up*/ -transform.right);
		RaycastHit2D hitRight = Physics2D.Raycast (posRayRight, /*-Vector2.up*/ transform.right);

		if (hitLeft && hitRight) {
			if (hitLeft.collider.gameObject.tag == "TrafficLight" || hitRight.collider.gameObject.tag == "TrafficLight" || hitLeft.collider.gameObject.tag == "ForbiddenCar" || hitRight.collider.gameObject.tag == "ForbiddenCar") {
				//Debug.Log ("Va cham : ");
				if(hitLeft.collider.gameObject.tag == "TrafficLight" || hitLeft.collider.gameObject.tag == "ForbiddenCar"){
					hitLeft.collider.enabled = false;
				};
				if (hitRight.collider.gameObject.tag == "TrafficLight" || hitRight.collider.gameObject.tag == "ForbiddenCar") {
					hitRight.collider.enabled = false;
				}	
				return 1;
			}
			if (hitLeft.collider.gameObject.tag == "Bump") {
				this.direction = hitLeft.collider.gameObject.GetComponent<Bump> ().getDCrossroads ();
			//	this.direction = 0f;
			
			}

			if (hitRight.collider.gameObject.tag == "Bump") {
			//	this.direction = 0;
			
			}
			//	Debug.Log ("InRoad");
			//	Debug.Log ("Hit Left: " + hitLeft.distance);
			//	Debug.Log ("Hit Right: " + hitRight.distance);
			//float mid = (hitLeft.distance + hitRight.distance)/2f;
			//if (hitLeft.distance >= mid)
				//	return (hitLeft.distance - mid) / mid;
			return (hitLeft.distance - 0.05f) / (hitLeft.distance + hitRight.distance - 0.1f);
		//	return (hitLeft.distance-mid) / (mid);
		} else {
			//	Debug.Log ("***** OutRoad *****");
			return 0f;
		}
	}

	void steer(float de,float disFob, float df, int t){
		if (de == 0f) {
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, direction*180));
			return;		
		};
		float st;
		if (t == 0) {
			st = Steerage.clarify (de);
		} else {
		//	Debug.Log ("DeviationFob: " + x + " Distance: " + disFob);
			st = SteerageFob.clarify (de,disFob,df);
		//	st = Steerage.clarify(x);
		//	Debug.Log ("Steerage Fob: " + st);
		}
	//	Debug.Log ("T : " + t);
	//	Debug.Log ("Steerage: " + st);
		float d = -(st - 0.5f) * 180f;
		//	Debug.Log ("Degree: " + d);
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, direction*180+d));
	//	Debug.Log ("Rotation: "+ transform.rotation.z);
		Vector2 v = getDirectVelocity(st);
	//	if(t == 1)
	//		Debug.Log ("Vector Velocity: " + v + " Speed: " + this.speed);
		rb.velocity = v*this.speed*3f;
		//	Debug.Log ("Velocity: "+rb.velocity);
	}

	void controlSpeed(){
		Vector3 posRayUp = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	//	Vector3 posRayUp = new Vector3(transform.position.x,transform.position.y);
	//	Vector3 directRay = new Vector3(1,0,0);
		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp,  transform.up);

//	Debug.Log ("Transform up: " + transform.up);
		float dev = getDeviation ();
		if (transform.rotation.z > -0.23f) {
			//this.direction = 0;
		//	Debug.Log ("Dev roration: " + dev);
			//dev = 0.6f;
		}

		if (dev == 1)
			return;
		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));

		int obj = 0;
		float disFob = 10;
		float df = 0;
		if (hitUp) {
			if (hitUp.collider.gameObject.tag == "TrafficLight") {

				TrafficLightController traffic = (TrafficLightController)hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
				float dis = hitUp.distance;
				//	Debug.Log ("Distance: "+dis);
				this.speed = Mathf.Abs (Speed.clarify (traffic.getIdL (), traffic.getRatioTime (), dis, dev));
				obj = 0;
				//Debug.Log ("Distance: " + dis + " Time: " + traffic.getRatioTime() + " Deviation: " + dev);
				//	Debug.Log ("Speed Controll: " + this.speed);
			} else if(hitUp.collider.gameObject.tag == "ForbiddenCar" && hitUp.distance < 2f){
				df = hitUp.collider.gameObject.GetComponent<ForbiddenCar> ().getDeviation ();
				disFob = hitUp.distance;
			//	this.speed = Mathf.Abs (Forbidden.clarify (hitUp.distance, df, 0));
				obj = 1;
				Debug.Log ("ForbiddenCar Distance: " + hitUp.distance);
			//	Debug.Log ("ForbiddenCar Deviation: " + df);
			}
		};

		//Debug.Log ("Dev: " + dev);

		steer (dev,disFob, df, obj);
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