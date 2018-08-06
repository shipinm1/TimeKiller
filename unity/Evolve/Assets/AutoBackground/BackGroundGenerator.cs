using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class BackGroundGenerator : MonoBehaviour {

    [Range(0, 100)]
    public int initialChance;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;
    [Range(1,10)]
    public int numberReput;
    private int count = 0;
    private int[,] terrainMap;
    public Vector3Int tmapSize;

    public Tilemap topMap;
    public Tilemap botMap;
    public Tile topTile;
    public Tile botTile;

    int width;
    int height;

    public void doSimulation(int numberReput)
    {
        clearMap(false);
        width = tmapSize.x;
        height = tmapSize.y;

        if (terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPosition();
        }

        for (int i = 0; i < numberReput; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
            }
        }
    }

    public int [,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }
                }
                if (oldMap[x, y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
                }
                if (oldMap[x, y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }
        }
        
        return newMap;
    }

    public void initPosition()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y< height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < initialChance ? 1 : 0;
            }
        }
    }
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            doSimulation(numberReput);
        }


        if (Input.GetMouseButtonDown(1))
        {
            clearMap(true);
        }

        if (Input.GetMouseButton(2))
        {
            saveTheMap();
            count++;
        }
	}
    public void saveTheMap()
    {
        string mapName = "tempXY_" + count;
        var mf = GameObject.Find("Grid");

        if (mf)
        {
            var savePath = "AutoBackGround/" + mapName + ".prefab";
            if (PrefabUtility.CreatePrefab(savePath, mf))
            {
                Debug.Log("DONE " + mapName);
            }
            else
            {
                Debug.Log("NOT DONE " + mapName);
            }
        }
    }

    public void clearMap(bool complete)
    {
        topMap.ClearAllTiles();
        botMap.ClearAllTiles();

        if (complete)
        {
            terrainMap = null;
        }
    }
}
