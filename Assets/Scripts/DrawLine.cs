using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

	public GameObject linePrefab;
	public GameObject currentLine;

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public List<Vector2> fingerPositions;

	public Vector3 startPoint;
	public Vector3 endPoint;

	int c = 0;

	// Use this for initialization
	void Start () {
		currentLine = Instantiate (linePrefab, Vector3.zero, Quaternion.identity);
		lineRenderer = currentLine.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			//CreateLine ();
			if (c == 0) {
				startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				c++;
			} else if(c==1){
				endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				c++;
				lineRenderer.SetPosition (0, startPoint);
				lineRenderer.SetPosition (1, endPoint);
			}
			//Debug.Log(Input.mousePosition.x + " - " + Input.mousePosition.y);
		}
	}

	void CreateLine(){
		lineRenderer = currentLine.GetComponent<LineRenderer> ();
		edgeCollider = currentLine.GetComponent<EdgeCollider2D> ();
		fingerPositions.Clear ();
		fingerPositions.Add (Camera.main.ScreenToWorldPoint (Input.mousePosition));
		fingerPositions.Add (Camera.main.ScreenToWorldPoint (Input.mousePosition));
		lineRenderer.SetPosition (0, fingerPositions [0]);
		lineRenderer.SetPosition (1, fingerPositions [1]);
		edgeCollider.points = fingerPositions.ToArray ();
	}

	void UpdateLine (Vector2 newFingerPos)
	{
		fingerPositions.Add (newFingerPos);
		lineRenderer.positionCount++;
		lineRenderer.SetPosition (lineRenderer.positionCount - 1, newFingerPos);  
		edgeCollider.points = fingerPositions.ToArray ();
	}

}
