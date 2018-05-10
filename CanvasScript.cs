using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CanvasScript : MonoBehaviour {

	public SaveLoadManager saveLoad;
	Spawner spawner;
	public NumberGroup highScore;
	public NumberGroup score;
	public Text bubbleCountTxt;
	public GameObject gameOver;
	public GameObject diver;
	public NumberGroup numberizer;
	public GameObject left;
	public GameObject right;
	public GameObject instructions;
	Diver diverScript;
	public int allTimeHighScore = 0;
	string hello = "hello";

	void Start ()
	{

		spawner = GameObject.FindGameObjectWithTag ("Spawner")
							.GetComponent<Spawner>();

		diver = GameObject.FindGameObjectWithTag ("MiniDiver");
		diverScript = diver.GetComponent<Diver> ();

		allTimeHighScore = PlayerPrefs.GetInt ("HighScore");




	}


	void Update ()
	{

		if (PlayerPrefs.GetInt ("SeenInstructions") == 1){
			instructions.SetActive (false);
		}

		numberizer.number = diverScript.bubblesPopped;

		if (!diver.activeInHierarchy){
			
			gameOver.SetActive (true);
			left.SetActive (false);
			right.SetActive (false);

			if (diverScript.bubblesPopped > allTimeHighScore){

				allTimeHighScore = diverScript.bubblesPopped;
				PlayerPrefs.SetInt ("HighScore", allTimeHighScore);

				highScore.number = allTimeHighScore;

			}
			else{

				highScore.number = allTimeHighScore;
			}

			score.number = diverScript.bubblesPopped;
		}
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt ("SeenInstructions", 0);
	}

	public void restartGame()
	{
		gameOver.SetActive (false);

		spawner.resetGame ();

		diverScript.bubblesPopped = 0;

	}

}
