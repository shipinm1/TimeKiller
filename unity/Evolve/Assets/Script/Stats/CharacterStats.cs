using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	void Awake () 
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage (float damage) 
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

	public virtual void Dead ()
	{

	}
}
