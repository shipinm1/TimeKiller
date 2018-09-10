using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour {

	#region Singleton

    public static EnemyInstance instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {

    }

    public RangedEnemyController enemyRanged;
    public MeleeEnemyController enemyMelee;
}
