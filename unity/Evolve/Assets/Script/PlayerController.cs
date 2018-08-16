using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	Rigidbody2D rb;
    public Animator animator;
	float horizontal, vertical;
    public bool facingRight = true;
	
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CombatTextManager.Instance.CreateText(transform.position, "yo!");
        }
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");
		rb.velocity = new Vector2(speed * horizontal, speed * vertical);
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal > 0)
            {
                if (facingRight == false)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                }
                facingRight = true;
                
            }
            else
            {
                if (facingRight == true)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                }
                facingRight = false;
                
            }
            animator.SetFloat("speed", 1f);
        }
        else
        {
            animator.SetFloat("speed", 0f);
        }

        if (Input.GetKey("e"))
        {
            animator.SetTrigger("eat");
        }

        if (Input.GetKey("f"))
        {
            animator.SetTrigger("gethit");
        }
	}
	
	void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.name == "good")
        {
            Destroy(other.gameObject);
        } else if (other.gameObject.name == "bad")
		{
			Destroy(other.gameObject);
		}
	}
}
