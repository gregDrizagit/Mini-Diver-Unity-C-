using UnityEngine;
using System.Collections;

public class BubbleDetector : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	}

	void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.gameObject.CompareTag ("Bubble"))
		{
			Debug.Log ("Bubble detected");

			transform.parent.gameObject.SetActive (false);

		}

	}
}
