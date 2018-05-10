
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject bubble1;
	public GameObject mine1;
	public GameObject diver;
	GameObject[] fish;
	public GameObject fish1;
	public GameObject fish2;
	public GameObject fish3;
	public GameObject fish4;
	public GameObject fish5;
	public Camera cam;
	GameObject canvas;
	public int numberOfBubble = 50;
	public int numberOfMines = 10;
	public int numberOfFish = 10;
	public GameObject miniDiver;
	GameObject ground;
	public List<GameObject>bubbleList;
	public List<GameObject>mineList;
	public List<GameObject>fishList;
	public float sizeChangeProbability = 0.005f;
	public float lowScaleBound = 0.1f;
	public float highScaleBound =  0.4f;
	public int probBubCount = 0;
	public int countToIncrementProbability = 5;
	public float percentIncrement = 0.005f;

	void Start ()
	{
		diver = GameObject.FindGameObjectWithTag ("DiverGround");

		cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();

		canvas = GameObject.FindGameObjectWithTag ("Distance");

		ground = GameObject.FindGameObjectWithTag ("Ground");

		bubbleList = new List<GameObject> ();
		mineList = new List<GameObject> ();
		fishList = new List<GameObject> ();

		fish = new GameObject[]{fish1, fish2, fish3, fish4, fish5};




		generateMines ();

		placeMines ();

		generateBubbles ();

		placeBubbles ();

		generateFish ();

		placeFish ();

	}

	// Update is called once per frame
	void Update ()
	{
		updateBubblePositions ();
		updateFishPosition ();
		incrementProbability ();
		updateMinePositions ();
	}

	public void placeBubbles()
	{
		for (int i = 0; i < bubbleList.Count; i++) //margins
		{
			bubbleList[i].transform.position = new Vector3 (middle (), transform.position.y * -i);
		}

	}

	public void updateBubblePositions()
	{
		for (int i = 0; i < bubbleList.Count; i++) {
			if (bubbleList[i].gameObject.activeInHierarchy == false){
				bubbleSizer (bubbleList [i]);
				bubbleList [i].transform.position = new Vector3(middle(), bubbleList[bubbleList.Count - 1].transform.position.y + Random.Range(7, 20));
				GameObject temp = bubbleList[i];
				bubbleList.RemoveAt (i);
				bubbleList.Add (temp);
				bubbleList [bubbleList.Count - 1].SetActive (true);

			}

		}
	}

	public void updateMinePositions(){
		for (int i = 0; i < mineList.Count; i++) {
			if (mineList[i].gameObject.activeInHierarchy == false){                                                                                                                       //10 15
				mineList [i].transform.position = new Vector3(margins(), mineList[mineList.Count - 1].transform.position.y + Random.Range(7, 10));
				GameObject temp = mineList[i];
				mineList.RemoveAt (i);
				mineList.Add (temp);
				mineList [mineList.Count - 1].SetActive (true);

			}

		}
	}

	public void updateFishPosition(){
		for (int i = 0; i < fishList.Count; i++){
			if (fishList[i].gameObject.activeInHierarchy == false){                                                                                                                       //10 15
				fishList[i].transform.position = new Vector3(Random.Range(-7, 7), fishList[fishList.Count - 1].transform.position.y + Random.Range(200, 400), 5f);

				GameObject temp = fishList[i];
				fishList.RemoveAt (i);
				fishList.Add (temp);
				fishList [fishList.Count - 1].SetActive (true);

			}

		}
	}


	public void generateBubbles(){
		for (int i = 0; i < numberOfBubble; i++) {
			GameObject bub = Instantiate (bubble1, new Vector3 (-1f, -1.91f * i, 0f), Quaternion.identity) as GameObject;
			bubbleList.Add (bub);
		}
	}

	public void generateMines(){
		for (int i = 0; i < numberOfMines; i++) {
			GameObject mine = Instantiate (mine1, new Vector3 (-1f, -1.91f * i, 0f), Quaternion.identity) as GameObject;

			mineList.Add (mine);
		}

	}

	public void generateFish(){
		for (int i = 0; i < numberOfFish; i++) {
			GameObject fishy = Instantiate (fish[Random.Range(0, 4)], new Vector3 (0f, 0f, 5f), Quaternion.identity) as GameObject;
			fishList.Add (fishy);
		}
	}

	public void placeFish(){
		for (int i = 0; i < fishList.Count; i++){
			fishList[i].transform.position = new Vector3 (Random.Range(-7, 7), transform.position.y * -i + Random.Range(20, 1000), 5f);
		}
	}

	public void placeMines()
	{
		for (int i = 0; i < mineList.Count; i++){
			mineList[i].transform.position = new Vector3 (margins(), transform.position.y * -i + Random.Range(20, 35));
		}


	}
	public void incrementProbability(){
		if (probBubCount == countToIncrementProbability){
			sizeChangeProbability += percentIncrement;
			probBubCount = 0;
			Debug.Log ("Current probability = " + sizeChangeProbability);
		}
	}
	public void bubbleSizer (GameObject obj){
		float roll = Random.value;

		if (roll < sizeChangeProbability){
			float newScale = Random.Range (lowScaleBound, highScaleBound);
			Vector3 scaleVec = new Vector3 (newScale, newScale, newScale);
			obj.transform.localScale = scaleVec;
		}

	}



	public float margins(){
		float newPosition;
		float randomSide = Random.value;

		if (randomSide > 0.5){

			return newPosition = Random.Range(-7f, -3f);

		}else {

			return newPosition = Random.Range(7f, 3f);
		}

	}

	public float middle(){
		float newPosition;
		return newPosition = Random.Range (-4f, 4f);
	}

	public void resetGame(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
