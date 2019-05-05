using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour {

	public float dCrossroads;

	public GameObject[] crossroads;

	public float getDCrossroads(){
		setDirecttion ();
		return this.dCrossroads;
	}

	public void setDirecttion(){
		if(this.dCrossroads == 0f){
			crossroads[0].SetActive(true);
		} else if(this.dCrossroads == -0.5f){
			crossroads[1].SetActive(true);
		} else if(this.dCrossroads == 1){
			crossroads[2].SetActive(true);
		} else {
			crossroads[3].SetActive(true);
		}
	}

}
