using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeedFob {

	static float di;

	static float burning = 0f;

	static void setParam(float di_){
		di = di_;
		burning = 0f;
	}

	public static float clarify(float di_){
		setParam (di_);
		float m = getRule01 () + getRule02 () + getRule03 ();
		return m/burning;
	}

	static float getRule01(){
		float uDi = Distance.uF (di);
		burning += uDi;
		return uDi * SpeedForbidden.medium (uDi);
	}

	static float getRule02(){
		float uDi = Distance.uM (di);
		burning += uDi;
		return uDi * SpeedForbidden.slower (uDi);
	}

	static float getRule03(){
		float uDi = Distance.uN (di);
		burning += uDi;
		return uDi * SpeedForbidden.stop (uDi);
	}

}
