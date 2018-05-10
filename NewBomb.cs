using UnityEngine;
using System.Collections;

public class NewBomb : MonoBehaviour {

	AudioSource mineAudio;
	public AudioClip mineDeath;
	GameObject miniDiver;
	Ray2D mineRay;
	Collider2D collider;
	GameObject mineFeet;
	AudioScript audio;
	Animator animation;
	public AnimationClip death;
	Collider2D hit;
	Renderer rend;
	void Start ()
	{
		miniDiver = GameObject.FindGameObjectWithTag ("MiniDiver");
		mineAudio = GetComponent<AudioSource> ();
		collider = GetComponent<CircleCollider2D> ();
		mineFeet = GameObject.FindGameObjectWithTag ("Minefeet");
		audio = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<AudioScript> ();
		animation = GetComponent<Animator> ();
		rend = GetComponent<Renderer> ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("MiniDiver"))
		{
			audio.playBoom ();

			StartCoroutine (PlayOneShot ("Death"));

			other.gameObject.SetActive (false);

		} else if (other.gameObject.CompareTag ("Bubble"))
		{
			gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("Mine"))
		{
			if (gameObject.GetInstanceID () < other.gameObject.GetInstanceID ())
			{
				gameObject.SetActive (false);
			}

		}

	}

	public IEnumerator PlayOneShot ( string paramName )
	{
		animation.SetTrigger (paramName);

		yield return new WaitForSeconds(death.length);

		gameObject.SetActive(false);


	}

	void Update ()
	{

		if (transform.position.y < miniDiver.transform.position.y - 20)
		{

			gameObject.SetActive (false);

		}




	}
}
