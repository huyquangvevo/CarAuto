using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Steerage {
/*
	public static float uHR(float x){
		if (x > 0.75) {
			return 1;
		} else if (x < 0.6) {
			return 0;
		} else {
			return 6.67f * x - 4;
		}
	}

	public static float uR(float x){
		if (x < 0.5 || x > 0.75) {
			return 0;
		} else if (x >= 0.5 && x <= 0.6) {
			return 10f * x - 5f;
		} else {
			return -6.67f * x + 5f;
		}
	}

	public static float uS(float x){
		if (x < 0.4 || x > 0.6) {
			return 0;
		} else if (x >= 0.4 && x <= 0.5f) {
			return 10f * x - 4;
		} else {
			return -10f * x + 6;
		}
	}

	public static float uL(float x){
		if (x < 0.25 || x > 0.5) {
			return 0;
		} else if (x >= 0.25 && x <= 0.4) {
			return 6.67f * x - 1.67f;
		} else {
			return -10f * x + 5f;
		}
	}

	public static float uHL(float x){
		if (x < 0.25) {
			return 1;
		} else if (x > 0.4) {
			return 0;
		} else {
			return -6.67f + 2.67f;
		}
	}

	// clarify

	public static float clarifyHR(float x){
		float d = Deviation.uFL (x);
		float r1 = (d + 4f) / 6.67f;
		float r2 = 1f;
		return (r1 + r2) / 2f;
	}

	public static float clarifyR(float x){
		float d = Deviation.uL (x);
		float r1 = (d + 5f) / 10f;
		float r2 = (5f - d) / 6.67f;
		return (r1 + r2) / 2f;
	}

	public static float clarifyS(float x){
		float d = Deviation.uM (x);
		float r1 = (4f + d) / 10f;
		float r2 = (6f - d) / 10f;
		return (r1 + r2) / 2f;
	}

	public static float clarifyL(float x){
		float d = Deviation.uR (x);
		float r1 = (1.67f + d) / 6.67f;
		float r2 = (5f - d) / 10f;
		return (r1 + r2) / 2f;
	}

	public static float clarifyHL(float x){
		float d = Deviation.uFR (x);
		float r1 = 0;
		float r2 = (2.67f - d) / 6.67f;
		return (r1 + r2) / 2f;
	}
*/

	public static float burning = 0;
	public static float de;

	public static void setParam(float x){
		de = x;
		burning = 0f;
	}

	public static float clarify(float x){
		/*
		float a = clarifyHR (x) * Deviation.uFL (x) + clarifyR (x) * Deviation.uL (x) + clarifyS (x) * Deviation.uM (x) 
			+ clarifyL (x) * Deviation.uR (x) + clarifyHL (x) * Deviation.uFR (x);

		float b = Deviation.uFL (x) + Deviation.uL (x) + Deviation.uM (x) + Deviation.uR (x) + Deviation.uFR (x);
		*/
	//	return a / b;
		setParam(x);
		float m = getRule01() + getRule02() + getRule03() + getRule04() + getRule05();
		return m / burning;
	}

	public static float hardRight(float x){
		float r1 = (4f + x) / 6.67f;
		float r2 = 1;
		return (r1 + r2) / 2f;
	}

	public static float right(float x){
		float r1 = (5f + x) / 10f;
		float r2 = (5f - x) / 6.67f;
		return (r1 + r2) / 2f;
	}

	public static float straight(float x){
		float r1 = (4f + x) / 10f;
		float r2 = (6f - x) / 10f;
		return (r1 + r2) / 2f;
	}

	public static float left(float x){
		float r1 = (1.67f + x) / 6.67f;
		float r2 = (5f - x) / 10f;
	//	float r1 = 0;
	//	float r2 = (1.25f - x) / 2.5f;
		return (r1 + r2) / 2f;
	}

	public static float hardLeft(float x){
		float r1 = 0;
		float r2 = (2.67f - x) / 6.67f;
		return (r1 + r2) / 2f;
	}

	public static float getRule01(){
		float a = Deviation.uFL (de);
		burning += a;
		//return a * hardRight (a);
		return a * hardRight (a);
	}

	public static float getRule02(){
		float a = Deviation.uL (de);
		burning += a;
		return a * right (a);
		//return a * hardRight (a);
	}

	public static float getRule03(){
		float a = Deviation.uM (de);
		burning += a;
		return a * straight (a);
		//return a * hardRight (a);
	}

	public static float getRule04(){
		float a = Deviation.uR (de);
		burning += a;
		return a * left (a);
	//	return a * straight (a);
	}

	public static float getRule05(){
		float a = Deviation.uFR (de);
		burning += a;
	//	return a * (a);
		return a * hardLeft (a);
	}

}
