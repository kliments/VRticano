using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsController : MonoBehaviour {
    public static float slowTimeScale = 2f;
    public static float normalTimeScale = 1f;
    public static float timeOut = 5f;
    private bool hasTouched = false;
    private int timer = 450;
    private GameObject stonePrefab;
    private GameObject[] listOfStones;
    private int i;
    // Use this for initialization
    	void Start () {
            stonePrefab = (GameObject)Resources.Load("RockPrefab", typeof(GameObject));
    }

    // Update is called once per frame
    void Update () {
        if (hasTouched)
        {
            if(timer == 0)
            {
                hasTouched = false;
                timer = 360;
                stonePrefab.GetComponent<Rigidbody>().drag = 2;
                for (i = 0; i < listOfStones.Length; i++)
                {
                    if (listOfStones[i] != null)
                    {
                        listOfStones[i].GetComponent<Rigidbody>().drag = 2;
                    }
                }
                Destroy(gameObject);
            }
            else
            {
                if(stonePrefab.GetComponent<Rigidbody>().drag != 5)
                {
                    stonePrefab.GetComponent<Rigidbody>().drag = 5;
                }
                for (i = 0; i<listOfStones.Length; i++)
                {
                    if(listOfStones[i]!= null && listOfStones[i].GetComponent<Rigidbody>().drag != 5)
                    {
                        listOfStones[i].GetComponent<Rigidbody>().drag = 5;
                    }
                }
                timer--;
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Controller (right)" || other.gameObject.name == "Controller (left)") {
            hasTouched = true;
            listOfStones = GameObject.FindGameObjectsWithTag("stone");
            Debug.Log("blalalallala");
        }
    }
    public static IEnumerator CountDown() {
        Time.timeScale = slowTimeScale;
        yield return new WaitForSeconds(timeOut);
        Time.timeScale = normalTimeScale;

    }

   

		

    
}
