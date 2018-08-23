using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject {

    public string itemName;
    public int gameStage = 0;
    public int price = 0;
    public bool available = false;
    public int itemLevel = 0;
    public Sprite icon;

    public virtual void Use() {
        //Debug.Log("a");
    }

    public virtual Item Copy() {
        //var item = (Item)MemberwiseClone();
        
        return null;
    }

}

