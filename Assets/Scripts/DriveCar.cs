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

	float factor = 2f;

	void Start () {
		factor = 2f;
		isStop = false;
		layerRoad = LayerMask.GetMask ("Road");
		layerForbidden = LayerMask.GetMask ("Forbidden");
		rb = GetComponent<Rigidbody2D> ();
		//steer ();
	}

	void FixedUpdate () {
		if(!isStop && (Shader.GetGlobalInt("start") == 1))
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
			if (hitLeftsensorUp.distance - mid <= 0) {
				this.factor = 2f;
			} else {
				this.factor = 2f;
			}
			return (hitLeftsensorUp.distance - mid) / mid;
		///	return (hitLeftsensorUp.distance + width * 0.5f) / (width * 1.5f);
		}
		else {
			this.factor = 2f;
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
//		rb.velocity = transform.up *this.speed* 2f;
		rb.velocity = transform.up *this.speed* this.factor;
	}

	void controlSpeed(){
		Vector2 posRayUp = sensorUp.transform.position;
		RaycastHit2D hitUp = Physics2D.Raycast (sensorUp.transform.position,directRoad, 10f/*Mathf.Infinity*/,layerForbidden);
		float dev = getDeviation (0);

		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));
		sensorLeft.transform.up = directRoad;
		sensorLeft.transform.position = laneLeft;
		sensorRight.transform.up = directRoad;
		sensorRight.transform.position = laneRight;

		RaycastHit2D hitRightDown = Physics2D.Raycast (laneRight,-directRoad,3f,layerForbidden);
		RaycastHit2D hitRightUp = Physics2D.Raycast (laneRight,directRoad,Mathf.Infinity,layerForbidden);

		int idFor = 0;
		float dis = 10;

		float disL = 10;

		float preSpeed = this.speed;

		if (hitUp) {
			dis = hitUp.distance;
			if (hitUp.collider.gameObject.tag == "TrafficLight") {
				TrafficLightController traffic = (TrafficLightController)hitUp.collider.gameObject.GetComponent<TrafficLightController> ();
				//dis = hitUp.distance;
				this.speed = Mathf.Abs (Speed.clarify (traffic.getIdL (), traffic.getRatioTime (), dis, dev));
				preSpeed = this.speed;
				idFor = 0;
			}
			;
		}	//else 
			if(hitRightUp)
			if (hitRightUp.collider.gameObject.tag == "ForbiddenCar" && hitRightUp.distance < 3f) {
				//this.speed = 0.75f;
				Vector2 posRayLeftUp = sensorLeft.transform.position;
				RaycastHit2D hitLeftUp = Physics2D.Raycast (laneLeft, directRoad, 12f, layerForbidden);
				if (hitLeftUp)
				if(hitLeftUp.collider.gameObject.tag != "TrafficLight"){
					disL = hitLeftUp.distance;
					if (disL < 1f) {
						disL = 0f;
					} else {
						disL -= 1;
					}
					if (hitLeftUp.collider.gameObject.GetInstanceID() != hitRightUp.collider.gameObject.GetInstanceID()) {
						//Debug.Log ("2 Forbidden! " + hitRightUp.collider.gameObject.GetInstanceID() + " - " + hitLeftUp.collider.gameObject.name);
					//	hitRightUp.collider.gameObject.GetComponent<ForbiddenCar> ().stopCar ();
					}
				}
				if (hitRightUp.distance < 1f) {
				//	dis = 0f;
				//	disL -= dis;
					dis = 0f;
				} else {
					dis = hitRightUp.distance - 1f;
				}
				
			//Debug.Log ("Space: " + (disL - dis) + " - " + disL + " - " + dis);
		
			float spaceFor = hitLeftUp.distance - hitRightUp.distance;
			spaceFor = disL - dis;
			if (spaceFor < 1f) {
				spaceFor = 0f;
			}
			dev = getDeviation (1);
			this.speed = SpeedForbidden.clarify (dev,dis,spaceFor);
			//	this.speed = 0.8f;
		//		this.speed = SpeedForbidden.clarify (dev,dis,disL);
		//	Debug.Log ("speed : " + this.speed);
				idFor = 1;
			} 

		if (hitRightDown) {
			//if(!hitRightUp)
			if (hitRightDown.collider.gameObject.tag == "ForbiddenCar") {
				//Debug.Log ("Right down distance : " + hitRightDown.distance);
				if (hitRightDown.distance <= 1f) {
					hitRightDown.distance = 0f;
				} else {
					hitRightDown.distance -= 1f;
				};
	//			this.speed = SpeedForbidden.clarify (dev, hitRightDown.distance, 7f);

				if (hitUp) {
					if (hitUp.collider.gameObject.tag != "TrafficLight") {
						this.speed = SpeedForbidden.clarify (dev, hitRightDown.distance, 20f); //preSpeed;
						//Debug.Log ("Right Down 101: " + hitUp.collider.gameObject.name);
					} else {
						//Debug.Log ("Right Down 102: " + hitUp.collider.gameObject.name);
					//	idFor = 1;
						if(hitUp.distance > 4f)
							this.speed = SpeedForbidden.clarify (dev, hitRightDown.distance, 20f);
						//this.speed = preSpeed;
					}
				} else {
					//Debug.Log ("Right Down 2 ");
					this.speed = SpeedForbidden.clarify (dev, hitRightDown.distance, 20f);
				}
			};
		};
			
		dev = getDeviation (idFor);
		steer (idFor,dev,dis,disL);
	}



}
