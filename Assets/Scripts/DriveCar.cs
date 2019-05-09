using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour {

	public GameObject sensorUp;
	public GameObject sensorLeft;
	public GameObject sensorRight;

	Rigidbody2D rb;

	Vector2 posRaysensorUp;
	Vector2 posRayCar;

	public Vector2 directRoad;

	Vector2 laneLeft;
	Vector2 laneRight;

	public float speed;

	int layerRoad;
	int layerForbidden;
	float angleCarAndRoad;

	bool isStop;

	void Start () {
		isStop = false;
		layerRoad = LayerMask.GetMask ("Road");
		layerForbidden = LayerMask.GetMask ("Forbidden");
		rb = GetComponent<Rigidbody2D> ();
		//steer ();
	}

	void Update () {
		if(!isStop)
			controlSpeed ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Realmadrid") {
			isStop = true;
			this.speed = 0;
			rb.velocity = rb.velocity * this.speed;
		}
	}

	float getDeviation(int mode){
		posRaysensorUp = sensorUp.transform.position;
		posRayCar = transform.position;

		RaycastHit2D hitLeftsensorUp = Physics2D.Raycast (posRaysensorUp, -sensorUp.transform.right, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightsensorUp = Physics2D.Raycast (posRaysensorUp, sensorUp.transform.right, Mathf.Infinity, layerRoad);

		RaycastHit2D hitLeftCar = Physics2D.Raycast (posRayCar, -transform.right,Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightCar = Physics2D.Raycast (posRayCar, transform.right, Mathf.Infinity, layerRoad);

		directRoad = hitRightsensorUp.point - hitRightCar.point;
		Vector2 linearRoad = Vector2.Perpendicular (directRoad);
//		Debug.Log ("DirectRoad: " + directRoad);
//		Debug.Log ("Linear Direct: " + linearRoad);
		RaycastHit2D hitLeftRoad = Physics2D.Raycast (transform.position, linearRoad, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightRoad = Physics2D.Raycast (transform.position, -linearRoad, Mathf.Infinity, layerRoad);

		laneLeft = (hitRightRoad.point - hitLeftRoad.point) / 4 + hitLeftRoad.point;
		laneRight = hitRightRoad.point - (hitRightRoad.point - hitLeftRoad.point) / 4;

//		laneLeft = (hitRightsensorUp.point - hitLeftsensorUp.point) / 4 + hitLeftsensorUp.point;
//		laneRight = hitRightsensorUp.point - (hitRightsensorUp.point - hitLeftsensorUp.point) / 4; 

		angleCarAndRoad = Vector2.SignedAngle (transform.up, directRoad);

		float mid = (hitLeftsensorUp.distance  + hitRightsensorUp.distance)/2f;
/*		Debug.Log ("Transform up: "+transform.up);
		Debug.Log ("Left distance: " + hitLeftsensorUp.distance);
		Debug.Log ("Left distance mid: " + (hitLeftsensorUp.distance - mid));
		Debug.Log ("right distance: " + hitRightsensorUp.distance);
		Debug.Log ("Direction Road: " + directRoad);
*/
		float width = hitLeftsensorUp.distance + hitRightsensorUp.distance;

		if (mode == 0) {
			return (hitLeftsensorUp.distance - mid) / mid;
		///	return (hitLeftsensorUp.distance + width * 0.5f) / (width * 1.5f);
		}
		else {

			return (hitLeftsensorUp.distance + width*0.5f) / (width*1.5f);
		}
	
	}



	void steer(int id, float de, float disR,float disL){


		float st;
		if (id == 0) {
			st = Steerage.clarify (de);
		//	Debug.Log ("Steerage : " + st);
		}
		else {
			st = SteerageForbidden.clarify (de, disR, disL);
		//	Debug.Log ("Steerage forbidden: " + st);
		}

		float d = (st - 0.5f) * 90;


		float a = d - angleCarAndRoad;
	
		float nextZ = (transform.eulerAngles.z - ( d - angleCarAndRoad));

		if (Mathf.Abs (a) > 1) {
			if (a > 0)
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z - 1f));
			else {
				transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z + 1f));

			}
		} else 
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z - ( d - angleCarAndRoad)));
		rb.velocity = transform.up *this.speed* 2f;

	}

	void controlSpeed(){
		Vector2 posRayUp = sensorUp.transform.position;
		RaycastHit2D hitUp = Physics2D.Raycast (laneRight,directRoad,Mathf.Infinity,layerForbidden);
		float dev = getDeviation (0);
		//Debug.Log ("Distance Forbidden: "+ hitUp.distance);

		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));
		sensorLeft.transform.up = directRoad;
		sensorLeft.transform.position = laneLeft;
		sensorRight.transform.up = directRoad;
		sensorRight.transform.position = laneRight;
		int idFor = 0;
		float dis = 10;

		float disL = 10;
		if (hitUp) {
			dis = hitUp.distance;
			if (hitUp.collider.gameObject.tag == "TrafficLight") {
				TrafficLightController traffic = (TrafficLightController)hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
				//dis = hitUp.distance;
				this.speed = Mathf.Abs (Speed.clarify (traffic.getIdL (), traffic.getRatioTime (), dis, dev));

				idFor = 0;
			} else if (hitUp.collider.gameObject.tag == "ForbiddenCar" && hitUp.distance < 3f) {
				//this.speed = 0.75f;
				if (hitUp.distance < 1f) {
					dis = 0f;
				} else {
					dis = hitUp.distance - 1f;
				}
				Vector2 posRayLeftUp = sensorLeft.transform.position;
				RaycastHit2D hitLeftUp = Physics2D.Raycast (laneLeft, directRoad, Mathf.Infinity, layerForbidden);
				if(hitLeftUp)
				if (hitLeftUp.collider.gameObject.tag == "ForbiddenCar") {
					if (hitLeftUp.distance > 1f)
						hitLeftUp.distance -= 1f;
					else
						hitLeftUp.distance = 0f;
					disL = hitLeftUp.distance;

				//	Debug.Log ("Left Forbidden: " + hitLeftUp.distance);
				} else {
					//Debug.Log ("No Left Forbidden");
				}
			//	this.speed = 0.85f;
				this.speed = SpeedForbidden.clarify (dev,dis,disL);
				idFor = 1;
			} else {
				//Debug.Break ();
			}
		} else {
			//Debug.Log ("No Forbidden");
			//Debug.Break ();
		}

		dev = getDeviation (idFor);
		steer (idFor,dev,dis,disL);
	}



}
