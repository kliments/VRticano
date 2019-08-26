using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	private RaycastHit lastRaycastHit;
	
	public GameObject DirectionOfObject()
	{
		Vector3 origin = Camera.main.transform.position;
		Vector3 direction = Camera.main.transform.forward;
		float range = 1000;
		if (Physics.Raycast (origin, direction, out lastRaycastHit, range))
			return lastRaycastHit.collider.gameObject;
		else
			return null;
	}
	public void TeleportTo(){
		Camera.main.transform.position=lastRaycastHit.point+lastRaycastHit.normal*2;//based on the size of game obj

	}
	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		if (DirectionOfObject () != null) {
			TeleportTo ();
		}
	}
}