using UnityEngine;
using System.Collections;

public class Diver : MonoBehaviour {
	Touch touch = new Touch();
	Camera camera;
	public bool isGrounded = true;
	public Animator animator;
	public float jumpVelocity = 50f;
	public float walkVelocity = 1000f;
	Rigidbody2D diver;
	Vector2 jumpForce;
	Vector2 walkForce;
	GameObject diverFeet;
	Spawner spawner;
	public GameObject gameMan;
	GameManager gameManager;
	float diverPositionX;
	bool facingRight = true;
	int animatorController;
	Vector3 zero = new Vector3(0f, 0f, 0f);
	public int bubblesPopped;
	AudioScript audio;
	public InstructionBubble instructions;

	public AnimationClip death;
	// Use this for initialization

	void Awake()
	{
		diverFeet = GameObject.Find ("DiverGround");
		animator = GetComponent<Animator> ();
		diver = GetComponent<Rigidbody2D> ();
		audio = GameObject.FindGameObjectWithTag("Spawner").GetComponent<AudioScript> ();
		camera = GameObject.Find ("MainCamera").GetComponent<Camera> ();
		spawner = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<Spawner>();
		instructions = GameObject.FindGameObjectWithTag ("Instructions").GetComponent<InstructionBubble> ();
		walkForce = new Vector2 (walkVelocity, 0f);
		jumpForce = new Vector2 (0f, jumpVelocity);

		diver.velocity = Vector3.zero;

	}
	void Start ()
	{

	}

	// Update is called once per frame

	void FixedUpdate()
	{
		onGround ();

		if (instructions.hasSeenInstructions || PlayerPrefs.GetInt("SeenInstructions") == 1) {

			foreach (Touch touch in Input.touches) {

				if (touch.phase == TouchPhase.Stationary) {

					animator.SetFloat ("Speed", Mathf.Abs (animatorController));

					if (touch.position.x < Screen.width / 2) {

						animatorController = -1;
						diver.AddForce (zero);
						diver.AddForce (-walkForce);
						if (facingRight) {
							Flip ();
						}

						if (!isGrounded)
							animator.SetFloat ("Speed", 0);

					} else if (touch.position.x > Screen.width / 2) {

						animatorController = 1;

						if (!facingRight) {
							Flip ();
						}
						diver.AddForce (zero);

						diver.AddForce (walkForce);

						if (!isGrounded)
							animator.SetFloat ("Speed", 0);

					}
				} else {
					if (touch.tapCount == 1 && isGrounded && touch.phase != TouchPhase.Stationary) {
						animator.SetBool ("Jump", true);
						diver.velocity = zero;
						diver.AddForce (jumpForce);

					}

					if (touch.phase == TouchPhase.Ended) {

						if (isGrounded) {
							diver.velocity = new Vector2 (0f, 0f);
						}

						animator.SetBool ("Jump", false);
						animator.SetFloat ("Speed", 0f);
					}


				}

			}
		}

	}


	void Update()
	{

		if (diver.transform.position.y < camera.transform.position.y - Camera.main.orthographicSize){
			gameObject.SetActive (false);
		}

		animator.SetFloat ("FallSpeed", diver.velocity.y);
		animator.SetFloat ("Speed", diver.velocity.y);



	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Mine")){
			audio.playBoom ();
			StartCoroutine (PlayOneShot("Death"));

		} else if (other.gameObject.CompareTag("Bubble"))
		{
			animator.SetTrigger ("BubbleJump");
			bubblesPopped++;
			spawner.probBubCount++;
			audio.playPop ();
		}



	}

	public IEnumerator PlayOneShot ( string paramName ){
		animator.SetTrigger ("Death");

		yield return new WaitForSeconds(death.length);

		gameObject.SetActive(false);


	}



	void Flip(){
		facingRight = !facingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void onGround(){
		if (transform.position.y > -10)
			isGrounded = false;
		else
			isGrounded = true;
	}





}
