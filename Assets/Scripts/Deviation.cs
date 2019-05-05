using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Deviation {

	public static float uFL(float x){
		if (x < 0.25) {
			return 1f;
		} else if (x > 0.4) {
			return 0f;
		} else {
			return -6.67f * x + 2.67f;
		}
	}

	public static float uL(float x){
		if (x < 0.25f || x > 0.5)
			return 0f;
		else if (x >= 0.25 && x <= 0.4) {
			return 6.67f * x - 1.67f;
		} else {
			return -10f * x + 5f;
		}
	}

	public static float uM(float x){
		if (x < 0.4 || x > 0.6) {
			return 0;
		} else if (x >= 0.4 && x < 0.5) {
			return 10f * x - 4f;
		} else {
			return -10f * x + 6f;
		}
	}

	public static float uR(float x){
		if (x < 0.5 || x > 0.75) {
			return 0f;
		} else if (x >= 0.5 && x <= 0.6) {
			return 10f * x - 5f;
		} else {
			return -6.67f * x + 5f;
		}
	}

	public static float uFR(float x){
		if (x < 0.6) {
			return 0f;
		} else if (x >= 0.75) {
			return 1f;
		} else {
			return 6.67f * x - 4f;
		}
	}

/*	public static float uFL(float x){
		if (x < 0.15f) {
			return 1;
		} else if (x > 0.3f) {
			return 0;
		} else {
			return -6.67f * x + 2;
		}
	}

	public static float uL(float x){
		if (x < 0.15f || x > 0.4f) {
			return 0;
		} else if (x >= 0.15f && x <= 0.3f) {
			return 6.67f * x - 1f;
		} else {
			return -10f * x + 4f;
		}
	}

	public static float uM(float x){
		if (x < 0.3f || x > 0.7f) {
			return 0f;
		} else if (x >= 0.3 && x <= 0.5) {
			return 5f*x - 1.5f;
		} else {
			return -5f*x + 3.5f;
		}
	}

	public static float uR(float x){
		if (x < 0.5f || x > 0.85f) {
			return 0f;
		} else if (x >= 0.5f && x <= 0.7f) {
			return 5f * x - 2.5f;
		} else {
			return -6.67f * x + 5.67f;
		}
	}

	public static float uFR(float x){
		if (x < 0.7f) {
			return 0f;
		} else if (x > 0.85f) {
			return 1f;
		} else {
			return 6.67f*x - 4.67f;
		}
	}
*/
}
