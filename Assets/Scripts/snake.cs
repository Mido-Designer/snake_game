using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class snake : MonoBehaviour {

	LineRenderer line;
	EdgeCollider2D col;

	public Transform head;
	public int SnakeSize  = 10;



	public float pointSpacing = 0.1f;
	public List<Vector2> points;
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		col = GetComponent<EdgeCollider2D> ();
		points = new List<Vector2>();


		SetPoint ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (points.Last (), head.position) > pointSpacing) {
			SetPoint ();

				
		}
	}


	void SetPoint(){

		if (points.Count > 1) {
			col.points = points.ToArray<Vector2> ();
		}

		if (points.Count == SnakeSize) {

			for (int i = 0; i < points.Count - 1; i++) {
				line.SetPosition (i, line.GetPosition (i + 1));
				points [i] = line.GetPosition (i + 1);
			}
			line.SetPosition (points.Count - 1, head.position);
			points [points.Count-1] = head.position;

		} else {
			points.Add (head.position);
			line.positionCount = points.Count;
			line.SetPosition (points.Count - 1,head.position);
		}
			

	
	}
		

	public void line_reset(Vector3 point){

		points.Clear ();
		points.Add (point);
		head.position = point;
		line.positionCount = 1;
		line.SetPosition (0, point);
		SnakeSize = 10;


	}


}

















