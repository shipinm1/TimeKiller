﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        else if (other.tag == "Enemy")
        {
            return;
        }



        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
