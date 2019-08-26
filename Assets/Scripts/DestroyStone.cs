using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour {

   

    private void OnCollisionEnter(Collision col)
    {
		Debug.Log ("We hit something");
     //   if (col.gameObject.name == "Plane")
       // {
         //   Destroy(col.gameObject);
        //}
    }
}
