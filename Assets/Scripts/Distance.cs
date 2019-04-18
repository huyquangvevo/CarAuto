using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Distance {

	public static float uN(float x){
		if (x < 0.1) {
			return 1;
		} else if (x > 0.4) {
			return 0;
		} else {
			return -0.033f * x + 1.33f;
		}
	}

	public static float uM(float x){
		if (x < 0.1 || x > 0.7) {
			return 0;
		} else if (x >= 0.1 && x <= 0.2) {
			return 0.1f * x - 1f;
		} else if (x > 0.5 && x <= 0.7) {
			return -0.05f * x + 3.5f;
		} else {
			return 1;
		}
	}

	public static float uF(float x){
		if (x < 0.4) {
			return 0;
		} else if (x > 0.7) {
			return 1;
		} else {
			return 0.033f * x - 1.33f;
		}
	}
}
