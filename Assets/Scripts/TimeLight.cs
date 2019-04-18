using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLight  {

	public int threshold;
	public int countTime;

	public TimeLight(int t,int c){
		this.threshold = t;
		this.countTime = c;
	}

	public bool countSeconds(){
		countTime -= 1;
		if (countTime == 0) {
			countTime = threshold;
			return false;
		};
		return true;
	}
		
	public int getDownTime(){
		return this.threshold - this.countTime;
	}
	public float getRatio(){
		
		return ((float) this.threshold - (float)this.countTime) / (float)this.threshold;

	}

}
