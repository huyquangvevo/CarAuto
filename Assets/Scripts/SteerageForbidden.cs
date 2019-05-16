using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SteerageForbidden {

	static float diR;
	static float diL;
	static float de;

	static float burning = 0f;


	static void setParam(float de_,float diR_,float diL_){
		burning = 0f;
		de = de_;
		diR = diR_;
		diL = diL_ - diR_;

	}

	public static float clarify(float de_,float diR_, float diL_){
		setParam (de_, diR_, diL_);
	/*	float m = getRule01 () + getRule02() + getRule03() + getRule04() + getRule05() + getRule06()
			+ getRule07() + getRule08() + getRule09() + getRule10() + getRule11();
*/		
		float m = getRule01 () + getRule02 () + getRule03 () + getRule04 ()  + getRule05 () + getRule06 ()
			+ getRule07 () + getRule08 () + getRule09 ()+ getRule10 () + getRule11 ();
		return m / burning;
	}

	static float getRule01(){
		float uDe = Deviation.uFL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	static float getRule02(){
		float uDe = Deviation.uL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.right (a);
	}

	static float getRule03(){
		float uDe = Deviation.uM (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.straight (a);
	}

	static float getRule04(){
		float uDe = Deviation.uR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	static float getRule05(){
		float uDe = Deviation.uFR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uF (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	static float getRule06(){
		float uDe = Deviation.uFL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	static float getRule07(){
		float uDe = Deviation.uL (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.right (a);
	}

	static float getRule08(){
		float uDe = Deviation.uM (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.straight (a);
	}

	static float getRule09(){
		float uDe = Deviation.uR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	static float getRule10(){
		float uDe = Deviation.uFR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uM (diL);
		float a = Mathf.Min (uDe, uDiR,uDiL);
		float b = uDe * uDiR*uDiL;
		burning += b;
		return b * Steerage.straight (a);
	}

	static float getRule11(){
	//	float uDe = Deviation.uFR (de);
		float uDiR = Distance.uN (diR);
		float uDiL = Distance.uN (diL);
		float a = Mathf.Min (uDiR,uDiL);
		float b = uDiR*uDiL;
		burning += b;
		return b * Steerage.straight (a);
	}


}
