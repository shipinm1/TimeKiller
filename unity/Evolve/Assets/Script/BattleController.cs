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
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 position = new Vector3(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y, -spawnPosition.z);
                    Quaternion rotation = Quaternion.Euler(0, 180, 0);
                    Instantiate(enemy, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 3)
        {
            //normal random spawn from left to right(false)
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 position = new Vector3(-spawnPosition.x, spawnPosition.y, Random.Range(spawnPosition.z, -spawnPosition.z));
                    Quaternion rotation = Quaternion.Euler(0, 270, 0);
                    Instantiate(enemy, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 4)
        {
            //normal random spawn from right to left(false)
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 position = new Vector3(spawnPosition.x, spawnPosition.y, Random.Range(spawnPosition.z, -spawnPosition.z));
                    Quaternion rotation = Quaternion.Euler(0, 90, 0);
                    Instantiate(enemy, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 5)
        {
            //normal random spawn four ways(false)
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector3 posTop = new Vector3(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y, spawnPosition.z);
                    Vector3 posBottom = new Vector3(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y, -spawnPosition.z);
                    Vector3 posLeft = new Vector3(-spawnPosition.x, spawnPosition.y, Random.Range(spawnPosition.z, -spawnPosition.z));
                    Vector3 posRight = new Vector3(spawnPosition.x, spawnPosition.y, Random.Range(spawnPosition.z, -spawnPosition.z));
                    //Quaternion rotation = Quaternion.identity;
                    Instantiate(enemy, posTop, Quaternion.Euler(0, 0, 0));
                    Instantiate(enemy, posBottom, Quaternion.Euler(0, 180, 0));
                    Instantiate(enemy, posLeft, Quaternion.Euler(0, 270, 0));
                    Instantiate(enemy, posRight, Quaternion.Euler(0, 90, 0));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }

    }
}
