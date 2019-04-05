using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour {

	public PathCreator pathCreator;

	void Start () {
		Debug.Log (pathCreator.path.GetPointAtDistance(50));
	}
}
