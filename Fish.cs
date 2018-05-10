using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// Use this for initialization
	bool facingRight = true;
	GameObject diver;
	public float fishSpeed = 0.05f;

	float startingZ;


	void Awake (){
		startingZ = transform.position.z;
	}


	void Start(){
		diver = GameObject.FindGameObjectWithTag ("MiniDiver");

		float random = Random.value;
		if (random > 0.5)
			Flip ();

	}
	// Update is called once per frame
	void Update () {

		if (facingRight) {
			transform.position = new Vector3 (transform.position.x + fishSpeed, transform.position.y, startingZ);
			if (transform.position.x > 20) {
				Flip ();
			}
		} else {
			transform.position = new Vector3 (transform.position.x - fishSpeed, transform.position.y, startingZ);
			if (transform.position.x < -20) {
				Flip ();
			}
		}




		if (transform.position.y < diver.transform.position.y - 20) {
			gameObject.SetActive (false);

		}






	}

	void OnTriggerEnter2D(Collider2D collision){

		if (collision.gameObject.CompareTag("Fish")){
			collision.gameObject.SetActive (false);
		}

	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}
