using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code still under developing. will be refactored eventually.

public class BattleController : MonoBehaviour {

    public GameObject hazard;
    public GameObject player;
    public GameObject benefit;
    public int resetTimer;
    public int volcanoTimer;
    public int enemyCount;
    public int waveType;
    public float spawnWait;
    public float startWait;
    public float environmentalDamage; 

    private Vector2 spawnPosition;
    private Vector2 target;
    private Vector2 offset = new Vector2(10f,5f);
    private Vector2 preVolcaPos;
    private Mover mover;
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
        spawnPosition = (Vector2)player.transform.position + offset;
        //Debug.Log("Updated spawnPosition: " + spawnPosition + "\n Player position: " + player.transform.position);
        //spawn things every 2 sec
        //The reason why without the IEnumerator is that
        //Once IEnumerator started, spawnPosition Can not be changed inside the IEnumerator

        if (frameCount % (spawnWait * 30) == 0 && frameCount != 0) // 1*spawnWait, spawn from right side towards player
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
            Debug.Log(180-direction + "" + " " +  direction);
            Instantiate(hazard, position, rotation);
            spawnCount += 1;
        }

        if (frameCount % (spawnWait * 45) == 0 && frameCount != 0)// 1.5*spawnWait, spawn from left side towards player
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
            Vector2 oppoSide = new Vector2(-position.x, position.y);
            Quaternion rotation = Quaternion.Euler(0, 0, direction);
            Quaternion oppoRotation = Quaternion.Euler(0, 0, 360 - direction);
            Debug.Log(180 - direction + "" + " " + direction);
            Instantiate(hazard, oppoSide, oppoRotation);
        }

        if (frameCount == volcanoTimer * 30)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
            preVolcaPos = new Vector2(Random.Range(target.x - 2, target.x + 2), -4);
        }
        if (frameCount > volcanoTimer * 30 && frameCount < volcanoTimer * 30 + 30) // spawn volcana random around player
        {
            for (int i = 0; i < 5; i++)
            {
                Quaternion directionVolca = Quaternion.Euler(0, 0, Random.Range(8, -8));
                Instantiate(hazard, preVolcaPos, directionVolca);
            }
        }

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

    //currently only using IEnumerator for random small things to spawn
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
                    Instantiate(hazard, position, rotation);
                    yield return new WaitForSeconds(spawnWait);
                    order = false;
                    //yield return null;
                }
            }
        }

    }
    
}
