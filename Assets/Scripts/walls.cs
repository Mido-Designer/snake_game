using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour {

	public GameObject snake;
	snake s ;

	public GameObject game_manager;
	game_manager gm;

	// Use this for initialization
	void Start () {
		s = snake.GetComponent<snake> ();
		gm = game_manager.GetComponent<game_manager> ();

	}
	

	void OnTriggerEnter2D (Collider2D col){
		if (col.name == "head" || col.name == "tail") {
			s.line_reset (Vector3.zero);
			gm.decrease_lifes ();
		}
	}

}
