using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour {

	AudioSource gameMusic;
	private bool musicStarted = false;


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
		if (!musicStarted && other.tag == "MainCamera") {
			gameMusic.Play ();
			musicStarted = true;
		}
	}
}
