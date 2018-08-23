using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
    public static GameControl gameControl;
	// Use this for initialization
	void Awake () {
        Debug.Log("gameControl");
        if (gameControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameControl = this;
        }
        else if(gameControl != this)
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {
        Debug.Log("game control start");
    }


}
