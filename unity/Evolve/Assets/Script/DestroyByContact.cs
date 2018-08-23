using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("eat");
            Destroy(gameObject);
        }
        if (other.tag == "Boundary")
        {
            return;
        }

        else if (other.tag == "Enemy")
        {
            return;
        }

        else if (other.tag == "benefit")
        {
            return;
        }

        
        
    }
}
