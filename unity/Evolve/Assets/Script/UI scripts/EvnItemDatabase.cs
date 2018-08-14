using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnvItemDatabase : ScriptableObject {

    public List<Item> envItemDatabase;
    private static EnvItemDatabase instance;
    private const string loadPath = "EnvItemDatabase";
    private const string creationPath = "Assets/Resources/EnvItemDatabase.asset";
    /*
     * set the instance for the allcondition
     * so other script could access to it
     */
    public static EnvItemDatabase Instance
    {
        get
        {
            if (!instance)
                instance = FindObjectOfType<EnvItemDatabase>();
            if (!instance)
                instance = Resources.Load<EnvItemDatabase>(loadPath);
            if (!instance)
                Debug.LogError("EnvItemDatabase has not been created yet.  Go to Assets > Create > Resouces > EnvItemDatabase.");
            return instance;
        }
        set { instance = value; }
    }
    // Use this for initialization



    [MenuItem("Assets/Create/EnvItemDatabase")]
    private static void CreatePlayerItemDatabaseAsset()
    {
        if (Instance)
            return;
        //set up the instance always equal to the same one
        EnvItemDatabase instance = CreateInstance<EnvItemDatabase>();
        AssetDatabase.CreateAsset(instance, creationPath);
        Instance = instance;

        instance.envItemDatabase = new List<Item>();
    }
}
