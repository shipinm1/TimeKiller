using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	#region Singleton

	public static PlayerHealth instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	float maxHealth;
	float currentHealth;

	public void takeDamage (float damage) 
	{
		float newHealth = currentHealth - damage;
		if (newHealth <= 0) {
			currentHealth = 0;
			Dead();
		} else {
			currentHealth = newHealth;
		}
	}

	public void Heal (float hp) 
	{
		float newHealth = currentHealth + hp;
		if (newHealth > maxHealth) {
			currentHealth = maxHealth;
		} else {
			currentHealth = newHealth;
		}
	}

	public void Dead ()
	{
		
	}
}
