using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	#region Singleton
	
	public static Player instance;
	public bool isDead = false;

	void Awake () 
	{
		instance = this;
	}

	#endregion

	public PlayerStats playerStats;
	public PlayerController playerController;

    public void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerController = GetComponent<PlayerController>();
    }
    public void Dead () 
	{
		isDead = true;
		Debug.Log("Player Dead!");
	}
}
