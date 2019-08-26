using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {
	private AudioSource playSplash;

	void Awake ()
	{
		playSplash = GetComponent <AudioSource> ();

	}
		
	void OnCollisionEnter (Collision other)
	{


		if (other.gameObject.tag == "stone") {

			playSplash.Play ();
		}
	}
}