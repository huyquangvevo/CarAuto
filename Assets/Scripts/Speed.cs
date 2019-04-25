using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Speed {

	static float sumBurning = 0f;
	static float timeL;
	static float di;
	static float de;

	static int countRule = 0;
	static int idRule = 0;

	public static void resetSumBurning(){
		sumBurning = 0f;
	}

	public static void setParam(float tL, float dis, float dev){
		countRule = 0;
		idRule = 0;
		timeL = tL;
		di = dis;
		de = dev;
	}

	public static float clarify(int idL, float timeLight,float distance,float deviation){
		resetSumBurning ();
		setParam (timeLight, distance, deviation);
		float m = getRule01() + getRule02() + getRule03() + getRule04() + getRule05() + getRule06() + getRule07() + getRule08() 
			+ getRule09() + getRule10() + getRule11() + getRule12() + getRule13() + getRule14() + getRule15() + getRule16() 
			+ getRule17() + getRule18() + getRule19() + getRule20() + getRule21() + getRule22() + getRule23() + getRule24() + getRule25()
			+ getRule26() + getRule27() + getRule28() + getRule29() + getRule30() + getRule31() + getRule32() + getRule33() + getRule34() 
			+ getRule35() + getRule36() + getRule37() + getRule38(); 
		return m / sumBurning;

	}

	public static void debugRule(float b){
		if(b != 0){
			countRule++;
			Debug.Log("rule: " + idRule);
		}
	}



	public static float getRule01(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uM (de);
		float b = uTimeL * uDe;
		float a = Mathf.Min (uTimeL,uDe);
		float r1 = (a + 3.5f) / 5f;
		float r2 = 1f;
		sumBurning += b;

		return b*(r1 + r2) / 2f;
	}

	public static float getRule02(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDe;
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule03(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDe;
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule04(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDe;
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule05(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDe;
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule06(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uM (de);
		float b = uDi * uDe;
		float a = Mathf.Min (uDi, uDe);
		float r1 = (3.5f + a) / 5f;
		float r2 = 1f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule07(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uL (de);
		float b = uDi * uDe;
		float a = Mathf.Min (uDi, uDe);
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning +=b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule08(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uR (de);
		float b = uDi * uDe;
		float a = Mathf.Min (uDi, uDe);
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule09(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uFL (de);
		float b = uDi * uDe;
		float a = Mathf.Min (uDi, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule10(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uFR (de);
		float b = uDi * uDe;
		float a = Mathf.Min (uDi, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule11(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule12(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDi * uDe;	
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning +=b;


		return b*(r1 + r2) / 2f;
	}

	public static float getRule13(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule14(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule15(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule16(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uN (di);
		float b = uTimeL * uDi;
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0f;
		float r2 = (1f - a) / 20f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule17(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule18(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule19(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule20(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule21(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning +=b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule22(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uN (di);
		float b = uTimeL * uDi;
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0f;
		float r2 = (1f - a) / 20f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule23(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (3.5f + a) / 5f;
		float r2 = 1;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule24(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule25(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule26(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule27(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule28(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uM (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule29(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule30(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule31(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = 0f;
		float r2 = (1f-a)/20f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule32(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = 0f;
		float r2 = (1f-a)/20f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule33(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM(de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule34(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning +=b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule35(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule36(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}

	public static float getRule37(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float b = uTimeL * uDi * uDe;
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}
		
	public static float getRule38(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uN (di);
		float b = uTimeL * uDi;
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0;
		float r2 = (1f - a) / 20f;
		sumBurning += b;
		return b*(r1 + r2) / 2f;
	}
		
}
