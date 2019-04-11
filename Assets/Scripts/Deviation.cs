using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Deviation {

	public static float uFL(float x){
		if (x < 0.25) {
			return 1;
		} else if (x > 0.4) {
			return 0;
		} else {
			return -6.67f * x + 2.67f;
		}
	}

	public static float uL(float x){
		if (x < 0.25f || x > 0.5)
			return 0;
		else if (x >= 0.25 && x <= 0.4) {
			return 6.67f * x - 1.67f;
		} else {
			return -10f * x + 5;
		}
	}

	public static float uM(float x){
		if (x < 0.4 || x > 0.6) {
			return 0;
		} else if (x >= 0.4 && x < 0.5) {
			return 10f * x - 4;
		} else {
			return 10f * x + 6;
		}
	}

	public static float uR(float x){
		if (x < 0.5 || x > 0.75) {
			return 0;
		} else if (x >= 0.5 && x <= 0.6) {
			return 10f * x - 5;
		} else {
			return -6.67f * x + 5;
		}
	}

	public static float uFR(float x){
		if (x < 0.6) {
			return 0;
		} else if (x >= 0.75) {
			return 1;
		} else {
			return 6.67f * x - 4;
		}
	}
}
