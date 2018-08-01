using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

    public GameObject enemy;
    public Vector3 spawnPosition;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public int waveType;

    void Start()
    {
        StartCoroutine(Waves());
    }


    IEnumerator Waves()
    {
        if (waveType == 1)
        {
            //normal random spawn from top to bottom
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 position = new Vector3(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y, spawnPosition.z);
                    Quaternion rotation = Quaternion.identity;
                    Instantiate(enemy, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 2)
        {
            //normal random spawn from bottom to top
        }
        else if (waveType == 3)
        {
            //normal random spawn from left to right
        }
        else if (waveType == 4)
        {
            //normal random spawn from right to left
        }
        else if (waveType == 5)
        {
            //normal random spawn four ways
        }

    }
}
