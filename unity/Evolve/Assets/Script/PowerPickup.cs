using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour {

	public float hp;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerHealth PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
			PlayerHealth.Heal(hp);
			Destroy(gameObject);
		}
	}
}
