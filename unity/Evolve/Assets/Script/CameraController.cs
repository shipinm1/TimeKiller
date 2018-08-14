using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// get the offset value for the camera related to player
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// fixed movement on x axis only
	void LateUpdate () {
        Vector3 temp = player.transform.position + offset;
        temp.y = 0;
        transform.position = temp;
	}
}
