using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class InstructionBubble : MonoBehaviour {

	public bool hasSeenInstructions = false; 

	public void seenInstructions()
	{
		gameObject.SetActive (false); 
		hasSeenInstructions = true;
		PlayerPrefs.SetInt ("SeenInstructions", 1);
	}
}
