using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Forbidden {

	static float de;
	static float di;
	static float df;
	static float burning = 0f;

	public static void setParam(float di_,float de_, float df_){
		burning = 0f;
		de = de_;
		di = di_;
		df = df_;

		idR = 0;
	}

	static int idR = 0;

	public static void debugRule(float b_){
		if (b_ != 0) {
			Debug.Log ("Rule: " + idR);
		}
	}

	public static float clarify(float di_, float de_, float df_){
		Debug.Log ("Di : "+di_ + " De: "+de_ + " Df: "+df_);
		setParam (di_, de_, df_);

		float m = getRule01 () + getRule02 () + getRule03 () + getRule04 () + getRule05 () 
			+ getRule06 () + getRule07() + getRule08() + getRule09() + getRule10() + getRule11();
		
		return m/burning;
	}

	public static float slower(float a_){
		float r1 = (0.11f + a_) / 4.44f;
		float r2 = (2f - a_) / 4f;
		return (r1 + r2) / 2f;
	}

	public static float slow(float a_){
		float r1 = (1f + a_) / 3.33f;
		float r2 = (4f - a_) / 5f;
		return (r1 + r2) / 2f;
	}

	public static float stop(float a_){
		float r1 = 0;
		float r2 = (1 - a_) / 20f;
		return (r1 + r2) / 2f;
	}

	public static float medium(float a_){
		float r1 = (3.5f + a_) / 5f;
		float r2 = 1f;
		return (r1 + r2) / 2f;
	}

/*	public static float getRule01(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDe * uDi;
		burning += b;
		idR++; debugRule(b); return b * slower (a);
	}

	public static float getRule02(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDe * uDi;
		burning += b;
		idR++; debugRule(b); return b * slower (a);
	}

	public static float getRule03(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDe * uDi;
		burning += b;
		idR++; debugRule(b); return b * slow (a);
	}

	public static float getRule04(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDe * uDi;
		burning += b;
		idR++; debugRule(b); return b * slow (a);
	}

	public static float getRule05(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDe * uDi;
		burning += b;
		idR++; debugRule(b); return b * medium (a);
	}

	public static float getRule06(){
		float uDi = Distance.uN (di);
	//	float uDe = Deviation.uL (de);
		float a = uDi;
		float b = uDi;
		burning += b;
		idR++; debugRule(b); return b * stop (a);
	}


	public static float getRule07(){
		float uDi = Distance.uF (di);
		//	float uDe = Deviation.uL (de);
		float a = uDi;
		float b = uDi;
		burning += b;
		idR++; debugRule(b); return b * medium (a);
	}
*/
	public static float getRule01(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * medium (a);
	}

	public static float getRule02(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * medium (a);
	}

	public static float getRule03(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slow (a);
	}

	public static float getRule04(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slow (a);
	}

	public static float getRule05(){
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slow (a);
	}

	public static float getRule06(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * medium (a);
	}

	public static float getRule07(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * medium (a);
	}

	public static float getRule08(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slower (a);
	}

	public static float getRule09(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slower (a);
	}

	public static float getRule10(){
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float b = uDi * uDe;
		burning += b;
		return b * slower (a);
	}

	public static float getRule11(){
		float uDi = Distance.uF (di);
		float a = uDi;
		float b = uDi;
		burning += b;
		idR++; debugRule(b); return b * medium (a);
	}
}
