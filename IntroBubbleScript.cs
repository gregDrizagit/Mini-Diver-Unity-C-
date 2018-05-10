using UnityEngine;
using System.Collections;

public class IntroBubbleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		float randomSize = Random.Range (0.05f, 0.2f); 
		transform.localScale = new Vector3(randomSize, randomSize, randomSize);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(0.015f, 0.2f)); 
	}
}
