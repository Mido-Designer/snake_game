using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {

	float xPose;
	float yPose;

	List<Vector2> spawned_points;

	Vector2 check;

	public GameObject food_item;

	Vector3 rand_pose = Vector3.zero;

	public GameObject snake;
	snake s;

	void Start(){
		
		s = snake.GetComponent<snake> ();

		spawned_points = new List<Vector2>();
		add_food ();

	}


	public void add_food(){
		rand_pose = gen_rand_vec3 (spawned_points);
		Instantiate (food_item, rand_pose, Quaternion.identity);
	}


	public Vector3 gen_rand_vec3(List<Vector2> spawned_points){

		Vector2 check;
	
		xPose = Random.Range (-6f, 6f);
		yPose = Random.Range (-4.5f, 4.5f);

		check = new Vector2 (xPose, yPose);
		Vector3 vec;

		if (!spawned_points.Contains (check) && !s.points.Contains(check)) {
			
			spawned_points.Add (check);
			vec = new Vector3 (xPose, yPose, 0);
			return vec;

		} else {
			gen_rand_vec3 (spawned_points);
			return Vector3.zero;
		}


	}


}
