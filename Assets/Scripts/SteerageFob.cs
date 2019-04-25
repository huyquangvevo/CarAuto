using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SteerageFob {
	static float di;
	static float de;

	static float burning = 0f;

	public static void setParam(float di_,float de_){
		burning = 0f;
		di = di_;
		de = de_;
	}

	public static float clarify(float di_,float de_){
		setParam (di_, de_);
		float m = getRule01 () + getRule02 () + getRule03 () + getRule04 () + getRule05 ()
			+ getRule06 () + getRule07 () + getRule08 () + getRule09 () + getRule10 ();
		return m / burning;
	}

	public static float hardRight(float a_){
		float r1 = (4f + a_) / 6.67f;
		float r2 = 1;
		return (r1 + r2) / 2f;
	}

	public static float right(float a_){
		float r1 = (5f + a_) / 10f;
		float r2 = (5f - a_) / 6.67f;
		return (r1 + r2) / 2f;
	}

	public static float straight(float a_){
		float r1 = (4f + a_) / 10f;
		float r2 = (6f - a_) / 10f;
		return (r1 + r2) / 2f;
	}

	public static float left(float a_){
		float r1 = (1.67f + a_) / 6.67f;
		float r2 = (5f - a_) / 10f;
		return (r1 + r2) / 2f;
	}

	public static float hardLeft(float a_){
		float r1 = 0;
		float r2 = (2.67f - a_) / 6.67f;
		return (r1 + r2) / 2f;
	}


	public static float getRule01(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * right (a);
	}

	public static float getRule02(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * right (a);
	}

	public static float getRule03(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * left (a);
	}

	public static float getRule04(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * straight (a);
	}

	public static float getRule05(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * right (a);
	}

	public static float getRule06(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * right (a);
	}

	public static float getRule07(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * right (a);
	}

	public static float getRule08(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * hardLeft (a);
	}

	public static float getRule09(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * left (a);
	}

	public static float getRule10(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * straight (a);
	}
}
