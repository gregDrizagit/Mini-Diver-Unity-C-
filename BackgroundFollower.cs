using UnityEngine;
using System.Collections;

public class BackgroundFollower : MonoBehaviour {
	GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("MainCamera");
	}

	// Update is called once per frame
	void Update (){
		transform.position = new Vector3(transform.position.x, camera.transform.position.y);
	}
}
