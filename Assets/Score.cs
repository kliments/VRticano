using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score: MonoBehaviour
{
    private bool hasTouched = false;
    private GameObject[] listOfStones;
    private int i;
    private int scoreValue = 1;
    private int hasTouchedAlready = 0;
    public TextMesh text;
    public GameObject scoreText;

    private AudioSource scoreAudio;


    void Awake()
    {
        scoreAudio = GetComponent<AudioSource>();
    }
    


    // Update is called once per frame
    void Update()
    {
        
        if (hasTouched)
          {
               scoreText.GetComponent<ScoreValue>().score++;
               hasTouched = false;
               // Debug.Log("Score: " + score);
               text.text = "Score: " + scoreText.GetComponent<ScoreValue>().score;
               scoreAudio.Play();
        }
        
        else
        {
         return;
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Controller (right)"|| other.gameObject.name == "Controller (left)") && hasTouchedAlready == 0)
        {
            hasTouchedAlready++;
            hasTouched = true;
            listOfStones = GameObject.FindGameObjectsWithTag("stone");
           // Debug.Log("stonesssss");
           
        }
    }
   

}
