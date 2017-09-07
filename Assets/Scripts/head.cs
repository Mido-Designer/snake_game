using UnityEngine;

public class head : MonoBehaviour {


	public float speed = 3.0f;
	public float rotation_speed = 200.0f;
	float horizontal = 0f;

	public int long_factor = 10 ;

	public GameObject snake;
	snake s;

	public GameObject game_manager;
	game_manager gm;


	public GameObject food;
	food f;

	int direction = 0;


	void Start(){

		s = snake.GetComponent<snake> ();
		f = food.GetComponent<food> ();
		gm = game_manager.GetComponent<game_manager> ();
	
	}
	// Update is called once per frame
	void Update () {

		direction = gm.move ();

		horizontal = Input.GetAxisRaw ("Horizontal");

	}

	void FixedUpdate(){

		transform.Translate (Vector3.up * speed * Time.fixedDeltaTime, Space.Self);
		transform.Rotate (Vector3.forward * rotation_speed * direction * Time.fixedDeltaTime);
	
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.name == "tail") {
			s.line_reset (transform.position);
			gm.decrease_lifes ();
		}

		if (col.tag == "food") {
			Destroy (col.gameObject);
			f.add_food ();
			s.SnakeSize += long_factor;
			gm.increase_score (10);
		}

	}
}
