using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionEffect : MonoBehaviour {

	public Transform explosion;
    public GameObject newRock;
	public Transform effect;



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
            if (collisionInfo.gameObject.tag == "cliff")
			{
			
                Instantiate(newRock, gameObject.transform.localPosition, Quaternion.identity);
                Destroy(gameObject);
            }
        
    }

}
