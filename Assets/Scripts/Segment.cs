using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment {

	public Vector2 startPoint;
	public Vector2 endPoint;

	public Segment(Vector2 s,Vector2 e){

		if (s.x > e.x || s.y > e.y) {
			Vector2 t = s;
			s = e;
			e = t;
		};

		this.startPoint = s;
		this.endPoint = e;
	}
}
