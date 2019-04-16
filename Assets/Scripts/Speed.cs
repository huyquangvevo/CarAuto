using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Speed {

	static float sumBurning = 0f;
	static float timeL;
	static float di;
	static float de;

	public static void resetSumBurning(){
		sumBurning = 0f;
	}

	public static void setParam(float tL, float div, float dev){
		timeL = tL;
		di = div;
		de = dev;
	}
		


	public static float getRule01(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uTimeL,uDe);
		float r1 = (a + 3.5f) / 5f;
		float r2 = 1f;
		sumBurning += uTimeL * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule02(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uTimeL * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule03(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uTimeL * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule04(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule05(){
		float uTimeL = LightStatus.uG (timeL);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule06(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uDi, uDe);
		float r1 = (3.5f + a) / 5f;
		float r2 = 1f;
		sumBurning += uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule07(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uDi, uDe);
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule08(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uDi, uDe);
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule09(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uDi, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule10(){
		float uDi = Distance.uF (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uDi, uDe);
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule11(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule12(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return(r1 + r2) / 2f;
	}

	public static float getRule13(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return(r1 + r2) / 2f;
	}

	public static float getRule14(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return(r1 + r2) / 2f;
	}

	public static float getRule15(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return(r1 + r2) / 2f;
	}

	public static float getRule16(){
		float uTimeL = LightStatus.uY (timeL);
		float uDi = Distance.uN (di);
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0f;
		float r2 = (1f - a) / 20f;
		sumBurning += uTimeL * uDi;
		return (r1 + r2) / 2f;
	}

	public static float getRule17(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f - a) / 5f;
		sumBurning += uTimeL * uDe * uDi;
		return (r1 + r2) / 2f;
	}

	public static float getRule18(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule19(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule20(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule21(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f - a) / 4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule22(){
		float uTimeL = LightStatus.uR (timeL);
		float uDi = Distance.uN (di);
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0f;
		float r2 = (1f - a) / 20f;
		sumBurning += uTimeL * uDi;
		return (r1 + r2) / 2f;
	}

	public static float getRule23(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (3.5f + a) / 5f;
		float r2 = 1;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule24(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule25(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 1f) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule26(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule27(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule28(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uM (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule29(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule30(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (a + 0.11f) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule31(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = 0f;
		float r2 = (1f-a)/20f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule32(){
		float uTimeL = LightStatus.uLG (timeL);
		float uDi = Distance.uN (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = 0f;
		float r2 = (1f-a)/20f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule33(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uM(de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (1f + a) / 3.33f;
		float r2 = (4f-a)/5f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule34(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule35(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule36(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFL (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}

	public static float getRule37(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uM (di);
		float uDe = Deviation.uFR (de);
		float a = Mathf.Min (uTimeL, Mathf.Min (uDi, uDe));
		float r1 = (0.11f + a) / 4.44f;
		float r2 = (2f-a)/4f;
		sumBurning += uTimeL * uDi * uDe;
		return (r1 + r2) / 2f;
	}
		
	public static float getRule38(){
		float uTimeL = LightStatus.uLR (timeL);
		float uDi = Distance.uN (di);
		float a = Mathf.Min (uTimeL, uDi);
		float r1 = 0;
		float r2 = (1f + a) / 20f;
		sumBurning += uTimeL * uDi;
		return (r1 + r2) / 2f;
	}
		
}
