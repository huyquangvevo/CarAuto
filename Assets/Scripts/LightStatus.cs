using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LightStatus {

	public static float uG(float x){
		if (x < 0.25) {
			return 1;
		} else if (x > 0.45) {
			return 0;
		} else {
			return -6.67f * x + 2.67f;
		}
	}

	public static float uLG(float x){
		if (x < 0.33 || x > 0.542) {
			return 0;
		} else if (x >= 0.33 && x <= 0.417) {
			return 11.5f * x - 3.795f;
		} else {
			return -8f * x + 4.336f;
		}
	}

	public static float uY(float x){
		if (x > 0.708 || x < 0.458) {
			return 0;
		} else if (x >= 0.458 && x <= 0.542) {
			return 11.9f * x - 5.45f;
		}  else {
			return -6f * x + 4.25f; 
		}
	}

	public static float uR(float x){
		if (x < 0.625 || x > 0.9 ) {
			return 0;
		} else if (x >= 0.625 && x <= 0.67) {
			return 22.22f * x - 13.89f;
		} else if (x > 0.83 && x <= 0.9) {
			return -14.29f * x + 12.86f;
		} else {
			return 1;
		}
	}

	public static float uLR(float x){
		if (x < 0.83) {
			return 0;
		} else if (x >= 1) {
			return 1;
		} else {
			return 11.49f * x - 9.54f;
		}
	}

}
