using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner1 : MonoBehaviour {

    public int openingDirection;
    private int rand;
    private RoomTemplates templates;
    public bool spawned = false;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 3f);
        
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], new Vector2(transform.position.x, transform.position.y - 0.1365f), templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], new Vector2(transform.position.x, transform.position.y - 0.1365f), templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], new Vector2(transform.position.x, transform.position.y - 0.1365f), templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], new Vector2(transform.position.x, transform.position.y - 0.1365f), templates.rightRooms[rand].transform.rotation);
            }
        }
        spawned = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner1>().spawned == true) {
            Destroy(gameObject);
        }
    }
}
