using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	Rigidbody2D diver;
	GameObject theDiver;
	public GameObject bubble;
	// Use this for initialization
	public float bubbleVelocity = 250f; 
	public int Yspacing = 25;
	Vector2 bubbleForce; 

	Camera cam; 
	Animator animator;
	float bubbleY; 
	Vector3 screen_size;
	Vector3 worldScreenSize;
	float screenExtentsY;
	float screenExtentsX;
	float screenCrossPoint;
	float additionalVelocity; 
	Vector2 newPosition;
	public AnimationClip pop;

	void Start ()
	{
		animator = GetComponent<Animator> (); 
		cam = GameObject.Find ("MainCamera").GetComponent<Camera> (); 
		theDiver = GameObject.Find ("DiverFeet");
		bubbleForce = new Vector2(0f, bubbleVelocity);  
		screen_size = new Vector3 (Screen.width, Screen.height, 0.0f);
		worldScreenSize = cam.ScreenToWorldPoint(screen_size);
		screenExtentsY = worldScreenSize.y;
		screenExtentsX = worldScreenSize.x;


	
	}

	public IEnumerator PlayOneShot ( string paramName )
	{
		animator.SetTrigger ("Squash"); 

		yield return new WaitForSeconds(pop.length);

		gameObject.SetActive(false);


	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag( "MiniDiver")) 
		{
			diver = collision.gameObject.GetComponent<Rigidbody2D> ();
			theDiver = collision.gameObject;

			StartCoroutine(PlayOneShot ("Squash"));

	
			if (diver.velocity.y >= 1 || diver.velocity.y <= 0) 
			{
				diver.velocity = new Vector3(0f, 0f); 
				diver.AddForce (bubbleForce);
			}
				
		}

	}

}
