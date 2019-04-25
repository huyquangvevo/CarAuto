using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Speed2 {

	static float sumBurning = 0f;
	static float timeL;
	static float di;
	static float de;

	public static void resetSumBurning(){
		sumBurning = 0f;
	}

	public static void setParam(float tL, float dis, float dev){
		sumBurning = 0f;
		timeL = tL;
		di = dis;
		de = dev;
	}
		


}
