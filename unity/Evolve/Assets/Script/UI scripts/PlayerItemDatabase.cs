using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerItemDatabase : ScriptableObject
{

    public List<Item> playerItemDatabase;
    private static PlayerItemDatabase instance;
    private const string loadPath = "PlayerItemDatabase";
    private const string creationPath = "Assets/Resources/PlayerItemDatabase.asset";
    /*
     * set the instance for the allcondition
     * so other script could access to it
     */
    public static PlayerItemDatabase Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<PlayerItemDatabase>();
            if (!instance)
                instance = Resources.Load<PlayerItemDatabase>(loadPath);
            if (!instance)
                Debug.LogError("PlayerItemDatabase has not been created yet.  Go to Assets > Create > PlayerItemDatabase.");
            return instance;
        }
        set { instance = value; }
    }
    // Use this for initialization



    [MenuItem("Assets/Create/PlayerItemDatabase")]
    private static void CreatePlayerItemDatabaseAsset()
    {
        if (PlayerItemDatabase.Instance)
            return;
        //set up the instance always equal to the same one
        PlayerItemDatabase instance = CreateInstance<PlayerItemDatabase>();
        AssetDatabase.CreateAsset(instance, creationPath);
        PlayerItemDatabase.Instance = instance;

        instance.playerItemDatabase = new List<Item>();
    }
}
