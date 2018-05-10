using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{

	GameObject miniDiver; 
	private float screenExtentsY;
	Vector2 cameraPosition; 
	Transform cameraTransform;
	Vector3 worldScreenSize; 
	public float cameraMargin = 0.25f; 
	public float smoothTime = 0.3F;
	private float yVelocity = 0.0F;
	public int playerPosition; 
	Camera camera;
	Spawner spawner;

	
	void Start () 
	{

		camera = GetComponent<Camera> (); 
		Vector3 screen_size = new Vector3 (Screen.width, Screen.height, 0.0f);
		worldScreenSize = camera.ScreenToWorldPoint(screen_size);
		screenExtentsY = worldScreenSize.y / 2f;
		miniDiver = GameObject.Find ("MiniDiver");


	}

		// Update is called once per frame
	void Update () 
	{
		cameraPosition = transform.position; 

		float minidiverYPositionRelativeToScreen = miniDiver.transform.position.y - transform.position.y + screenExtentsY;

		float newCameraY; 
		if (minidiverYPositionRelativeToScreen / (2.0f * screenExtentsY) > cameraMargin) 
		{
			
			float targetY = miniDiver.transform.position.y - (cameraMargin * 2.0f * screenExtentsY) + playerPosition;

			if (targetY <= transform.position.y)
			{
				newCameraY = transform.position.y;

			}else
			{
				newCameraY = Mathf.SmoothDamp (transform.position.y, targetY, ref yVelocity, smoothTime);

			}

		}else
		{
			newCameraY = transform.position.y;
		}

		transform.position = new Vector3 (transform.position.x, newCameraY, transform.position.z); 

	}


}

