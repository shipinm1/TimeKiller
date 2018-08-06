using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {
    public float scrollSpeed;
    private Vector3 startPosition;
    public float tileSize;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.right * newPosition;
    }
}
