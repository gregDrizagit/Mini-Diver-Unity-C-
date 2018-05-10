using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	public AudioClip pop;
	public AudioClip boom;
	AudioSource audio;
	void Start()
	{
		audio = GetComponent<AudioSource> ();
	}

	public void playPop(){
		audio.PlayOneShot (pop);

	}

	public void playBoom(){
		audio.PlayOneShot (boom);

	}
}
