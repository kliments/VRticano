using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score: MonoBehaviour
{
    private bool hasTouched = false;
    private GameObject[] listOfStones;
    private int i;
    private int score = 0;
    private int scoreValue = 1;
    public TextMesh text;

    private void Start()
    {
        score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (hasTouched)
          {
               score += scoreValue;
               hasTouched = false;
              // Debug.Log("Score: " + score);
               text.text = "Score: " + score;
        }
        
        else
        {
         return;
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller (right)"|| other.gameObject.name == "Controller (left)")
        {
            hasTouched = true;
            listOfStones = GameObject.FindGameObjectsWithTag("stone");
           // Debug.Log("stonesssss");
           
        }
    }
   

}
