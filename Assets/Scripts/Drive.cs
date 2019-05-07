using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 0.3f;
	public float direction = -0.5f;

	public GameObject sensor;

	Vector2 posRaySensor;

	int layerRoad;

//	Vector2 posRayLeft;
//	Vector2 posRayRight;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		layerRoad = LayerMask.GetMask ("Road");
		Debug.Log (LayerMask.GetMask("Road"));
		demo ();
		//driveCar ();
	}

	void demo(){
		Vector2 posRay1 = transform.position;
		Vector2 posRay2 = sensor.transform.position;

		RaycastHit2D hit1 = Physics2D.Raycast (posRay1, transform.right,Mathf.Infinity,layerRoad);
		RaycastHit2D hit2 = Physics2D.Raycast (posRay2, sensor.transform.right, Mathf.Infinity, layerRoad);
		Debug.Log ("Distance to right : " + hit1.distance + " - " + hit2.distance);
		Debug.Log ("Point : " + hit1.point + " - " + hit2.point);
	}

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Va cham Trigger: " + col.gameObject.tag);
		if (col.gameObject.tag == "Bump") {
		//	this.direction = 0.5f;
		//	transform.rotation = Quaternion.Euler (0, 0, 90);
		}
	}

	void Update () {
		//	steer(getDeviation());
	//	controlSpeed ();
		//driveCar();
	}

	void driveCar(){
		Debug.Log ("Forward: " + transform.up);
		this.rb.velocity = transform.up * 1f;
		//this.rb.velocity = new Vector2 (1f,0f)*speed;
		//this.rb.AddRelativeForce(transform.up*1000);
	}
		


	float getDeviation(){

		posRaySensor = getPosSensor();
		//posRaySensor = transform.position;

		RaycastHit2D hitLeft = Physics2D.Raycast (posRaySensor,/*Vector2.up*/ -transform.right,Mathf.Infinity,layerRoad);
		RaycastHit2D hitRight = Physics2D.Raycast (posRaySensor, /*-Vector2.up*/ transform.right,Mathf.Infinity, layerRoad);

		if (hitLeft && hitRight) {
			if (hitLeft.collider.gameObject.tag == "TrafficLight" || hitRight.collider.gameObject.tag == "TrafficLight" || hitLeft.collider.gameObject.tag == "ForbiddenCar" || hitRight.collider.gameObject.tag == "ForbiddenCar") {
				//Debug.Log ("Va cham : ");
				if(hitLeft.collider.gameObject.tag == "TrafficLight" || hitLeft.collider.gameObject.tag == "ForbiddenCar"){
					//hitLeft.collider.enabled = false;
					Debug.Log("Hit col left: "+hitLeft.collider.gameObject.name);
				};
				if (hitRight.collider.gameObject.tag == "TrafficLight" || hitRight.collider.gameObject.tag == "ForbiddenCar") {
					//hitRight.collider.enabled = false;
					Debug.Log("Hit col right: "+hitRight.collider.gameObject.name);
				}	
				return 1;
			}
			if (hitLeft.collider.gameObject.tag == "Bump") {
			//	this.direction = hitLeft.collider.gameObject.GetComponent<Bump> ().getDCrossroads ();
			//	this.direction = 0f;
			
			}

			if (hitRight.collider.gameObject.tag == "Bump") {
			//	this.direction = 0;
			
			}
			//	Debug.Log ("InRoad");
			//	Debug.Log ("Hit Left: " + hitLeft.distance);
			//	Debug.Log ("Hit Right: " + hitRight.distance);
			float mid = (hitLeft.distance + hitRight.distance)/2f;
			return (hitLeft.distance - mid) / mid;
			//if (hitLeft.distance >= mid)
				//	return (hitLeft.distance - mid) / mid;
		//	return (hitLeft.distance) / (hitLeft.distance + hitRight.distance);
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
			Debug.Log ("Steerage Fob: " + st);
		}
		Debug.Log ("Steerage: " + st);
	//	float d = -(st - 0.5f) * 180f;

		if (st < 0.126f || st > 0.874f) {
		//	transform.Rotate (0, 0, d);
			if (st < 0.126) {
			//	transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, 90), 10 * Time.deltaTime);
			//	this.direction = 0.5f;
				transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,transform.eulerAngles.z + 90), 10*Time.deltaTime);

			} else {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, -90), 10 * Time.deltaTime);
			//	if(transform.rotation == Quaternion.Euler(0,0,-90))
					this.direction = -0.5f;
			}
			//	transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, -90), 40* Time.deltaTime);
			//	this.direction = -0.5f;
			//return;
			//st = 0.49f;
		} else {

			//	Debug.Log ("T : " + t);
			//	Debug.Log ("Steerage: " + st);
			float d = -(st - 0.5f) * 180f;
			//	Debug.Log ("Degree: " + d);
	
		//	Debug.Log ("Euler Angles z: " + transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, direction * 180 + d));
			//	transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z + d));
			//	transform.Rotate(new Vector3(0,0,d),Mathf.Abs(d));	
			Debug.Log ("Degree: " + d);
		//	Debug.Log ("Euler Angles z 2: " + transform.eulerAngles.z);	
		}
	//	transform.Rotate(new Vector3(0,0,d),Mathf.Abs(d));

	//	transform.Rotate(0,0,d);

		//	Debug.Log ("Rotation: "+ transform.rotation.z);
	//	Vector2 v = getDirectVelocity(st);
		rb.velocity = transform.up*this.speed*2.5f;
	//	rb.velocity = v*this.speed*3f;
		//	Debug.Log ("Velocity: "+rb.velocity);
	}

	void controlSpeed(){
		Vector2 posRayUp = transform.position;
	//	Vector3 directRay = new Vector3(1,0,0);
		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp,  transform.up);

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
			//	Debug.Log ("Distance: " + dis + " Time: " + traffic.getRatioTime() + " Deviation: " + dev);
				//	Debug.Log ("Speed Controll: " + this.speed);
			} else if(hitUp.collider.gameObject.tag == "ForbiddenCar" && hitUp.distance < 2f){
				df = hitUp.collider.gameObject.GetComponent<ForbiddenCar> ().getDeviation ();
				disFob = hitUp.distance;
				obj = 1;
			//	Debug.Log ("ForbiddenCar Distance: " + hitUp.distance);
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

	public Vector2 getPosSensor(){
		if (direction == 0f) {
			return new Vector2 (transform.position.x, transform.position.y + 0.5f);
		} else if (direction == -0.5f) {
			return new Vector2 (transform.position.x + 0.5f, transform.position.y);
		} else if (direction == 0.5f) {
			return new Vector2 (transform.position.x - 0.5f, transform.position.y);
		} else {
			return new Vector2 (transform.position.x, transform.position.y - 0.5f);
		}
	}
}