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
	int layerForbidden;
	float angleCarAndRoad;

	void Start () {
		layerRoad = LayerMask.GetMask ("Road");
		layerForbidden = LayerMask.GetMask ("Forbidden");
		rb = GetComponent<Rigidbody2D> ();
		//steer ();
	}

	void Update () {
		controlSpeed ();
	}

	float getDeviation(){
		posRaySensor = sensor.transform.position;
		posRayCar = transform.position;

		RaycastHit2D hitLeftSensor = Physics2D.Raycast (posRaySensor, -sensor.transform.right, Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightSensor = Physics2D.Raycast (posRaySensor, sensor.transform.right, Mathf.Infinity, layerRoad);

		RaycastHit2D hitLeftCar = Physics2D.Raycast (posRayCar, -transform.right,Mathf.Infinity, layerRoad);
		RaycastHit2D hitRightCar = Physics2D.Raycast (posRayCar, transform.right, Mathf.Infinity, layerRoad);

		Vector2 directRoad = hitRightSensor.point - hitRightCar.point;
	
		angleCarAndRoad = Vector2.SignedAngle (transform.up, directRoad);

		float mid = (hitLeftSensor.distance  + hitRightSensor.distance)/2f;
/*		Debug.Log ("Transform up: "+transform.up);
		Debug.Log ("Left distance: " + hitLeftSensor.distance);
		Debug.Log ("Left distance mid: " + (hitLeftSensor.distance - mid));
		Debug.Log ("right distance: " + hitRightSensor.distance);
		Debug.Log ("Direction Road: " + directRoad);
*/	
		return (hitLeftSensor.distance - mid) / mid;
	
	}



	void steer(float de){

		float st = Steerage.clarify (de);
		float d = (st - 0.5f) * 90;


		float a = d - angleCarAndRoad;
	
		float nextZ = (transform.eulerAngles.z - ( d - angleCarAndRoad));

		if (Mathf.Abs (a) > 5) {
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
		Vector2 posRayUp = sensor.transform.position;
		RaycastHit2D hitUp = Physics2D.Raycast (posRayUp,sensor.transform.up,Mathf.Infinity,layerForbidden);
		float dev = getDeviation ();
		Debug.Log ("Distance Forbidden: "+ hitUp.distance);
		this.speed = Mathf.Abs (Speed.clarify (1, 0f, 10f, dev));



		steer (dev);
	}


}
