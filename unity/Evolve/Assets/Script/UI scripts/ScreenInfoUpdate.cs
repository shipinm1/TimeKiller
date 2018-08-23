using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInfoUpdate : MonoBehaviour {

    public Slider healthBar;
    public Text healthValue;
	// Use this for initialization
	void Start () {
        //healthBar.value = Player.instance.playerStats.currentHealth / Player.instance.playerStats.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PlayerStats.instance.currentHealth);
        healthBar.value = PlayerStats.instance.currentHealth / PlayerStats.instance.maxHealth;
        healthValue.text = PlayerStats.instance.currentHealth.ToString() +  "/" + PlayerStats.instance.maxHealth.ToString();
    }
}
