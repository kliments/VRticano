using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
	
	public Image goalImage;
	public Color goalColour = new Color(1f,1f,1f);

	AudioSource gameMusic;
	private bool goalMusicStarted = false;


	void Awake ()
	{
		gameMusic = GetComponent <AudioSource> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)  {
		if (!goalMusicStarted && other.tag == "MainCamera") {
			gameMusic.Play ();
			goalMusicStarted = true;
			goalImage.color = goalColour;
			Debug.Log ("hit goal plane");
		}
	}
}
