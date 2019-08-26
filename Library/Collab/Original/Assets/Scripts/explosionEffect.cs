using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class explosionEffect : MonoBehaviour {

	public Transform explosion;
    public GameObject newRock;
	public Transform effect;
    public bool objectIsGrabbed;

    public int score;
    private int scoreValue = 10;
    Text text;


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;

        

    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }


    // private void Start()
    // {
    //SplashPlay = GetComponent<AudioSource> ();
    // remains = GameObject.FindGameObjectWithTag("remainsTag");
    // }



    void OnCollisionEnter (Collision other){


		if (other.gameObject.tag == "lava"){


			Destroy(gameObject);
			//AudioSource.PlayClipAtPoint(playSplash,transform.position,10f);
            Debug.Log("Ontriggger func");
			GameObject splash=Instantiate(effect.gameObject, gameObject.transform.position, Quaternion.identity);
			//gameMusic.Play ();
			//musicStarted = true;
           // GameObject last = Instantiate(explosion.gameObject, gameObject.transform.position, Quaternion.identity);
            
            //Destroy(last, 1F);

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
        }
        
    }

}
