using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour {

    public Transform player;
	Rigidbody2D rbody;
	public GameObject enemyGraphic;
	Animator animator;
	private float speed = 3f;
	bool forward = true;
    public float range = 5f;
    public float distance;
    float nextDamage;
    public float damage = 20f;
    public float waitTime = 5f;
	
	// Use this for initialization
	void Start () 
	{
		rbody = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!Player.instance.isDead) 
            inRange();
	}

	void FacePlayer()
    {
        forward = !forward;
        float newScale = enemyGraphic.transform.localScale.x;
        newScale *= -1;
        enemyGraphic.transform.localScale = new Vector3(newScale, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);

    }

    void inRange() {
        distance = Vector3.Distance (player.position, transform.position);
        if (distance <= range) {
            FacePlayer();
            attack();
        }
    }

    void attack()
    {
        //CharacterStats playerStats = player.GetComponent<CharacterStats>();
        if (Time.time > nextDamage)
        {
            nextDamage = Time.time + waitTime;
            animator.SetTrigger("Attack");
        }
    }
}
