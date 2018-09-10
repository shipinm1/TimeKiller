using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : MonoBehaviour {

    Rigidbody2D rbody;
    public GameObject enemyGraphic;
    Animator animator;
    private float speed = 3.5f;
    public bool forward = true;
    float nextDamage;
    public float damage = 20f;
    public float waitTime = 5f;
    public Transform spawn;
    public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FacePlayer()
    {
        forward = !forward;
        float newScale = enemyGraphic.transform.localScale.x;
        newScale *= -1;
        enemyGraphic.transform.localScale = new Vector3(newScale, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (forward && other.transform.position.x < transform.position.x)
            {
                FacePlayer();
            }
            else if (!forward && other.transform.position.x > transform.position.x)
            {
                FacePlayer();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {   
            int direction;
            if (other.transform.position.x < enemyGraphic.transform.position.x){
                if (forward)
                    FacePlayer();
                direction = -1;
            } else{
                if (!forward)
                    FacePlayer();
                direction = 1;   
            }
            if (Mathf.Abs(other.transform.position.x - enemyGraphic.transform.position.x) > 5f) {   
                rbody.velocity = new Vector2(direction, 0) * speed;  
                animator.SetFloat("Speed", rbody.velocity.magnitude);
            }
            else {
                rbody.velocity = new Vector2(0f, 0f);
                //PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
                //if(playerHealth.count > 0) fireProjectile();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rbody.velocity = new Vector2(0f, 0f);
        }
    }

    void fireProjectile()
    {
        if (Time.time > nextDamage)
        {
            nextDamage = Time.time + waitTime;
            if (forward)
            {
                Instantiate(projectile, spawn.position, Quaternion.Euler(new Vector3(0, 0, -90)));
            }
            else if (!forward)
            {
                Instantiate(projectile, spawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
            animator.SetTrigger("Throw");
        }
    }
}
