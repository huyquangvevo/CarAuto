using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour {

	void Start(){
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player")
			GetComponentInParent<ForbiddenCar> ().stopCar ();
	}

}
