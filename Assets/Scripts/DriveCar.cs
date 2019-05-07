using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour {

	public GameObject sensor;

	Rigidbody2D rb;

	Vector2 posRaySensor;
	Vector2 posRayCar;

	public float speed;

	int layerRoad;
	float angleCarAndRoad;

	// Use this for initialization
	void Start () {
		layerRoad = LayerMask.GetMask ("Road");
		rb = GetComponent<Rigidbody2D> ();
		//steer ();
	}

	// Update is called once per frame
	void Update () {
		//controlSpeed ();
		steer(0);
	}

	float getDeviation(){
		posRaySensor = sensor.transform.position;
		posRayCar = transform.position;

		RaycastHit2D hitLeftSensor = Physics2D.Raycast (posRaySensor, -sensor.transform.right, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightSensor = Physics2D.Raycast (posRaySensor, sensor.transform.right, Mathf.Infinity, layerRoad);

		RaycastHit2D hitLeftCar = Physics2D.Raycast (posRayCar, -transform.right,Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightCar = Physics2D.Raycast (posRayCar, transform.right, Mathf.Infinity, layerRoad);

		Vector2 directRoad = hitRightSensor.point - hitRightCar.point;
		//directRoad = hitLeftSensor.point - hitLeftCar.point;
//		Debug.Log ("Sensor - car: " + hitRightSensor.point +" ---- " + hitRightCar.point);
	//	Debug.Log ("Angle Road Right: " + directRoad);
	//	Debug.Log ("Angle road left: " + (hitLeftSensor.point - hitLeftCar.point));
		angleCarAndRoad = Vector2.SignedAngle (transform.up, directRoad);
	//	Debug.Log ("Angle Car - Road : " + Vector2.SignedAngle (transform.up,directRoad));
	//	Debug.Log ("Angle Road - car: " + Vector2.SignedAngle (directRoad, transform.up));
		float mid = (hitLeftSensor.distance  + hitRightSensor.distance)/2f;
		Debug.Log ("Left distance: " + hitLeftSensor.distance);
		Debug.Log ("Left distance mid: " + (hitLeftSensor.distance - mid));
		Debug.Log ("right distance: " + hitRightSensor.distance);
	//	if (hitLeftSensor.distance - mid < 0)
	//		Debug.Break ();
	//	return (hitLeftSensor.distance - mid) / mid;
		return (hitLeftSensor.distance) / (hitLeftSensor.distance + hitRightSensor.distance);
	}



	void steer(float dev){
		float de = getDeviation ();
		float st = Steerage.clarify (de);
	//	Debug.Log ("Steering: " + st);
		float d = (st - 0.5f) * 90;

	//	Debug.Log ("Steerage Degree: " + d);
	//	Debug.Log ("Angle Car And Road: " + angleCarAndRoad);
		float a = d - angleCarAndRoad;
		Debug.Log ("Xe: " + transform.position);
	//	Debug.Log ("Angle rotate: " + a);
	//	rb.velocity = transform.up*0f;
		float nextZ = (transform.eulerAngles.z - ( d - angleCarAndRoad));
		Debug.Log("next z: " + nextZ);
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, transform.eulerAngles.z - ( d - angleCarAndRoad)));
	//	Debug.Log ("z: " + transform.eulerAngles.z);
		rb.velocity = transform.up *this.speed* 2f;
	//	if (nextZ > 90)
	//		Debug.Break ();
	}

	void controlSpeed(){
		Vector2 posRayUp = sensor.transform.position;
		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp,transform.up);
		float dev = getDeviation ();
		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));
		this.speed = 1f;
		steer (dev);
	}


}
