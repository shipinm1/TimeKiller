using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour {

	public float hp;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			CharacterStats playerHealth = other.gameObject.GetComponent<CharacterStats>();
			playerHealth.Heal(hp);
			Destroy(gameObject);
		}
	}
}
