using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightController : MonoBehaviour {

	public Button[] lights;
	public TimeLight[] timeLights = new TimeLight[3];
	public int[] thresholdLight = new int[3];
	public int[] startPoint;
	public Color[] colorLights = {Color.red,Color.green,Color.yellow};
	public int idL = 0;
	// Use this for initialization
	void Start () {
		timeLights [0] = new TimeLight (thresholdLight[0], startPoint[0]);
		timeLights [1] = new TimeLight (thresholdLight[1], startPoint[1]);
		timeLights [2] = new TimeLight (thresholdLight[2], startPoint[2]);

		StartCoroutine (ControllLight ());
	}
	
	void Update () {
		
	}

	public int getIdL(){
		return this.idL;
	}

	public float getRatioTime(){
		return timeLights [idL].getRatio ();
	}

	IEnumerator ControllLight(){
		while (true) {
			if (!timeLights [idL].countSeconds ()) {
				ColorBlock cb = lights[idL].colors;
				cb.normalColor = Color.grey;
				lights [idL].colors = cb;//colorLights [idL];
				lights [idL].GetComponentInChildren<Text> ().text = "";
				idL = (idL + 1) % 3;
				//yield return new WaitForSeconds (0.1f);
			} else {
				ColorBlock cb = lights [idL].colors;
				cb.normalColor = colorLights [idL];
				lights [idL].colors = cb;
				lights [idL].GetComponentInChildren<Text> ().text = timeLights [idL].countTime.ToString ();
				yield return new WaitForSeconds (1f);
			}
		}
	}
}

