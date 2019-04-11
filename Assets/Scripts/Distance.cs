using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Distance {

	public static float uN(float x){
		if (x < 10) {
			return 1;
		} else if (x > 40) {
			return 0;
		} else {
			return -0.033f * x + 1.33f;
		}
	}

	public static float uM(float x){
		if (x < 10 || x > 70) {
			return 0;
		} else if (x >= 10 && x <= 20) {
			return 0.1f * x - 1f;
		} else if (x > 50 && x <= 70) {
			return -0.05f * x + 3.5f;
		} else {
			return 1;
		}
	}

	public static float uF(float x){
		if (x < 40) {
			return 0;
		} else if (x > 70) {
			return 1;
		} else {
			return 0.033f * x - 1.33f;
		}
	}
}
