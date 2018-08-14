using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackGround : MonoBehaviour {

    public Sprite[] backGrounds;
    public SpriteRenderer render;
    public int orderNumber;
	
	void Start ()
    {
        render = GetComponent<SpriteRenderer>();
        render.sprite = backGrounds[0];
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            render.sprite = backGrounds[Random.Range(1, backGrounds.Length)];
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            render.sprite = backGrounds[Random.Range(1, backGrounds.Length)];
        } */
    }
}
