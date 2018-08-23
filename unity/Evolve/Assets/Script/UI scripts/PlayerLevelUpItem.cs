using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerLevelUpItem", menuName = "Inventory/Item/PlayerLevelUpItem", order = 1)]
public class PlayerLevelUpItem : LevelUpItem {
    public PlayerStatType playerStatType;
    //public GameObject player;
    //public PlayerStats playerStats = PlayerStats.instance;

    public override void Use()
    {
        base.Use();
        //Debug.Log("b");
        itemLevel++;
        switch (playerStatType) {
            case PlayerStatType.fireResist:
                Debug.Log("fire");
                PlayerStats.instance.fireResist.AddModifier(0, 0.20f);
                break;

            case PlayerStatType.coldResist:
                Debug.Log("cold");
                PlayerStats.instance.coldResist.AddModifier(0, 0.20f);
                break;

            default:
                Debug.Log("default");
                break;
        }


    }

    public override Item Copy()
    {
        PlayerLevelUpItem newItem = new PlayerLevelUpItem();
        newItem.itemName = this.itemName;
        newItem.gameStage = this.gameStage;
        newItem.price = price;
        newItem.available = available;
        newItem.itemLevel = itemLevel;
        newItem.icon = icon;
        newItem.playerStatType = playerStatType;
        return newItem;
        //return base.Copy();
    }
}

public enum PlayerStatType {
    damage,
    coldResist,
    fireResist,
    highPressureResist,
    lowPressureResist,
};
