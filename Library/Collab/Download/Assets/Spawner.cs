using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] rocks;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;

    int randRock;

	// Use this for initialization
	void Start () {
        StartCoroutine(waitSpawner());
	}
	
	// Update is called once per frame
	void Update () {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
	}

    IEnumerator waitSpawner() {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randRock = (int)Random.Range(0.0f, 4f); //which

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(rocks[randRock],spawnPosition + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }


}
