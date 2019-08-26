using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score: MonoBehaviour
{
    public static float slowTimeScale = 2f;
    public static float normalTimeScale = 1f;
    public static float timeOut = 5f;
    private bool hasTouched = false;
    private int timer = 450;
    private GameObject stonePrefab;
    private GameObject[] listOfStones;
    private int i;
    public bool flag;
    public int score;
    private int scoreValue = 1;
    Text text;

    void Awake()
    {
        score = 0;

        //text = GetComponent<Text>();
    }


    // Use this for initialization
    void Start()
    {
        stonePrefab = (GameObject)Resources.Load("RockPrefab", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        //if it is not touched already touch it and remove it from the list of stones
         if (hasTouched)
          {
            
                    score += scoreValue;
            hasTouched = false;
            Debug.Log("Score: " + score);
                   
                }
            
       



        else
        //if it is touched already remove it from the list of the stoens
        {

            return;
            }
          }

        //text.text = "Score: " + score;

        


    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller (right)")
        {
            hasTouched = true;
            listOfStones = GameObject.FindGameObjectsWithTag("stone");
            Debug.Log("stonesssss");
           
        }
    }
   

}
