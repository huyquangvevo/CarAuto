using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedForbidden {

	static float de;
	static float diR;
	static float diL;

	static float burning = 0f;

	static void setParam(float de_,float diR_,float diL_){
		burning = 0f;
		de = de_;
		diR = diR_;
		diL = diL_ - diR_;
	}

	public static float clarify(float de_, float diR_,float diL_){
		setParam (de_, diR_,diL_);
		float m = getRule01 () + getRule02 () + getRule03 () + getRule04 () + getRule05 () + getRule06() 
			+ getRule07();
		return m / burning;
	}

	public static float stop(float a_){
		float r1 = 0;
		float r2 = (1f - a_) / 20f;
		return (r1 + r2) / 2f;
	}

	public static float slower(float a_){
		float r1 = (0.11f + a_)/4.44f;
		float r2 = (2f - a_) / 4f;
		return (r1 + r2) / 2f;
	}

	public static float slow(float a_){
		float r1 = (1f + a_) / 3.33f;
		float r2 = (4f - a_) / 5f;
		return (r1 + r2) / 2f;
	}

	public static float medium (float a_){
		float r1 = (3.5f + a_) / 5f;
		float r2 = 1f;
		return (r1 + r2) / 2f;
	}

	static float getRule01(){
		float uDe = Deviation.uFL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slow (a);
	}

	static float getRule02(){
		float uDe = Deviation.uL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * medium (a);
	}

	static float getRule03(){
		float uDe = Deviation.uM (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * medium (a);
	}

	static float getRule04(){
		float uDe = Deviation.uR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slow (a);
	}

	static float getRule05(){
		float uDe = Deviation.uFR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slow (a);
	}

	static float getRule06(){
		float uDiL = Distance.uM (diL);
		float uDiR = Distance.uN (diR);
		float a = Mathf.Min (uDiL, uDiR);
		float b = uDiL * uDiR;
		burning += b;
		return b * stop (a);
	}

	static float getRule07(){
		float uDiL = Distance.uN (diL);
		float uDiR = Distance.uN (diR);
		float a = Mathf.Min (uDiL, uDiR);
		float b = uDiL * uDiR;
		burning += b;
		return b * stop (a);
	}

/*	static float getRule06(){
		float uDe = Deviation.uFL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slow (a);
	}

	static float getRule07(){
		float uDe = Deviation.uL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slow (a);
	}

	static float getRule08(){
		float uDe = Deviation.uM (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slower (a);
	}

	static float getRule09(){
		float uDe = Deviation.uR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slower (a);
	}

	static float getRule10(){
		float uDe = Deviation.uFR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, Mathf.Min(uDiR,uDiL));
		float b = uDe * uDiR * uDiL;
		burning += b;
		return b * slower (a);
	}

	static float getRule11(){
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uN (diL);
		float a = Mathf.Min (uDiR, uDiL);
		float b = uDiR * uDiL;
		burning += b;
		return b * stop (a);
	}
*/
}
