using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SteerageFob {
	static float di;
	static float de;
	static float df;

	static float burning = 0f;

	static int idR = 0;

	public static void setParam(float de_,float di_, float df_){
		burning = 0f;
		di = di_;
		de = de_;
		df = df_;
		idR = 0;
	}

	public static void debugRule(float b_){
		if (b_ != 0) {
			Debug.Log ("Steerage Fob Rule: " + idR);
		}
	}

	public static float clarify(float de_, float di_, float df_){

		setParam (de_, di_, df_);
		float m = getRule01 () + getRule02 () + getRule03 () + getRule04 () + getRule05 () + getRule06 () + getRule07 () + getRule08 ()
			+ getRule09 () + getRule10 () + getRule11 () + getRule12 () + getRule13 () + getRule14 () + getRule15 () + getRule16 ()
			+ getRule17 () + getRule18 () + getRule19 () + getRule20 () + getRule21 () + getRule22 () + getRule23 () + getRule24 ()
			+ getRule25 (); 

		return m / burning;

	}

	//public static float 

	public static float getRule01(){
		float uDe = Deviation.uFL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule02(){
		float uDe = Deviation.uFL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule03(){
		float uDe = Deviation.uFL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uM (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule04(){
		float uDe = Deviation.uFL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.right (a);
	}

	public static float getRule05(){
		float uDe = Deviation.uFL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule06(){
		float uDe = Deviation.uL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule07(){
		float uDe = Deviation.uL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule08(){
		float uDe = Deviation.uL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uM (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule09(){
		float uDe = Deviation.uL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule10(){
		float uDe = Deviation.uL (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.right (a);
	}

	public static float getRule11(){
		float uDe = Deviation.uM (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule12(){
		float uDe = Deviation.uM (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule13(){
		float uDe = Deviation.uM (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uM (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule14(){
		float uDe = Deviation.uM (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule15(){
		float uDe = Deviation.uM (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule16(){
		float uDe = Deviation.uR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.left (a);
	}

	public static float getRule17(){
		float uDe = Deviation.uR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule18(){
		float uDe = Deviation.uR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uM (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardRight (a);
	}

	public static float getRule19(){
		float uDe = Deviation.uR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule20(){
		float uDe = Deviation.uR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule21(){
		float uDe = Deviation.uFR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule22(){
		float uDe = Deviation.uFR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uL (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.left (a);
	}

	public static float getRule23(){
		float uDe = Deviation.uFR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uM (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.straight (a);
	}

	public static float getRule24(){
		float uDe = Deviation.uFR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

	public static float getRule25(){
		float uDe = Deviation.uFR (de);
		float uDi = Distance.uN (di);
		float uDf = Deviation.uFR (df);
		float a = Mathf.Min (uDe, Mathf.Min (uDi, uDf));
		float b = uDe * uDi * uDf;
		burning += b;
		return b * Steerage.hardLeft (a);
	}

}
