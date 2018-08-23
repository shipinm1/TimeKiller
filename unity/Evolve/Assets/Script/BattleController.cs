using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code still under developing. will be refactored eventually.

public class BattleController : MonoBehaviour {

    public GameObject hazard;
    public GameObject player;
    public GameObject benefit;
    public GameObject volcano;
    public Vector2 BadThingsSpawnRange;
    public int resetTimer;
    public int volcanoTimer;
    public int enemyCount;
    public int waveType;
    public float spawnWait;
    public float startWait;
    public float environmentalDamage;
    public float beneftitWait;
    
    private Vector2 spawnPosition;
    private Vector2 target;
    private Vector2 offset = new Vector2(10f,0);
    private Vector2 preVolcaPos;
    private Mover mover;
    private GameObject temp;
    private float direction;
    private float frameCount = 0;
    private int spawnCount;

    void Start()
    {

        StartCoroutine(Waves());
        mover = hazard.GetComponent<Mover>();

    }
    private void LateUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        //Debug.Log("Updated spawnPosition: " + spawnPosition + "\n Player position: " + player.transform.position);
        //spawn things every 2 sec
        //The reason why without the IEnumerator is that
        //Once IEnumerator started, spawnPosition Can not be changed inside the IEnumerator


        //Things 1*spawnWait, spawn from right side towards player
        if (frameCount % (((int)Random.Range(BadThingsSpawnRange.x,BadThingsSpawnRange.y)) * 15) == 0 && frameCount != 0) 
        {
            spawnPosition = target + offset;
            Vector2 position = new Vector2(spawnPosition.x, Random.Range(-6, 6));
            float degree = Mathf.Atan(10 / (position.y - target.y)) * (180 / Mathf.PI);
            if (degree > 0)
            {
                direction = 180 - degree;
            }
            else
            {
                direction = -degree;
            }
            
            Quaternion rotation = Quaternion.Euler(0, 0, direction);
            //Debug.Log(180-direction + "" + " " +  direction);
            Instantiate(hazard, position, rotation);
            spawnCount += 1;
        }

        //Things 1.5*spawnWait, spawn from left side towards player
        if (frameCount % (((int)Random.Range(BadThingsSpawnRange.x, BadThingsSpawnRange.y)) * 20) == 0 && frameCount != 0)
        {
            spawnPosition = target - offset;
            Vector2 position = new Vector2(spawnPosition.x, Random.Range(-6, 6));
            float degree = Mathf.Atan(-10 / (position.y - target.y)) * (180 / Mathf.PI);
            if (degree > 0)
            {
                direction = 360 - degree;
            }
            else
            {
                direction = 300 + degree;
                Debug.Log("The degree: " + degree);
            }
            //Debug.Log("The degree: " + degree);
            //Debug.Log("The direction: " + direction);
            Quaternion rotation = Quaternion.Euler(0, 0, direction);
            Instantiate(hazard, position, rotation);
        }

        //spawn volcano
        if (frameCount == volcanoTimer * 30)
        {
            preVolcaPos = new Vector2(Random.Range(target.x - 2, target.x + 2), -4);
            temp = Instantiate(volcano, preVolcaPos, Quaternion.identity);
            preVolcaPos.y += 1;
        }

        if (frameCount > volcanoTimer * 30 + 50 && frameCount < volcanoTimer * 30 + 70) // spawn volcana random around player
        {
            for (int i = 0; i < 5; i++)
            {
                Quaternion directionVolca = Quaternion.Euler(0, 0, Random.Range(8, -8));
                Instantiate(hazard, preVolcaPos, directionVolca);
            }
        }

        if (frameCount == volcanoTimer * 30 + 75) //destroy the volcano
        {
            Destroy(temp);
        }

        //spawn normal benefit
        if (frameCount % (beneftitWait * 30) == 0)
        {
            Vector2 posLeft = new Vector2(target.x - 10, Random.Range(-4, 4));
            Vector2 posRight = new Vector2(target.x + 10, Random.Range(-4, 4));
            Instantiate(benefit, posLeft, Quaternion.Euler(0, 0, Random.Range(235, 305)));
            Instantiate(benefit, posRight, Quaternion.Euler(0, 0, Random.Range(55, 125)));
        }

        //frame update/reset
        frameCount += 1;
        if (frameCount == resetTimer * 30) 
        {
            frameCount = 0;
        }
    }

    /*
  _  _         _         _                  _   _          _      _       
 | \| |  ___  | |_      /_\   __ __  __ _  | | (_)  __ _  | |__  | |  ___ 
 | .` | / _ \ |  _|    / _ \  \ V / / _` | | | | | / _` | | '_ \ | | / -_)
 |_|\_| \___/  \__|   /_/ \_\  \_/  \__,_| |_| |_| \__,_| |_.__/ |_| \___|
    */

    //Currently not using this as spawner
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
                    mover.speed = 100; // can change moving speed of the object
                    Vector2 position = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y);
                    Quaternion rotation = Quaternion.Euler(180, 0, 0);
                    Instantiate(hazard, position, rotation);
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
                    Instantiate(hazard, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 3)
        {
            //normal random spawn from left to right
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector2 position = new Vector2(-spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Quaternion rotation = Quaternion.Euler(0, 0, 270);
                    Instantiate(hazard, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 4)
        {
            //normal random spawn from right to left
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    Vector2 position = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Quaternion rotation = Quaternion.Euler(0, 0, 90);
                    Instantiate(hazard, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }
        else if (waveType == 5)
        {
            //normal random spawn side ways
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    //Vector2 posTop = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), spawnPosition.y);
                    //Vector2 posBottom = new Vector2(Random.Range(spawnPosition.x, -spawnPosition.x), -spawnPosition.y);
                    Vector2 posLeft = new Vector2(-spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    Vector2 posRight = new Vector2(spawnPosition.x, Random.Range(-spawnPosition.y, spawnPosition.y));
                    //Quaternion rotation = Quaternion.identity;
                    //Instantiate(hazard, posTop, Quaternion.Euler(180, 0, 0));
                    //Instantiate(hazard, posBottom, Quaternion.Euler(0, 0, 0));
                    Instantiate(benefit, posLeft, Quaternion.Euler(0, 0, Random.Range(245,295)));
                    Instantiate(benefit, posRight, Quaternion.Euler(0, 0, Random.Range(65,115)));
                    yield return new WaitForSeconds(spawnWait);
                }
            }
        }

        else if (waveType == 6)
        {
            //Debug.Log("Inside coroutine player position: " + player.transform.position);
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
                    Instantiate(hazard, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                    order = false;
                    //yield return null;
                }
            }
        }

    }
    
}
