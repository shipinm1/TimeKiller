using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float tumble;
    
    private void Start()
    {
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(tumble,0);
    }
    //private void Update()
    //{
    //    GetComponent<Rigidbody2D>().transform.Rotate(Vector3.forward * tumble * Time.deltaTime);
    //}
}
