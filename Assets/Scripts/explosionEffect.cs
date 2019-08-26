using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionEffect : MonoBehaviour {

	public Transform explosion;
    public GameObject newRock;
	public Transform effect;
    public bool objectIsGrabbed;
    private AudioSource throwRockSound;

    // private void Start()
    // {
    //SplashPlay = GetComponent<AudioSource> ();
    // remains = GameObject.FindGameObjectWithTag("remainsTag");
    // }


    void Awake()
    {
        throwRockSound = GetComponent<AudioSource>();
    }


    void OnCollisionEnter (Collision other){


		if (other.gameObject.tag == "lava"){


			Destroy(gameObject);
			//AudioSource.PlayClipAtPoint(playSplash,transform.position,10f);
           // Debug.Log("Ontriggger func");
			GameObject splash=Instantiate(effect.gameObject, gameObject.transform.position, Quaternion.identity);

			Destroy (splash,1F);
        }
		Destroy (gameObject,10F);
	}


    void OnCollisionStay(Collision collisionInfo)
    {
            if (collisionInfo.gameObject.tag == "cliff" && objectIsGrabbed)
			{
			
                Instantiate(newRock, gameObject.transform.localPosition, Quaternion.identity);
                Destroy(gameObject);
                throwRockSound.Play();
            }
        
    }

}
