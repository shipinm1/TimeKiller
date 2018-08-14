using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleController : MonoBehaviour {

    public GameObject enemy;
    
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public int waveType;
    public GameObject player;

    private Vector2 spawnPosition;
    private Mover mover;
    private float direction;
    private Vector2 target;
    private Vector2 offset = new Vector2(10f,5f);
    private float frameCount = 0;
    

    void Start()
    {

        StartCoroutine(Waves(spawnPosition));
        mover = enemy.GetComponent<Mover>();

    }
    private void LateUpdate()
    {
        spawnPosition = (Vector2)player.transform.position + offset;
        //Debug.Log("Updated spawnPosition: " + spawnPosition + "\n Player position: " + player.transform.position);
        //spawn things every 2 sec
        //The reason why without the IEnumerator is that
        //Once IEnumerator started, spawnPosition Can not be changed inside the IEnumerator
        if (frameCount == spawnWait * 30) // 30frame/sec
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;     
            Vector2 position = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
            float degree = Mathf.Atan((position.x - target.x) / (position.y - target.y)) * (180 / Mathf.PI);
            if (degree > 0)
            {
                direction = 180 - degree;
            }
            else
            {
                direction = -degree;
            }
                
            Quaternion rotation = Quaternion.Euler(0, 0, direction);
            Instantiate(enemy, position, rotation);
            frameCount = 0;    
        }
        frameCount += 1;
    }


    IEnumerator Waves(Vector2 spawnPosition)
    {
        if (waveType == 1)
        {
            //normal random spawn from top to bottom
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    mover.speed = 100; // can change moving speed of the object
                    Vector2 position = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y);
                    Quaternion rotation = Quaternion.Euler(180, 0, 0);
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
                    Vector2 position = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), -spawnPosition.y);
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
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
                    Vector2 position = new Vector2(-spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Quaternion rotation = Quaternion.Euler(0, 0, 270);
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
                    Vector2 position = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Quaternion rotation = Quaternion.Euler(0, 0, 90);
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
                    Vector2 posTop = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y);
                    Vector2 posBottom = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), -spawnPosition.y);
                    Vector2 posLeft = new Vector2(-spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Vector2 posRight = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    //Quaternion rotation = Quaternion.identity;
                    Instantiate(enemy, posTop, Quaternion.Euler(180, 0, 0));
                    Instantiate(enemy, posBottom, Quaternion.Euler(0, 0, 0));
                    Instantiate(enemy, posLeft, Quaternion.Euler(0, 0, 270));
                    Instantiate(enemy, posRight, Quaternion.Euler(0, 0, 90));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }

        else if (waveType == 6)
        {
            Debug.Log("Inside coroutine player position: " + player.transform.position);
            //spawn towards player's current location
            yield return new WaitForSeconds(startWait);
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
            bool order = true;
            while (order == true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector2 position = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    float degree = Mathf.Atan((position.x - target.x) / (position.y - target.y)) * (180 / Mathf.PI);
                    if (degree > 0)
                    {
                        direction = 180 - degree;
                    }
                    else
                    {
                        direction =  -degree;
                    }
                    //Debug.Log(direction);
                    Quaternion rotation = Quaternion.Euler(0, 0, direction);
                    Instantiate(enemy, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                    order = false;
                    //yield return null;
                }
            }
        }

    }
    
}
