using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour {

	public Text score;
	public Text life_times;

	public GameObject snake;
	snake s;

	public GameObject head;
	head h;

	int scre  = 0;
	int lifes = 5;

	void Start(){
		s = snake.GetComponent<snake> ();
		h = head.GetComponent<head> ();
	}

	public void increase_score(int factor){
		scre = scre + factor;
		score.text = scre.ToString ();
	}

	public int move(){
		if (Input.touchCount > 0 && Input.GetTouch(0).position.x < (Screen.width / 2)) {
			return 1;
		} else if (Input.touchCount > 0 && Input.GetTouch(0).position.x > (Screen.width / 2)) {
			return -1;
		} else {
			return 0;
		}
	}

	public void decrease_lifes(){
		lifes = lifes - 1;
		life_times.text = lifes.ToString ();

		if (lifes <= 0) {
			print ("game Over");
			reset_game ();

		}
	}

	public void reset_score(){
		scre = 0;
		score.text = scre.ToString ();
	}
	void reset_lifes(){
		lifes = 5;
		life_times.text = lifes.ToString ();
	}

	public void reset_game(){
		reset_score ();
		reset_lifes ();
		s.line_reset (Vector3.zero);

	}


}
