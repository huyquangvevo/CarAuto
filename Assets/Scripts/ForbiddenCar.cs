using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenCar : MonoBehaviour {

	public GameObject sensorUpFor;

	Rigidbody2D rb;
	Vector2 posRaySensor;
	Vector2 posRayCar;
	Vector2 directRoad;

	float angleForAndRoad;

	float devFullRoad;

	public float speed;// = 0.5f;

	int layerCar;
	int layerRoad;
	int layerForbidden;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	//	getDeviation ();
		layerCar = LayerMask.GetMask ("Car");
		layerRoad = LayerMask.GetMask ("Road");
		layerForbidden = LayerMask.GetMask ("Forbidden");
	
	}

	void Update(){
		controlSpeed ();
		//steer ();
		//getEdge ();
	//	move();
	}

	float calculateDeviation(){

		posRaySensor = sensorUpFor.transform.position;
		posRayCar = transform.position;

		RaycastHit2D hitLeftSensor = Physics2D.Raycast (posRaySensor, -sensorUpFor.transform.right, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightSensor = Physics2D.Raycast (posRaySensor, sensorUpFor.transform.right, Mathf.Infinity, layerRoad);

		RaycastHit2D hitLeftCar = Physics2D.Raycast (posRayCar, -transform.right, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightCar = Physics2D.Raycast (posRayCar, transform.right, Mathf.Infinity, layerRoad);

		directRoad = hitRightSensor.point - hitRightCar.point;

		angleForAndRoad = Vector2.SignedAngle (transform.up, directRoad);

		devFullRoad = (hitLeftCar.distance) / (hitLeftCar.distance + hitRightCar.distance);

		float mid = (hitLeftSensor.distance + hitRightSensor.distance) / 2f;
		if (hitLeftSensor.distance > hitRightSensor.distance)
			return(hitLeftSensor.distance - mid) / mid;
		else
			return (hitLeftSensor.distance) / mid;
	}

	void steer(float de){
	//	float de = calculateDeviation ();
		float st = Steerage.clarify (de);

		Debug.Log ("Forbidden ST: " + st);
		float d = (st - 0.5f) * 90;
		float a = d - angleForAndRoad;

		if (Mathf.Abs (a) > 1) {
			if (a > 0) {
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z - 1f));
			} else {
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z + 1f));
			}
		} else 

		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z - a));

		rb.velocity = transform.up * this.speed*0.6f;
	}

	void controlSpeed(){
		float dev = calculateDeviation ();
		Vector2 posRayUp = sensorUpFor.transform.position;
		RaycastHit2D hitUp = Physics2D.Raycast(posRayUp,transform.up,Mathf.Infinity,layerForbidden);

		this.speed = Mathf.Abs (Speed.clarify(1,0f,10f,dev));

		if (hitUp) {
			if (hitUp.collider.gameObject.tag == "TrafficLight") {
				TrafficLightController traffic = (TrafficLightController)hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
				this.speed = Mathf.Abs (Speed.clarify (traffic.getIdL (), traffic.getRatioTime (), hitUp.distance, dev));
			} else if (hitUp.collider.gameObject.tag == "ForbiddenCar") {
				this.speed = Mathf.Abs (SpeedFob.clarify (hitUp.distance));
			}
		}

		steer (dev);

	}


/*
	void move(){
		RaycastHit2D hitUpFor = Physics2D.Raycast (transform.position, transform.up, 2f, layerCar);
		if (hitUpFor) {
			this.speed = 0;
		} else {
			this.speed = 1f;
		}

		transform.Translate (-transform.up*this.speed*Time.deltaTime);
	}
*/
	public float getDeviation(){
		return this.devFullRoad;
/*	
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
		*/	
	}
}
