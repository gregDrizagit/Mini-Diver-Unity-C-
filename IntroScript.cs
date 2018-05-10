using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour 
{

	// Use this for initialization
	public Transform startTarget; 
	public Transform endTarget;
	public Transform midTarget; 
	public GameObject button; 
	float currentLerpTime; 
	float lerpTime = 1f; 
	public AnimationClip clip;
	Animator animator; 
	public int bubbleGenNum = 3; 
	public GameObject bub; 
	void Start () 
	{
		Debug.LogError ("blarg");
 
		//transform.position = startTarget.transform.position; 

		float distance = Vector3.Distance (startTarget.position, endTarget.position); 
		animator = GetComponent<Animator> ();

		for (int i = 0; i < bubbleGenNum; i++) 
		{
			Instantiate (bub, new Vector3 (Random.Range (-4, 4), Random.Range(-6, -9)), Quaternion.identity); 
		}
	}

	// Update is called once per frame
	void Update () 
	{
		animator.SetBool("arrived", true); 
		currentLerpTime += Time.deltaTime;
		float perc = currentLerpTime / lerpTime; 
		transform.position = Vector3.Lerp (startTarget.position, endTarget.position, perc);

		StartCoroutine (PlayOneShot("arrived")); 

		if (transform.position == endTarget.position) 
		{
			animator.SetTrigger ("bounce"); 
			
			button.SetActive (true); 
		}
	}


	public void startTheGame()
	{
		Application.LoadLevel ("Main"); 
	}


	public IEnumerator PlayOneShot(string param)
	{
		animator.SetBool(param, true);

		yield return new WaitForSeconds(clip.length); 

		Debug.Log ("ended"); 
		animator.SetBool (param, false); 
	}
}
